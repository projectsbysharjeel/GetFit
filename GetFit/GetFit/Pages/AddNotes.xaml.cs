using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using GetFit.Models;

namespace GetFit
{
    public partial class AddNotes : ContentPage
    {
        public AddNotes()
        {
            InitializeComponent();
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            var note = (Note)BindingContext;

            if (string.IsNullOrWhiteSpace(note.Filename))
            {
                // Save
                var filename = Path.Combine(App.FolderPath, $"{Path.GetRandomFileName()}.notes.txt");

                //===============================================================================================
                // Reference B2: Personal Assistance
                // Purpose: Write every note that's added in the Entry
                // Date: 03 November 2020
                // Source: Lab Tutor
                // Assistance: Esxplained and helped with Writing files
                //===============================================================================================

                var writer = new StreamWriter(File.OpenWrite(filename));
                writer.WriteLine(note.WorkoutPlan);
                writer.WriteLine(note.MealPlan);
                writer.WriteLine(note.Breakfast);
                writer.WriteLine(note.Lunch);
                writer.WriteLine(note.Dinner);

                writer.Close();
            }
            else
            {
                // Update
                var writer = new StreamWriter(File.OpenWrite(note.Filename));
                writer.WriteLine(note.WorkoutPlan);
                writer.WriteLine(note.MealPlan);
                writer.WriteLine(note.Breakfast);
                writer.WriteLine(note.Lunch);
                writer.WriteLine(note.Dinner);

                writer.Close();
            }

            //===============================================================================================
            // End reference B2
            //===============================================================================================

            await Navigation.PopAsync();

        }

        async void Delete_Clicked(System.Object sender, System.EventArgs e)
        {
            //==============================================================================================
            // Reference A2: Externally sourced program
            // Purpose: Deletes the note that's added already 
            // Date: 16 Oct 2020
            // Source: GitHub Xamarin forms samples
            // Author: David Britch
            // Url: https://github.com/xamarin/xamarin-forms-samples/tree/master/GetStarted/Notes/MultiPage
            // Adaptation: Got the idea on how to delete file when button pressed 
            //===============================================================================================

            var note = (Note)BindingContext;

            if (File.Exists(note.Filename))
            {
                File.Delete(note.Filename);
            }

            //===============================================================================================
            // End reference A1
            //===============================================================================================

            await Navigation.PopAsync();
        }
    }
}