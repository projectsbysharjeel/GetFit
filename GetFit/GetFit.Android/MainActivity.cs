using System;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.IO;
using Android.Content;
using Xamarin.Forms;

namespace GetFit.Droid
{
    [Activity(Label = "GetFit", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            string fileName = "myProfile_db.sqlite";
            string fileLocation = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal));
            string full_path = Path.Combine(fileLocation, fileName);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }

        //==============================================================================================
        // Reference F3: Externally sourced program
        // Purpose: Accessing Accelerometer 
        // Date: 07 Nov 2020
        // Source: YouTube Video
        // Author: Microsoft Developer 
        // Url: https://www.youtube.com/watch?v=h2MGTh5bkdA
        // Adaptation: Giving permission to access accelerometer 
        //===============================================================================================

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);         
        }

        //===============================================================================================
        // End reference F3
        //===============================================================================================
        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
        }
    }
}