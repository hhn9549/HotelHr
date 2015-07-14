﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

using OracleDBHelper;

namespace HotelHR
{
    public partial class HrManage : Form
    {
        private OracleHelper helper;

        public HrManage()
        {
            InitializeComponent();
            helper = new OracleHelper();
            employeePerform.DataSource = helper.showEmployeePerform();
            employeePerform.Columns[1].ReadOnly = true;
            employeePerform.Columns[4].Visible = false;
        }

        //Page Control
        //show employee info
        private void employPerform_Selecting(object sender, TabControlCancelEventArgs e)
        {
            employeeJobTitle.DataSource = helper.showEmployeeJobTitle();
            employeeJobTitle.Columns[0].ReadOnly = true;
            employeeJobTitle.Columns[1].ReadOnly = true;

            employeeSalary.DataSource = helper.showEmployeeSalary();
            employeeSalary.Columns[0].ReadOnly = true;
            employeeSalary.Columns[1].ReadOnly = true;

            employeeInfo.DataSource = helper.showEmployeeInfo();
            //employeeInfo.Columns[7].Visible = false;
            
        }

        //EmployeePerform Page
        //employeePerform update
        private void employeePerform_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (employeePerform.Rows.Count > 0)
            {
                
                //helper.updateEmployeePerform(this.employeePerform.Rows[e.RowIndex].Cells[0].Value.ToString(),
                //    this.employeePerform.Rows[e.RowIndex].Cells[2].Value.ToString(),
                //    int.Parse(this.employeePerform.Rows[e.RowIndex].Cells[3].Value.ToString()),
                //    int.Parse(this.employeePerform.Rows[e.RowIndex].Cells[4].Value.ToString()));
                if (e.ColumnIndex == 0)
                {
                    int pos = 0;
                    helper.updateEmployeePerform(pos,this.employeePerform.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(),
                        int.Parse(this.employeePerform.Rows[e.RowIndex].Cells[4].Value.ToString()));
                }
                else if (e.ColumnIndex == 2)
                {
                    int pos = 2;
                    helper.updateEmployeePerform(pos, this.employeePerform.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(),
                        int.Parse(this.employeePerform.Rows[e.RowIndex].Cells[4].Value.ToString()));
                }
                else if (e.ColumnIndex == 3)
                {
                    int pos = 3;
                    helper.updateEmployeePerform(pos, int.Parse(this.employeePerform.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()),
                       int.Parse(this.employeePerform.Rows[e.RowIndex].Cells[4].Value.ToString()));
                }
                else
                {

                }
                employeePerform.DataSource = helper.showEmployeePerform();   
            }
        }

        //submit a employee perform
        private void submitButton_Click(object sender, EventArgs e)
        {

            var result = MessageBox.Show("Sure to submit?", "",MessageBoxButtons.YesNo);

            //confirm to submit
            if (result == DialogResult.Yes)
            {
                int type = 0;
                if (positiveRadio.Checked)
                {
                    type = 1;
                }
                else if (nagetiveRadio.Checked)
                {
                    type = -1;
                }

                if (helper.insertEmployeePerform(employeeIdBox.Text, reasonBox.Text, type))
                {
                    MessageBox.Show("Success!");
                    employeeIdBox.Text = "";
                    reasonBox.Text = "";
                    nagetiveRadio.Checked = false;
                    positiveRadio.Checked = false;
                }
            }
            else
            {

            }
        }

        //JobTitle Page
        //
        private void showAll_Click(object sender, EventArgs e)
        {
            employeeJobTitle.DataSource = helper.showEmployeeJobTitle();
        }

        //submitButton2_Click
        private void submitButton2_Click(object sender, EventArgs e)
        {
            employeeJobTitle.DataSource = helper.searchJobTitle(employeeIdBox2.Text);
        }

        //employeeJobTitle update
        private void employeeJobTitle_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if(employeeJobTitle.Rows.Count > 0)
            {
                helper.updateEmployeeJobTitle(this.employeeJobTitle.Rows[e.RowIndex].Cells[0].Value.ToString(), this.employeeJobTitle.Rows[e.RowIndex].Cells[2].Value.ToString());   
            }
        }


        //Salary Page
        //
        private void showAll2_Click(object sender, EventArgs e)
        {
            employeeSalary.DataSource = helper.showEmployeeSalary();
        }
        //submitButton3_Click
        private void submitButton3_Click(object sender, EventArgs e)
        {
            employeeSalary.DataSource = helper.searchSalary(employeeIdBox3.Text);
        }

        //employeeSalary update
        private void employeeSalary_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (employeeSalary.Rows.Count > 0)
            {
                helper.updateEmployeeSalary(this.employeeSalary.Rows[e.RowIndex].Cells[0].Value.ToString(), int.Parse(this.employeeSalary.Rows[e.RowIndex].Cells[2].Value.ToString()));
            }
        }




        private void promoteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void employPerform_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void employeeInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void jobTitleMenuStrip_Opening(object sender, CancelEventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_MouseDown(object sender, MouseEventArgs e)
        {
            this.infoButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.infoButton.FlatAppearance.BorderSize = 0;
            this.infoButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.performButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Tile;
            this.performButton.FlatAppearance.BorderSize = 1;
            this.performButton.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.jobButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Tile;
            this.jobButton.FlatAppearance.BorderSize = 1;
            this.jobButton.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.salaryButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Tile;
            this.salaryButton.FlatAppearance.BorderSize = 1;
            this.salaryButton.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.employPerform.SelectedIndex = 3;
        }

        private void employeeIdBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            this.performButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.performButton.FlatAppearance.BorderSize = 0;
            this.performButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.infoButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Tile;
            this.infoButton.FlatAppearance.BorderSize = 1;
            this.infoButton.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.jobButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Tile;
            this.jobButton.FlatAppearance.BorderSize = 1;
            this.jobButton.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.salaryButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Tile;
            this.salaryButton.FlatAppearance.BorderSize = 1;
            this.salaryButton.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.employPerform.SelectedIndex = 0;
        }

        private void button2_MouseDown(object sender, MouseEventArgs e)
        {
            this.jobButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.jobButton.FlatAppearance.BorderSize = 0;
            this.jobButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.performButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Tile;
            this.performButton.FlatAppearance.BorderSize = 1;
            this.performButton.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.infoButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Tile;
            this.infoButton.FlatAppearance.BorderSize = 1;
            this.infoButton.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.salaryButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Tile;
            this.salaryButton.FlatAppearance.BorderSize = 1;
            this.salaryButton.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.employPerform.SelectedIndex = 1;
        }

        private void button3_MouseDown(object sender, MouseEventArgs e)
        {
            this.salaryButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.salaryButton.FlatAppearance.BorderSize = 0;
            this.salaryButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.performButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Tile;
            this.performButton.FlatAppearance.BorderSize = 1;
            this.performButton.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.jobButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Tile;
            this.jobButton.FlatAppearance.BorderSize = 1;
            this.jobButton.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.infoButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Tile;
            this.infoButton.FlatAppearance.BorderSize = 1;
            this.infoButton.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.employPerform.SelectedIndex = 2;
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void employeeIdLabel3_Click(object sender, EventArgs e)
        {

        }

        private void employeePerform_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        
        

       
        
        //K-
    }
}
