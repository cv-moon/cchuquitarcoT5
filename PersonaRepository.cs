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

        public void AddNewPerson(string name)
        {
            int result = 0;
            try
            {
                Init();
                if (string.IsNullOrEmpty(name))
                    throw new Exception("El campo Nombre es requerido");
                Persona persona = new() { Name = name };
                result = conn.Insert(persona);
                StatusMessage = string.Format("Se insertó una persona.", result, name);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Error! no se pudo insertar.", name, ex.Message);
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
    }
}
