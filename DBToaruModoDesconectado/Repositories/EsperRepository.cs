using DBToaruModoDesconectado.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBToaruModoDesconectado.Repositories
{
    public class EsperRepository
    {
        ToaruContext context = new();

        public IEnumerable<Espers> GetAll()
        {
            return context.Espers.OrderBy(x => x.Nombre);
        }
        public void Agregar(Espers p)
        {
            context.Espers.Add(p);
            context.SaveChanges();
        }
        public void Eliminar(Espers p)
        {
            context.Espers.Remove(p);
            context.SaveChanges();
        }
    }
}
