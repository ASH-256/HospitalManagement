using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HospitalManagement
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

     

        private void Dashboard_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
        }

       
        private void btnNewPatient_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = false;
            panel3.Visible = false;
            btnNewPatient.BackColor = Color.LightBlue;
            btnDiagnosisInformation.BackColor = Color.LightGreen;
            btnHistory.BackColor = Color.LightGreen;
            btnHospitalInformation.BackColor = Color.LightGreen;
        }

        private void btnDiagnosisInformation_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel3.Visible = false;
            panel2.Visible = true;
            btnDiagnosisInformation.BackColor = Color.LightBlue;
            btnNewPatient.BackColor = Color.LightGreen;
            btnHistory.BackColor = Color.LightGreen;
            btnHospitalInformation.BackColor = Color.LightGreen;
        
    }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = true;
            btnHistory.BackColor = Color.LightBlue;
            btnNewPatient.BackColor = Color.LightGreen;
            btnDiagnosisInformation.BackColor = Color.LightGreen;
            btnHospitalInformation.BackColor = Color.LightGreen;
            string command = "select P_ID, PatientsDiagnosisInformation.S_ID, PatientName,Age,BloodGroup, MajorDisease, Symptoms, Diagnosis, Medicines, Ward, WardType from PatientsRecords INNER JOIN  PatientsDiagnosisInformation on PatientsRecords.S_ID = PatientsDiagnosisInformation.S_ID";

            SqlConnection con = new SqlConnection();

            con.ConnectionString = "server  = localhost; database  = HospitalRecords; integrated security = True";

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = command;

            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataSet DS = new DataSet();
            DA.Fill(DS);
            dataGridView2.DataSource = DS.Tables[0];

        }

        private void btnHospitalInformation_Click(object sender, EventArgs e)
        {
            btnHospitalInformation.BackColor = Color.LightBlue;
            btnHistory.BackColor = Color.LightGreen;
            btnNewPatient.BackColor = Color.LightGreen;
            btnDiagnosisInformation.BackColor = Color.LightGreen;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtName.Text;
                string address = txtAddress.Text;
                Int64 contact = Convert.ToInt64(txtContactNumber.Text);
                int age = Convert.ToInt32(txtAge.Text);
                string blood = txtBlood.Text;
                string gender = comboGender.Text;
                string previous = txtPreviousIllness.Text;
                int p_id = Convert.ToInt32(txtPatientID.Text);

                SqlConnection sql = new SqlConnection();
                sql.ConnectionString = "server  = localhost; database  = HospitalRecords; integrated security = True";

                SqlCommand cmd = new SqlCommand();

                cmd.Connection = sql;

                cmd.CommandText = "insert into PatientsRecords values ('" + name + "','" + address + "'," + contact + "," + age + ",'" + gender + "','" + blood + "','" + previous + "', " + p_id + ")";

                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataSet DS = new DataSet();
                DA.Fill(DS);
                MessageBox.Show("Data is Saved");
            }
            catch(Exception) {

                Console.WriteLine("SQL Connection Might Be Incorrect");
                MessageBox.Show("Invalid Data or Non Unique Patient ID ");


            }
            
            ClearTexts();
            


        }
        private  void ClearTexts() {
            txtName.Clear();
            txtAddress.Clear();
            txtContactNumber.Clear();
            txtAge.Clear();
            txtBlood.Clear();
            comboGender.ResetText();
            txtPreviousIllness.Clear();
            txtPatientID.Clear();
        }

        
       

        private void txtSearchPID_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchPID.Text != "")
            {
                int pid = Convert.ToInt32(txtSearchPID.Text);

                SqlConnection con = new SqlConnection();

                con.ConnectionString = "server  = localhost; database  = HospitalRecords; integrated security = True";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "Select * from PatientsRecords where S_ID = " + pid + "";

                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataSet DS = new DataSet();
                DA.Fill(DS);
                dataGridView1.DataSource = DS.Tables[0];

            }
            
        }

        private void btnSave1_Click(object sender, EventArgs e)
        {
            int pid = Convert.ToInt32(txtSearchPID.Text);
            string symptoms = txtSymptoms.Text;
            string diagnosis = txtDiagnosis.Text;
            string medicines = txtMedicines.Text;
            string ward = comboWard.Text;
            string wardType = comboWardType.Text;

            try
            {
                SqlConnection sql = new SqlConnection();
                sql.ConnectionString = "server  = localhost; database  = HospitalRecords; integrated security = True";

                SqlCommand cmd = new SqlCommand();

                cmd.Connection = sql;

                cmd.CommandText = "insert into PatientsDiagnosisInformation values (" + pid + ",'" + symptoms + "','" + diagnosis + "','" + medicines + "','" + ward + "', '" + wardType + "')";
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataSet DS = new DataSet();
                DA.Fill(DS);
                MessageBox.Show("Data is Saved");
            }
            catch (Exception) {

                Console.WriteLine("SQL Connection Might Be Incorrect");
                MessageBox.Show("Invalid Data or Non Unique Patient ID ");

            }
            ClearDiagnosisTexts();

        }
        private void ClearDiagnosisTexts() {

            txtSymptoms.Clear();
            txtDiagnosis.Clear();
            txtMedicines.Clear();
            comboWard.ResetText();
            comboWardType.ResetText();





        }

       

       
    }
}
