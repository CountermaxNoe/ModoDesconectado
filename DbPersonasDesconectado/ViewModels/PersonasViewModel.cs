using DbPersonasDesconectado.Models;
using DbPersonasDesconectado.Repositories;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DbPersonasDesconectado.ViewModels
{
    public enum Sexo { Hombre = 1, Mujer = 2 }
    public class PersonasViewModel: INotifyPropertyChanged
    {
        PersonaRepository repos = new();

        public event PropertyChangedEventHandler? PropertyChanged;
        public long Hombres { get; set; }
        public long Mujeres { get; set; }

        public ObservableCollection<Personas> Personas { get; set; } = new();
        public Personas? Persona { get; set; }
        public string Modo { get; set; } = "Lista";
        public ICommand AgregarCommand { get; set; }
        public ICommand EliminarCommand { get; set; }
        public ICommand GuardarCommnad {  get; set; }
        public ICommand VerEditarCommand {  get; set; }
        public ICommand EditarCommand {  get; set; }
        public ICommand CancelarCommand {  get; set; }
        public string? Error 
        {
            get { return error; }
            set { error = value; }
        }
        public string? error;

        public PersonasViewModel()
        {
            AgregarCommand = new RelayCommand(VerAgregar);
            EliminarCommand = new RelayCommand(Eliminar);
            GuardarCommnad = new RelayCommand(Guardar);
            VerEditarCommand = new RelayCommand(VerEditar);
            EditarCommand = new RelayCommand(Editar);
            CancelarCommand = new RelayCommand(Cancelar);
            Actualizar();
        }

        private void Cancelar()
        {
            Modo = "Ver";
            Persona = null;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
        }

        private void Editar()
        {
            if (Persona != null)
            {
                if(!repos.Validar(Persona, out error))
                {
                    Personas? clon = repos.GetById(Persona.Id);
                    if (Persona != null)
                    {
                        clon.Nombre = Persona.Nombre;
                        clon.Edad = Persona.Edad;
                        clon.Genero = Persona.Genero;

                        repos.Editar(clon);
                        Modo = "Ver";
                        Actualizar();
                    }
                }
            }
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
        }

        private void VerEditar()
        {
            if (Persona != null)
            {
                Personas clon = new Personas()
                {
                    Edad=Persona.Edad,
                    Nombre=Persona.Nombre,
                    Genero=Persona.Genero,
                    Id=Persona.Id
                };
                Persona = clon;
                Modo = "Editar";
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
            }
        }

        private void Eliminar()
        {
            if (Persona != null)
            {
                repos.Eliminar(Persona);
                Actualizar();
            }
        }

        private void Guardar()
        {
            if (Persona != null)
            {
                if (!repos.Validar(Persona, out error))
                {
                    repos.Agregar(Persona);
                    Modo = "Ver";
                }
                Actualizar();
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
            }
        }

        private void VerAgregar()
        {
            Persona = new();
            Modo = "Agregar";
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
        }

        public void Actualizar()
        {
            Personas.Clear();
            foreach(Personas p in repos.GetAll())
            {
                Personas.Add(p);
            }
            Hombres = repos.GetNumeroPersonas(Sexo.Hombre);
            Mujeres = repos.GetNumeroPersonas(Sexo.Mujer);

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));

        }
    }
}
