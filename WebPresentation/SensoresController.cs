using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataAccessLayer;

namespace WebPresentation
{
    public class SensoresController : Controller
    {
        private CEREBROEntities1 db = new CEREBROEntities1();

        // GET: Sensores
        public ActionResult Index()
        {
            var sensores = db.Sensores.Include(s => s.Vehiculos);
            return View(sensores.ToList());
        }

        // GET: Sensores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sensores sensores = db.Sensores.Find(id);
            if (sensores == null)
            {
                return HttpNotFound();
            }
            return View(sensores);
        }

        // GET: Sensores/Create
        public ActionResult Create()
        {
            ViewBag.Id_Vehiculo = new SelectList(db.Vehiculos, "Id", "Marca");
            return View();
        }

        // POST: Sensores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Api,Maximo,Minimo,Envio_Siempre,Frecuencia,Activo,Id_Vehiculo,Tipo_Sensor")] Sensores sensores)
        {
            if (ModelState.IsValid)
            {
                db.Sensores.Add(sensores);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Vehiculo = new SelectList(db.Vehiculos, "Id", "Marca", sensores.Id_Vehiculo);
            return View(sensores);
        }

        // GET: Sensores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sensores sensores = db.Sensores.Find(id);
            if (sensores == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Vehiculo = new SelectList(db.Vehiculos, "Id", "Marca", sensores.Id_Vehiculo);
            return View(sensores);
        }

        // POST: Sensores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Api,Maximo,Minimo,Envio_Siempre,Frecuencia,Activo,Id_Vehiculo,Tipo_Sensor")] Sensores sensores)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sensores).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Vehiculo = new SelectList(db.Vehiculos, "Id", "Marca", sensores.Id_Vehiculo);
            return View(sensores);
        }

        // GET: Sensores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sensores sensores = db.Sensores.Find(id);
            if (sensores == null)
            {
                return HttpNotFound();
            }
            return View(sensores);
        }

        // POST: Sensores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sensores sensores = db.Sensores.Find(id);
            db.Sensores.Remove(sensores);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
