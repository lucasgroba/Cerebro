using System.Net;
using System.Web.Mvc;
using BusinessLayer.Controladores;
using SHARE.Entities;

namespace WebPresentation
{
    public class VehiculosController : Controller
    {
        private BLEmpresa emp = new BLEmpresa();
        private BLVehiculo vehi = new BLVehiculo();

        // GET: Vehiculos
        public ActionResult Index()
        {
            var vehiculos = vehi.GetAllVehiculos();
            return View(vehiculos);
        }

        // GET: Vehiculos/Details/5
        public ActionResult Details(int id)
        {
            var vehiculo = vehi.GetVehiculo(id);    //empresa.Lista_Vehiculos.Find(s => s.Id == idvehi);
            if (id == 0)
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
        public ActionResult Create([Bind(Include = "Marca,Modelo,Id_Empleado,Activo,EmpresaRef")] Vehiculo vehiculo)
        {
            if (ModelState.IsValid)
            {
                vehi.AltaVehiculo(vehiculo);
                return RedirectToAction("Index");
            }

            return View(vehiculo);
        }

        // GET: Vehiculos/Edit/5
        public ActionResult Edit(int id)
        {
            var vehiculo = vehi.GetVehiculo(id); //empresa.Lista_Vehiculos.Find(s => s.Id == idvehi);
            if (id == 0)
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
        public ActionResult Edit([Bind(Include = "Marca,Modelo,Id_Empleado,Activo,EmpresaRef")] Vehiculo vehiculo)
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
            var vehiculo = vehi.GetVehiculo(id);   //empresa.Lista_Vehiculos.Find(s => s.Id == idvehi);
            if (id == 0)
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
