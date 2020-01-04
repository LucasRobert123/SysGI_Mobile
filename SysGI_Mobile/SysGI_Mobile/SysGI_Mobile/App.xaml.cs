using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SysGI_Mobile.Views;
namespace SysGI_Mobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new Views.CadastroDeMenor();
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
