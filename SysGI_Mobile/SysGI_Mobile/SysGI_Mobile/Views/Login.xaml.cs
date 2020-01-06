using SysGI_Mobile.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SysGI_Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public string Rodape { get => App.Rodape; }

        public Login()
        {
            InitializeComponent();

            if (!Network.Connect())
            {
                DisplayAlert("Sucesso:", "Conectado ao Mongo!", "OK");
            }

            BindingContext = this;
        }

        async public void Btn_Login_Click(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MENU());
        }

        async public void Btn_Cadastrar_Click(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CadastroDeUsuario());
        }
    }
}