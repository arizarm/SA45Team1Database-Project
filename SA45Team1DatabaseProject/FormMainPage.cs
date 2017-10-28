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
    public partial class FormMainPage : Form
    {
        public FormMainPage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var RentalStatusEnquiry = new RentalStatusEnquiry();
            RentalStatusEnquiry.Closed += (s, args) => this.Close();
            RentalStatusEnquiry.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            var RentVehicle = new RentVehicle();
            RentVehicle.Closed += (s, args) => this.Close();
            RentVehicle.Show();

            
        }
    }
}
