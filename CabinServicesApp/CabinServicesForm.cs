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
        List<Cabin> cabins;
        List<Service> services;
        List<ReservationResponse> reservations;
        Cabin chosenCabin;
        Service chosenService;
        System.DateTime chosenDateTime;
        string chosenDateString;
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
                RenderReservations();
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
                $"\n Price: {chosenService.Price}€";
        }

        private async void RenderReservations()
        {
            try
            {
                string email = EmailTextBox.Text;
                var reservationsResponse = await api.GetReservations(email);
                if (reservationsResponse == null)
                {
                    return;
                }
                reservations = new List<ReservationResponse>(reservationsResponse);
                ReservationsList.Items.Clear();

                foreach (ReservationResponse res in reservations)
                {
                    ReservationsList.Items.Add($"{res.CabinAddress}, {res.ServiceType}, {res.ScheduledDate} ,{res.id}");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception in RenderReservations" + ex.Message);
            }
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
            chosenDateTime = dateTimePicker1.Value;
            chosenDateString = chosenDateTime.ToShortDateString();
            var splitted = chosenDateString.Split('.');
            // Formats the date around so it gets accepted by sql database
            chosenDateString = $"{splitted[2]}-{splitted[1]}-{splitted[0]}";
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                FailSaveLabel.Visible = false;
                SaveProgress.Visible = true;
                SaveProgress.Value = 0;
                var reservation = new Reservation()
                {
                    ServiceId = chosenService.id,
                    CabinId = chosenCabin._id,
                    CabinOwnerName = chosenCabin.ownerName,
                    CabinEmail = chosenCabin.owner.email,
                    CabinAddress = chosenCabin.address,
                    ScheduledDate = chosenDateString
                };
                var result = await api.SaveReservation(reservation);

                if (result)
                {
                    SaveProgress.Value = 100;
                    RenderReservations();
                }
                else
                {
                    SaveProgress.Visible = false;
                    FailSaveLabel.Visible = true;
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception saving reservation: " + ex.Message);
            }
        }
    }
}
