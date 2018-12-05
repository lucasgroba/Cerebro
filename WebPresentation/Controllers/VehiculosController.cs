using System.Net;
using System.Web.Mvc;
using BusinessLayer.Controladores;
using SHARE.Entities;
using WebPresentation.ManejoPermisos;

namespace WebPresentation
{
    //[Authorize(Roles = "A")]
    public class VehiculosController : Controller
    {
        private BLEmpresa emp = new BLEmpresa();
        private BLVehiculo vehi = new BLVehiculo();
        private BLEmpleado emple = new BLEmpleado();
        private Empresa empre = new Empresa();

        // GET: Vehiculos
        public ActionResult Index()
        {
            empre = new UserRole().GetEmpresaUser(HttpContext.User.Identity.Name);
            var vehiculos = empre.Lista_Vehiculos;
            //var user = User.Identity.Name;

            return View(vehiculos);
        }

        // GET: Vehiculos/Details/5
        public ActionResult Details(int id)
        {
            var vehiculo = vehi.GetVehiculo(id);   
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (vehiculo == null)
            {
                return HttpNotFound();
            }
            return View(vehiculo);
        }

        // GET: Vehiculos/Create
        public ActionResult Create()
        {
            var empresas = emp.GetAllEmpresas();

            ViewBag.Id_Empleado = new SelectList(emple.GetAllEmpleados(), "CI", "Nombre");
            ViewBag.EmpresaRef = new SelectList(empresas, "RUT", "Nombre");

            return View();
        }

        // POST: Vehiculos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Marca,Modelo,EmpresaRef,Activo,Id_Empleado")] Vehiculo vehiculo)
        {
            var vehiculos = vehi.GetAllVehiculos();
            if (ModelState.IsValid)
            {
                vehi.AltaVehiculo(vehiculo);
                return RedirectToAction("Index");
            }

            return View(vehiculos);
        }

        // GET: Vehiculos/Edit/5
        public ActionResult Edit(int id)
        {
            var vehiculo = vehi.GetVehiculo(id); 
            var empre = vehiculo.EmpresaRef;
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (vehiculo == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Empleado = new SelectList(emp.GetEmpresa(empre).Lista_Empleados, "CI", "Nombre");
            ViewBag.EmpresaRef = new SelectList(emp.GetAllEmpresas(), "RUT", "Nombre");

            return View(vehiculo);
        }

        // POST: Vehiculos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Marca,Modelo,EmpresaRef,Activo,Id_Empleado")] Vehiculo vehiculo)
        {
            if (ModelState.IsValid)
            {
                vehi.UpdateVehiculo(vehiculo);
                return RedirectToAction("Index");
            }
            return View(vehiculo);
        }

        // GET: Vehiculos/Delete/5
        public ActionResult Delete(int id)
        {
            var vehiculo = vehi.GetVehiculo(id);   
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (vehiculo == null)
            {
                return HttpNotFound();
            }
            return View(vehiculo);
        }

        // POST: Vehiculos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            vehi.DeleteVehiculo(id);
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
