using Repaso.Dato;
using Repaso.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Repaso.Controllers
{
    public class AccesorioController : Controller
    {
        AccesorioAdmin admin = new AccesorioAdmin();
        private IEnumerable<SelectListItem> vehiculos;
        public void LlenarCombo()
        {
            vehiculos = new VehiculoAdmin().Consultar().ToList().Select(p => new SelectListItem { Value = p.Id.ToString(), Text = p.marca + " " + p.precio }); ;

        }
        // GET: Accesorio
        public ActionResult Index()
        {

            return View(admin.Consultar());
        }
        public ActionResult Guardar() {
            LlenarCombo();
            VehiculoAccesorioModel modelo = new VehiculoAccesorioModel() {
                ListadoVehiculos = vehiculos
            };
            ViewBag.mensaje = "";
            return View(modelo);
        }
        public ActionResult Nuevo(VehiculoAccesorioModel modelo) {
            //Accesorio modeloAux = modelo.accesorio;
            Accesorio modeloAux = new Accesorio() {
                idvehiculo = modelo.accesorio.idvehiculo,
                nombre = modelo.accesorio.nombre
            };
            admin.Guardar(modeloAux);
            LlenarCombo();
            //modelo.ListadoVehiculos = vehiculos;
            modelo = new VehiculoAccesorioModel() {
                ListadoVehiculos = vehiculos
            };
            ViewBag.mensaje = "Accesorio Guardado";
            return View("Guardar", modelo);
        }
        public ActionResult Modificar(int id=0) {
            LlenarCombo();
            VehiculoAccesorioModel modelo = new VehiculoAccesorioModel()
            {
                ListadoVehiculos = vehiculos,
                accesorio=admin.Consultar(id)
            };
            ViewBag.mensaje = "";
            return View(modelo);
        }
        public ActionResult Actualizar(VehiculoAccesorioModel modelo) {
            Accesorio modeloAux = new Accesorio()
            {
                idvehiculo = modelo.accesorio.idvehiculo,
                nombre = modelo.accesorio.nombre,
                Id=modelo.accesorio.Id
            };
            admin.Modificar(modeloAux);
            LlenarCombo();
            modelo.ListadoVehiculos = vehiculos;            
            ViewBag.mensaje = "Accesorio Modificado";
            return View("Modificar", modelo);
        }

    }
}