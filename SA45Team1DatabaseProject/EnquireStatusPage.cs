using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SA45Team1DatabaseProject
{
    public partial class RentalStatusEnquiry : Form
    {
        public RentalStatusEnquiry()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (RVUtil.isEmpty(textBox1.Text))
                {
                    MessageBox.Show(RVMessage.EmptyPlateNo);
                    textBox2.Text = String.Empty;
                    textBox3.Text = String.Empty;
                    textBox4.Text = String.Empty;
                    textBox5.Text = String.Empty;
                    textBox6.Text = String.Empty;

                }
                else
                {
                    EnquiryVehicleStatusControl evControl = new EnquiryVehicleStatusControl();
                    Vehicle c = evControl.RetrievePlateNo(textBox1.Text.ToString());

                    textBox1.Text = String.Empty;
                    textBox2.Text = c.model;
                    textBox3.Text = c.colour;
                    textBox4.Text = c.engineNo;
                    textBox5.Text = c.status;
                    textBox6.Text = c.plateNo;
                }
            }
            catch (RVException rvExcep)
            {
                Console.WriteLine("Exception !!!");
                Console.WriteLine(rvExcep.Message);
                Console.WriteLine(rvExcep.StackTrace);
                MessageBox.Show(rvExcep.Message);
            }
            catch (Exception excep)
            {
                Console.WriteLine("Exception !!!");
                Console.WriteLine(excep.Message);
                Console.WriteLine(excep.StackTrace);
                MessageBox.Show(RVMessage.GenError);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            var FormMainPage = new FormMainPage();
            FormMainPage.Closed += (s, args) => this.Close();
            FormMainPage.Show();
        }
    }
}
