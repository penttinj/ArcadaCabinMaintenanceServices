namespace CabinServicesApp
{
    partial class CabinServicesForm
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
            this.EmailSubmitButton = new System.Windows.Forms.Button();
            this.EmailTextBox = new System.Windows.Forms.TextBox();
            this.WelcomeLabel = new System.Windows.Forms.Label();
            this.WelcomePanel = new System.Windows.Forms.Panel();
            this.LoggedInPanel = new System.Windows.Forms.Panel();
            this.ModifyProgress = new System.Windows.Forms.ProgressBar();
            this.FailModifyLabel = new System.Windows.Forms.Label();
            this.ModifyButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.ModifyDate = new System.Windows.Forms.DateTimePicker();
            this.CabinsCombo = new System.Windows.Forms.ComboBox();
            this.ServicesCombo = new System.Windows.Forms.ComboBox();
            this.FailSaveLabel = new System.Windows.Forms.Label();
            this.SaveProgress = new System.Windows.Forms.ProgressBar();
            this.ChosenServiceInfo = new System.Windows.Forms.Label();
            this.ChosenCabinInfo = new System.Windows.Forms.Label();
            this.ReservationsList = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.ServicesList = new System.Windows.Forms.ListBox();
            this.CabinsList = new System.Windows.Forms.ListBox();
            this.NoReservationLabel = new System.Windows.Forms.Label();
            this.WelcomePanel.SuspendLayout();
            this.LoggedInPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // EmailSubmitButton
            // 
            this.EmailSubmitButton.Location = new System.Drawing.Point(93, 67);
            this.EmailSubmitButton.Name = "EmailSubmitButton";
            this.EmailSubmitButton.Size = new System.Drawing.Size(75, 23);
            this.EmailSubmitButton.TabIndex = 1;
            this.EmailSubmitButton.Text = "Submit";
            this.EmailSubmitButton.UseVisualStyleBackColor = true;
            this.EmailSubmitButton.Click += new System.EventHandler(this.EmailSubmitButton_Click);
            // 
            // EmailTextBox
            // 
            this.EmailTextBox.Location = new System.Drawing.Point(93, 41);
            this.EmailTextBox.Name = "EmailTextBox";
            this.EmailTextBox.Size = new System.Drawing.Size(100, 20);
            this.EmailTextBox.TabIndex = 2;
            this.EmailTextBox.Text = "foo@bar.com";
            this.EmailTextBox.TextChanged += new System.EventHandler(this.EmailTextBox_TextChanged);
            // 
            // WelcomeLabel
            // 
            this.WelcomeLabel.AutoSize = true;
            this.WelcomeLabel.Location = new System.Drawing.Point(3, 2);
            this.WelcomeLabel.Name = "WelcomeLabel";
            this.WelcomeLabel.Size = new System.Drawing.Size(243, 26);
            this.WelcomeLabel.TabIndex = 3;
            this.WelcomeLabel.Text = "Please enter your email to find the cabins you own\r\non arcada-cabin-broker!";
            this.WelcomeLabel.Click += new System.EventHandler(this.WelcomeLabel_Click);
            // 
            // WelcomePanel
            // 
            this.WelcomePanel.Controls.Add(this.EmailSubmitButton);
            this.WelcomePanel.Controls.Add(this.WelcomeLabel);
            this.WelcomePanel.Controls.Add(this.EmailTextBox);
            this.WelcomePanel.Location = new System.Drawing.Point(238, 152);
            this.WelcomePanel.Name = "WelcomePanel";
            this.WelcomePanel.Size = new System.Drawing.Size(270, 138);
            this.WelcomePanel.TabIndex = 4;
            this.WelcomePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.WelcomePanel_Paint);
            // 
            // LoggedInPanel
            // 
            this.LoggedInPanel.Controls.Add(this.NoReservationLabel);
            this.LoggedInPanel.Controls.Add(this.ModifyProgress);
            this.LoggedInPanel.Controls.Add(this.FailModifyLabel);
            this.LoggedInPanel.Controls.Add(this.ModifyButton);
            this.LoggedInPanel.Controls.Add(this.DeleteButton);
            this.LoggedInPanel.Controls.Add(this.ModifyDate);
            this.LoggedInPanel.Controls.Add(this.CabinsCombo);
            this.LoggedInPanel.Controls.Add(this.ServicesCombo);
            this.LoggedInPanel.Controls.Add(this.FailSaveLabel);
            this.LoggedInPanel.Controls.Add(this.SaveProgress);
            this.LoggedInPanel.Controls.Add(this.ChosenServiceInfo);
            this.LoggedInPanel.Controls.Add(this.ChosenCabinInfo);
            this.LoggedInPanel.Controls.Add(this.ReservationsList);
            this.LoggedInPanel.Controls.Add(this.button1);
            this.LoggedInPanel.Controls.Add(this.dateTimePicker1);
            this.LoggedInPanel.Controls.Add(this.ServicesList);
            this.LoggedInPanel.Controls.Add(this.CabinsList);
            this.LoggedInPanel.Location = new System.Drawing.Point(35, 12);
            this.LoggedInPanel.Name = "LoggedInPanel";
            this.LoggedInPanel.Size = new System.Drawing.Size(773, 475);
            this.LoggedInPanel.TabIndex = 5;
            this.LoggedInPanel.Visible = false;
            // 
            // ModifyProgress
            // 
            this.ModifyProgress.Location = new System.Drawing.Point(580, 351);
            this.ModifyProgress.Name = "ModifyProgress";
            this.ModifyProgress.Size = new System.Drawing.Size(100, 23);
            this.ModifyProgress.TabIndex = 16;
            this.ModifyProgress.Visible = false;
            // 
            // FailModifyLabel
            // 
            this.FailModifyLabel.AutoSize = true;
            this.FailModifyLabel.ForeColor = System.Drawing.Color.Red;
            this.FailModifyLabel.Location = new System.Drawing.Point(565, 377);
            this.FailModifyLabel.Name = "FailModifyLabel";
            this.FailModifyLabel.Size = new System.Drawing.Size(135, 13);
            this.FailModifyLabel.TabIndex = 15;
            this.FailModifyLabel.Text = "Action failed to reservation!";
            this.FailModifyLabel.Visible = false;
            // 
            // ModifyButton
            // 
            this.ModifyButton.Location = new System.Drawing.Point(649, 322);
            this.ModifyButton.Name = "ModifyButton";
            this.ModifyButton.Size = new System.Drawing.Size(75, 23);
            this.ModifyButton.TabIndex = 13;
            this.ModifyButton.Text = "Modify";
            this.ModifyButton.UseVisualStyleBackColor = true;
            this.ModifyButton.Click += new System.EventHandler(this.ModifyButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(547, 322);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(75, 23);
            this.DeleteButton.TabIndex = 12;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // ModifyDate
            // 
            this.ModifyDate.Location = new System.Drawing.Point(547, 284);
            this.ModifyDate.Name = "ModifyDate";
            this.ModifyDate.Size = new System.Drawing.Size(200, 20);
            this.ModifyDate.TabIndex = 11;
            // 
            // CabinsCombo
            // 
            this.CabinsCombo.FormattingEnabled = true;
            this.CabinsCombo.Location = new System.Drawing.Point(479, 257);
            this.CabinsCombo.Name = "CabinsCombo";
            this.CabinsCombo.Size = new System.Drawing.Size(169, 21);
            this.CabinsCombo.TabIndex = 10;
            this.CabinsCombo.Visible = false;
            // 
            // ServicesCombo
            // 
            this.ServicesCombo.FormattingEnabled = true;
            this.ServicesCombo.Location = new System.Drawing.Point(649, 257);
            this.ServicesCombo.Name = "ServicesCombo";
            this.ServicesCombo.Size = new System.Drawing.Size(121, 21);
            this.ServicesCombo.TabIndex = 9;
            this.ServicesCombo.Visible = false;
            // 
            // FailSaveLabel
            // 
            this.FailSaveLabel.AutoSize = true;
            this.FailSaveLabel.ForeColor = System.Drawing.Color.Red;
            this.FailSaveLabel.Location = new System.Drawing.Point(135, 431);
            this.FailSaveLabel.Name = "FailSaveLabel";
            this.FailSaveLabel.Size = new System.Drawing.Size(131, 13);
            this.FailSaveLabel.TabIndex = 8;
            this.FailSaveLabel.Text = "Failed to save reservation!";
            this.FailSaveLabel.Visible = false;
            // 
            // SaveProgress
            // 
            this.SaveProgress.Location = new System.Drawing.Point(134, 431);
            this.SaveProgress.Name = "SaveProgress";
            this.SaveProgress.Size = new System.Drawing.Size(100, 23);
            this.SaveProgress.TabIndex = 7;
            this.SaveProgress.Visible = false;
            // 
            // ChosenServiceInfo
            // 
            this.ChosenServiceInfo.AutoSize = true;
            this.ChosenServiceInfo.Location = new System.Drawing.Point(272, 237);
            this.ChosenServiceInfo.Name = "ChosenServiceInfo";
            this.ChosenServiceInfo.Size = new System.Drawing.Size(64, 13);
            this.ChosenServiceInfo.TabIndex = 6;
            this.ChosenServiceInfo.Text = "Service Info";
            // 
            // ChosenCabinInfo
            // 
            this.ChosenCabinInfo.AutoSize = true;
            this.ChosenCabinInfo.Location = new System.Drawing.Point(269, 44);
            this.ChosenCabinInfo.Name = "ChosenCabinInfo";
            this.ChosenCabinInfo.Size = new System.Drawing.Size(55, 13);
            this.ChosenCabinInfo.TabIndex = 5;
            this.ChosenCabinInfo.Text = "Cabin Info";
            this.ChosenCabinInfo.Click += new System.EventHandler(this.ChosenCabinInfo_Click);
            // 
            // ReservationsList
            // 
            this.ReservationsList.FormattingEnabled = true;
            this.ReservationsList.Location = new System.Drawing.Point(527, 44);
            this.ReservationsList.Name = "ReservationsList";
            this.ReservationsList.Size = new System.Drawing.Size(232, 186);
            this.ReservationsList.TabIndex = 4;
            this.ReservationsList.SelectedIndexChanged += new System.EventHandler(this.ReservationsList_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(22, 431);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(106, 31);
            this.button1.TabIndex = 3;
            this.button1.Text = "Make Reservation";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(22, 404);
            this.dateTimePicker1.MinDate = new System.DateTime(2020, 10, 4, 0, 0, 0, 0);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 2;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // ServicesList
            // 
            this.ServicesList.FormattingEnabled = true;
            this.ServicesList.Location = new System.Drawing.Point(22, 237);
            this.ServicesList.Name = "ServicesList";
            this.ServicesList.Size = new System.Drawing.Size(211, 160);
            this.ServicesList.TabIndex = 1;
            this.ServicesList.SelectedIndexChanged += new System.EventHandler(this.ServicesList_SelectedIndexChanged);
            // 
            // CabinsList
            // 
            this.CabinsList.FormattingEnabled = true;
            this.CabinsList.Location = new System.Drawing.Point(22, 44);
            this.CabinsList.Name = "CabinsList";
            this.CabinsList.Size = new System.Drawing.Size(211, 186);
            this.CabinsList.TabIndex = 0;
            this.CabinsList.SelectedIndexChanged += new System.EventHandler(this.CabinsList_SelectedIndexChanged);
            // 
            // NoReservationLabel
            // 
            this.NoReservationLabel.AutoSize = true;
            this.NoReservationLabel.Cursor = System.Windows.Forms.Cursors.Default;
            this.NoReservationLabel.ForeColor = System.Drawing.Color.IndianRed;
            this.NoReservationLabel.Location = new System.Drawing.Point(565, 390);
            this.NoReservationLabel.Name = "NoReservationLabel";
            this.NoReservationLabel.Size = new System.Drawing.Size(141, 13);
            this.NoReservationLabel.TabIndex = 17;
            this.NoReservationLabel.Text = "No reservation was selected";
            this.NoReservationLabel.Visible = false;
            // 
            // CabinServicesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 499);
            this.Controls.Add(this.LoggedInPanel);
            this.Controls.Add(this.WelcomePanel);
            this.Name = "CabinServicesForm";
            this.Text = "Cabin Service Orderer";
            this.WelcomePanel.ResumeLayout(false);
            this.WelcomePanel.PerformLayout();
            this.LoggedInPanel.ResumeLayout(false);
            this.LoggedInPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button EmailSubmitButton;
        private System.Windows.Forms.TextBox EmailTextBox;
        private System.Windows.Forms.Label WelcomeLabel;
        private System.Windows.Forms.Panel WelcomePanel;
        private System.Windows.Forms.Panel LoggedInPanel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ListBox ServicesList;
        private System.Windows.Forms.ListBox CabinsList;
        private System.Windows.Forms.Label ChosenCabinInfo;
        private System.Windows.Forms.ListBox ReservationsList;
        private System.Windows.Forms.Label ChosenServiceInfo;
        private System.Windows.Forms.ProgressBar SaveProgress;
        private System.Windows.Forms.Label FailSaveLabel;
        private System.Windows.Forms.Button ModifyButton;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.DateTimePicker ModifyDate;
        private System.Windows.Forms.ComboBox CabinsCombo;
        private System.Windows.Forms.ComboBox ServicesCombo;
        private System.Windows.Forms.ProgressBar ModifyProgress;
        private System.Windows.Forms.Label FailModifyLabel;
        private System.Windows.Forms.Label NoReservationLabel;
    }
}

