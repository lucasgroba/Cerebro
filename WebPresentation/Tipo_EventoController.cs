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
    public class Tipo_EventoController : Controller
    {
        private CEREBROEntities1 db = new CEREBROEntities1();

        // GET: Tipo_Evento
        public ActionResult Index()
        {
            return View(db.Tipo_Evento.ToList());
        }

        // GET: Tipo_Evento/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_Eventos tipo_Eventos = db.Tipo_Evento.Find(id);
            if (tipo_Eventos == null)
            {
                return HttpNotFound();
            }
            return View(tipo_Eventos);
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
        public ActionResult Create([Bind(Include = "Id,Periodo,Maximo,Minimo,Accion,Activo")] Tipo_Eventos tipo_Eventos)
        {
            if (ModelState.IsValid)
            {
                db.Tipo_Evento.Add(tipo_Eventos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipo_Eventos);
        }

        // GET: Tipo_Evento/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_Eventos tipo_Eventos = db.Tipo_Evento.Find(id);
            if (tipo_Eventos == null)
            {
                return HttpNotFound();
            }
            return View(tipo_Eventos);
        }

        // POST: Tipo_Evento/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Periodo,Maximo,Minimo,Accion,Activo")] Tipo_Eventos tipo_Eventos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipo_Eventos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipo_Eventos);
        }

        // GET: Tipo_Evento/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_Eventos tipo_Eventos = db.Tipo_Evento.Find(id);
            if (tipo_Eventos == null)
            {
                return HttpNotFound();
            }
            return View(tipo_Eventos);
        }

        // POST: Tipo_Evento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tipo_Eventos tipo_Eventos = db.Tipo_Evento.Find(id);
            db.Tipo_Evento.Remove(tipo_Eventos);
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
