using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SysGI_Mobile.Models;
using SysGI_Mobile.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SysGI_Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CadastroDeUsuario : ContentPage
    {
        public readonly User_Service user_Service = new User_Service();

        public string Rodape { get => App.Rodape; }

        public CadastroDeUsuario()
        {
            InitializeComponent();
            BindingContext = this;
        }

        async public void Btn_Salvar_Click(object sender, EventArgs e)
        {
            User user = new User();
            user.Credencial = Credencial_User.SelectedIndex;
            user.Nome = Name_User.Text;
           // user.Identificacao = Identification_User.Text;
            user.Telefone = Telephone_User.Text;
            user.Email = Email_User.Text;
            user.Passpassword = Password_User.Text;
            await user_Service.Add(user);            
            await Navigation.PopAsync();
        }
    }
}