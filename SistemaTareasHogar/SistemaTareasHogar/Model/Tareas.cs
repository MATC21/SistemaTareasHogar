using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SistemaTareasHogar.Model
{
    public class Tareas
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public TimeSpan horaInicio { get; set; }
        public TimeSpan horaFin {  get; set; }
        public bool estado { get; set; }

    }
}
