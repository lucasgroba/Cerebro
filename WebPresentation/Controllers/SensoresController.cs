using BusinessLayer.Controladores;
using SHARE.Entities;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;

namespace WebPresentation
{
    public class SensoresController : Controller
    {
        private BLVehiculo vehi = new BLVehiculo();
        private BLSensor sens = new BLSensor();
        private List<SelectListItem> Options = new List<SelectListItem>();
        
        
        // GET: Sensores
        public ActionResult Index()
        {
            var sensores = sens.GetAllSensores(); 
            return View(sensores);
        }

        // GET: Sensores/Details/5
        public ActionResult Details(int id)
        {
            //var vehiculo = vehi.GetVehiculo(idvehi);
            var sensores = sens.GetAllSensores();  
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sensor sensor = sens.GetSensor(id);
            if (sensores == null)
            {
                return HttpNotFound();
            }
            return View(sensor);
        }

        // GET: Sensores/Create
        public ActionResult Create()
        {
            //var vehiculos = vehi.GetAllVehiculos();
            //ViewBag.Id_Vehiculo = new SelectList(vehiculos, "Id", "Marca");
            
            Options.Add(new SelectListItem() { Text = "GPS", Value = "G" });
            Options.Add(new SelectListItem() { Text = "Motor", Value = "M" });
            Options.Add(new SelectListItem() { Text = "Seguridad", Value = "S" });
            Options.Add(new SelectListItem() { Text = "Combustible", Value = "C" });
            ViewBag.Options = Options;
            return View();
        }

        // POST: Sensores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Api,Maximo,Minimo,Envio_Siempre,Frecuencia,Activo,VehiculoRef,Tipo_Sensor")] Sensor sensores)
        {
            var vehiculos = vehi.GetAllVehiculos();
            if (ModelState.IsValid)
            {
                sens.AltaSensor(sensores);
                return RedirectToAction("Index");
            }

            //ViewBag.Id_Vehiculo = new SelectList(vehiculos, "Id", "Marca", sensores.VehiculoRef);
            return View(vehiculos);
        }

        // GET: Sensores/Edit/5
        public ActionResult Edit(int id)
        {
            Options.Add(new SelectListItem() { Text = "GPS", Value = "G" });
            Options.Add(new SelectListItem() { Text = "Motor", Value = "M" });
            Options.Add(new SelectListItem() { Text = "Seguridad", Value = "S" });
            Options.Add(new SelectListItem() { Text = "Combustible", Value = "C" });
            ViewBag.Options = Options;

            //var vehiculos = vehi.GetAllVehiculos();
            Sensor sensor = sens.GetSensor(id);  //vehiculo.Lista_Sensores.Find(x => x.Id == idsen);
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Sensores sensores = db.Sensores.Find(id);
            if (sensor == null)
            {
                return HttpNotFound();
            }
           // ViewBag.Id_Vehiculo = new SelectList(vehiculos, "Id", "Marca", sensores.VehiculoRef);
            return View(sensor);
        }

        // POST: Sensores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Api,Maximo,Minimo,Envio_Siempre,Frecuencia,Activo,VehiculoRef,Tipo_Sensor")] Sensor sensores)
        {
            //var vehiculos = vehi.GetAllVehiculos();
            if (ModelState.IsValid)
            {
                sens.UpdateSensor(sensores);
                return RedirectToAction("Index");
            }
            //ViewBag.Id_Vehiculo = new SelectList(vehiculos, "Id", "Marca", sensores.VehiculoRef);
            return View(sensores);
        }

        // GET: Sensores/Delete/5
        public ActionResult Delete(int id)
        {
            //var vehiculo = vehi.GetVehiculo(idvehi);
            var sensor = sens.GetSensor(id);  //vehiculo.Lista_Sensores.Find(x => x.Id == idsen);
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Sensores sensores = db.Sensores.Find(id);
            if (sensor == null)
            {
                return HttpNotFound();
            }
            return View(sensor);
        }

        // POST: Sensores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            sens.DeleteSensor(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
