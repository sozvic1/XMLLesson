using System;
using System.Xml;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using System.Configuration;
using System.Collections.Specialized;


namespace HomeTask4
{
    public partial class Form1 : Form
    {
        //private ListBox listBox1;
       
        private ColorDialog chooseColorDialog = new ColorDialog();
        
        public Form1()
        {
            InitializeComponent();
            button1.Click += new EventHandler(ChooseColor);
           
            try
            {
                if (ReadSettings() == false)
                    listBox1.Items.Add("В файле конфигурации нет информации...");
                else
                    listBox1.Items.Add("Информация успешно загружена из файла конфигурации...");

                this.StartPosition = FormStartPosition.CenterScreen;
            }
            catch (Exception e)
            {
                listBox1.Items.Add("Возникала проблема при загрузке данных из файла конфигурации:");
                listBox1.Items.Add(e.Message);
            }
        }   

        private void ChooseColor(object Sender, EventArgs e)
        {
            if (chooseColorDialog.ShowDialog() == DialogResult.OK)
                this.BackColor = chooseColorDialog.Color;

        }
        private void ColorText()
        {
            if (chooseColorDialog.ShowDialog() == DialogResult.OK)
                this.ForeColor = chooseColorDialog.Color;
        }
        bool ReadSettings()
        {
            // Загрузка настроек по парам [ключ]-[значение].
            NameValueCollection allAppSettings = ConfigurationManager.AppSettings;
            if (allAppSettings.Count < 1) { return (false); }

            // Восстановление состояния:
            //1. Цвет фона.
            int red = Convert.ToInt32(allAppSettings["BackGroundColor.R"]);
            int green = Convert.ToInt32(allAppSettings["BackGroundColor.G"]);
            int blue = Convert.ToInt32(allAppSettings["BackGroundColor.B"]);

            this.BackColor = Color.FromArgb(red, green, blue);
            listBox1.Items.Add("Цвет фона: " + BackColor.Name);            
        

            this.Height = Convert.ToInt32(allAppSettings["Window.Height"]);
            this.Width = Convert.ToInt32(allAppSettings["Window.Width"]);
            this.Text =  new Size(Width, Height).ToString();

           

            //4. Состояние окна.
            string winState = allAppSettings["Window.State"];
            listBox1.Items.Add("Состояние окна: " + winState);
            this.WindowState = (FormWindowState)FormWindowState.Parse(WindowState.GetType(), winState);
            return (true);
        }

       
    }
}
