using CabinServicesApp.Logic;
using CabinServicesApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CabinServicesApp
{
    public partial class CabinServicesForm : Form
    {
        Api api;
        List<CabinsResponse> cabins;
        public CabinServicesForm()
        {
            InitializeComponent();
            api = new Api();
        }


        private async void EmailSubmitButton_Click(object sender, EventArgs e)
        {
            try
            {
                string email = EmailTextBox.Text;
                var _cabins = await api.GetCabins(email);
                if (_cabins == null)
                {
                    WelcomeLabel.ForeColor = Color.Red;
                    WelcomeLabel.Text = "No cabins were found with this email address.\nRegister email/cabins?";
                    return;
                }
                
                Debug.WriteLine(_cabins);
                // Cabins were found for the email address, hiding this panel and going forward.
                WelcomePanel.Visible = false;
                cabins = _cabins;

                RenderCabins();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception in emailsubmitbutton_click " + ex.Message);
            }
        }

        private async void RenderCabins()
        {
            await api.GetCabins("asd@asd.co");
        }

        private void EmailTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void WelcomeLabel_Click(object sender, EventArgs e)
        {

        }

        private void WelcomePanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ChosenCabinInfo_Click(object sender, EventArgs e)
        {

        }
    }
}
