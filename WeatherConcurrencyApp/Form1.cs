using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeatherConcurrencyApp.Infrastructure.OpenWeatherClient;
using WeatherConcurrentApp.Domain.Entities;

namespace WeatherConcurrencyApp
{
    public partial class FrmMain : Form
    {
        public HttpOpenWeatherClient httpOpenWeatherClient;
        public OpenWeather openWeather;
        public FrmMain()
        {
            httpOpenWeatherClient = new HttpOpenWeatherClient();
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                Task.Run(Request).Wait();
                if(openWeather == null)
                {
                    throw new NullReferenceException("Fallo al obtener el objeto OpeWeather.");
                }

                WeatherPanel weatherPanel = new WeatherPanel();
                weatherPanel.pictureBox1.ImageLocation = "https://openweathermap.org/img/w/" + openWeather.Weather[0].Icon + ".png";
                weatherPanel.lblCity.Text = textBox1.Text;
                weatherPanel.lblTemperature.Text = openWeather.Main.Temp.ToString() + "°C";
                weatherPanel.lblWeather.Text = "Temperature";
                weatherPanel.feels.lblDetailValue.Text = openWeather.Main.Feels_like.ToString();
              
                weatherPanel.presion.lblDetailValue.Text = openWeather.Main.Pressure.ToString();
                weatherPanel.humedad.lblDetailValue.Text = openWeather.Main.Humidity.ToString();
                weatherPanel.tempMin.lblDetailValue.Text = openWeather.Main.Temp_min.ToString() + "°C";
                weatherPanel.tempMax.lblDetailValue.Text = openWeather.Main.Temp_max.ToString() + "°C";
                weatherPanel.longitud.lblDetailValue.Text = openWeather.Coord.Lon.ToString();
                weatherPanel.latitud.lblDetailValue.Text = openWeather.Coord.Lat.ToString();
                
                weatherPanel.tmzone.lblDetailValue.Text = openWeather.Timezone.ToString();
                weatherPanel.velocidad.lblDetailValue.Text = openWeather.Wind.Speed.ToString();
                weatherPanel.visibilidad.lblDetailValue.Text = openWeather.Visibility.ToString() + "m";
                weatherPanel.sunr.lblDetailValue.Text = convertLongToDate(openWeather.Sys.Sunrise).ToShortTimeString();
                weatherPanel.suns.lblDetailValue.Text = convertLongToDate(openWeather.Sys.Sunset).ToShortTimeString();
                flpContent.Controls.Add(weatherPanel);

            }
            catch (Exception)
            {
                
            }
           
        }
        DateTime convertLongToDate(long date)
        {
            DateTime time = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).ToLocalTime();
            time = time.AddSeconds(date).ToLocalTime();
            return time;
        }
        public async Task Request()
        {
           openWeather = await httpOpenWeatherClient.GetWeatherByCityNameAsync(textBox1.Text);
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        //private void historial()
        //{
        //    FrmForecast frmForecast;
        //    for (int i = 0; i < 8; i++)
        //    {
        //        frmForecast = new FrmForecast();
        //        frmForecast.TopLevel = false;
        //        frmForecast.pictureBox1.ImageLocation = wheaterser.GetImageLocation(forecast.daily[i].weather[0]);
        //        frmForecast.lblDescription.Text = forecast.daily[i].weather[0].description;
        //        frmForecast.lblWeather.Text = forecast.daily[i].weather[0].main;
        //        frmForecast.lblDay.Text = wheaterser.convertToDateTime(forecast.daily[i].dt).DayOfWeek.ToString();
        //        flowLayoutPanel1.Controls.Add(frmForecast);
        //        frmForecast.Show();
        //    }
        //}
    }
}
