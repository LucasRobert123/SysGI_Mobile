using System;
using Xamarin.Forms;
using SysGI_Mobile.Views;

namespace SysGI_Mobile
{
    public partial class App : Application
    {
        public static string Rodape { get; set; } = "Todos os Direitos Reservados - UNIFENAS - " + DateTime.Today.Year;

        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new Login());
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
