using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace HavamBatsinApp
{
    public partial class Form1 : Form
    {
        string seciliSehir = "Adana";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedItem = "Adana";
            string path = "https://api.openweathermap.org/data/2.5/weather?q=" + seciliSehir + "&appid=68cc50411677424c33ee75803590a790&mode=xml&lang=tr&units=metric";
            XDocument havadurumu = XDocument.Load(path);
            XElement current = havadurumu.Root;

            double sicaklik = Convert.ToInt32(Convert.ToDouble(current.Element("temperature").Attribute("value").Value.Replace('.', ',')));
            lbl_sicaklik.Text = sicaklik.ToString() + "°C";

            string durum = current.Element("weather").Attribute("value").Value;
            string ikon = current.Element("weather").Attribute("icon").Value;
            string imagePath = "https://openweathermap.org/img/wn/" + ikon + "@2x.png";
            pictureBox1.ImageLocation = imagePath;
            lbl_durum.Text = durum;
            lbl_sehir.Text = seciliSehir;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            seciliSehir = comboBox1.SelectedItem.ToString();
            SehirSec();
        }
        private void SehirSec()
        {
            string path = "https://api.openweathermap.org/data/2.5/weather?q=" + seciliSehir + "&appid=68cc50411677424c33ee75803590a790&mode=xml&lang=tr&units=metric";
            XDocument havadurumu = XDocument.Load(path);
            XElement current = havadurumu.Root;

            double sicaklik = Convert.ToInt32(Convert.ToDouble(current.Element("temperature").Attribute("value").Value.Replace('.', ',')));
            lbl_sicaklik.Text = sicaklik.ToString() + "°C";

            string durum = current.Element("weather").Attribute("value").Value;
            string ikon = current.Element("weather").Attribute("icon").Value;
            string imagePath = "https://openweathermap.org/img/wn/" + ikon + "@2x.png";
            pictureBox1.ImageLocation = imagePath;
            lbl_durum.Text = durum;
            lbl_sehir.Text = seciliSehir;
        }
    }
}
