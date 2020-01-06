using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SysGI_Mobile.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SysGI_Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CadastroDeUsuario : ContentPage
    {
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
            Data_Controller.Add_User(user);
            
            await Navigation.PopAsync();
        }
    }
}