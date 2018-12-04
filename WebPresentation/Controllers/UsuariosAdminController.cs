using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SHARE.Entities;
using WebPresentation.Models;
using BusinessLayer.Controladores;

namespace WebPresentation
{
    [Authorize(Roles = "A,S")]
    public class UsuariosAdminController : Controller
    {
        private List<SelectListItem> options = new List<SelectListItem>();
        
        private BLUsuario BLU = new BLUsuario();
        private BLEmpresa BLE = new BLEmpresa();
        public ActionResult Index()
        {

            return View(BLU.GetAllUsuarios());
        }

        // GET: Vehiculos/Edit/5
        public ActionResult Edit(String id)
        {

            options.Add(new SelectListItem() { Text = "SuperAdmin", Value = "S" });
            options.Add(new SelectListItem() { Text = "Administrador", Value = "A" });
            options.Add(new SelectListItem() { Text = "Visualizador", Value = "V" });

            var usuario = BLU.GetUsuario(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmpresaRef = new SelectList(BLE.GetAllEmpresas(), "RUT", "Nombre");
            ViewBag.Options = options;
            return View(usuario);
        }

        // POST: Vehiculos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,mail,pass,Tipo_User,EmpresaRef")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                BLU.UpdateUsuario(usuario); 
                return RedirectToAction("Index");
            }
            return View(usuario);
        }


        // GET: Vehiculos/Delete/5
        public ActionResult Delete( String id)
        {

            
            if (id.Equals(""))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                return View(BLU.GetUsuario(id));
            }
        }

        // POST: Vehiculos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            BLU.DeleteUsuario(id);
            return RedirectToAction("Index");
        }
    }
}
