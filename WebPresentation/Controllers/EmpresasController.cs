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
    public class EmpresasController : Controller
    {
        private BLEmpresa emp = new BLEmpresa();

        // GET: Empresas
        public ActionResult Index()
        {
            var empresas = emp.GetAllEmpresas();
            return View(empresas);
        }

        // GET: Empresas/Details/5
        public ActionResult Details(int id)
        {
            var empresas = emp.GetAllEmpresas();
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empresa empre = empresas.Find(x => x.RUT == id);
            if (empresas == null)
            {
                return HttpNotFound();
            }
            return View(empresas);
        }

        // GET: Empresas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Empresas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RUT,Nombre,Zona_Latitud,Zona_Longitud,Activo")] Empresa empresa)
        {
            var empresas = emp.GetAllEmpresas();
            if (ModelState.IsValid)
            {
                empresas.Remove(empresa);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(empresas);
        }

        // GET: Empresas/Edit/5
        public ActionResult Edit(int id)
        {
            var empresas = emp.GetAllEmpresas();
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empresa empre = empresas.Find(x => x.RUT == id);
            if (empresas == null)
            {
                return HttpNotFound();
            }
            return View(empresas);
        }

        // POST: Empresas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RUT,Nombre,Zona_Latitud,Zona_Longitud,Activo")] Empresa empresas)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(empresas).State = EntityState.Modified;
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(empresas);
        }

        // GET: Empresas/Delete/5
        public ActionResult Delete(int id)
        {
            var empresas = emp.GetAllEmpresas();
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empresa empresa = empresas.Find(x => x.RUT == id);
            if (empresas == null)
            {
                return HttpNotFound();
            }
            return View(empresas);
        }

        // POST: Empresas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var empresas = emp.GetAllEmpresas();
            var empre = empresas.Find(x => x.RUT == id);
            empresas.Remove(empre);
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
