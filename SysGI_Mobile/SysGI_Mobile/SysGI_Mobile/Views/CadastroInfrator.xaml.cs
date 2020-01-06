using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SysGI_Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CadastroInfrator : ContentPage
    {
        public CadastroInfrator()
        {
            InitializeComponent();
        }

        async public void Btn_Cancelar_Click(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        async public void Btn_Salvar_Click(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}