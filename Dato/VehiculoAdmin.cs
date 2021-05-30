using Repaso.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Repaso.Dato
{
    public class VehiculoAdmin
    {
        /// <summary>
        /// Consulta todos los vehiculos
        /// </summary>
        /// <returns>datos de los vehiculos</returns>
        public IEnumerable<vehiculo> Consultar() {
            using (RepasodbEntities contexto=new RepasodbEntities()) {
                return contexto.vehiculo.AsNoTracking().ToList();
            }
        }
        /// <summary>
        /// Guarda un vehiculo en la base de datos
        /// </summary>
        /// <param name="modelo">datos del vehiculo</param>
        public void Guardar(vehiculo modelo) {
            using (RepasodbEntities contexto = new RepasodbEntities()) {
                contexto.vehiculo.Add(modelo);
                contexto.SaveChanges();
            }
        }
        /// <summary>
        /// Consulta un vehiculo
        /// </summary>
        /// <param name="id">Id del vehiculo</param>
        /// <returns>datos del vehiculo</returns>
        public vehiculo Consultar(int id) {
            using (RepasodbEntities contexto = new RepasodbEntities()) {
                return contexto.vehiculo.FirstOrDefault(v => v.Id == id);
            }
        }
        /// <summary>
        /// Modifica los datos del vehiculo
        /// </summary>
        /// <param name="modelo">Datos del vehiculo</param>
        public void Modificar(vehiculo modelo) {
            using (RepasodbEntities contexto = new RepasodbEntities()) {
                contexto.Entry(modelo).State = System.Data.Entity.EntityState.Modified;
                contexto.SaveChanges();

            }
        }
        /// <summary>
        /// Elimina un vehiculo
        /// </summary>
        /// <param name="modelo">Vehiculo a eliminar</param>
        public void Eliminar(vehiculo modelo) {
            using (RepasodbEntities contexto = new RepasodbEntities()) {
                contexto.Entry(modelo).State = System.Data.Entity.EntityState.Deleted;
                contexto.SaveChanges();

            }
        }
        /// <summary>
        /// Consulta todos los datos del procedimiento
        /// </summary>
        /// <returns>Datos del vehiculo</returns>
        public IEnumerable<Sp_ConsultarVehiculo2_Result> ConsultarSp() {
            using (RepasodbEntities contexto = new RepasodbEntities()) {
                return contexto.Sp_ConsultarVehiculo2().ToList();
            }
        }
    }
}