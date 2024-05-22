using SistemaTareasHogar.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SistemaTareasHogar.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditarPage : ContentPage
    {
        private Tareas tarea;
        public EditarPage(Model.Tareas tarea)
        {
            InitializeComponent();
            this.tarea = tarea;
            CargarDatosTarea();
        }
        private void CargarDatosTarea()
        {
            nombre.Text = tarea.nombre;
            descripcion.Text = tarea.descripcion;
            horaInicio.Time = tarea.horaInicio;
            horaFin.Time = tarea.horaFin;
            estado.IsToggled = tarea.estado;
        }

        private async void GuardarClicked(object sender, EventArgs e)
        {
            try
            {
                tarea.nombre = nombre.Text;
                tarea.descripcion = descripcion.Text;
                tarea.horaInicio = horaInicio.Time;
                tarea.horaFin = horaFin.Time;
                tarea.estado = estado.IsToggled;

                var result = await App.DataBaseConnection.EditItem(tarea);

                if (result == 1)
                {
                    await DisplayAlert("Listo", "Se editó su tarea", "Aceptar");

                    // Limpiar los campos después de editar la tarea
                    nombre.Text = string.Empty;
                    descripcion.Text = string.Empty;
                    horaInicio.Time = TimeSpan.Zero;
                    horaFin.Time = TimeSpan.Zero;

                    // Actualizar la página TareasPage para reflejar los cambios
                    
                    //await Navigation.PopAsync(); // Volver a la página anterior (EditarTareaPage)
                    await Navigation.PushAsync(new TareasPage());

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

    }
}