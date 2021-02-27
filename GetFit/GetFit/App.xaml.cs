using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using DeviceMotion.Plugin;

[assembly: ExportFont("PlayfairDisplay-Regular.otf")]
[assembly: ExportFont("PlayfairDisplay-Regular.otf", Alias = "MyFont")]
namespace GetFit
{
    public partial class App : Application
    {
        public static string FolderPath { get; private set; }

        public App()
        {
            InitializeComponent();
            FolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));


            var n1 = new NavigationPage(new GetFit.HomePage());
            var n2 = new NavigationPage(new GetFit.ProgressPage());
            var n3 = new NavigationPage(new GetFit.DiaryPage());
            var n4 = new NavigationPage(new GetFit.MyProfilePage());

            n1.Title = "Home";
            n1.IconImageSource = "Home.png";
            n1.BackgroundColor = Color.FromHex("#81d8f0");

            n2.Title = "Progress";
            n2.IconImageSource = "Progress.png";
            n2.BackgroundColor = Color.FromHex("#81d8f0");

            n3.Title = "Diary";
            n3.IconImageSource = "Diary.png";
            n3.BackgroundColor = Color.FromHex("#81d8f0");

            n4.Title = "Profile";
            n4.IconImageSource = "Profile.png";
            n4.BackgroundColor = Color.FromHex("#81d8f0");


            var tab = new TabbedPage();
            tab.Children.Add(n1);
            tab.Children.Add(n2);
            tab.Children.Add(n3);
            tab.Children.Add(n4);
            MainPage = tab;
        }

    protected override void OnStart()
    {
    }

    protected override void OnSleep()
    {
    }

    protected override void OnResume()
    {
    }
}
}
