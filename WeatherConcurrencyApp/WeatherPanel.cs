using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeatherConcurrencyApp
{
    public partial class WeatherPanel : UserControl
    {
        public DetailsWeather longitud = new DetailsWeather();
        public DetailsWeather latitud = new DetailsWeather();
        public DetailsWeather temperatura = new DetailsWeather();
        public DetailsWeather feels = new DetailsWeather();
        public DetailsWeather tempMin = new DetailsWeather();
        public DetailsWeather tempMax = new DetailsWeather();
        public DetailsWeather presion = new DetailsWeather();
        public DetailsWeather humedad = new DetailsWeather();
        public DetailsWeather visibilidad = new DetailsWeather();
        public DetailsWeather velocidad = new DetailsWeather();
        public DetailsWeather sunr = new DetailsWeather();
        public DetailsWeather suns = new DetailsWeather();
        public DetailsWeather tmzone = new DetailsWeather();
        public WeatherPanel()
        {
            InitializeComponent();
        }

        private void WeatherPanel_Load(object sender, EventArgs e)
        {
            
    
            longitud.lblDetail.Text = "longitud";
            flpContent.Controls.Add(longitud);

            latitud.lblDetail.Text = "latitud";
            flpContent.Controls.Add(latitud);

            temperatura.lblDetail.Text = "Temperatura";
            flpContent.Controls.Add(temperatura);

            feels.lblDetail.Text = "feels_like";
            flpContent.Controls.Add(feels);

            tempMin.lblDetail.Text = "temp_min";
            flpContent.Controls.Add(tempMin);

            tempMax.lblDetail.Text = "temp_max";
            flpContent.Controls.Add(tempMax);

            presion.lblDetail.Text = "pressure";
            flpContent.Controls.Add(presion);

            humedad.lblDetail.Text = "humidity";
            flpContent.Controls.Add(humedad);

            visibilidad.lblDetail.Text = "visibility";
            flpContent.Controls.Add(visibilidad);

            velocidad.lblDetail.Text = "speed";
            flpContent.Controls.Add(velocidad);

            sunr.lblDetail.Text = "sunrise";
            flpContent.Controls.Add(sunr);

            suns.lblDetail.Text = "sunset";
            flpContent.Controls.Add(suns);

            tmzone.lblDetail.Text = "timezone";
            flpContent.Controls.Add(tmzone);
            
        }

    }
}
