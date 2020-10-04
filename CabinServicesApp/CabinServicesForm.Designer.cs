﻿namespace CabinServicesApp
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
            this.ChosenServiceInfo = new System.Windows.Forms.Label();
            this.ChosenCabinInfo = new System.Windows.Forms.Label();
            this.ReservationsList = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.ServicesList = new System.Windows.Forms.ListBox();
            this.CabinsList = new System.Windows.Forms.ListBox();
            this.SaveProgress = new System.Windows.Forms.ProgressBar();
            this.FailSaveLabel = new System.Windows.Forms.Label();
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
            // SaveProgress
            // 
            this.SaveProgress.Location = new System.Drawing.Point(134, 431);
            this.SaveProgress.Name = "SaveProgress";
            this.SaveProgress.Size = new System.Drawing.Size(100, 23);
            this.SaveProgress.TabIndex = 7;
            this.SaveProgress.Visible = false;
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
    }
}

