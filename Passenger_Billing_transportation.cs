  /*Application for Bus Drivers in Mild Atlantic Bus Tours to enter their name, discounts, 
 * student and  full-fare passengers that they have carried on their tours that day
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment2
{
    public partial class Form1 : Form

    {
        public Form1()
        {

            InitializeComponent();
            driversNameBox.Focus();
            driversSummaryGroupBox.Visible = false;
            companySummaryDataGroupBox.Visible = false;
            summaryButton.Enabled = false;
            
        }

   //Declaration of constant variables that is being used throughout the program.
        const Double fullFarePrice = 5.50;
        const Double studentFarePrice = 4.50;
        const Double discountFarePrice = 3.75;

 //Declaration of variables for performing calculations on drivers and company's data. 
        Double totalPassengers;            //calculate total Passenger for driver
        Double totalReceipts;             //calculate total Receipts for driver
        Double avgReceiptsRound;         //calculate total average receipt
        Double allTotalPassengers = 0;  //calculate all total Passenger for company
        Double allTotalReceipts = 0;   //calculate all total Receipts for company
        Double allTotalAvg;           //calculate all total average for company
        int totalDrivers = 0;         //declaration for calculating the total number of drivers.
                              
       //Variable declaration for accepting the Input values from textbox.
        Double fullFareInput;
        Double studentRidersInput;
        Double discountFareInput;



        private void CalculateButton_Click(object sender, EventArgs e)
        {

            calculateButton.Enabled = false;
            summaryButton.Enabled = true;
            companySummaryDataGroupBox.Visible = false;

            //Condition check if textboxes have empty values.
            if (driversNameBox.Text == "" || fullFareBox.Text == "" || studentRidersBox.Text == "" || discountRidersBox.Text == "")

            {
                MessageBox.Show("Please enter all the fields");
                driversSummaryGroupBox.Visible = false;
                driversNameBox.Focus();

            }



    //Exception handling for performing calculations for Driver and Company data.
            try
            {
                fullFareInput = Double.Parse(fullFareBox.Text);
                try
                {
                    studentRidersInput = Double.Parse(studentRidersBox.Text);
                    try
                    {
                        discountFareInput = Double.Parse(discountRidersBox.Text);
                        driversSummaryGroupBox.Visible = true;

         //Calculaing prices of users per trip for Driver Groupbox
                        string driverName = driversNameBox.Text;
                        totalPassengers = fullFareInput + studentRidersInput + discountFareInput;
                        totalReceipts = (fullFarePrice * fullFareInput) + (studentFarePrice * studentRidersInput) + (discountFarePrice * discountFareInput);
                        Double averageReceipts = totalReceipts / totalPassengers;
                        avgReceiptsRound = Math.Round(averageReceipts, 2);  //displays average value upto 2 decimal values

                        //Displaying values in Euros for Drivers groupbox
                        driverNameSummaryBox.Text = driverName;
                        totalPassengersSummaryBox.Text = totalPassengers.ToString();
                        totalReceiptsSummaryBox.Text = "\u20AC" + totalReceipts.ToString();
                        avgPassengerSummaryBox.Text = "\u20AC" + avgReceiptsRound.ToString();



                        driverDataGroupBox.Enabled = false;

                        //Calculation performed for displaying the company data for all the drivers combined for the tour
                        driversNameBox.Text = "";
                        fullFareBox.Text = "";
                        studentRidersBox.Text = "";
                        discountRidersBox.Text = "";
                        totalDrivers++;
                        allTotalPassengers = totalPassengers + allTotalPassengers;
                        allTotalReceipts = totalReceipts + allTotalReceipts;
                        allTotalAvg = Math.Round((allTotalReceipts / allTotalPassengers), 2);
                        companyAvgPassengerReceipt.Text = "\u20AC" + allTotalAvg.ToString();
                        companyTotalDriversbox.Text = totalDrivers.ToString();
                        companyTotalPassengers.Text = allTotalPassengers.ToString();
                        companyTotalReceipts.Text = "\u20AC" + allTotalReceipts.ToString();

                    }
                    catch
                    {
                        MessageBox.Show("Please enter only numeric data for discount Fare Riders", "Warning",
                                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                        calculateButton.Enabled = true;
                        summaryButton.Enabled = false;
                        discountRidersBox.Focus();
                        discountRidersBox.SelectAll();
                    }
                }
                catch
                {
                    MessageBox.Show("Please enter only numeric data for  Student Riders", "Warning",
                                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                    calculateButton.Enabled = true;
                    summaryButton.Enabled = false;
                    studentRidersBox.Focus();
                    studentRidersBox.SelectAll();
                }
            }
            catch
            {
                MessageBox.Show("Please enter only numeric data for Full Fare Riders", "Warning",
                                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                calculateButton.Enabled = true;
                summaryButton.Enabled = false;
                fullFareBox.Focus();
                fullFareBox.SelectAll();

            }
        }



        private void SummaryButton_Click(object sender, EventArgs e)
        {
            driverDataGroupBox.Visible = false;
            driversSummaryGroupBox.Visible = false;
            companySummaryDataGroupBox.Visible = true;
            summaryButton.Enabled = false;
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            //closes the form and all its background threads after clicking on the exit button
            this.Close();
            System.Windows.Forms.Application.ExitThread();

        }

        private void DriversNameBox_MouseHover(object sender, EventArgs e)
        {   
            //Tooltip created to help driver enter Driver name
            ToolTip t1 = new ToolTip();
            t1.Active = true;
            t1.AutoPopDelay = 2000;
            t1.InitialDelay = 400;
            t1.IsBalloon = true;
            t1.ToolTipIcon = ToolTipIcon.Info;
            t1.SetToolTip(driversNameBox, "Please enter Driver's name");
        }

        private void FullFareBox_MouseHover(object sender, EventArgs e)
        {
            //Tooltip created to help driver enter Full Fare value
            ToolTip t2 = new ToolTip();
            t2.Active = true;
            t2.AutoPopDelay = 2000;
            t2.InitialDelay = 400;
            t2.IsBalloon = true;
            t2.ToolTipIcon = ToolTipIcon.Info;
            t2.SetToolTip(fullFareBox, "Please enter fare for Full Fair Riders");
        }

        private void StudentRidersBox_MouseHover(object sender, EventArgs e)
        {
            //Tooltip created to help driver enter Student Fare value
            ToolTip t3 = new ToolTip();
            t3.Active = true;
            t3.AutoPopDelay = 2000;
            t3.InitialDelay = 400;
            t3.IsBalloon = true;
            t3.ToolTipIcon = ToolTipIcon.Info;
            t3.SetToolTip(studentRidersBox, "Please enter fare for Student Riders");
        }

        private void DiscountRidersBox_TextChanged(object sender, EventArgs e)
        {
            //Tooltip created to help driver enter discount value
            ToolTip t4 = new ToolTip();
            t4.Active = true;
            t4.AutoPopDelay = 2000;
            t4.InitialDelay = 400;
            t4.IsBalloon = true;
            t4.ToolTipIcon = ToolTipIcon.Info;
            t4.SetToolTip(discountRidersBox, "Please enter the Discounted Fare");
        }

        private void SummaryButton_MouseHover(object sender, EventArgs e)
        {
            //Tooltip created to help driver see the data summary
            ToolTip t5 = new ToolTip();
            t5.Active = true;
            t5.AutoPopDelay = 2000;
            t5.InitialDelay = 400;
            t5.IsBalloon = true;
            t5.ToolTipIcon = ToolTipIcon.Info;
            t5.SetToolTip(summaryButton, "Press for company data summary");
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {

            //Clear button clear the form and lets the driver enter new values
            driverDataGroupBox.Visible= true;
            driverDataGroupBox.Enabled = true;
            driversNameBox.Focus();
            calculateButton.Enabled = true;
            summaryButton.Enabled = false;
            driversSummaryGroupBox.Visible = false;
            companySummaryDataGroupBox.Visible = false;

            driversNameBox.Text = "";
            fullFareBox.Text = "";
            studentRidersBox.Text = "";
            discountRidersBox.Text = "";

        }

        private void CalculateButton_MouseHover(object sender, EventArgs e)
        {
            //Tooltip created to help driver see the total fare data
            ToolTip t5 = new ToolTip();
            t5.Active = true;
            t5.AutoPopDelay = 2000;
            t5.InitialDelay = 400;
            t5.IsBalloon = true;
            t5.ToolTipIcon = ToolTipIcon.Info;
            t5.SetToolTip(calculateButton, "Press to show the ride data");
        }

        private void ClearButton_MouseHover(object sender, EventArgs e)
        {
            //Tooltip created to help driver clear the data and enter new values
            ToolTip t6 = new ToolTip();
            t6.Active = true;
            t6.AutoPopDelay = 2000;
            t6.InitialDelay = 400;
            t6.IsBalloon = true;
            t6.ToolTipIcon = ToolTipIcon.Info;
            t6.SetToolTip(clearButton, "Press to clear the data and enter new values");
        }

        private void ExitButton_MouseHover(object sender, EventArgs e)
        {
            //Tooltip created to exit the application
            ToolTip t7 = new ToolTip();
            t7.Active = true;
            t7.AutoPopDelay = 2000;
            t7.InitialDelay = 400;
            t7.IsBalloon = true;
            t7.ToolTipIcon = ToolTipIcon.Info;
            t7.SetToolTip(exitButton, "Press to exit the application");
        }

            }
}

