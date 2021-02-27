using System;
using System.Collections.Generic;
using GetFit.Models;
using GetFit.Pages;
using Xamarin.Forms;

namespace GetFit
{
    public partial class MyProfilePage : ContentPage
    {
        
        public MyProfilePage()
        {
            InitializeComponent();
        }

        void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new EditProfile());
        }
    }
}
