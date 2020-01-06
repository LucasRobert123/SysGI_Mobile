using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SysGI_Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MENU : ContentPage
    {
        public string MenuFrase { get; set; }
        public string PowerIcon { get; set; }
        public MENU()
        {
            InitializeComponent();
            string user_name = "Fulano";
            MenuFrase = $"Bem-vindo, {user_name}!";
            PowerIcon = "\u23FB";
            BindingContext = this;
        }

        async public void Btn_Cadastrar_Click(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CadastroInfrator());
        }

        async public void Btn_Consultar_Click(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Consulta());
        }

        async public void Btn_Logoff_Click(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}