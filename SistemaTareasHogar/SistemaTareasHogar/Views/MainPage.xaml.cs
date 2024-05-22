using SistemaTareasHogar.Model;
using SistemaTareasHogar.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SistemaTareasHogar
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void btn_guardar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var tarea = new Tareas
                {
                    nombre = nombre.Text,
                    descripcion = descripcion.Text,
                    horaInicio = horaInicio.Time,
                    horaFin = horaFin.Time
                };

                var result = await App.DataBaseConnection.InsertItem(tarea);

                if (result == 1)
                {
                    await DisplayAlert("Listo", "Se guardo su tarea", "Aceptar");
                    nombre.Text = string.Empty;
                    descripcion.Text = string.Empty;
                    horaInicio.Time = TimeSpan.Zero; // Puedes asignar TimeSpan.Zero o cualquier otro valor predeterminado
                    horaFin.Time = TimeSpan.Zero;
                    await Navigation.PopAsync();
                }
                else
                {
                    await DisplayAlert("Error", "No se pudo guardar", "Aceptar");
                }

            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Aceptar");
            }

        }

        public async void btn_otraVista_Clicked(object sender,EventArgs e)
        {
            await Navigation.PushAsync(new TareasPage());
        }
    }
}
