using cchuquitarcoT5.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cchuquitarcoT5
{
    public class PersonaRepository
    {
        string _dbPath;
        private SQLiteConnection conn;
        public string StatusMessage { get; set; }

        private void Init()
        {
            if (conn is not null)
                return;
            conn = new(_dbPath);
            conn.CreateTable<Persona>();
        }

        public PersonaRepository(string dbPath)
        {
            _dbPath = dbPath;
        }

        public void AddNewPerson(string nombre, string apellido, int edad)
        {
            int result = 0;
            try
            {
                Init();
                if (string.IsNullOrEmpty(nombre))
                    throw new Exception("El campo Nombre es requerido");
                Persona person = new()
                {
                    Nombre = nombre,
                    Apellido = apellido,
                    Edad = edad
                };
                result = conn.Insert(person);
                StatusMessage = string.Format("Se insertó un nuevo registro.", result);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Error! no se pudo insertar.", ex.Message);
            }
        }

        public List<Persona> getAllPeople()
        {
            try
            {
                Init();
                return conn.Table<Persona>().ToList();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Error al listar.", ex.Message);
            }
            return new List<Persona>();
        }

        public Persona GetPerson(int id)
        {
            Init();
            return conn.Table<Persona>().Where(x => x.Id == id).FirstOrDefault();
        }

        public void EditPerson(int id, string nombre, string apellido, int edad)
        {
            int result = 0;
            try
            {
                Init();
                if (string.IsNullOrEmpty(nombre))
                    throw new Exception("El campo Nombre es requerido");
                Persona persona = conn.Table<Persona>().Where(x => x.Id == id).FirstOrDefault();
                persona.Nombre = nombre;
                persona.Apellido = apellido;
                persona.Edad = edad;
                result = conn.Update(persona);
                StatusMessage = string.Format("Se actualizó una persona.", result);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Error! no se pudo actualizar.", ex.Message);
            }
        }

        public void DeletePerson(int id)
        {
            int result = 0;
            try
            {
                Init();
                Persona persona = conn.Table<Persona>().Where(x => x.Id == id).FirstOrDefault();
                result = conn.Delete(persona);
                StatusMessage = string.Format("Se eliminó el registro.");
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Error! no se pudo eliminar.", ex.Message);
            }
        }
    }
}
