﻿using Laboratoire02.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Laboratoire02
{
    public partial class MainPage : ContentPage
    {
        public IList<Inscription> inscriptions = new List<Inscription>(8);
        public MainPage()
        {
            InitializeComponent();
        }

        private void switch_condition_Toggled(object sender, ToggledEventArgs e)
        {
            if(e.Value) btn_inscription.IsEnabled = true;
            else btn_inscription.IsEnabled = false;
        }

        public bool formValidation()
        {
            bool valid = false;
            foreach(var entry in form.Children)
            {
                if(entry.GetType() == typeof(Entry))
                {
                    if ((entry as Entry).Text == null)
                    {
                        valid = false;
                    }
                    else valid = true;
                }
            }
            return valid;
        }

        private async void btn_inscription_Clicked(object sender, EventArgs e)
        {
            if(formValidation())
            {
                var inscription = new Inscription()
                {
                    Nom = txt_Nom.Text,
                    Telephone = txt_Telephone.Text,
                    MotPasse = txt_MotPasse.Text,
                };
                inscriptions.Add(inscription);
                var res = await DisplayAlert("Confirmation", "Inscription avec success", "Ok", "Fermer");
                if(res || !res)
                {
                condition.IsVisible = false;
                section_condition.IsVisible = false;
                }
            }
            else
            {
                await DisplayAlert("Erreur", "Veuillez remplir tous les champs", "Ok", "Fermer");
            }
        }
    }
}
