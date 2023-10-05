using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq.Expressions;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Text.Json.Nodes;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        BindingList<Employee> employees;
        // private List<Employee> employees;
        private string filePath;
        private DataSet ds = new DataSet();
        int indexRow;

        public Form1()
        {
            InitializeComponent();
            filePath = "EmpData.xml";

        }

        //SUBMIT BUTTON
        private void submitBtn_Click(object sender, EventArgs e)
        {


            employees.Add(new Employee()
            {
                Id = Convert.ToInt32(idText.Text),
                DepName = depname.Text,
                Fname = fnametext.Text,
                Mname = mnametext.Text,
                Lname = lnametext.Text,
                HireDate = hdtext.Text,
                Dob = dobtext.Text,
                Gender = gendertext.Text,
                MaterialStatus = mstext.Text,
                Address = addtext.Text,
                Mobile = Convert.ToInt64(mobtext.Text),
                Email = etext.Text
            });




            XmlSerializer xs = new XmlSerializer(typeof(BindingList<Employee>));
            /*StreamReader reader = new StreamReader(filePath);
            reader.ReadToEnd();
            employees = (List<Employee>)xs.Deserialize(reader);
            reader.Close();*/

            using (StreamWriter sw = new StreamWriter(filePath))
            {
                xs.Serialize(sw, employees);
            }

            this.populateGrid();

            MessageBox.Show("Employee Details Save Suceessfully");

        }


        //COUNT BUTTON

        private void bt1_Click(object sender, EventArgs e)
        {

            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(filePath);


            XmlNodeList employeeNodes = xmlDocument.SelectNodes("//Employee");
            int employeeCount = employeeNodes.Count;

            MessageBox.Show($"Total Employees: {employeeCount}", "Employee Count");




        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {

                XmlSerializer xs = new XmlSerializer(typeof(BindingList<Employee>));
                var data = reader.ReadLine();
                employees = (BindingList<Employee>)xs.Deserialize(reader);
                this.populateGrid();
            }

        }


        //Add BUTTON
        private void bt3_Click(object sender, EventArgs e)
        {
            foreach (Control X in this.Controls)
            {
                if (X is System.Windows.Forms.TextBox)
                    X.Text = " ";

            }

        }

        //UPDATE BUTTON
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            indexRow = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[indexRow];
            idText.Text = row.Cells[0].Value.ToString();
            depname.Text = row.Cells[1].Value.ToString();
            fnametext.Text = row.Cells[2].Value.ToString();
            mnametext.Text = row.Cells[3].Value.ToString();
            lnametext.Text = row.Cells[4].Value.ToString();
            hdtext.Text = row.Cells[5].Value.ToString();
            dobtext.Text = row.Cells[6].Value.ToString();
            gendertext.Text = row.Cells[7].Value.ToString();
            mstext.Text = row.Cells[8].Value.ToString();
            addtext.Text = row.Cells[9].Value.ToString();
            mobtext.Text = row.Cells[10].Value.ToString();
            etext.Text = row.Cells[11].Value.ToString();


        }

        private void bt4_Click(object sender, EventArgs e)
        {
            DataGridViewRow newDataRow = dataGridView1.Rows[indexRow];
            newDataRow.Cells[0].Value = idText.Text;
            newDataRow.Cells[1].Value = depname.Text;
            newDataRow.Cells[2].Value = fnametext.Text;
            newDataRow.Cells[3].Value = mnametext.Text;
            newDataRow.Cells[4].Value = lnametext.Text;
            newDataRow.Cells[5].Value = hdtext.Text;
            newDataRow.Cells[6].Value = dobtext.Text;
            newDataRow.Cells[7].Value = gendertext.Text;
            newDataRow.Cells[8].Value = mstext.Text;
            newDataRow.Cells[9].Value = addtext.Text;
            newDataRow.Cells[10].Value = mobtext.Text;
            newDataRow.Cells[11].Value = etext.Text;

            save();

            MessageBox.Show("Employee Details Updated Suceessfully");

        }

        //DELETE BUTTON

        private void bt5_Click(object sender, EventArgs e)
        {
            /* if (this.dataGridView1.SelectedRows.Count > 0)
             {
                 dataGridView1.Rows.RemoveAt(this.dataGridView1.SelectedRows[0].Index);
             }
            */
            employees.RemoveAt(dataGridView1.SelectedRows[0].Index);

            save();

            MessageBox.Show("Employee Details Deleted Suceessfully");


        }


        public void populateGrid()
        {

            if (employees.Count > 0)
            {
                dataGridView1.DataSource = employees;
                dataGridView1.Update();
                dataGridView1.Refresh();


            }
        }


        public void save()
        {

            XmlSerializer xs = new XmlSerializer(typeof(BindingList<Employee>));

            using (StreamWriter sw = new StreamWriter(filePath))
            {
                xs.Serialize(sw, employees);
            }
        }







        //For uploading image in form
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(openFileDialog.FileName);
            }
        }





    }
}

