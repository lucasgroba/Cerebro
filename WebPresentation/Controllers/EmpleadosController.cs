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
    [Authorize(Roles = "A")]
    public class EmpleadosController : Controller
    {
       private BLEmpresa emp = new BLEmpresa();

        // GET: Empleados
        public ActionResult Index(int id)
        {
            var empresas = emp.GetEmpresa(id);   //   Empleados.Include(e => e.Empresas);
            return View(empresas.Lista_Empleados);
        }

        // GET: Empleados/Details/5
        public ActionResult Details(int idemp, int idemple)
        {
            var empresa = emp.GetEmpresa(idemp);
            var empleados = empresa.Lista_Empleados.Find(x => x.Ci == idemple);
            if (idemp == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //BLEmpleado empleados = db.Empleados.Find(id);
            if (empleados == null)
            {
                return HttpNotFound();
            }
            return View(empleados);
        }

        // GET: Empleados/Create
        public ActionResult Create()
        {
            var empresas = emp.GetAllEmpresas();
  
            ViewBag.RUT_Empresa = new SelectList(empresas, "RUT", "Nombre");
            return View();
        }

        // POST: Empleados/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Ci,Nombre,Fecha_Nac,Tel,Direccion,Activo,RUT_Empresa")] Empleado empleados,int idemp)
        {
            var empresa = emp.GetEmpresa(idemp);
            var empresas = emp.GetAllEmpresas();
            if (ModelState.IsValid)
            {
                empresa.Lista_Empleados.Add(empleados);
                //empresa.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RUT_Empresa = new SelectList(empresas, "RUT", "Nombre", empleados.RUT_Empresa);
            return View(empleados);
        }

        // GET: Empleados/Edit/5
        public ActionResult Edit(int idemp, int idemple)
        {
            var empresa = emp.GetEmpresa(idemp);
            var empresas = emp.GetAllEmpresas();
            var empleados = empresa.Lista_Empleados.Find(x => x.Ci == idemple);
            if (idemp == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Empleados empleados = db.Empleados.Find(id);
            if (empleados == null)
            {
                return HttpNotFound();
            }
            ViewBag.RUT_Empresa = new SelectList(empresas, "RUT", "Nombre", empleados.RUT_Empresa);
            return View(empleados);
        }

        // POST: Empleados/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Ci,Nombre,Fecha_Nac,Tel,Direccion,Activo,RUT_Empresa")] Empleado empleados)
        {
            if (ModelState.IsValid)
            {
                
                //db.Entry(empleados).State = EntityState.Modified;
                //db.SaveChanges();
                //return RedirectToAction("Index");
            }
            //ViewBag.RUT_Empresa = new SelectList(db.Empresas, "RUT", "Nombre", empleados.RUT_Empresa);
            return View(empleados);
        }

        // GET: Empleados/Delete/5
        public ActionResult Delete(int idemp, int idemple )
        {
            var empresa = emp.GetEmpresa(idemp);
            var empleados = empresa.Lista_Empleados.Find(x => x.Ci == idemple);
            if (idemp == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Empleados empleados = db.Empleados.Find(id);
            if (empleados == null)
            {
                return HttpNotFound();
            }
            return View(empleados);
        }

        // POST: Empleados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int idemp, int idemple)
        {
            var empresa = emp.GetEmpresa(idemp);
            var empleados = empresa.Lista_Empleados.Find(x => x.Ci == idemple);
            empresa.Lista_Empleados.Remove(empleados);
            //db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
               // db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
