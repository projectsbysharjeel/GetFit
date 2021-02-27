using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using GetFit.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GetFit
{
    public partial class DiaryPage : ContentPage
    {
        public DiaryPage()
        {
            InitializeComponent();
        }

        //==============================================================================================
        // Reference A1: Externally sourced program
        // Purpose: Shows the note that's saved in a text file in a ListView
        // Date: 16 Oct 2020
        // Source: GitHub Xamarin forms samples
        // Author: David Britch
        // Url: https://github.com/xamarin/xamarin-forms-samples/tree/master/GetStarted/Notes/MultiPage
        // Adaptation: Got the idea on how to read files from StreamReader but totally implemented my way
        //===============================================================================================


        protected override void OnAppearing()
        {
            base.OnAppearing();
            
            var notes = new List<Note>();

            var files = Directory.EnumerateFiles(App.FolderPath, "*.notes.txt");
            foreach(var filename in files)
            {

                //===============================================================================================
                // Reference B1: Personal Assistance
                // Purpose: Read every note in the note added
                // Date: 03 November 2020
                // Source: Lab Tutor
                // Assistance: Esxplained and helped with reading files
                //===============================================================================================

                var reader = new StreamReader(File.OpenRead(filename));

                notes.Add(new Note
                {
                    Filename = filename,
                    WorkoutPlan = reader.ReadLine(),
                    MealPlan = reader.ReadLine(),
                    Breakfast = reader.ReadLine(),
                    Lunch = reader.ReadLine(),
                    Dinner = reader.ReadLine(),
                    Date = File.GetCreationTime(filename)
                });

                //===============================================================================================
                // End reference B1
                //===============================================================================================
            }

            listView.ItemsSource = notes
                .OrderBy(d => d.Date)
                .ToList();
        }

        async void ToolbarItem_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new AddNotes
            {
                BindingContext = new Note()
            });
        }

        async void listView_ItemSelected(System.Object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            if(e.SelectedItem != null)
            {
                await Navigation.PushAsync(new AddNotes
                {
                    BindingContext = e.SelectedItem as Note
                });
            }
        }

        //===============================================================================================
        // End reference A1
        //===============================================================================================
    }
}