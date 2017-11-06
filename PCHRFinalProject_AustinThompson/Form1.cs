using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

//This form is used as the login form. It also is used to create and show the register form and details form
namespace PCHRFinalProject_AustinThompson
{
    public partial class login_Frm : Form
    {
        SqlConnection connection;
        string conString;
        private static string patientID; 

        public login_Frm()
        {
            InitializeComponent();
            conString = ConfigurationManager.ConnectionStrings["PCHRFinalProject_AustinThompson.Properties.Settings.pchr42563ConnectionString"].ConnectionString;
        }

        private void register_But_Click(object sender, EventArgs e)
        {
            reg_Frm regFrm = new reg_Frm();
            regFrm.Show();
        }

        private void cancelLog_But_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void log_But_Click(object sender, EventArgs e)
        {
            
            if(Validator.IsPresent(lOG_USERTextBox) && Validator.IsPresent(lOG_PASSTextBox))
            {
                GlobalID.idValue = getTblId(); //this passes the patient id to the details form so that the details page only pulls in the user's info
                pchrMain_Frm pcFrm = new pchrMain_Frm();
                pcFrm.Show();
            }
            
        }

        //This method is used get the patient id based on the username and password entered
        public string getTblId()
        {
            string getid = "SELECT PATIENT_ID FROM PATIENT_TBL WHERE LOG_USER = @LOG_USER";
            using (connection = new SqlConnection(conString))
            using(SqlCommand cmd = new SqlCommand(getid, connection))
            {
                connection.Open();
                cmd.Parameters.AddWithValue("@LOG_USER", lOG_USERTextBox.Text);
                try
                {
                    patientID = (string)cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            return patientID;
        } 
    }
}
