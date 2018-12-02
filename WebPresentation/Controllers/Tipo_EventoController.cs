using BusinessLayer.Controladores;
using SHARE.Entities;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;

namespace WebPresentation
{
    public class Tipo_EventoController : Controller
    {
        private BLVehiculo vehi = new BLVehiculo();
        private BLTipo_Evento teven = new BLTipo_Evento();
        private List<SelectListItem> Options = new List<SelectListItem>();
        private List<SelectListItem> OptionsAction = new List<SelectListItem>();


        // GET: Tipo_Evento
        public ActionResult Index()
        {
            var teventos = teven.GetAllTipo_Eventos(); 
            return View(teventos);
        }

        // GET: Tipo_Evento/Details/5
        public ActionResult Details(int id)
        {
            //var vehiculo = vehi.GetVehiculo(idvehi);
            var tevento = teven.GetTipo_Evento(id); //vehiculo.Lista_Tipo_Eventos.Find(x => x.Id == idtsen);
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           // Tipo_Eventos tipo_Eventos = db.Tipo_Evento.Find(id);
            if (tevento == null)
            {
                return HttpNotFound();
            }
            return View(tevento);
        }

        // GET: Tipo_Evento/Create
        public ActionResult Create()
        {
            OptionsAction.Add(new SelectListItem() { Text = "Mail", Value = "M" });
            OptionsAction.Add(new SelectListItem() { Text = "Evento", Value = "E" });

            Options.Add(new SelectListItem() { Text = "Velocidad", Value = "V" });
            Options.Add(new SelectListItem() { Text = "Aceleracion", Value = "A" });
            Options.Add(new SelectListItem() { Text = "Presion", Value = "P" });
            Options.Add(new SelectListItem() { Text = "Temperatura", Value = "T" });
            Options.Add(new SelectListItem() { Text = "Alarma", Value = "S" });
            Options.Add(new SelectListItem() { Text = "Combustible", Value = "C" });

            ViewBag.OptionsAction = OptionsAction;
            ViewBag.Options = Options;

            return View();
        }

        // POST: Tipo_Evento/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Periodo,Nombre,Maximo,Minimo,Accion,Activo,TipoLectura")] Tipo_Evento tipo_Evento)
        {
            //var tipo_eventos = teven.GetAllTipo_Eventos();
            if (ModelState.IsValid)
            {
                teven.AltaVehiculo(tipo_Evento);
                return RedirectToAction("Index");
            }

            return View(tipo_Evento);
        }

        // GET: Tipo_Evento/Edit/5
        public ActionResult Edit(int id)
        {
            OptionsAction.Add(new SelectListItem() { Text = "Mail", Value = "M" });
            OptionsAction.Add(new SelectListItem() { Text = "Evento", Value = "E" });

            Options.Add(new SelectListItem() { Text = "Velocidad", Value = "V" });
            Options.Add(new SelectListItem() { Text = "Aceleracion", Value = "A" });
            Options.Add(new SelectListItem() { Text = "Presion", Value = "P" });
            Options.Add(new SelectListItem() { Text = "Temperatura", Value = "T" });
            Options.Add(new SelectListItem() { Text = "Alarma", Value = "S" });
            Options.Add(new SelectListItem() { Text = "Combustible", Value = "C" });

            ViewBag.OptionsAction = OptionsAction;
            ViewBag.Options = Options;

            //var vehiculos = vehi.GetAllVehiculos();
            var tevento = teven.GetTipo_Evento(id);// vehiculo.Lista_Tipo_Eventos.Find(x => x.Id == idtsen);
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //tsensor tipo_Eventos = db.Tipo_Evento.Find(id);
            if (tevento == null)
            {
                return HttpNotFound();
            }
            return View(tevento);
        }

        // POST: Tipo_Evento/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Periodo,Nombre,Maximo,Minimo,Accion,Activo,TipoLectura")] Tipo_Evento tipo_Eventos)
        {
            if (ModelState.IsValid)
            {
                teven.UpdateTipo_Evento(tipo_Eventos);
                return RedirectToAction("Index");
            }
            return View(tipo_Eventos);
        }

        // GET: Tipo_Evento/Delete/5
        public ActionResult Delete(int id)
        {
            var tevento = teven.GetTipo_Evento(id); //vehiculo.Lista_Tipo_Eventos.Find(x => x.Id == idtsen);
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Tipo_Eventos tipo_Eventos = db.Tipo_Evento.Find(id);
            if (tevento == null)
            {
                return HttpNotFound();
            }
            return View(tevento);
        }

        // POST: Tipo_Evento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            teven.DeleteTipo_Evento(id);
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
