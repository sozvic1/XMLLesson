using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Settings
{
    public partial class Form1 : Form
    {
        private ColorDialog chooseColor = new ColorDialog();
        
        public Form1()
        {
            InitializeComponent();
            colorFone.Click += new EventHandler(ClickChooseBackColor);
      
            try
            {
                if (ReadSettings() == false)
                    listBox1.Items.Add("В реестре нет информации...");
                else
                    listBox1.Items.Add("Информация успешно загружена из реестра...");

                StartPosition = FormStartPosition.Manual;
            }
            catch (Exception e)
            {
                listBox1.Items.Add("Возникала проблема при загрузке данных из реестра:");
                listBox1.Items.Add(e.Message);
            }
        }
        void ClickChooseBackColor(object Sender, EventArgs e)
        {
            if (chooseColor.ShowDialog() == DialogResult.OK)
                BackColor = chooseColor.Color;
        }
      
        bool ReadSettings()
        {
            RegistryKey softwareKey = Registry.LocalMachine.OpenSubKey("ITEA");
            RegistryKey wroxKey = softwareKey.OpenSubKey("Setting");

            if (wroxKey == null)
                return false;

            RegistryKey selfPlacingWindowKey = wroxKey.OpenSubKey("MyWindow");

            if (selfPlacingWindowKey == null)
                return false;
            else
                listBox1.Items.Add("Успешно открыт ключ " + selfPlacingWindowKey.ToString());

            int redComponent = (int)selfPlacingWindowKey.GetValue("Red");
            int greenComponent = (int)selfPlacingWindowKey.GetValue("Green");
            int blueComponent = (int)selfPlacingWindowKey.GetValue("Blue");
            this.BackColor = Color.FromArgb(redComponent, greenComponent, blueComponent);
            listBox1.Items.Add("Цвет фона: " + BackColor.Name);
            int X = (int)selfPlacingWindowKey.GetValue("X");
            int Y = (int)selfPlacingWindowKey.GetValue("Y");
            this.DesktopLocation = new Point(X, Y);
            listBox1.Items.Add("Расположение: " + DesktopLocation.ToString());
            this.Height = (int)selfPlacingWindowKey.GetValue("Height");
            this.Width = (int)selfPlacingWindowKey.GetValue("Width");
            listBox1.Items.Add("Размер: " + new Size(Width, Height).ToString());
            string initialWindowState = (string)selfPlacingWindowKey.GetValue("WindowState");
            listBox1.Items.Add("Состояние окна: " + initialWindowState);
            this.WindowState = (FormWindowState)FormWindowState.Parse(WindowState.GetType(), initialWindowState);
            return true;
        }
        void SaveSettings()
        {
            RegistryKey softwareKey = Registry.LocalMachine.OpenSubKey("ITEA", true);
            RegistryKey wroxKey = softwareKey.CreateSubKey("Setting");
            RegistryKey selfPlacingWindowKey = wroxKey.CreateSubKey("MyWindow");

            selfPlacingWindowKey.SetValue("BackColor", (object)BackColor.ToKnownColor());
            selfPlacingWindowKey.SetValue("Red", (object)(int)BackColor.R);
            selfPlacingWindowKey.SetValue("Green", (object)(int)BackColor.G);
            selfPlacingWindowKey.SetValue("Blue", (object)(int)BackColor.B);
            selfPlacingWindowKey.SetValue("Width", (object)Width);
            selfPlacingWindowKey.SetValue("Height", (object)Height);
            selfPlacingWindowKey.SetValue("X", (object)DesktopLocation.X);
            selfPlacingWindowKey.SetValue("Y", (object)DesktopLocation.Y);
            selfPlacingWindowKey.SetValue("WindowState", (object)WindowState.ToString());
        }

    }
}
