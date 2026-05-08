using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ULMSWinFormsApp.Models;

namespace ULMSWinFormsApp.Forms
{
    public partial class FrmMarksCapture : Form
    {
        public FrmMarksCapture()
        {
            InitializeComponent();
        }

        private void btnCalculateResults_Click(object sender, EventArgs e)
        {
            // Fixed Validation in 3 steps Trial and Error approach

            // 1. Initialize the record
            MarkRecord record = new MarkRecord();
            record.StudentId = txtMarkStudentId.Text;
            record.StudentName = txtMarkStudentName.Text;

            // 2. Defensive Programming: Validate all inputs before calculation
            // We use double.TryParse to avoid System.FormatException crashes
            bool s1Valid = double.TryParse(txtSubject1.Text, out double s1);
            bool s2Valid = double.TryParse(txtSubject2.Text, out double s2);
            bool s3Valid = double.TryParse(txtSubject3.Text, out double s3);

            if (!s1Valid || !s2Valid || !s3Valid)
            {
                MessageBox.Show("Please enter valid numeric marks for all subjects.",
                                "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Stop execution if inputs are invalid
            }

            // 3. Assign validated values to the record
            record.Subject1 = s1;
            record.Subject2 = s2;
            record.Subject3 = s3;
            // corrected average calculation to divide by 3 instead of 2
            record.Average = (record.Subject1 + record.Subject2 + record.Subject3) / 3;


            if (record.Average >= 50)
            {
                record.ResultStatus = "PASS";
            }
            else
            {
                record.ResultStatus = "FAIL";
            }

            txtMarksOutput.Text =
                "Marks processed successfully!" + Environment.NewLine +
                "Student ID: " + record.StudentId + Environment.NewLine +
                "Student Name: " + record.StudentName + Environment.NewLine +
                "Subject 1: " + record.Subject1 + Environment.NewLine +
                "Subject 2: " + record.Subject2 + Environment.NewLine +
                "Subject 3: " + record.Subject3 + Environment.NewLine +
                "Average: " + record.Average + Environment.NewLine +
                "Final Result: " + record.ResultStatus;
        }

        private void btnClearMarks_Click(object sender, EventArgs e)
        {
            txtMarkStudentId.Clear();
            txtMarkStudentName.Clear();
            txtSubject1.Clear();
            txtSubject2.Clear();
            txtSubject3.Clear();
            txtMarksOutput.Clear();
            txtMarkStudentId.Focus();
        }

        private void btnBackMarks_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
