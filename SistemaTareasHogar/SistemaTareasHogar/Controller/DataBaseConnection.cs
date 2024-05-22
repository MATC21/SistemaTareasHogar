using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using SQLite;
using SistemaTareasHogar.Model;

namespace SistemaTareasHogar.Controller
{
    public class DataBaseConnection
    {
        public SQLiteAsyncConnection Connection { get; set; }
        public DataBaseConnection(string path)
        {
            Connection = new SQLiteAsyncConnection(path);
            //Creamos una tabla Tarea
            Connection.CreateTableAsync<Tareas>().Wait();
        }
        public async Task<int> InsertItem(Tareas item)
        {
            return await Connection.InsertAsync(item);
        }
        public async Task<List<Tareas>> getItem()
        {
            return await Connection.Table<Tareas>().ToListAsync();
        }
        public async Task<int> DeleteItem(Tareas item)
        {
            return await Connection.DeleteAsync(item);
        }
        public async Task<int> EditItem(Tareas item)
        {
            Tareas tareaEncontrada = await Connection.FindAsync<Tareas>(t => t.id == item.id);

            if (tareaEncontrada != null)
            {
                tareaEncontrada.nombre = item.nombre;
                tareaEncontrada.descripcion = item.descripcion;
                tareaEncontrada.horaInicio = item.horaInicio;
                tareaEncontrada.horaFin = item.horaFin;
                tareaEncontrada.estado = item.estado;
            }

            return await Connection.UpdateAsync(tareaEncontrada);
        }
    }
}
