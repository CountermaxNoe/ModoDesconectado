using Ej2PlantaDocente.Models;
using Ej2PlantaDocente.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Ej2PlantaDocente.ViewModel
{
    public class PlantaDocenteViewModel: INotifyPropertyChanged
    {
        /*ListaCordinaciones:List<Coordinaciones>
        CordinadorAcademico: Coordinaciones
        ListaDocentes: List<Docentes>*/
        //cargar las coordinaciones cuandi inicie la ejecucion de las vistas en el econstructor

        CoordinacionesRepositories reposCoordinacion = new CoordinacionesRepositories();
        DocentesRepositories reposdocente = new DocentesRepositories();
        public List<Docentes> ListaDocentes { get; set; }= new List<Docentes>();

        public Coordinaciones? coordinador;
        public Coordinaciones? CordinadorAcademico
        {
            get
            {
                return coordinador;
            }
            set 
            {
                coordinador=value;
                GetDocenteByCoordinador();
            }
        }

        private void GetDocenteByCoordinador()
        {
            if (coordinador != null)
            {
                ListaDocentes=reposdocente.GetDocentesByCoordinacion(coordinador).ToList();
                PropertyChanged?.Invoke(this, new(nameof(ListaDocentes)));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public List<Coordinaciones> ListaCordinaciones { get; set; }=new List<Coordinaciones>();

        public PlantaDocenteViewModel() 
        {
            ListaCordinaciones = reposCoordinacion.GetAll().ToList();
        }
    }
}
