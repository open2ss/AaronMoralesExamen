using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AaronMoralesExamen
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registro : ContentPage
    {
        public Registro(string usuario)
        {
            InitializeComponent(); txtUser1.Text = usuario;
        }
        private void btnCalculate_Clicked(object sender, EventArgs e)
        {
            double amounth = Convert.ToDouble(txtAmount.Text);
            if (amounth > 1800 || amounth < 0)
            {
                DisplayAlert("Alerta", "EL MONTO NO PUEDE SER MAYOR QUE $1800 NI MENOR QUE $0", "Aceptar");
            }
            else
            {
                double pago = Convert.ToDouble(txtAmount.Text);
                double diferencia = 1800 - pago;
                diferencia = (diferencia + (diferencia * 0.05)) / 3;
                txtPayment.Text = diferencia.ToString();
            }
        }
        private async void btnSave_Clicked(object sender, EventArgs e)
        {
            double total = Convert.ToDouble(txtAmount.Text) + Convert.ToDouble(txtPayment.Text) * 3;
            DisplayAlert("Alerta", "Registro guardado con éxito", "Aceptar");
            await Navigation.PushAsync(new Resumen(txtUser1.Text, txtName.Text, total.ToString()));
        }
    }
}