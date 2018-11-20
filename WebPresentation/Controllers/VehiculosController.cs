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

namespace WebPresentation
{
    public class VehiculosController : Controller
    {
        private BLEmpresa emp = new BLEmpresa();

        // GET: Vehiculos
        public ActionResult Index(int id)
        {
            var vehiculos = emp.GetEmpresa(id);          //Vehiculos.Include(v => v.Empresas);
            return View(vehiculos.Lista_Vehiculos);
        }

        // GET: Vehiculos/Details/5
        public ActionResult Details(int idemp, int idvehi)
        {
            var empresa = emp.GetEmpresa(idemp);
            var vehiculos = empresa.Lista_Vehiculos.Find(x => x.Id == idvehi);
            if (idemp == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //BLVehiculo vehiculos = empresa.Lista_Vehiculos.Find(id);
            if (vehiculos == null)
            {
                return HttpNotFound();
            }
            return View(vehiculos);
        }

        // GET: Vehiculos/Create
        public ActionResult Create()
        {
            var empresas = emp.GetAllEmpresas();

            ViewBag.RUT_Empresa = new SelectList(empresas, "RUT", "Nombre");
            return View();
        }

        // POST: Vehiculos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Marca,Modelo,Id_Empleado,Activo,RUT_Empresa")] Vehiculo vehiculos, int idemp)
        {
            var empresa = emp.GetEmpresa(idemp);
            var empresas = emp.GetAllEmpresas();
            if (ModelState.IsValid)
            {
                empresa.Lista_Vehiculos.Add(vehiculos);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RUT_Empresa = new SelectList(empresas, "RUT", "Nombre", vehiculos.EmpresaRef);
            return View(vehiculos);
        }

        // GET: Vehiculos/Edit/5
        public ActionResult Edit(int idemp, int idvehi)
        {
            var empresa = emp.GetEmpresa(idemp);
            var empresas = emp.GetAllEmpresas();
            var vehiculos = empresa.Lista_Vehiculos.Find(x => x.Id == idvehi);
            if (idemp == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Vehiculos vehiculos = db.Vehiculos.Find(id);
            if (vehiculos == null)
            {
                return HttpNotFound();
            }
            ViewBag.RUT_Empresa = new SelectList(empresas, "RUT", "Nombre", vehiculos.EmpresaRef);
            return View(vehiculos);
        }

        // POST: Vehiculos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Marca,Modelo,Id_Empleado,Activo,RUT_Empresa")] Vehiculo vehiculos)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(vehiculos).State = EntityState.Modified;
                //db.SaveChanges();
                //return RedirectToAction("Index");
            }
            //ViewBag.RUT_Empresa = new SelectList(db.Empresas, "RUT", "Nombre", vehiculos.RUT_Empresa);
            return View(vehiculos);
        }

        // GET: Vehiculos/Delete/5
        public ActionResult Delete(int idemp, int idvehi)
        {
            var empresa = emp.GetEmpresa(idemp);
            var vehiculos = empresa.Lista_Vehiculos.Find(x => x.Id == idvehi);
            if (idemp == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Vehiculos vehiculos = db.Vehiculos.Find(id);
            if (vehiculos == null)
            {
                return HttpNotFound();
            }
            return View(vehiculos);
        }

        // POST: Vehiculos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int idemp, int idvehi)
        {
            var empresa = emp.GetEmpresa(idemp);
            var vehiculos = empresa.Lista_Vehiculos.Find(x => x.Id == idvehi);
            empresa.Lista_Vehiculos.Remove(vehiculos);
            //db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
              //  db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
