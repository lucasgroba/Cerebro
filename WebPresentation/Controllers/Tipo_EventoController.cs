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
    public class Tipo_EventoController : Controller
    {
        private BLVehiculo vehi = new BLVehiculo();

        // GET: Tipo_Evento
        public ActionResult Index(int id)
        {
            var vehiculo = vehi.GetVehiculo(id);
            return View(vehiculo.Lista_Tipo_Eventos);
        }

        // GET: Tipo_Evento/Details/5
        public ActionResult Details(int idvehi, int idtsen)
        {
            var vehiculo = vehi.GetVehiculo(idvehi);
            var tsensor = vehiculo.Lista_Tipo_Eventos.Find(x => x.Id == idtsen);
            if (idvehi == 0)
                if (idtsen == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           // Tipo_Eventos tipo_Eventos = db.Tipo_Evento.Find(id);
            if (tsensor == null)
            {
                return HttpNotFound();
            }
            return View(tsensor);
        }

        // GET: Tipo_Evento/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tipo_Evento/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Periodo,Maximo,Minimo,Accion,Activo")] Tipo_Evento tipo_Eventos, int idvehi)
        {
            if (ModelState.IsValid)
            {
                var vehiculo = vehi.GetVehiculo(idvehi);
                var vehiculos = vehi.GetAllVehiculos();
               // db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipo_Eventos);
        }

        // GET: Tipo_Evento/Edit/5
        public ActionResult Edit(int idvehi, int idtsen)
        {
            var vehiculo = vehi.GetVehiculo(idvehi);
            var vehiculos = vehi.GetAllVehiculos();
            var tsensor = vehiculo.Lista_Tipo_Eventos.Find(x => x.Id == idtsen);
            if (idvehi == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //tsensor tipo_Eventos = db.Tipo_Evento.Find(id);
            if (tsensor == null)
            {
                return HttpNotFound();
            }
            return View(tsensor);
        }

        // POST: Tipo_Evento/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Periodo,Maximo,Minimo,Accion,Activo")] Tipo_Evento tipo_Eventos)
        {
            if (ModelState.IsValid)
            {
               // db.Entry(tipo_Eventos).State = EntityState.Modified;
                //db.SaveChanges();
                //return RedirectToAction("Index");
            }
            return View(tipo_Eventos);
        }

        // GET: Tipo_Evento/Delete/5
        public ActionResult Delete(int idvehi, int idtsen)
        {
            var vehiculo = vehi.GetVehiculo(idvehi);
            var tsensor = vehiculo.Lista_Tipo_Eventos.Find(x => x.Id == idtsen);
            if (idvehi == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Tipo_Eventos tipo_Eventos = db.Tipo_Evento.Find(id);
            if (tsensor == null)
            {
                return HttpNotFound();
            }
            return View(tsensor);
        }

        // POST: Tipo_Evento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int idvehi, int idtsen)
        {
            var vehiculo = vehi.GetVehiculo(idvehi);
            var tsensor = vehiculo.Lista_Tipo_Eventos.Find(x => x.Id == idtsen);
            vehiculo.Lista_Tipo_Eventos.Remove(tsensor);
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
