namespace PCHRFinalProject_AustinThompson
{
    partial class login_Frm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Label lOG_USERLabel;
            System.Windows.Forms.Label lOG_PASSLabel;
            this.log_But = new System.Windows.Forms.Button();
            this.cancelLog_But = new System.Windows.Forms.Button();
            this.register_But = new System.Windows.Forms.Button();
            this.lOG_USERTextBox = new System.Windows.Forms.TextBox();
            this.lOG_PASSTextBox = new System.Windows.Forms.TextBox();
            lOG_USERLabel = new System.Windows.Forms.Label();
            lOG_PASSLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lOG_USERLabel
            // 
            lOG_USERLabel.AutoSize = true;
            lOG_USERLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            lOG_USERLabel.Location = new System.Drawing.Point(12, 24);
            lOG_USERLabel.Name = "lOG_USERLabel";
            lOG_USERLabel.Size = new System.Drawing.Size(102, 24);
            lOG_USERLabel.TabIndex = 6;
            lOG_USERLabel.Text = "Username:";
            // 
            // lOG_PASSLabel
            // 
            lOG_PASSLabel.AutoSize = true;
            lOG_PASSLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            lOG_PASSLabel.Location = new System.Drawing.Point(13, 78);
            lOG_PASSLabel.Name = "lOG_PASSLabel";
            lOG_PASSLabel.Size = new System.Drawing.Size(97, 24);
            lOG_PASSLabel.TabIndex = 7;
            lOG_PASSLabel.Text = "Password:";
            // 
            // log_But
            // 
            this.log_But.Location = new System.Drawing.Point(205, 142);
            this.log_But.Name = "log_But";
            this.log_But.Size = new System.Drawing.Size(75, 23);
            this.log_But.TabIndex = 4;
            this.log_But.Text = "LOGIN";
            this.log_But.UseVisualStyleBackColor = true;
            this.log_But.Click += new System.EventHandler(this.log_But_Click);
            // 
            // cancelLog_But
            // 
            this.cancelLog_But.Location = new System.Drawing.Point(318, 142);
            this.cancelLog_But.Name = "cancelLog_But";
            this.cancelLog_But.Size = new System.Drawing.Size(75, 23);
            this.cancelLog_But.TabIndex = 5;
            this.cancelLog_But.Text = "CANCEL";
            this.cancelLog_But.UseVisualStyleBackColor = true;
            this.cancelLog_But.Click += new System.EventHandler(this.cancelLog_But_Click);
            // 
            // register_But
            // 
            this.register_But.Location = new System.Drawing.Point(205, 188);
            this.register_But.Name = "register_But";
            this.register_But.Size = new System.Drawing.Size(188, 23);
            this.register_But.TabIndex = 6;
            this.register_But.Text = "REGISTER";
            this.register_But.UseVisualStyleBackColor = true;
            this.register_But.Click += new System.EventHandler(this.register_But_Click);
            // 
            // lOG_USERTextBox
            // 
            this.lOG_USERTextBox.Location = new System.Drawing.Point(120, 29);
            this.lOG_USERTextBox.Name = "lOG_USERTextBox";
            this.lOG_USERTextBox.Size = new System.Drawing.Size(331, 20);
            this.lOG_USERTextBox.TabIndex = 7;
            // 
            // lOG_PASSTextBox
            // 
            this.lOG_PASSTextBox.Location = new System.Drawing.Point(120, 75);
            this.lOG_PASSTextBox.Name = "lOG_PASSTextBox";
            this.lOG_PASSTextBox.Size = new System.Drawing.Size(331, 20);
            this.lOG_PASSTextBox.TabIndex = 8;
            // 
            // login_Frm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 261);
            this.Controls.Add(lOG_PASSLabel);
            this.Controls.Add(this.lOG_PASSTextBox);
            this.Controls.Add(lOG_USERLabel);
            this.Controls.Add(this.lOG_USERTextBox);
            this.Controls.Add(this.register_But);
            this.Controls.Add(this.cancelLog_But);
            this.Controls.Add(this.log_But);
            this.Name = "login_Frm";
            this.Text = "Login Page";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button log_But;
        private System.Windows.Forms.Button cancelLog_But;
        private System.Windows.Forms.Button register_But;
        public System.Windows.Forms.TextBox lOG_USERTextBox;
        public System.Windows.Forms.TextBox lOG_PASSTextBox;
    }
}

