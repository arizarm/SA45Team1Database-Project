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
    public partial class RentVehicle : Form
    {
        public RentVehicle()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (RVUtil.isEmpty(textBox2.Text))
                {
                    MessageBox.Show(RVMessage.NoCatIndentified);
                }
                else
                {
                    RentVehicleControl mcControl = new RentVehicleControl();
                    DataTable rentalAvailableList = mcControl.retrieveVehicleInfo(textBox2.Text.ToString());
                    dataGridView1.DataSource = rentalAvailableList;
                    dateTimePicker1.Enabled = true;
                    textBox1.ReadOnly = false;
                    button2.Enabled = true;
                }
            }
            catch (Exception excep)
            {
                Console.WriteLine("Exception !!!");
                Console.WriteLine(excep.Message);
                Console.WriteLine(excep.StackTrace);
                MessageBox.Show(RVMessage.GenError);

                // cancel form load event and close the form
                this.BeginInvoke(new MethodInvoker(this.Close));

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (RVUtil.isEmpty(textBox1.Text))
                {
                    MessageBox.Show(RVMessage.EmptyCustomerID);
                    return;
                }
                else
                {
                    RentVehicleControl rvControl = new RentVehicleControl();

                    int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                    DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];

                    Vehicle c = new Vehicle();
                    c.plateNo = Convert.ToString(selectedRow.Cells[0].Value);

                    rvControl.updateVehicleInfo(c);

                    Rental r = new Rental();
                    r.customerID = textBox1.Text.ToString();
                    r.plateNum = Convert.ToString(selectedRow.Cells[0].Value);
                    r.dateOfRental = dateTimePicker1.Value.ToShortDateString();

                    rvControl.createRental(r);


                    MessageBox.Show(RVMessage.RentVehicleSuccessful);

                    this.Hide();
                    var RentVehicle = new RentVehicle();
                    RentVehicle.Closed += (s, args) => this.Close();
                    RentVehicle.Show();
                }
            }
            catch (RVException dftExcep)
            {
                Console.WriteLine("Exception !!!");
                Console.WriteLine(dftExcep.Message);
                Console.WriteLine(dftExcep.StackTrace);
                MessageBox.Show(dftExcep.Message);
            }
            catch (Exception excep)
            {
                Console.WriteLine("Exception !!!");
                Console.WriteLine(excep.Message);
                Console.WriteLine(excep.StackTrace);
                MessageBox.Show(RVMessage.GenError);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            var FormMainPage = new FormMainPage();
            FormMainPage.Closed += (s, args) => this.Close();
            FormMainPage.Show();
        }
    }
}
