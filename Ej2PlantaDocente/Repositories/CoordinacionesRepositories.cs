using Ej2PlantaDocente.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej2PlantaDocente.Repositories
{
    public class CoordinacionesRepositories
    {
        PlantaDocenteContext context= new PlantaDocenteContext();
        public IEnumerable<Coordinaciones> GetAll()
        {
            return context.Coordinaciones.OrderBy(x=>x.Nombre);
        }
    }
}
