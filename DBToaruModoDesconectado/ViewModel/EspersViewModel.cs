using DBToaruModoDesconectado.Models;
using DBToaruModoDesconectado.Repositories;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DBToaruModoDesconectado.ViewModel
{
    public class EspersViewModel : INotifyPropertyChanged
    {
        public Espers esper { get; set; }
        public EsperRepository repository = new();
        public string Error
        {
            get { return error; }
            set { error = value; }
        }
        public decimal MediaNivel { get; set; }
        public int MayorNivel { get; set; }
        public int MenorNivel { get; set; }
        public int MayorCantidad { get; set; }
        public ICommand CancelarCommand { get; set; }
        public ICommand AgregarCommand { get; set; }
        public ICommand VerAgregarCommand { get; set; }
        public ICommand EliminarCommand { get; set; }
        public ICommand VerDetallesCommand { get; set; }
        public ICommand VerEliminarCommand { get; set; }
        public ICommand EsperSeleccionado { get; set; }
        //public Vista Vista { get; set; } = Vista.Lista;
        private string? error;
        public ObservableCollection<Espers> Espers { get; set; } = new();

        public event PropertyChangedEventHandler? PropertyChanged;
        public EspersViewModel()
        {
            //AgregarCommand = new RelayCommand(Agregar);
            //EliminarCommand = new RelayCommand(Eliminar);
            //VerEliminarCommand = new RelayCommand<Espers>(VerEliminar);
            //CancelarCommand = new RelayCommand(Cancelar);
            //VerAgregarCommand = new RelayCommand(VerAgregar);
            //VerDetallesCommand = new RelayCommand<Espers>(VerDetalles);
            Actualizar();
        }

        //private void Eliminar()
        //{
        //    repository.Eliminar(esper);
        //    Vista = Vista.Lista;
        //    Actualizar();
        //}

        //private void VerEliminar(EsperModel e)
        //{
        //    Vista = Vista.Eliminar;
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
        //}

        //private void VerDetalles(EsperModel e)
        //{
        //    if (esper != null)
        //    {
        //        esper = new Espers()
        //        {
        //            Id = e.Id,
        //            Nombre = e.Nombre,
        //            Apodo = e.Apodo,
        //            Nivel = e.Nivel,
        //            Habilidad = e.Habilidad,
        //            Descripcion = e.Descripcion,
        //            URLImagen = e.URLImagen,
        //        };
        //    }
        //    Vista = Vista.Esper;
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
        //}

        //private void Agregar()
        //{
        //    if (!repository.Validar(esper, out string? error))
        //    {
        //        repository.Agregar(esper);
        //        Vista = Vista.Lista;
        //    }
        //    else
        //    {
        //        Error = error;
        //    }
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
        //    Actualizar();
        //}

        //private void Cancelar()
        //{
        //    Vista = Vista.Lista;
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
        //}

        //private void VerAgregar()
        //{
        //    esper = new Espers();
        //    Vista = Vista.Agregar;
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
        //}
        private void Actualizar()
        {
            Espers.Clear();
            foreach (Espers espers in repository.GetAll())
            {
                Espers.Add(espers);
            }

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
        }
    }
}
