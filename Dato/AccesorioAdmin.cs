using Repaso.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Repaso.Dato
{
    public class AccesorioAdmin
    {
        /// <summary>
        /// Consulta todos los accesorios
        /// </summary>
        /// <returns>Datos de los accesorios</returns>
        public IEnumerable<Accesorio> Consultar() {
            using (RepasodbEntities contexto = new RepasodbEntities()) {
                return contexto.Accesorio.AsNoTracking().ToList();
            }
        }
        /// <summary>
        /// Consulta un acccesorio
        /// </summary>
        /// <param name="id">Id del accesorio</param>
        /// <returns>Datos del accesorio</returns>
        public Accesorio Consultar(int id) {
            using (RepasodbEntities contexto = new RepasodbEntities()) {
                return contexto.Accesorio.AsNoTracking().FirstOrDefault(a=>a.Id==id);
            }
        } 
        /// <summary>
        /// Guarda un accesorio
        /// </summary>
        /// <param name="modelo">Datos del accesorio</param>
        public void Guardar(Accesorio modelo) {
            using (RepasodbEntities contexto = new RepasodbEntities()) {
                contexto.Accesorio.Add(modelo);
                contexto.SaveChanges();
            }
        }
        /// <summary>
        /// Modifica un accesorio
        /// </summary>
        /// <param name="modelo">Datos del accesorio</param>
        public void Modificar(Accesorio modelo) {
            using (RepasodbEntities contexto = new RepasodbEntities()) {
                contexto.Entry(modelo).State = System.Data.Entity.EntityState.Modified;
                contexto.SaveChanges();
            }
        } 
        /// <summary>
        /// Elimina un accesorio
        /// </summary>
        /// <param name="modelo">Datos del accesorio</param>
        public void Eliminar(Accesorio modelo) {
            using (RepasodbEntities contexto = new RepasodbEntities()) {
                contexto.Entry(modelo).State = System.Data.Entity.EntityState.Deleted;
                contexto.SaveChanges();
            }
        }


    }
}