using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace PCHRFinalProject_AustinThompson
{
    public partial class reg_Frm : Form
    {
        SqlConnection connection;
        private string conString;


        public reg_Frm()
        {
            InitializeComponent();

            conString = ConfigurationManager.ConnectionStrings["PCHRFinalProject_AustinThompson.Properties.Settings.pchr42563ConnectionString"].ConnectionString;
        }

        private void cancelReg_But_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void registerFrm_But_Click(object sender, EventArgs e)
        {
            addPatient();
            this.Close();
        }
        //This method is the sql query used to get the info and store it in the patient tbl
        private void addPatient()
        {
            if (Validator.IsPresent(regLog_txt) && Validator.IsPresent(lOG_PASSTextBox) && Validator.IsPresent(lAST_NAMETextBox) &&
                Validator.IsPresent(fIRST_NAMETextBox) && Validator.IsPresent(aDDRESS_STREETTextBox) && Validator.IsPresent(aDDRESS_CITYTextBox) 
                && Validator.IsPresent(aDDRESS_STATETextBox) && Validator.IsPresent(aDDRESS_ZIPTextBox) && Validator.IsPresent(pHONE_HOMETextBox)
                && Validator.IsPresent(pHONE_MOBILETextBox) && Validator.IsPresent(textBox1) && Validator.IsPresent(pATIENT_IDTextBox) && lOG_PASSTextBox.Text == textBox1.Text)
            {
                string insertQ = "INSERT INTO PATIENT_TBL (LOG_USER, LOG_PASS, PATIENT_ID, LAST_NAME, FIRST_NAME, DATE_OF_BIRTH, ADDRESS_STREET, ADDRESS_CITY, ADDRESS_STATE, ADDRESS_ZIP, PHONE_HOME, PHONE_MOBILE) "
                + " VALUES(@LOG_USER, @LOG_PASS, @PATIENT_ID, @LAST_NAME, @FIRST_NAME, @DATE_OF_BIRTH, @ADDRESS_STREET, @ADDRESS_CITY, @ADDRESS_STATE, @ADDRESS_ZIP, @PHONE_HOME, @PHONE_MOBILE)";
                using (connection = new SqlConnection(conString))
                using (SqlCommand command = new SqlCommand(insertQ, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@LOG_USER", regLog_txt.Text);
                    command.Parameters.AddWithValue("@LOG_PASS", lOG_PASSTextBox.Text);
                    command.Parameters.AddWithValue("@PATIENT_ID", pATIENT_IDTextBox.Text);
                    command.Parameters.AddWithValue("@LAST_NAME", lAST_NAMETextBox.Text);
                    command.Parameters.AddWithValue("@FIRST_NAME", fIRST_NAMETextBox.Text);
                    command.Parameters.AddWithValue("@DATE_OF_BIRTH", dATE_Of_BIRTHDateTimePicker.Value);
                    command.Parameters.AddWithValue("@ADDRESS_STREET", aDDRESS_STREETTextBox.Text);
                    command.Parameters.AddWithValue("@ADDRESS_CITY", aDDRESS_CITYTextBox.Text);
                    command.Parameters.AddWithValue("@ADDRESS_STATE", aDDRESS_STATETextBox.Text);
                    command.Parameters.AddWithValue("@ADDRESS_ZIP", aDDRESS_ZIPTextBox.Text);
                    command.Parameters.AddWithValue("@PHONE_HOME", pHONE_HOMETextBox.Text);
                    command.Parameters.AddWithValue("@PHONE_MOBILE", pHONE_MOBILETextBox.Text);
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }
    }
}
