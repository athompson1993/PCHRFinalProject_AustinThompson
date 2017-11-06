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

//This form is used to add, edit, delet, and display data for each patient's personal record 
namespace PCHRFinalProject_AustinThompson
{
    public partial class pchrMain_Frm : Form
    {

        SqlConnection connection;
        string conString;

        public pchrMain_Frm()
        {
            InitializeComponent();
            conString = ConfigurationManager.ConnectionStrings["PCHRFinalProject_AustinThompson.Properties.Settings.pchr42563ConnectionString"].ConnectionString;
        }

        private void pchrMain_Frm_Load(object sender, EventArgs e)
        {
            loadFrms();
        }

        //this method is used to fill and display the data for the patient
        private void loadFrms()
        {
            string getPatient = "SELECT LOG_USER, LOG_PASS, LAST_NAME, FIRST_NAME, DATE_OF_BIRTH, ADDRESS_STREET, ADDRESS_CITY, ADDRESS_STATE, ADDRESS_ZIP, PHONE_HOME, PHONE_MOBILE, PRIMARY_ID FROM PATIENT_TBL WHERE PATIENT_ID = @PATIENT_ID";
            using (connection = new SqlConnection(conString))
            using (SqlCommand readPatient = new SqlCommand(getPatient, connection))
            {
                connection.Open();
                readPatient.Parameters.AddWithValue("@PATIENT_ID", GlobalID.idValue);
                try
                {
                    SqlDataReader sdr = readPatient.ExecuteReader();
                    while (sdr.Read())
                    {
                        lOG_USERTextBox.Text = sdr["LOG_USER"].ToString();
                        textBoxOldPass.Text = sdr["LOG_PASS"].ToString();
                        pRIMARY_IDTextBox.Text = sdr["PRIMARY_ID"].ToString();
                        lAST_NAMETextBox.Text = sdr["LAST_NAME"].ToString();
                        fIRST_NAMETextBox.Text = sdr["FIRST_NAME"].ToString();
                        dATE_Of_BIRTHDateTimePicker.Value = (DateTime)sdr["DATE_OF_BIRTH"];
                        aDDRESS_STREETTextBox.Text = sdr["ADDRESS_STREET"].ToString();
                        aDDRESS_CITYTextBox.Text = sdr["ADDRESS_CITY"].ToString();
                        aDDRESS_STATETextBox.Text = sdr["ADDRESS_STATE"].ToString();
                        aDDRESS_ZIPTextBox.Text = sdr["ADDRESS_ZIP"].ToString();
                        pHONE_HOMETextBox.Text = sdr["PHONE_HOME"].ToString();
                        pHONE_MOBILETextBox.Text = sdr["PHONE_MOBILE"].ToString();
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            string getPrimeCare = "SELECT PATIENT_TBL.PATIENT_ID, PRIMARY_CARE_TBL.NAME_LAST, PRIMARY_CARE_TBL.NAME_FISRT, PRIMARY_CARE_TBL.TITLE, PRIMARY_CARE_TBL.SPECIALTY, PRIMARY_CARE_TBL.PHONE_OFFICE, PRIMARY_CARE_TBL.PHONE_MOBILE FROM PRIMARY_CARE_TBL, PATIENT_TBL WHERE PRIMARY_CARE_TBL.PRIMARY_ID = PATIENT_TBL.PRIMARY_ID AND PATIENT_ID = @PATIENT_ID";
            using (connection = new SqlConnection(conString))
            using (SqlCommand readPrimeCare = new SqlCommand(getPrimeCare, connection))
            {
                connection.Open();
                readPrimeCare.Parameters.AddWithValue("@PATIENT_ID", GlobalID.idValue);
                try
                {
                    SqlDataReader sdr = readPrimeCare.ExecuteReader();
                    while (sdr.Read())
                    {
                        nAME_LASTTextBox.Text = sdr["NAME_LAST"].ToString();
                        nAME_FISRTTextBox.Text = sdr["NAME_FISRT"].ToString();
                        tITLETextBox.Text = sdr["TITLE"].ToString();
                        sPECIALTYTextBox.Text = sdr["SPECIALTY"].ToString();
                        pHONE_OFFICETextBox.Text = sdr["PHONE_OFFICE"].ToString();
                        pHONE_MOBILETextBox1.Text = sdr["PHONE_MOBILE"].ToString();
                    }
                }
                catch(SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            Boolean hiv;
            Boolean donor;
            string getPersDets = "SELECT BLOOD_TYPE, ORGAN_DONOR, HIV_STATUS, HEIGHT_INCHES, WEIGHT_LBS FROM PER_DETAILS_TBL WHERE PATIENT_ID = @PATIENT_ID";
            using (connection = new SqlConnection(conString))
            using (SqlCommand readPerDets = new SqlCommand(getPersDets, connection))
            {
                connection.Open();
                readPerDets.Parameters.AddWithValue("@PATIENT_ID", GlobalID.idValue);
                try
                {
                    SqlDataReader sdr = readPerDets.ExecuteReader();
                    while (sdr.Read())
                    {
                        bLOOD_TYPETextBox.Text = sdr["BLOOD_TYPE"].ToString();
                        donor = (Boolean)sdr["ORGAN_DONOR"];
                        hiv = (Boolean)sdr["HIV_STATUS"];
                        hEIGHT_INCHESTextBox.Text = sdr["HEIGHT_INCHES"].ToString();
                        wEIGHT_LBSTextBox.Text = sdr["WEIGHT_LBS"].ToString();
                        if(donor == true)
                        {
                            oRGAN_DONORCheckBox.Checked = true;
                        }
                        else
                        {
                            checkBox1.Checked = true;
                        }
                        if(hiv == true)
                        {
                            checkBox3.Checked = true;
                        }
                        else
                        {
                            checkBox2.Checked = true;
                        }
                    }
                }
                catch(SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            string getAllergy = "SELECT ALLERGEN, ONSET_DATE, NOTE FROM ALLERGY_TBL WHERE PATIENT_ID = @PATIENT_ID";
            using (connection = new SqlConnection(conString))
            using(SqlCommand readAllergy = new SqlCommand(getAllergy, connection))
            {
                connection.Open();
                readAllergy.Parameters.AddWithValue("@PATIENT_ID", GlobalID.idValue);
                try
                {
                    SqlDataReader sdr = readAllergy.ExecuteReader();
                    while (sdr.Read())
                    {
                        listBoxAllergy.Items.Add(sdr["ALLERGEN"].ToString() + " " + sdr["ONSET_DATE"].ToString() + " " + sdr["NOTE"].ToString());
                    }
                }
                catch(SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            string getImmune = "SELECT IMMUNIZATION, DATE, NOTE FROM IMMUNIZATION_TBL WHERE PATIENT_ID = @PATIENT_ID";
            using (connection = new SqlConnection(conString))
            using(SqlCommand readImmune = new SqlCommand(getImmune, connection))
            {
                connection.Open();
                readImmune.Parameters.AddWithValue("@PATIENT_ID", GlobalID.idValue);
                try
                {
                    SqlDataReader sdr = readImmune.ExecuteReader();
                    while (sdr.Read())
                    {
                        listBoxImmune.Items.Add(sdr["IMMUNIZATION"].ToString() + " " + sdr["DATE"].ToString() + " " + sdr["NOTE"].ToString());
                    }
                }
                catch(SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            string getMedication = "SELECT MEDICATION, DATE, CHRONIC, NOTE FROM MEDICATION_TBL WHERE PATIENT_ID = @PATIENT_ID";
            using (connection = new SqlConnection(conString))
            using (SqlCommand readMed = new SqlCommand(getMedication, connection))
            {
                connection.Open();
                readMed.Parameters.AddWithValue("@PATIENT_ID", GlobalID.idValue);
                try
                {
                    SqlDataReader sdr = readMed.ExecuteReader();
                    while (sdr.Read())
                    {
                        listBoxMed.Items.Add(sdr["MEDICATION"].ToString() + " " + sdr["DATE"].ToString() + " Chronic: " + sdr["CHRONIC"].ToString() + " " + sdr["NOTE"].ToString());
                    }
                }
                catch(SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            string getTest = "SELECT TEST, RESULT, DATE, NOTE FROM TEST_TBL WHERE PATIENT_ID = @PATIENT_ID";
            using (connection = new SqlConnection(conString))
            using (SqlCommand readTest = new SqlCommand(getTest, connection))
            {
                connection.Open();
                readTest.Parameters.AddWithValue("@PATIENT_ID", GlobalID.idValue);
                try
                {
                    SqlDataReader sdr = readTest.ExecuteReader();
                    while (sdr.Read())
                    {
                        listBoxTest.Items.Add(sdr["TEST"].ToString() + " " + sdr["RESULT"].ToString() + " " + sdr["DATE"].ToString() + " " + sdr["NOTE"].ToString());
                    }
                }
                catch(SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            string getCondition = "SELECT CONDITION, ONSET_DATE, ACUTE, CHRONIC, NOTE FROM CONDITION WHERE PATIENT_ID = @PATIENT_ID";
            using (connection = new SqlConnection(conString))
            using (SqlCommand readCond = new SqlCommand(getCondition, connection))
            {
                connection.Open();
                readCond.Parameters.AddWithValue("@PATIENT_ID", GlobalID.idValue);
                try
                {
                    SqlDataReader sdr = readCond.ExecuteReader();
                    while (sdr.Read())
                    {
                        listBoxCond.Items.Add(sdr["CONDITION"].ToString() + " " + sdr["ONSET_DATE"].ToString() + " Acute: " + sdr["ACTUE"].ToString() + " Chronic: " + sdr["CHRONIC"].ToString() + " " + sdr["NOTE"].ToString());
                    }
                }
                catch(SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            string getProcedure = "SELECT MED_PROCEDURE, DATE, DOCTOR, NOTE FROM MED_PROC_TBL WHERE PATIENT_ID = @PATIENT_ID";
            using (connection = new SqlConnection(conString))
            using (SqlCommand readProc = new SqlCommand(getProcedure, connection))
            {
                connection.Open();
                readProc.Parameters.AddWithValue("@PATIENT_ID", GlobalID.idValue);
                try
                {
                    SqlDataReader sdr = readProc.ExecuteReader();
                    while (sdr.Read())
                    {
                        listBoxProcedure.Items.Add(sdr["MED_PROCEDURE"].ToString() + " " + sdr["DATE"].ToString() + " " + sdr["DOCTOR"].ToString() + " " + sdr["NOTE"].ToString());
                    }
                }
                catch(SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        //Below is all the event handlers for each edit, save, cancel, and delete button/link label

        private void button1_Click(object sender, EventArgs e)
        {
            if(Validator.IsPresent(textBoxNewPass) && Validator.IsPresent(textBoxOldPass) && Validator.IsPresent(textBoxConfNewPass) && textBoxNewPass.Text == textBoxConfNewPass.Text)
            {
                string updatePass = "UPDATE PATIENT_TBL SET LOG_PASS = @LOG_PASS WHERE PATIENT_ID = @PATIENT_ID";
                using (connection = new SqlConnection(conString))
                using (SqlCommand update = new SqlCommand(updatePass, connection))
                {
                    connection.Open();
                    update.Parameters.AddWithValue("@LOG_PASS", textBoxNewPass.Text);
                    update.Parameters.AddWithValue("@PATIENT_ID", GlobalID.idValue);
                    try
                    {
                        update.ExecuteNonQuery();
                    }
                    catch(SqlException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                loadFrms();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBoxNewPass.Text = "";
            textBoxConfNewPass.Text = "";
        }

        private void editLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabelSavePersDets.Visible = true;
            linkLabelCancelPersDets.Visible = true;
            pRIMARY_IDTextBox.ReadOnly = false;
            lAST_NAMETextBox.ReadOnly = false;
            fIRST_NAMETextBox.ReadOnly = false;
        }

        private void linkLabelSavePersDets_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(Validator.IsPresent(pRIMARY_IDTextBox) && Validator.IsPresent(lAST_NAMETextBox) && Validator.IsPresent(fIRST_NAMETextBox))
            {
                string updatePatDets = "UPDATE PATIENT_TBL SET PRIMARY_ID = @PRIMARY_ID, LAST_NAME = @LAST_NAME, FIRST_NAME = @FIRST_NAME, DATE_OF_BIRTH = @DATE_OF_BIRTH WHERE PATIENT_ID = @PATIENT_ID";
                using (connection = new SqlConnection(conString))
                using (SqlCommand update = new SqlCommand(updatePatDets, connection))
                {
                    connection.Open();
                    update.Parameters.AddWithValue("@PATIENT_ID", GlobalID.idValue);
                    update.Parameters.AddWithValue("@PRIMARY_ID", pRIMARY_IDTextBox.Text);
                    update.Parameters.AddWithValue("@LAST_NAME", lAST_NAMETextBox.Text);
                    update.Parameters.AddWithValue("@FIRST_NAME", fIRST_NAMETextBox.Text);
                    update.Parameters.AddWithValue("@DATE_OF_BIRTH", dATE_Of_BIRTHDateTimePicker.Value);
                    try
                    {
                        update.ExecuteNonQuery();
                    }
                    catch(SqlException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                loadFrms();
                pRIMARY_IDTextBox.ReadOnly = true;
                lAST_NAMETextBox.ReadOnly = true;
                fIRST_NAMETextBox.ReadOnly = true;
                linkLabelCancelPersDets.Visible = false;
                linkLabelSavePersDets.Visible = false;
            }
        }

        private void linkLabelCancelPersDets_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            loadFrms();
            pRIMARY_IDTextBox.ReadOnly = true;
            lAST_NAMETextBox.ReadOnly = true;
            fIRST_NAMETextBox.ReadOnly = true;
            linkLabelCancelPersDets.Visible = false;
            linkLabelSavePersDets.Visible = false;
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            aDDRESS_STREETTextBox.ReadOnly = false;
            aDDRESS_CITYTextBox.ReadOnly = false;
            aDDRESS_STATETextBox.ReadOnly = false;
            aDDRESS_ZIPTextBox.ReadOnly = false;
            pHONE_HOMETextBox.ReadOnly = false;
            pHONE_MOBILETextBox.ReadOnly = false;
            linkLabelSaveContact.Visible = true;
            linkLabelCancelContact.Visible = true;

        }

        private void linkLabelSaveContact_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Validator.IsPresent(aDDRESS_STREETTextBox) && Validator.IsPresent(aDDRESS_CITYTextBox) && Validator.IsPresent(aDDRESS_STATETextBox) && Validator.IsPresent(aDDRESS_ZIPTextBox) && Validator.IsPresent(pHONE_HOMETextBox) && Validator.IsPresent(pHONE_MOBILETextBox))
            {
                string updateContact = "UPDATE PATIENT_TBL SET ADDRESS_STREET = @STREET, ADDRESS_CITY = @CITY, ADDRESS_STATE = @STATE, ADDRESS_ZIP = @ZIP, PHONE_HOME = @HOME, PHONE_MOBILE = @MOBILE";
                using (connection = new SqlConnection(conString))
                using (SqlCommand update = new SqlCommand(updateContact, connection))
                {
                    connection.Open();
                    update.Parameters.AddWithValue("@PATIENT_ID", GlobalID.idValue);
                    update.Parameters.AddWithValue("@STREET", aDDRESS_STREETTextBox.Text);
                    update.Parameters.AddWithValue("@CITY", aDDRESS_CITYTextBox.Text);
                    update.Parameters.AddWithValue("@STATE", aDDRESS_STATETextBox.Text);
                    update.Parameters.AddWithValue("@ZIP", aDDRESS_ZIPTextBox.Text);
                    update.Parameters.AddWithValue("@HOME", pHONE_HOMETextBox.Text);
                    update.Parameters.AddWithValue("@MOBILE", pHONE_MOBILETextBox.Text);
                    try
                    {
                        update.ExecuteNonQuery();
                    }
                    catch(SqlException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                loadFrms();
                aDDRESS_STREETTextBox.ReadOnly = true;
                aDDRESS_CITYTextBox.ReadOnly = true;
                aDDRESS_STATETextBox.ReadOnly = true;
                aDDRESS_ZIPTextBox.ReadOnly = true;
                pHONE_HOMETextBox.ReadOnly = true;
                pHONE_MOBILETextBox.ReadOnly = true;
                linkLabelCancelContact.Visible = false;
                linkLabelSaveContact.Visible = false;
            }
        }

        
        private void linkLabelCancelContact_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            loadFrms();
            aDDRESS_STREETTextBox.ReadOnly = true;
            aDDRESS_CITYTextBox.ReadOnly = true;
            aDDRESS_STATETextBox.ReadOnly = true;
            aDDRESS_ZIPTextBox.ReadOnly = true;
            pHONE_HOMETextBox.ReadOnly = true;
            pHONE_MOBILETextBox.ReadOnly = true;
            linkLabelCancelContact.Visible = false;
            linkLabelSaveContact.Visible = false;
        }

        private void linkLabel8_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabelPrimaryCareSave.Visible = true;
            linkLabelPrimaryCareCancel.Visible = true;
            nAME_FISRTTextBox.ReadOnly = false;
            nAME_LASTTextBox.ReadOnly = false;
            tITLETextBox.ReadOnly = false;
            sPECIALTYTextBox.ReadOnly = false;
            pHONE_MOBILETextBox1.ReadOnly = false;
            pHONE_OFFICETextBox.ReadOnly = false;
        }

        private void linkLabelPrimaryCareSave_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Validator.IsPresent(nAME_LASTTextBox) && Validator.IsPresent(nAME_FISRTTextBox) && Validator.IsPresent(tITLETextBox) && Validator.IsPresent(sPECIALTYTextBox) && Validator.IsPresent(pHONE_MOBILETextBox1) && Validator.IsPresent(pHONE_OFFICETextBox))
            {
                string updatePrimaryCare = "UPDATE PRIMARY_CARE_TBL, PATIENT_TBL SET PRIMARY_CARE_TBL.NAME_LAST = @LAST, PRIMARY_CARE_TBL.NAME_FISRT = @FIRST, PRIMARY_CARE_TBL.TITLE = @TITLE, PRIMARY_CARE_TBL.SPECIALTY = @SPECIALTY, PRIMARY_CARE_TBL.PHONE_OFFICE = @OFFICE, PRIMARY_CARE_TBL.PHONE_MOBILE = @MOBILE WHERE PRIMARY_CARE_TBL.PRIMARY_ID = PATIENT_TBL.PRIMARY_ID AND PATIENT_ID = @PATIENT_ID";
                using (connection = new SqlConnection(conString))
                using (SqlCommand update = new SqlCommand(updatePrimaryCare, connection))
                {
                    connection.Open();
                    update.Parameters.AddWithValue("@PATIENT_ID", GlobalID.idValue);
                    update.Parameters.AddWithValue("@PRIMARY_ID", pRIMARY_IDTextBox.Text);
                    update.Parameters.AddWithValue("@NAME_LAST", nAME_LASTTextBox.Text);
                    update.Parameters.AddWithValue("@NAME_FISRT", nAME_FISRTTextBox.Text);
                    update.Parameters.AddWithValue("@TITLE", tITLETextBox.Text);
                    update.Parameters.AddWithValue("@SPECIALTY", sPECIALTYTextBox.Text);
                    update.Parameters.AddWithValue("@PHONE_OFFICE", pHONE_OFFICETextBox.Text);
                    update.Parameters.AddWithValue("@PHONE_MOBILE", pHONE_MOBILETextBox1.Text);
                    try
                    {
                        update.ExecuteNonQuery();
                    }
                    catch(SqlException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                loadFrms();
                pRIMARY_IDTextBox.ReadOnly = true;
                nAME_LASTTextBox.ReadOnly = true;
                nAME_FISRTTextBox.ReadOnly = true;
                tITLETextBox.ReadOnly = true;
                sPECIALTYTextBox.ReadOnly = true;
                pHONE_OFFICETextBox.ReadOnly = true;
                pHONE_MOBILETextBox1.ReadOnly = true;
                linkLabelPrimaryCareCancel.Visible = false;
                linkLabelPrimaryCareSave.Visible = false;
            }
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            loadFrms();
            pRIMARY_IDTextBox.ReadOnly = true;
            nAME_LASTTextBox.ReadOnly = true;
            nAME_FISRTTextBox.ReadOnly = true;
            tITLETextBox.ReadOnly = true;
            sPECIALTYTextBox.ReadOnly = true;
            pHONE_OFFICETextBox.ReadOnly = true;
            pHONE_MOBILETextBox1.ReadOnly = true;
            linkLabelPrimaryCareCancel.Visible = false;
            linkLabelPrimaryCareSave.Visible = false;
        }

        private void linkLabel11_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            bLOOD_TYPETextBox.ReadOnly = false;
            hEIGHT_INCHESTextBox.ReadOnly = false;
            wEIGHT_LBSTextBox.ReadOnly = false;
            linkLabelCancelPerMedDets.Visible = true;
            linkLabelSaveMedDets.Visible = true;
        }

        private void linkLabelCancelPerMedDets_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            loadFrms();
            bLOOD_TYPETextBox.ReadOnly = true;
            hEIGHT_INCHESTextBox.ReadOnly = true;
            wEIGHT_LBSTextBox.ReadOnly = true;
            linkLabelCancelPerMedDets.Visible = false;
            linkLabelSaveMedDets.Visible = false;
        }

        private void linkLabelSaveMedDets_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(Validator.IsPresent(bLOOD_TYPETextBox) && Validator.IsPresent(hEIGHT_INCHESTextBox) && Validator.IsPresent(wEIGHT_LBSTextBox))
            {
                bool organ;
                bool hiv;
                if (oRGAN_DONORCheckBox.Checked == true)
                {
                    organ = true;
                }
                else
                {
                    organ = false;
                }
                if (checkBox3.Checked == true)
                {
                    hiv = true;
                }
                else
                {
                    hiv = false;
                }
                string updateMedDets = "UPDATE PER_DETAILS_TBL SET BLOOD_TYPE = @BLOOD, ORGAN_DONOR = @DONOR, HIV_STATUS = @HIV, HEIGHT_INCHES = @HEIGHT, WEIGHT_LBS = @WEIGHT WHERE PATIENT_ID = @PATIENT_ID";
                using (connection = new SqlConnection(conString))
                using (SqlCommand update = new SqlCommand(updateMedDets, connection))
                {
                    connection.Open();
                    update.Parameters.AddWithValue("@PATIENT_ID", GlobalID.idValue);
                    update.Parameters.AddWithValue("@BLOOD", bLOOD_TYPETextBox.Text);
                    update.Parameters.AddWithValue("@DONOR", organ);
                    update.Parameters.AddWithValue("@HIV", hiv);
                    update.Parameters.AddWithValue("@HEIGHT", hEIGHT_INCHESTextBox.Text);
                    update.Parameters.AddWithValue("WEIGHT", wEIGHT_LBSTextBox.Text);
                    try
                    {
                        update.ExecuteNonQuery();
                    }
                    catch(SqlException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                loadFrms();
                bLOOD_TYPETextBox.ReadOnly = true;
                hEIGHT_INCHESTextBox.ReadOnly = true;
                wEIGHT_LBSTextBox.ReadOnly = true;
                linkLabelCancelPerMedDets.Visible = false;
                linkLabelSaveMedDets.Visible = false;
            }
        }

        private void linkLabel14_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Validator.IsPresent(aLLERGENTextBox))
            {
                string getAllergy = "UPDATE ALLERGY_TBL SET ALLERGEN = @ALLERGEN, ONSET_DATE = @DATE, NOTE = @NOTE WHERE PATIENT_ID = @PATIENT_ID AND ALLERGY_ID = @ALLERGY_ID";
                using (connection = new SqlConnection(conString))
                using (SqlCommand updateAllergy = new SqlCommand(getAllergy, connection))
                {
                    connection.Open();
                    updateAllergy.Parameters.AddWithValue("@PATIENT_ID", GlobalID.idValue);
                    updateAllergy.Parameters.AddWithValue("@ALLERGY_ID", (listBoxAllergy.SelectedIndex + 1).ToString());
                    updateAllergy.Parameters.AddWithValue("@ALLERGEN", aLLERGENTextBox.Text);
                    updateAllergy.Parameters.AddWithValue("@DATE", oNSET_DATEDateTimePicker.Value);
                    updateAllergy.Parameters.AddWithValue("@NOTE", nOTERichTextBox.Text);
                    try
                    {
                        updateAllergy.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                listBoxAllergy.Items.Clear();
                loadFrms();
            }
        }

        private void linkLabelSaveAllergy_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Validator.IsPresent(aLLERGENTextBox))
            {
                string addAllergy = "INSERT INTO ALLERGY_TBL (PATIENT_ID, ALLERGY_ID, ALLERGEN, ONSET_DATE, NOTE) VALUES(@PATIENT_ID, @ALLERGY_ID, @ALLERGEN, @ONSET_DATE, @NOTE)";
                using (connection = new SqlConnection(conString))
                using (SqlCommand addAllergen = new SqlCommand(addAllergy, connection))
                {
                    connection.Open();
                    addAllergen.Parameters.AddWithValue("@PATIENT_ID", GlobalID.idValue);
                    addAllergen.Parameters.AddWithValue("@ALLERGY_ID", (listBoxAllergy.Items.Count + 1)).ToString();
                    addAllergen.Parameters.AddWithValue("@ALLERGEN", aLLERGENTextBox.Text);
                    addAllergen.Parameters.AddWithValue("@ONSET_DATE", oNSET_DATEDateTimePicker.Value);
                    addAllergen.Parameters.AddWithValue("@NOTE", nOTERichTextBox.Text);
                    try
                    {
                        addAllergen.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                listBoxAllergy.Items.Clear();
                loadFrms();
            }
        }

        private void linkLabel30_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string deleteAllergy = "DELETE FROM ALLERGY_TBL WHERE PATIENT_ID = @PATIENT_ID AND ALLERGY_ID = @ALLERGY_ID";
            using (connection = new SqlConnection(conString))
            using (SqlCommand deleteAllergen = new SqlCommand(deleteAllergy, connection))
            {
                connection.Open();
                deleteAllergen.Parameters.AddWithValue("@PATIENT_ID", GlobalID.idValue);
                deleteAllergen.Parameters.AddWithValue("@ALLERGY_ID", (listBoxAllergy.SelectedIndex + 1).ToString());
                try
                {
                    deleteAllergen.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            listBoxAllergy.Items.Clear();
            loadFrms();
        }

        private void linkLabelCancelAllergy_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            aLLERGENTextBox.Text = "";
            nOTERichTextBox.Text = "";
        }

        private void linkLabelEditImmune_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Validator.IsPresent(iMMUNIZATIONTextBox))
            {
                string getImmunity = "UPDATE IMMUNIZATION_TBL SET IMMUNIZATION = @IMMUNIZATION, DATE = @DATE, NOTE = @NOTE WHERE PATIENT_ID = @PATIENT_ID AND IMMUNIZATION_ID = @IMMUNIZATION_ID";
                using (connection = new SqlConnection(conString))
                using (SqlCommand updateAllergy = new SqlCommand(getImmunity, connection))
                {
                    connection.Open();
                    updateAllergy.Parameters.AddWithValue("@PATIENT_ID", GlobalID.idValue);
                    updateAllergy.Parameters.AddWithValue("@IMMUNIZATION_ID", (listBoxImmune.SelectedIndex + 1).ToString());
                    updateAllergy.Parameters.AddWithValue("@IMMUNIZATION", iMMUNIZATIONTextBox.Text);
                    updateAllergy.Parameters.AddWithValue("@DATE", dATEDateTimePicker.Value);
                    updateAllergy.Parameters.AddWithValue("@NOTE", nOTERichTextBox1.Text);
                    try
                    {
                        updateAllergy.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                listBoxImmune.Items.Clear();
                loadFrms();
            }
        }

        private void linkLabelSaveImmune_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Validator.IsPresent(iMMUNIZATIONTextBox))
            {
                string addImmunization = "INSERT INTO IMMUNIZATION_TBL (PATIENT_ID, IMMUNIZATION_ID, IMMUNIZATION, DATE, NOTE) VALUES(@PATIENT_ID, @IMMUNIZATION_ID, @IMMUNIZATION, @DATE, @NOTE)";
                using (connection = new SqlConnection(conString))
                using (SqlCommand addAllergen = new SqlCommand(addImmunization, connection))
                {
                    connection.Open();
                    addAllergen.Parameters.AddWithValue("@PATIENT_ID", GlobalID.idValue);
                    addAllergen.Parameters.AddWithValue("@IMMUNIZATION_ID", (listBoxImmune.Items.Count + 1)).ToString();
                    addAllergen.Parameters.AddWithValue("@IMMUNIZATION", iMMUNIZATIONTextBox.Text);
                    addAllergen.Parameters.AddWithValue("@DATE", dATEDateTimePicker.Value);
                    addAllergen.Parameters.AddWithValue("@NOTE", nOTERichTextBox1.Text);
                    try
                    {
                        addAllergen.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                listBoxImmune.Items.Clear();
                loadFrms();
            }
        }

        private void linkLabelCancelImmune_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            iMMUNIZATIONTextBox.Text = "";
            nOTERichTextBox1.Text = "";
        }

        private void linkLabelRemoveImmune_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string deleteImmunization = "DELETE FROM IMMUNIZATION_TBL WHERE PATIENT_ID = @PATIENT_ID AND IMMUNIZATION_ID = @IMMUNIZATION_ID";
            using (connection = new SqlConnection(conString))
            using (SqlCommand deleteAllergen = new SqlCommand(deleteImmunization, connection))
            {
                connection.Open();
                deleteAllergen.Parameters.AddWithValue("@PATIENT_ID", GlobalID.idValue);
                deleteAllergen.Parameters.AddWithValue("@IMMUNIZATION_ID", (listBoxImmune.SelectedIndex + 1).ToString());
                try
                {
                    deleteAllergen.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            listBoxImmune.Items.Clear();
            loadFrms();
        }

        private void linkLabelMedEdit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Validator.IsPresent(mEDICATIONTextBox))
            {
                bool chronic;
                if (cHRONICCheckBox.Checked == true)
                {
                    chronic = true;
                }
                else
                {
                    chronic = false;
                }
                string getMeds = "UPDATE MEDICATION_TBL SET MEDICATION = @MEDICATION, DATE = @DATE, CHRONIC = @CHRONIC, NOTE = @NOTE WHERE PATIENT_ID = @PATIENT_ID AND MED_ID = @MED_ID";
                using (connection = new SqlConnection(conString))
                using (SqlCommand updateAllergy = new SqlCommand(getMeds, connection))
                {
                    connection.Open();
                    updateAllergy.Parameters.AddWithValue("@PATIENT_ID", GlobalID.idValue);
                    updateAllergy.Parameters.AddWithValue("@MED_ID", (listBoxMed.SelectedIndex + 1).ToString());
                    updateAllergy.Parameters.AddWithValue("@MEDICATION", mEDICATIONTextBox.Text);
                    updateAllergy.Parameters.AddWithValue("@DATE", dATEDateTimePicker1.Value);
                    updateAllergy.Parameters.AddWithValue("@NOTE", nOTETextBox.Text);
                    updateAllergy.Parameters.AddWithValue("@CHRONIC", chronic);
                    try
                    {
                        updateAllergy.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                listBoxMed.Items.Clear();
                loadFrms();
            }
        }

        private void linkLabeMedSave_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Validator.IsPresent(mEDICATIONTextBox))
            {
                bool chronic;
                if (cHRONICCheckBox.Checked == true)
                {
                    chronic = true;
                }
                else
                {
                    chronic = false;
                }
                string addMed = "INSERT INTO MEDICATION_TBL (PATIENT_ID, MED_ID, MEDICATION, DATE, CHRONIC, NOTE) VALUES(@PATIENT_ID, @MED_ID, @MEDICATION, @DATE, @CHRONIC, @NOTE)";
                using (connection = new SqlConnection(conString))
                using (SqlCommand addAllergen = new SqlCommand(addMed, connection))
                {
                    connection.Open();
                    addAllergen.Parameters.AddWithValue("@PATIENT_ID", GlobalID.idValue);
                    addAllergen.Parameters.AddWithValue("@MED_ID", (listBoxMed.Items.Count + 1)).ToString();
                    addAllergen.Parameters.AddWithValue("@MEDICATION", mEDICATIONTextBox.Text);
                    addAllergen.Parameters.AddWithValue("@DATE", dATEDateTimePicker1.Value);
                    addAllergen.Parameters.AddWithValue("@NOTE", nOTETextBox.Text);
                    addAllergen.Parameters.AddWithValue("@CHRONIC", chronic);
                    try
                    {
                        addAllergen.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                listBoxMed.Items.Clear();
                loadFrms();
            }
        }

        private void linkLabelRemoveMed_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string deleteMed = "DELETE FROM MEDICATION_TBL WHERE PATIENT_ID = @PATIENT_ID AND MED_ID = @MED_ID";
            using (connection = new SqlConnection(conString))
            using (SqlCommand deleteAllergen = new SqlCommand(deleteMed, connection))
            {
                connection.Open();
                deleteAllergen.Parameters.AddWithValue("@PATIENT_ID", GlobalID.idValue);
                deleteAllergen.Parameters.AddWithValue("@MED_ID", (listBoxMed.SelectedIndex + 1).ToString());
                try
                {
                    deleteAllergen.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            listBoxMed.Items.Clear();
            loadFrms();
        }

        private void linkLabelCancelMed_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            mEDICATIONTextBox.Text = "";
            cHRONICCheckBox.Checked = false;
            nOTETextBox.Text = "";
        }

        private void linkLabeEditTest_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(Validator.IsPresent(tESTTextBox) && Validator.IsPresent(rESULTTextBox))
            {
                string getTest = "UPDATE TEST_TBL SET TEST = @TEST, DATE = @DATE, NOTE = @NOTE, RESULT = @RESULT WHERE PATIENT_ID = @PATIENT_ID AND TEST_ID = @TEST_ID";
                using (connection = new SqlConnection(conString))
                using (SqlCommand updateAllergy = new SqlCommand(getTest, connection))
                {
                    connection.Open();
                    updateAllergy.Parameters.AddWithValue("@PATIENT_ID", GlobalID.idValue);
                    updateAllergy.Parameters.AddWithValue("@TEST_ID", (listBoxTest.SelectedIndex + 1).ToString());
                    updateAllergy.Parameters.AddWithValue("@TEST", tESTTextBox.Text);
                    updateAllergy.Parameters.AddWithValue("@DATE", dATEDateTimePicker2.Value);
                    updateAllergy.Parameters.AddWithValue("@NOTE", nOTETextBox1.Text);
                    updateAllergy.Parameters.AddWithValue("@RESULT", rESULTTextBox.Text);
                    try
                    {
                        updateAllergy.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                listBoxTest.Items.Clear();
                loadFrms();
            }
        }

        private void linkLabelSaveTest_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(Validator.IsPresent(tESTTextBox) && Validator.IsPresent(rESULTTextBox))
            {
                string addTest = "INSERT INTO TEST_TBL (PATIENT_ID, TEST_ID, TEST, RESULT, DATE, NOTE) VALUES(@PATIENT_ID, @TEST_ID, @TEST, @RESULT, @DATE, @NOTE)";
                using (connection = new SqlConnection(conString))
                using (SqlCommand addAllergen = new SqlCommand(addTest, connection))
                {
                    connection.Open();
                    addAllergen.Parameters.AddWithValue("@PATIENT_ID", GlobalID.idValue);
                    addAllergen.Parameters.AddWithValue("@TEST_ID", (listBoxTest.Items.Count + 1)).ToString();
                    addAllergen.Parameters.AddWithValue("@TEST", tESTTextBox.Text);
                    addAllergen.Parameters.AddWithValue("@DATE", dATEDateTimePicker2.Value);
                    addAllergen.Parameters.AddWithValue("@NOTE", nOTETextBox1.Text);
                    addAllergen.Parameters.AddWithValue("@RESULT", rESULTTextBox.Text);
                    try
                    {
                        addAllergen.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                listBoxTest.Items.Clear();
                loadFrms();
            }
        }

        private void linkLabelCancelTest_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tESTTextBox.Text = "";
            rESULTTextBox.Text = "";
            nOTETextBox1.Text = "";
        }

        private void linkLabelRemoveTest_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string deleteTest = "DELETE FROM TEST_TBL WHERE PATIENT_ID = @PATIENT_ID AND TEST_ID = @TEST_ID";
            using (connection = new SqlConnection(conString))
            using (SqlCommand deleteAllergen = new SqlCommand(deleteTest, connection))
            {
                connection.Open();
                deleteAllergen.Parameters.AddWithValue("@PATIENT_ID", GlobalID.idValue);
                deleteAllergen.Parameters.AddWithValue("@TEST_ID", (listBoxTest.SelectedIndex + 1).ToString());
                try
                {
                    deleteAllergen.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            listBoxTest.Items.Clear();
            loadFrms();
        }

        private void linkLabelEditCondition_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Validator.IsPresent(cONDITIONTextBox))
            {
                bool chronic;
                bool acute;
                if (cHRONICCheckBox.Checked == true)
                {
                    chronic = true;
                }
                else
                {
                    chronic = false;
                }
                if (aCUTECheckBox.Checked == true)
                {
                    acute = true;
                }
                else
                {
                    acute = false;
                }
                string getCond = "UPDATE CONDITION SET CONDITION = @CONDITION, ONSET_DATE = @DATE, ACUTE = @ACUTE, CHRONIC = @CHRONIC, NOTE = @NOTE WHERE PATIENT_ID = @PATIENT_ID AND CONDITION_ID = @CONDITION_ID";
                using (connection = new SqlConnection(conString))
                using (SqlCommand updateAllergy = new SqlCommand(getCond, connection))
                {
                    connection.Open();
                    updateAllergy.Parameters.AddWithValue("@PATIENT_ID", GlobalID.idValue);
                    updateAllergy.Parameters.AddWithValue("@CONDITION_ID", (listBoxCond.SelectedIndex + 1).ToString());
                    updateAllergy.Parameters.AddWithValue("@CONDITION", cONDITIONTextBox.Text);
                    updateAllergy.Parameters.AddWithValue("@DATE", oNSET_DATEDateTimePicker1.Value);
                    updateAllergy.Parameters.AddWithValue("@NOTE", nOTETextBox2.Text);
                    updateAllergy.Parameters.AddWithValue("@CHRONIC", chronic);
                    updateAllergy.Parameters.AddWithValue("@ACUTE", acute);
                    try
                    {
                        updateAllergy.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                listBoxCond.Items.Clear();
                loadFrms();
            }
        }

        private void linkLabelSaveCondition_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Validator.IsPresent(cONDITIONTextBox))
            {
                bool chronic;
                bool acute;
                if (cHRONICCheckBox.Checked == true)
                {
                    chronic = true;
                }
                else
                {
                    chronic = false;
                }
                if (aCUTECheckBox.Checked == true)
                {
                    acute = true;
                }
                else
                {
                    acute = false;
                }
                string addCond = "INSERT INTO CONDITION (PATIENT_ID, CONDITION_ID, CONDITION, ONSET_DATE, ACUTE, CHRONIC, NOTE) VALUES(@PATIENT_ID, @CONDITION_ID, @CONDITION, @DATE, @ACUTE, @CHRONIC, @NOTE)";
                using (connection = new SqlConnection(conString))
                using (SqlCommand addAllergen = new SqlCommand(addCond, connection))
                {
                    connection.Open();
                    addAllergen.Parameters.AddWithValue("@PATIENT_ID", GlobalID.idValue);
                    addAllergen.Parameters.AddWithValue("@CONDITION_ID", (listBoxCond.SelectedIndex + 1).ToString());
                    addAllergen.Parameters.AddWithValue("@CONDITION", cONDITIONTextBox.Text);
                    addAllergen.Parameters.AddWithValue("@DATE", oNSET_DATEDateTimePicker1.Value);
                    addAllergen.Parameters.AddWithValue("@NOTE", nOTETextBox2.Text);
                    addAllergen.Parameters.AddWithValue("@CHRONIC", chronic);
                    addAllergen.Parameters.AddWithValue("@ACUTE", acute);
                    try
                    {
                        addAllergen.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                listBoxCond.Items.Clear();
                loadFrms();
            }
        }

        private void linkLabelCancelCondition_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            cONDITIONTextBox.Text = "";
            cHRONICCheckBox1.Checked = false;
            aCUTECheckBox.Checked = false;
            nOTETextBox2.Text = "";
        }

        private void linkLabelRemoveCondition_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string deleteCond = "DELETE FROM CONDITION WHERE PATIENT_ID = @PATIENT_ID AND CONDITION_ID = @CONDITION_ID";
            using (connection = new SqlConnection(conString))
            using (SqlCommand deleteAllergen = new SqlCommand(deleteCond, connection))
            {
                connection.Open();
                deleteAllergen.Parameters.AddWithValue("@PATIENT_ID", GlobalID.idValue);
                deleteAllergen.Parameters.AddWithValue("@CONDITION_ID", (listBoxCond.SelectedIndex + 1).ToString());
                try
                {
                    deleteAllergen.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            listBoxCond.Items.Clear();
            loadFrms();
        }

        private void linkLabelEditProcedure_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(Validator.IsPresent(mED_PROCEDURETextBox) && Validator.IsPresent(dOCTORTextBox))
            {
                string getProc = "UPDATE MED_PROC_TBL SET MED_PROCEDURE = @PROCEDURE, DATE = @DATE, DOCTOR = @DOCTOR, NOTE = @NOTE WHERE PATIENT_ID = @PATIENT_ID AND PROCEDURE_ID = @PROCEDURE_ID";
                using (connection = new SqlConnection(conString))
                using (SqlCommand updateAllergy = new SqlCommand(getProc, connection))
                {
                    connection.Open();
                    updateAllergy.Parameters.AddWithValue("@PATIENT_ID", GlobalID.idValue);
                    updateAllergy.Parameters.AddWithValue("@PROCEDURE_ID", (listBoxProcedure.SelectedIndex + 1).ToString());
                    updateAllergy.Parameters.AddWithValue("@PROCEDURE", mED_PROCEDURETextBox.Text);
                    updateAllergy.Parameters.AddWithValue("@DATE", dATEDateTimePicker3.Value);
                    updateAllergy.Parameters.AddWithValue("@NOTE", nOTETextBox3.Text);
                    updateAllergy.Parameters.AddWithValue("@DOCTOR", dOCTORTextBox.Text);
                    try
                    {
                        updateAllergy.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                listBoxProcedure.Items.Clear();
                loadFrms();
            }
        }

        private void linkLabelSaveProcedure_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Validator.IsPresent(mED_PROCEDURETextBox) && Validator.IsPresent(dOCTORTextBox))
            {
                string addProc = "INSERT INTO MED_PROC_TBL (PATIENT_ID, PROCEDURE_ID, MED_PROCEDURE, DATE, DOCTOR, NOTE) VALUES(@PATIENT_ID, @PROCEDURE_ID, @PROCEDURE, @DATE, @DOCTOR, @NOTE)";
                using (connection = new SqlConnection(conString))
                using (SqlCommand addAllergen = new SqlCommand(addProc, connection))
                {
                    connection.Open();
                    addAllergen.Parameters.AddWithValue("@PATIENT_ID", GlobalID.idValue);
                    addAllergen.Parameters.AddWithValue("@PROCEDURE_ID", (listBoxProcedure.SelectedIndex + 1).ToString());
                    addAllergen.Parameters.AddWithValue("@PROCEDURE", mED_PROCEDURETextBox.Text);
                    addAllergen.Parameters.AddWithValue("@DATE", dATEDateTimePicker3.Value);
                    addAllergen.Parameters.AddWithValue("@NOTE", nOTETextBox3.Text);
                    addAllergen.Parameters.AddWithValue("@DOCTOR", dOCTORTextBox.Text);
                    try
                    {
                        addAllergen.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                listBoxProcedure.Items.Clear();
                loadFrms();
            }
        }

        private void linkLabel27_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            mED_PROCEDURETextBox.Text = "";
            dOCTORTextBox.Text = "";
            nOTETextBox3.Text = "";
        }

        private void linkLabelRemoveProcedure_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string deleteProc = "DELETE FROM MED_PROC_TBL WHERE PATIENT_ID = @PATIENT_ID AND PROCEDURE_ID = @PROCEDURE_ID";
            using (connection = new SqlConnection(conString))
            using (SqlCommand deleteAllergen = new SqlCommand(deleteProc, connection))
            {
                connection.Open();
                deleteAllergen.Parameters.AddWithValue("@PATIENT_ID", GlobalID.idValue);
                deleteAllergen.Parameters.AddWithValue("@PROCEDURE_ID", (listBoxProcedure.SelectedIndex + 1).ToString());
                try
                {
                    deleteAllergen.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            listBoxCond.Items.Clear();
            loadFrms();
        }
    }
}
