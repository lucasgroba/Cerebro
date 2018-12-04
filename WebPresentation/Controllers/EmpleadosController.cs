using System.Net;
using System.Web.Mvc;
using BusinessLayer.Controladores;
using SHARE.Entities;

namespace WebPresentation
{
    [Authorize(Roles = "A")]
    public class EmpleadosController : Controller
    {
        private BLEmpresa emp = new BLEmpresa();
        private BLEmpleado emple = new BLEmpleado(); 

        // GET: Empleados
        public ActionResult Index()
        {
            var empleados = emple.GetAllEmpleados();
            return View(empleados);
        }

        // GET: Empleados/Details/5
        public ActionResult Details(int id)
        {
            var empleados = emple.GetAllEmpleados();
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = emple.GetEmpleado(id);  
            if (empleados == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
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
        public ActionResult Create([Bind(Include = "Nombre,Fecha_Nac,Tel,Direccion,Activo,RUT_Empresa")] Empleado empleado)
        {
            var empleados = emple.GetAllEmpleados();
            if (ModelState.IsValid)
            {
                emple.AltaEmpleado(empleado);
                return RedirectToAction("Index");
            }

            return View(empleados);
        }

        // GET: Empleados/Edit/5
        public ActionResult Edit(int id)
        {
            var empresas = emp.GetAllEmpresas();
            var empleado = emple.GetEmpleado(id);  
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (empleado == null)
            {
                return HttpNotFound();
            }
            ViewBag.RUT_Empresa = new SelectList(emp.GetAllEmpresas(), "RUT", "Nombre");
            return View(empleado);
        }

        // POST: Empleados/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CI,Nombre,Fecha_Nac,Tel,Direccion,Activo,RUT_Empresa")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                emple.UpdateEmpleado(empleado);
                return RedirectToAction("Index");
            }
            return View(empleado);
        }

        // GET: Empleados/Delete/5
        public ActionResult Delete(int id )
        {
            var empleados = emple.GetAllEmpleados();
            var empleado = emple.GetEmpleado(id);  
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        // POST: Empleados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            emple.DeleteEmpleado(id);
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
