﻿using CabinServicesApp.Logic;
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
        List<Cabin> cabins;
        List<Service> services;
        Cabin chosenCabin;
        Service chosenService;
        System.DateTime chosenDate;
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
                var cabinsResponse = await api.GetCabins(email);
                if (cabinsResponse == null)
                {
                    WelcomeLabel.ForeColor = Color.Red;
                    WelcomeLabel.Text = "No cabins were found with this email address.\nRegister email/cabins?";
                    return;
                }

                Debug.WriteLine(cabinsResponse);
                // Cabins were found for the email address, hiding this panel and going forward.
                WelcomePanel.Visible = false;
                cabins = new List<Cabin>(cabinsResponse);

                RenderCabins();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception in emailsubmitbutton_click " + ex.Message);
            }
        }

        private async void RenderCabins()
        {
            LoggedInPanel.Visible = true;
            foreach (Cabin cabin in cabins)
            {
                CabinsList.Items.Add($"{cabin.address}, {cabin.squarageProperty} m2 ,{cabin._id}");
            }
        }

        private async void RenderCabinInfo(string selected)
        {
            var cabinId = selected.Split(',')[2];
            chosenCabin = cabins.Find(c => c._id == cabinId);
            ChosenCabinInfo.Text = $"" +
                $" {chosenCabin.address} " +
                $"\n Property: {chosenCabin.squarageProperty}m2" +
                $"\n Cabin: {chosenCabin.squarageCabin}m2" +
                $"\n Sauna: {chosenCabin.sauna}" +
                $"\n Beach Front: {chosenCabin.beachfront}" +
                $"\n Name: {chosenCabin.ownerName} " +
                $"\n Email: {chosenCabin.owner.email} ";
        }

        private async void RenderServices()
        {
            try
            {
                var servicesResponse = await api.GetServices();
                if (servicesResponse == null)
                {
                    return;
                }
                services = new List<Service>(servicesResponse);

                ServicesList.Items.Clear();
                
                foreach (Service service in services)
                {
                    ServicesList.Items.Add($"{service.ServiceType}, {service.Description}, {service.Price} € ,{service.id}");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception in RenderServices " + ex.Message);
            }
        }

        private async void RenderServiceInfo(string selected)
        {
            var serviceId = Int32.Parse(selected.Split(',')[3]);
            chosenService = services.Find(s => s.id == serviceId);
            ChosenServiceInfo.Text = $"" +
                $" Type: {chosenService.ServiceType} " +
                $"\n Description: {chosenService.Description}" +
                $"\n Price: {chosenService.Price}";
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

        private void CabinsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var listBox = (ListBox)sender;
            ChosenServiceInfo.Text = "";
            RenderServices();
            RenderCabinInfo(listBox.SelectedItem.ToString());
            
        }

        private void ServicesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var listBox = (ListBox)sender;
            RenderServiceInfo(listBox.SelectedItem.ToString());
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            //chosenDate = (DateTimePicker)sender.
            // sender.Value is System.DateTime
            Debug.WriteLine("Clicked on a new date");
        }
    }
}
