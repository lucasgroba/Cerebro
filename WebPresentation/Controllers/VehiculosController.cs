using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Controladores;
using SHARE.Entities;
using WebPresentation.Models;

namespace WebPresentation
{
    [Authorize(Roles = "A")]
    public class VehiculosController : Controller
    {
        private BLEmpresa emp = new BLEmpresa();

        // GET: Vehiculos
        public ActionResult Index(int idemp)
        {
            var empresa = emp.GetEmpresa(idemp);
            return View(empresa.Lista_Vehiculos);
        }

        // GET: Vehiculos/Details/5
        public ActionResult Details(int idemp, int idvehi)
        {
            var empresa = emp.GetEmpresa(idemp);
            var vehiculo = empresa.Lista_Vehiculos.Find(s => s.Id == idvehi);
            if (idemp == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Vehiculo vehiculo = db.Vehiculoes.Find(id);
            if (vehiculo == null)
            {
                return HttpNotFound();
            }
            return View(vehiculo);
        }

        // GET: Vehiculos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vehiculos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Marca,Modelo,Id_Empleado,Activo,EmpresaRef")] Vehiculo vehiculo, int idemp)
        {
            var empresa = emp.GetEmpresa(idemp);
            if (ModelState.IsValid)
            {
                empresa.Lista_Vehiculos.Add(vehiculo);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vehiculo);
        }

        // GET: Vehiculos/Edit/5
        public ActionResult Edit(int idemp, int idvehi)
        {
            var empresa = emp.GetEmpresa(idemp);
            var vehiculo = empresa.Lista_Vehiculos.Find(s => s.Id == idvehi);
            if (idemp == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Vehiculo vehiculo = db.Vehiculoes.Find(id);
            if (vehiculo == null)
            {
                return HttpNotFound();
            }
            return View(vehiculo);
        }

        // POST: Vehiculos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Marca,Modelo,Id_Empleado,Activo,EmpresaRef")] Vehiculo vehiculo)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(vehiculo).State = EntityState.Modified;
                //db.SaveChanges();
                //return RedirectToAction("Index");
            }
            return View(vehiculo);
        }

        // GET: Vehiculos/Delete/5
        public ActionResult Delete(int idemp, int idvehi)
        {
            var empresa = emp.GetEmpresa(idemp);
            var vehiculo = empresa.Lista_Vehiculos.Find(s => s.Id == idvehi);
            if (idemp == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Vehiculo vehiculo = db.Vehiculoes.Find(id);
            if (vehiculo == null)
            {
                return HttpNotFound();
            }
            return View(vehiculo);
        }

        // POST: Vehiculos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int idemp, int idvehi)
        {
            var empresa = emp.GetEmpresa(idemp);
            var vehiculo = empresa.Lista_Vehiculos.Find(s => s.Id == idvehi);
            empresa.Lista_Vehiculos.Remove(vehiculo);
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
