using BusinessLayer.Controladores;
using SHARE.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace WebPresentation
{
    public class SensoresController : Controller
    {
        private BLVehiculo vehi = new BLVehiculo();

        // GET: Sensores
        public ActionResult Index(int id)
        {
            var vehiculo = vehi.GetVehiculo(id);    //Sensores.Include(s => s.Vehiculos);
            return View();
        }

        // GET: Sensores/Details/5
        public ActionResult Details(int idvehi, int idsen)
        {
            var vehiculo = vehi.GetVehiculo(idvehi);
            var sensores = vehiculo.Lista_Sensores.Find(x => x.Id == idsen);
            if (idvehi == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Sensores sensores = db.Sensores.Find(id);
            if (sensores == null)
            {
                return HttpNotFound();
            }
            return View(sensores);
        }

        // GET: Sensores/Create
        public ActionResult Create()
        {
            var vehiculos = vehi.GetAllVehiculos();
            ViewBag.Id_Vehiculo = new SelectList(vehiculos, "Id", "Marca");
            return View();
        }

        // POST: Sensores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Api,Maximo,Minimo,Envio_Siempre,Frecuencia,Activo,Id_Vehiculo,Tipo_Sensor")] Sensor sensores, int idvehi)
        {
            var vehiculo = vehi.GetVehiculo(idvehi);
            var vehiculos = vehi.GetAllVehiculos();
            if (ModelState.IsValid)
            {
                vehiculo.Lista_Sensores.Add(sensores);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Vehiculo = new SelectList(vehiculos, "Id", "Marca", sensores.VehiculoRef);
            return View(sensores);
        }

        // GET: Sensores/Edit/5
        public ActionResult Edit(int idvehi, int idsen)
        {
            var vehiculo = vehi.GetVehiculo(idvehi);
            var vehiculos = vehi.GetAllVehiculos();
            var sensores = vehiculo.Lista_Sensores.Find(x => x.Id == idsen);
            if (idvehi == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Sensores sensores = db.Sensores.Find(id);
            if (sensores == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Vehiculo = new SelectList(vehiculos, "Id", "Marca", sensores.VehiculoRef);
            return View(sensores);
        }

        // POST: Sensores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Api,Maximo,Minimo,Envio_Siempre,Frecuencia,Activo,Id_Vehiculo,Tipo_Sensor")] Sensor sensores)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(sensores).State = EntityState.Modified;
                //db.SaveChanges();
                //return RedirectToAction("Index");
            }
            //ViewBag.Id_Vehiculo = new SelectList(db.Vehiculos, "Id", "Marca", sensores.Id_Vehiculo);
            return View(sensores);
        }

        // GET: Sensores/Delete/5
        public ActionResult Delete(int idvehi, int idsen)
        {
            var vehiculo = vehi.GetVehiculo(idvehi);
            var sensores = vehiculo.Lista_Sensores.Find(x => x.Id == idsen);
            if (idvehi == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Sensores sensores = db.Sensores.Find(id);
            if (sensores == null)
            {
                return HttpNotFound();
            }
            return View(sensores);
        }

        // POST: Sensores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int idvehi, int idsen)
        {
            var vehiculo = vehi.GetVehiculo(idvehi);
            var sensores = vehiculo.Lista_Sensores.Find(x => x.Id == idsen);
            vehiculo.Lista_Sensores.Remove(sensores);
            //db.SaveChanges();
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
