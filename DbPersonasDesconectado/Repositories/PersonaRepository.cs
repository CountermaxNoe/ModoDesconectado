using DbPersonasDesconectado.Models;
using DbPersonasDesconectado.ViewModels;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DbPersonasDesconectado.Repositories
{
    public class PersonaRepository
    {
        RegistroPoblacionalContext context = new();

        public IEnumerable<Personas> GetAll()
        {
            return context.Personas.OrderBy(x => x.Nombre);
        }
        public void Agregar(Personas p)
        {
            context.Personas.Add(p);
            context.SaveChanges();
        }
        public void Eliminar(Personas p)
        {
            context.Personas.Remove(p);
            context.SaveChanges();
        }
        public Personas? GetById(int id)
        {
            return context.Personas.Find(id);
        }
        public void Editar(Personas p)
        {
            //Personas? pm = context.Personas.Find(p.Id);
            ////context.Personas.FirstOrDefault(x => x.Id == p.Id);
            //pm.Edad=p.Edad;
            //pm.Nombre=p.Nombre;
            //pm.Genero=p.Genero;
            context.Personas.Update(p);
            context.SaveChanges();
        }
        public bool Validar(Personas p, out string? error)
        {
            List<string> listaerrores = new List<string>();

            int longitud= p.Nombre.Length;
            if (string.IsNullOrWhiteSpace(p.Nombre))
            {
                listaerrores.Add("Escriba el nombre de la persona");
            }
            if (longitud > 99)
            {
                listaerrores.Add("El nombre es demasiado largo (Maximo 99 caracteres)");
            }
            if (p.Edad < 0 || p.Edad > 100)
            {
                listaerrores.Add("La edad debe de ser entre 0 y 100 años");
            }
            if (p.Genero == 0)
            {
                listaerrores.Add("Seleccione un genero valido: Hombre, Mujer");
            }
            //validacion al insertar una persona que el nombre no se repita
            if (context.Personas.Any(x=>x.Nombre.ToLower()==p.Nombre.ToLower())&& p.Id==0)
            {
                listaerrores.Add("El nombre ya existe");
            }
            if(context.Personas.Any(x=>x.Nombre.ToLower()==p.Nombre.ToLower()&& p.Id != x.Id))
            {
                listaerrores.Add("No se puede editar una personas con un nombre previamente registrado");
            }
            //error = string.Join(" '\n' ", listaerrores);
            error = string.Join(Environment.NewLine, listaerrores);

            return listaerrores.Count != 0;
        }
        public long GetNumeroPersonas(Sexo s)
        {
            return context.Personas.Count(x => x.Genero == s);
        }
    }
}
