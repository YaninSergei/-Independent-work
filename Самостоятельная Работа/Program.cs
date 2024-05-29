using System;
using System.Collections.Generic;
using System.IO.Ports; //Библиотека по портам.
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;


namespace transmitter
{


    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SerialPort serialPort1 = new SerialPort();
        private void Form1_Load(object sender, EventArgs e)
        {

            serialPort1.PortName = "COM11";
            serialPort1.BaudRate = 115200; // Convert.'тип данных'(конвертируемый объект) - Конвертация переменных в другой тип данных.
            serialPort1.DataBits = 8;
            serialPort1.StopBits = (StopBits)Enum.Parse(typeof(StopBits), "One"); //Enum.Parse: преобразование строки в перечисление. Смотреть описание - нихрена не понятно.
            serialPort1.Parity = (Parity)Enum.Parse(typeof(Parity), "None");
            serialPort1.Open();
            timer.Enabled = true;
            if (!serialPort1.IsOpen | !timer.Enabled)
            {
                System.Windows.Forms.Application.Exit();
            }


        }
        public void timer_Tick(object sender, EventArgs e)
        {
            DateTime timNow = DateTime.Now;
            Int32 ticks = (Int32)timNow.Ticks;

            int sinusoida(double t, double A, double W)
            {

                double X = A * Math.Sin(W * t);
                return Convert.ToInt32(X);
            }
            string Znachenie = Convert.ToString(sinusoida(Convert.ToDouble(ticks) / 10000000, 100, 0.5))
                + "," + Convert.ToString(sinusoida(Convert.ToDouble(ticks) / 10000000, 80, 0.5))
                + "," + Convert.ToString(sinusoida(Convert.ToDouble(ticks) / 10000000, 120, 0.5));



            void WorkComport(string Plucheni, List<string> spisok)
            {
                string[] datas = Plucheni.Split(',');
                for (int i = 0; i < datas.Length; i++)
                {
                    if (datas[i] != "")
                    {
                        string chislo = (datas[i]);
                        spisok.Add(chislo);
                    }
                }
            }

            List<string> funcia(string Data)
            {

                List<string> spisok = new List<string>();
                for (int i = 0; i < Znachenie.Length; i++)
                {
                    WorkComport(Znachenie, spisok);

                }
                return spisok;
            }

            serialPort1.Write(Znachenie + "\n");

        }
    }
}
