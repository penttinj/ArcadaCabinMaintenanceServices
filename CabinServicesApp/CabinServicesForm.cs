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
        int chosenResId;
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

                GetServices();
                RenderCabins();
                RenderReservations();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception in emailsubmitbutton_click " + ex.Message);
            }
        }

        private async void GetServices()
        {
            var servicesResponse = await api.GetServices();
            if (servicesResponse == null)
            {
                return;
            }
            services = new List<Service>(servicesResponse);
        }

        private void RenderCabins()
        {
            LoggedInPanel.Visible = true;
            foreach (Cabin cabin in cabins)
            {
                CabinsList.Items.Add($"{cabin.address}, {cabin.squarageProperty} m2 ,{cabin._id}");
            }
        }

        private async void RenderCabinInfo(string selected)
        {
            var split = selected.Split(',');
            var cabinId = split[split.Length - 1];
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
            var split = selected.Split(',');
            var serviceId = Int32.Parse(split[split.Length - 1]);
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
                    ReservationsList.Items.Add($"{res.id}, {res.CabinAddress}, {res.ServiceType}, {res.ScheduledDate}");
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
            try
            {
                var listBox = (ListBox)sender;
                ChosenServiceInfo.Text = "";
                RenderServices();
                RenderCabinInfo(listBox.SelectedItem.ToString());
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private void ServicesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var listBox = (ListBox)sender;
                RenderServiceInfo(listBox.SelectedItem.ToString());
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
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
                ClearModifyFields();

                CabinsCombo.Visible = false;
                ServicesCombo.Visible = false;
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

        private void ReservationsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var listBox = (ListBox)sender;
                RenderModification(listBox.SelectedItem.ToString());
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private void RenderModification(string resItem)
        {
            chosenResId = Int32.Parse(resItem.Split(',')[0]);
            var res = reservations.Find(r => r.id == chosenResId);
            var cabinInRes = cabins.Find(c => c._id == res.CabinId);
            var serviceInRes = services.Find(s => s.id == res.ServiceId);

            CabinsCombo.Items.Clear();
            ServicesCombo.Items.Clear();

            foreach (Cabin cabin in cabins)
            {
                CabinsCombo.Items.Add($"{cabin.address} ,{cabin._id}");
            }
            foreach (Service service in services)
            {
                ServicesCombo.Items.Add($"{service.id}, {service.ServiceType}");
            }

            ServicesCombo.SelectedItem = res.ServiceId;

            CabinsCombo.Visible = true;
            ServicesCombo.Visible = true;

            Debug.WriteLine("Service combo selected item:");
            Debug.WriteLine(ServicesCombo.SelectedItem);
            Debug.WriteLine("cabin combo selected item:");
            Debug.WriteLine(CabinsCombo.SelectedItem);
        }

        private async void ModifyButton_Click(object sender, EventArgs e)
        {

            // Checks that a reservation is actually chosen. 0 is a default for no cabin chosen.
            if (chosenResId == 0)
            {
                NoReservationLabel.Visible = true;
                return;
            }
            string modifiedCabinId = null;
            string modifiedCabinAddress = null;
            int modifiedServiceId = 0;
            string modifiedDateString = null;

            // Spammy code I know... too lazy to find more concise way.
            try
            {
                modifiedCabinAddress = CabinsCombo.SelectedItem.ToString().Split(',')[0];
                modifiedCabinId = CabinsCombo.SelectedItem.ToString().Split(',')[1];
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Some modifications were empty: " + ex.Message);
            }
            try
            {
                modifiedServiceId = Int32.Parse(ServicesCombo.SelectedItem.ToString().Split(',')[0]);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Some modifications were empty: " + ex.Message);
            }
            try
            {
                var modifiedTime = ModifyDate.Value;
                var splitted = modifiedTime.ToShortDateString().Split('.');
                // Formats the date around so it gets accepted by sql database
                modifiedDateString = $"{splitted[2]}-{splitted[1]}-{splitted[0]}";
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Some modifications were empty: " + ex.Message);
            }
            try
            {
                CabinsCombo.Visible = false;
                ServicesCombo.Visible = false;
                FailModifyLabel.Visible = false;
                ModifyProgress.Visible = true;
                ModifyProgress.Value = 0;


                var reservation = new Reservation();
                if (modifiedServiceId != 0) reservation.ServiceId = modifiedServiceId;
                if (modifiedDateString != null) reservation.ScheduledDate = modifiedDateString;
                if (modifiedCabinId != null)
                {
                    reservation.CabinId = modifiedCabinId;
                    reservation.CabinAddress = modifiedCabinAddress;
                }

                var result = await api.ModifyReservation(reservation, chosenResId);

                if (result)
                {
                    ClearModifyFields();
                    ModifyProgress.Value = 100;
                    NoReservationLabel.Visible = false;
                    chosenResId = 0;
                    RenderReservations();
                }
                else
                {
                    ClearModifyFields();
                    Debug.WriteLine("Failed modify");
                    ModifyProgress.Visible = false;
                    FailModifyLabel.Visible = true;
                    chosenResId = 0;
                }

            }
            catch (Exception ex)
            {
                ClearModifyFields();
                Debug.WriteLine("Exception saving reservation: " + ex.Message);
            }
        }

        private async void DeleteButton_Click(object sender, EventArgs e)
        {
            ClearModifyFields();

            if (chosenResId == 0)
            {
                NoReservationLabel.Visible = true;
                return;
            }

            CabinsCombo.Visible = false;
            ServicesCombo.Visible = false;
            FailModifyLabel.Visible = false;
            ModifyProgress.Visible = true;
            ModifyProgress.Value = 0;

            var result = await api.DeleteReservation(chosenResId);
            if (result)
            {
                ModifyProgress.Value = 100;
                NoReservationLabel.Visible = false;
                chosenResId = 0;
                RenderReservations();
            }
            else
            {
                Debug.WriteLine("Failed delete");
                ModifyProgress.Visible = false;
                FailModifyLabel.Visible = true;
                chosenResId = 0;
            }
        }

        private void ClearModifyFields()
        {
            CabinsCombo.SelectedIndex = -1;
            ServicesCombo.SelectedIndex = -1;
        }
    }
}
