using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Repaso.Models
{
    public class VehiculoAccesorioModel
    {
        public Accesorio accesorio { get; set; }
        public IEnumerable<SelectListItem> ListadoVehiculos { get; set; }
    }
}