using AyuboGUI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ayubo_System;

namespace AyuboGUI
{
    public partial class Home : Form
    {
        private DataAccessService dataAccessService;

        public Home()
        {
            InitializeComponent();
            dataAccessService = new DataAccessService();

            label5.Enabled = false;
            label13.Visible = false;
        }

        private void Home_Load(object sender, EventArgs e)
        {
            var vehicleTypes = dataAccessService.GetVehicleTypes();
            for (int i = 0; i < vehicleTypes.Count; i++)
            {
                comboBox1.Items.Insert(i, vehicleTypes[i].TypeName);
                comboBox4.Items.Insert(i, vehicleTypes[i].TypeName);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var newVehicleType = new Models.VehicleType();
            newVehicleType.TypeName = this.textBox1.Text;

            newVehicleType = dataAccessService.AddVehicleType(newVehicleType);
            if(newVehicleType.Id > 0)
            {
                checkBox2.Checked = true;
            }
            else
            {
                checkBox2.Checked = false;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var vehicleType = dataAccessService.FindVehicleTypes(textBox2.Text);
            if (vehicleType != null)
            {
                checkBox1.Checked = true;
                label5.Text = vehicleType.Id.ToString();
                textBox3.Text = vehicleType.TypeName;
                textBox3.Enabled = true;
                button3.Enabled = true;

            }
            else
            {
                checkBox1.Checked = false;
                label5.Enabled = false;
                textBox3.Enabled = false;
                button3.Enabled = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dataAccessService.GetVehicleTypes();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            var vehicleType = dataAccessService.FindVehicleTypes(textBox4.Text);
            if (vehicleType != null)
            {
                button6.Visible = true;
                label6.Text = "Item found";
                label6.Visible = true;
            }
            else
            {
                label6.Text = "Item not found , try with proper name.";
                button6.Visible = false;
                label6.Visible = true;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var vehicleType = dataAccessService.FindVehicleTypes(textBox4.Text);
            if (vehicleType != null)
            {
                var deletion = dataAccessService.DeleteVehicleType(vehicleType);
                if (deletion)
                {
                    button6.Visible = false;
                    label6.Text = "Item deleted successfully";
                    label6.Visible = true;
                }
            }
            else
            {
                label6.Text = "Deletion failed try find again";
                label6.Visible = true;
            }
           
        }

        private void button7_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            bool validated = true;

            Models.Package newpackage = new Models.Package();
            newpackage.PackageName = textBox5.Text;
            newpackage.IsApplicable = checkBox3.Checked;


            try{ 
                newpackage.StandardRate = double.Parse(textBox6.Text); 
            }
            catch (Exception ex){

                validated = false;
                errorProvider1.SetError(textBox6, "Enter valid number");
            }

            try
            {
                newpackage.ExtraKmRate = double.Parse(textBox7.Text);
            }
            catch (Exception ex)
            {
                validated = false;
                errorProvider1.SetError(textBox7, "Enter valid number");
            }

            try
            {
                newpackage.MaxKmLimit = double.Parse(textBox8.Text);
            }
            catch (Exception ex)
            {
                validated = false;
                errorProvider1.SetError(textBox8, "Enter valid number");
            }

            try
            {
                newpackage.MaxHoursLimit = double.Parse(textBox9.Text);
            }
            catch (Exception ex)
            {
                validated = false;
                errorProvider1.SetError(textBox9, "Enter valid number");
            }

            if (validated)
            {
                newpackage = dataAccessService.Addpackage(newpackage);
                if (newpackage.Id > 0)
                {
                    label13.Text = "Package created successfully.";
                    label13.Visible = true;
                }
                else
                {
                    label13.Text = "Package creation error.";
                    label13.Visible = true;
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = dataAccessService.Getpackages();        
        }

        private void button9_Click(object sender, EventArgs e)
        {
            var package = dataAccessService.FindPackage(textBox10.Text);
            if (package != null)
            {
                label15.Text = "Item Found";
                textBox11.Text = package.PackageName;
                checkBox4.Checked = package.IsApplicable;
                textBox12.Text = package.StandardRate.ToString();
                textBox13.Text = package.ExtraKmRate.ToString();
                textBox14.Text = package.MaxKmLimit.ToString();
                textBox15.Text = package.MaxHoursLimit.ToString();
            }
            else
            {
                label15.Text = "Item Not Found";
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var vehicleType = dataAccessService.FindVehicleTypes(textBox2.Text);
            if (vehicleType != null)
            {
                vehicleType.TypeName = textBox3.Text;
                textBox3.Enabled = true;
                button3.Enabled = true;
                dataAccessService.UpdateVehicleType(vehicleType);
            }
            
        }

        private void button10_Click(object sender, EventArgs e)
        {
            var package = dataAccessService.FindPackage(textBox10.Text);
            if (package != null)
            {             
                package.PackageName = textBox11.Text;
                package.IsApplicable = checkBox4.Checked;
                package.StandardRate = double.Parse(textBox12.Text);
                package.ExtraKmRate = double.Parse(textBox13.Text);
                package.MaxKmLimit = double.Parse(textBox14.Text);
                package.MaxHoursLimit = double.Parse(textBox15.Text);
                package.MaxHoursLimit = double.Parse(textBox15.Text);

                dataAccessService.UpdatePackage(package);
                label15.Text = "Item updated successfully";

            }
            else
            {
                label15.Text = "Item updation error.";
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            var package = dataAccessService.FindPackage(textBox16.Text);
            if (package != null)
            {
                button12.Visible = true;
                label23.Text = "Item found";
                label23.Visible = true;
            }
            else
            {
                label23.Text = "Item not found , try with proper name.";
                button12.Visible = false;
                label23.Visible = true;
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            var package = dataAccessService.FindPackage(textBox16.Text);
            if (package != null)
            {
                var result = dataAccessService.DeletePackage(package);
                if (result)
                {
                    label23.Text = "Item deleted successfully";
                    label23.Visible = true;
                }
                else
                {
                    label23.Text = "Item deletion error.";
                    label23.Visible = true;
                }

            }
            else
            {
                label23.Text = "Item not found";
                label23.Visible = true;
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Models.Rental modelRental = dataAccessService.FindRentalVehicle(textBox17.Text);
            if(modelRental != null)
            {
                Ayubo_System.Rental rental = new Ayubo_System.Rental();

                rental.DailyDriverCost = modelRental.DailyDriverCost;
                rental.DailyRental = modelRental.DailyRental;
                //rental.Driver = modelRental.Driver;
                rental.MonthlyRental = modelRental.MonthlyRental;
                rental.Tarrif = modelRental.Tarrif;
                rental.VehicleNo = modelRental.VehicleNo;
                rental.VehicleType = new Ayubo_System.VehicleType() { TypeName = modelRental.VehicleType.TypeName } ;
                rental.WeeklyRental = modelRental.WeeklyRental;

                var rentedDate = dateTimePicker1.Value;
                var returnedDate = dateTimePicker2.Value;
                var withDriver = checkBox5.Checked;

                var rentAmount = rental.RentCalculation( rental.VehicleNo , rentedDate, returnedDate, withDriver );

                label30.Text = rentAmount.ToString();
            }
            
        }

        private void button17_Click(object sender, EventArgs e)
        {
            Models.Hire modelHire = dataAccessService.FindHireVehicle(textBox24.Text);
            if (modelHire != null)
            {
                Ayubo_System.Hire hire = new Ayubo_System.Hire();

                //hire.Driver = modelHire.Driver;
                hire.WaitingCharge = modelHire.WaitingCharge;
                hire.Tarrif = modelHire.Tarrif;
                hire.VehicleNo = modelHire.VehicleNo;
                hire.VehicleType = new Ayubo_System.VehicleType() { TypeName = modelHire.VehicleType.TypeName };

                Models.Package package = dataAccessService.FindPackage(comboBox2.SelectedItem.ToString());
                Ayubo_System.Package ayuboPackageModel = new Ayubo_System.Package();
                ayuboPackageModel.ExtraKmRate = package.ExtraKmRate;
                ayuboPackageModel.IsApplicable = package.IsApplicable;
                ayuboPackageModel.MaxHoursLimit = package.MaxHoursLimit;
                ayuboPackageModel.MaxKmLimit = package.MaxKmLimit;
                ayuboPackageModel.PackageName = package.PackageName;
                ayuboPackageModel.StandardRate = package.StandardRate;
                

                var startTime = dateTimePicker4.Value;
                var endTime = dateTimePicker3.Value;

                float startKmReading = float.Parse(textBox25.Text);
                float endKmReading = float.Parse(textBox26.Text);

                var withDriver = checkBox6.Checked;

                var rentAmount = hire.DayTourRentalCalculation(hire.VehicleNo, ayuboPackageModel, startTime, endTime, startKmReading, endKmReading);

                label38.Text = rentAmount.ToString();
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            Models.Hire modelHire = dataAccessService.FindHireVehicle(textBox29.Text);
            if (modelHire != null)
            {
                Ayubo_System.Hire hire = new Ayubo_System.Hire();

                //hire.Driver = modelHire.Driver;
                hire.WaitingCharge = modelHire.WaitingCharge;
                hire.Tarrif = modelHire.Tarrif;
                hire.VehicleNo = modelHire.VehicleNo;
                hire.VehicleType = new Ayubo_System.VehicleType() { TypeName = modelHire.VehicleType.TypeName };

                Models.Package package = dataAccessService.FindPackage(comboBox3.SelectedItem.ToString());
                Ayubo_System.Package ayuboPackageModel = new Ayubo_System.Package();
                ayuboPackageModel.ExtraKmRate = package.ExtraKmRate;
                ayuboPackageModel.IsApplicable = package.IsApplicable;
                ayuboPackageModel.MaxHoursLimit = package.MaxHoursLimit;
                ayuboPackageModel.MaxKmLimit = package.MaxKmLimit;
                ayuboPackageModel.PackageName = package.PackageName;
                ayuboPackageModel.StandardRate = package.StandardRate;


                DateTime startDate = dateTimePicker6.Value;
                DateTime endDate = dateTimePicker5.Value;

                float startKmReading = float.Parse(textBox28.Text);
                float endKmReading = float.Parse(textBox27.Text);

                var withDriver = checkBox7.Checked;

                var rentAmount = hire.LongTourRentalCalculation(hire.VehicleNo, ayuboPackageModel, startDate, endDate, startKmReading, endKmReading);

                label51.Text = rentAmount.ToString();
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            var newRentVehicle = new Models.Rental();
            newRentVehicle.VehicleNo = this.textBox18.Text;

            Models.VehicleType vehicleType = dataAccessService.FindVehicleTypes(this.comboBox1.SelectedItem.ToString());


            newRentVehicle.VehicleType = vehicleType;
            newRentVehicle.Tarrif = float.Parse(textBox19.Text);

            newRentVehicle.DailyRental = float.Parse(this.textBox20.Text);
            newRentVehicle.WeeklyRental = float.Parse(this.textBox21.Text);
            newRentVehicle.MonthlyRental = float.Parse(this.textBox22.Text);
            newRentVehicle.DailyDriverCost = float.Parse(this.textBox23.Text);

            newRentVehicle = dataAccessService.AddRentalVehicle(newRentVehicle);
            if (newRentVehicle.Id > 0)
            {
                checkBox2.Checked = true;
            }
            else
            {
                checkBox2.Checked = false;
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            var rentVehicle = dataAccessService.FindRentalVehicle(textBox35.Text);
            if (rentVehicle != null)
            {
                label65.Text = "Item Found";
                textBox35.Text = rentVehicle.VehicleNo;
                comboBox4.SelectedItem = rentVehicle.VehicleType.TypeName;
                textBox34.Text = rentVehicle.Tarrif.ToString();
                textBox33.Text = rentVehicle.DailyRental.ToString();
                textBox32.Text = rentVehicle.WeeklyRental.ToString();
                textBox31.Text = rentVehicle.MonthlyRental.ToString();
                textBox30.Text = rentVehicle.DailyDriverCost.ToString();
            }
            else
            {
                label65.Text = "Item Not Found";
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            var rentVehicle = dataAccessService.FindRentalVehicle(textBox35.Text);
            if (rentVehicle != null)
            {
                Models.VehicleType updatedVehicleType = dataAccessService.FindVehicleTypes(comboBox4.SelectedItem.ToString());

                rentVehicle.VehicleNo = textBox35.Text;
                rentVehicle.VehicleType = updatedVehicleType;
                rentVehicle.Tarrif = float.Parse(textBox34.Text);
                rentVehicle.DailyRental = float.Parse(textBox33.Text);
                rentVehicle.WeeklyRental = float.Parse(textBox32.Text);
                rentVehicle.MonthlyRental = float.Parse(textBox31.Text);
                rentVehicle.DailyDriverCost = float.Parse(textBox30.Text);

                dataAccessService.UpdateRentalVehicle(rentVehicle);
                label65.Text = "Rental vehicle updated successfully";

            }
            else
            {
                label65.Text = "Rental vehicle updation error.";
            }
        }
    }
}
