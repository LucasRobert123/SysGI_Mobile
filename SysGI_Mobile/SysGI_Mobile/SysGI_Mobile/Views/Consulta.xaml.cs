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
    public partial class Consulta : ContentPage
    {
        public string Rodape { get => App.Rodape; }
        public Consulta()
        {
            InitializeComponent();
            BindingContext = this;
        }
    }
}