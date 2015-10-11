using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tour_Agency.ServiceReference1;
//using WcfServiceLibrary1;
//using System.Net.Configuration;
//using System.ServiceModel;


namespace Tour_Agency
{
    public partial class Form1 : Form
    {
        Service1Client client;
        bool ea;
        //ServiceHost host = new ServiceHost(typeof(WcfServiceLibrary1.Service1));
        //Service1 serv1;

        public Form1()
        {
            InitializeComponent();
            client = new Service1Client();
            ea = true;
            //host.Open();
            //serv1 = new Service1();
            //MessageBox.Show("Host start...");

            string[] euTours = client.GetEuropeTour();

            foreach (string tour in euTours)
            {
                listBox1.Items.Add(tour);
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            string[] euTours = client.GetEuropeTour();

            if (euTours.Count() > 0)
            {
                foreach (string tour in euTours)
                {
                    listBox1.Items.Add(tour);
                }
                ea = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            string[] afTours = client.GetAfricaTour();

            if (afTours.Count() > 0)
            {
                foreach (string tour in afTours)
                {
                    listBox1.Items.Add(tour);
                }
                ea = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >=0)
            {
                MessageBox.Show("ok");
                client.RegBuy(ea, (string)listBox1.SelectedItem);

                listBox1.Items.Clear();
                if (ea)
                {
                    string[] euTours = client.GetEuropeTour();

                    if (euTours.Count() > 0)
                    {
                        foreach (string tour in euTours)
                        {
                            listBox1.Items.Add(tour);
                        }
                    }
                }
                else
                {
                    string[] afTours = client.GetAfricaTour();

                    if (afTours.Count() > 0)
                    {
                        foreach (string tour in afTours)
                        {
                            listBox1.Items.Add(tour);
                        }
                    }
                }
            }
        }
    }
}
