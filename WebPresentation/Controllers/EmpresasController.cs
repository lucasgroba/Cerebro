using BusinessLayer.Controladores;
using SHARE.Entities;
using System.Net;
using System.Web.Mvc;

namespace WebPresentation
{
    [Authorize(Roles = "A,S")]
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
            Empresa empre = emp.GetEmpresa(id);
            if (empresas == null)
            {
                return HttpNotFound();
            }
            return View(empre);
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
        public ActionResult Create([Bind(Include = "Nombre,Zona_Latitud,Zona_Longitud,Activo")] Empresa empresa)
        {
            var empresas = emp.GetAllEmpresas();
            if (ModelState.IsValid)
            {
                emp.AltaEmpresa(empresa);
                return RedirectToAction("Index");
            }

            return View(empresas);
        }

        // GET: Empresas/Edit/5
        public ActionResult Edit(int id)
        {
            Empresa empresa = emp.GetEmpresa(id);
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (empresa == null)
            {
                return HttpNotFound();
            }
            return View(empresa);
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
                emp.UpdateEmpresa(empresas);
                return RedirectToAction("Index");
            }
            return View(empresas);
        }

        // GET: Empresas/Delete/5
        public ActionResult Delete(int id)
        {
            var empresa = emp.GetEmpresa(id);
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (empresa == null)
            {
                return HttpNotFound();
            }
            return View(empresa);
        }

        // POST: Empresas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            emp.DeleteEmpresa(id);
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
