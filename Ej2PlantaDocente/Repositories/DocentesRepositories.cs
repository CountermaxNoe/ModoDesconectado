using Ej2PlantaDocente.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej2PlantaDocente.Repositories
{
    public class DocentesRepositories
    {
        PlantaDocenteContext context= new PlantaDocenteContext();
       // public IEnumerable<Docentes> GetDocentesByCoordinacion(string coordinacion)
        //{
         //   return context.Docentes.Where(x => x.IdCoordinacion == coordinacion);
       // }
        public IEnumerable<Docentes> GetDocentesByCoordinacion(Coordinaciones coordinacion)
        {
            return context.Coordinaciones.Where(x => x.Clave == coordinacion.Clave).SelectMany(x => x.Docentes);
        }
    }
}
