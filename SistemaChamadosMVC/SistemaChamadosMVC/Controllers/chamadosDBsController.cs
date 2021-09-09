using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SistemaChamadosMVC.Models;

namespace SistemaChamadosMVC.Controllers
{
    public class chamadosDBsController : Controller
    {
        private ExemploBDEntities db = new ExemploBDEntities();

        // GET: chamadosDBs
        public ActionResult Index()
        {
            var chamadosDB = db.chamadosDB.Include(c => c.usuariosDB);
            return View(chamadosDB.ToList());
        }

        // GET: chamadosDBs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            chamadosDB chamadosDB = db.chamadosDB.Find(id);
            if (chamadosDB == null)
            {
                return HttpNotFound();
            }
            return View(chamadosDB);
        }

        // GET: chamadosDBs/Create
        public ActionResult Create()
        {
            ViewBag.usuarioID = new SelectList(db.usuariosDB, "usuarioID", "nome");
            return View();
        }

        // POST: chamadosDBs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "chamadoID,usuarioID,sistemaChamado,descricao")] chamadosDB chamadosDB)
        {
            if (ModelState.IsValid)
            {
                db.chamadosDB.Add(chamadosDB);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.usuarioID = new SelectList(db.usuariosDB, "usuarioID", "nome", chamadosDB.usuarioID);
            return View(chamadosDB);
        }

        // GET: chamadosDBs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            chamadosDB chamadosDB = db.chamadosDB.Find(id);
            if (chamadosDB == null)
            {
                return HttpNotFound();
            }
            ViewBag.usuarioID = new SelectList(db.usuariosDB, "usuarioID", "nome", chamadosDB.usuarioID);
            return View(chamadosDB);
        }

        // POST: chamadosDBs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "chamadoID,usuarioID,sistemaChamado,descricao")] chamadosDB chamadosDB)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chamadosDB).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.usuarioID = new SelectList(db.usuariosDB, "usuarioID", "nome", chamadosDB.usuarioID);
            return View(chamadosDB);
        }

        // GET: chamadosDBs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            chamadosDB chamadosDB = db.chamadosDB.Find(id);
            if (chamadosDB == null)
            {
                return HttpNotFound();
            }
            return View(chamadosDB);
        }

        // POST: chamadosDBs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            chamadosDB chamadosDB = db.chamadosDB.Find(id);
            db.chamadosDB.Remove(chamadosDB);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
