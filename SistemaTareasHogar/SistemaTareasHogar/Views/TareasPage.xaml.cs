using SistemaTareasHogar.Model;
using SistemaTareasHogar.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SistemaTareasHogar.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TareasPage : ContentPage
    {
        private ObservableCollection<Tareas> tareas;
        public TareasPage()
        {
            InitializeComponent();
            LoadTareas();
        }
        private async void LoadTareas()
        {
            var tareasList = await App.DataBaseConnection.getItem();
            tareas = new ObservableCollection<Tareas>(tareasList);
            tareasListView.ItemsSource = tareas;
        }
        private async void OnEditButtonClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var tarea = button?.BindingContext as Tareas;
            if (tarea != null)
            {
                // Navega a una página de edición pasando la tarea seleccionada
                await Navigation.PushAsync(new EditarPage(tarea));
            }
        }

        private async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var tarea = button?.BindingContext as Tareas;
            if (tarea != null)
            {
                bool confirm = await DisplayAlert("Confirmar eliminación", "¿Estás seguro de que deseas eliminar esta tarea?", "Sí", "No");
                if (confirm)
                {
                    await App.DataBaseConnection.DeleteItem(tarea);
                    tareas.Remove(tarea);
                }
            }
        }
        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null; // Desmarca la tarea seleccionada
        }
    }
}