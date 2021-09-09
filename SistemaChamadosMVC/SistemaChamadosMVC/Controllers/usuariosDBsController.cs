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
    public class usuariosDBsController : Controller
    {
        private ExemploBDEntities db = new ExemploBDEntities();

        // GET: usuariosDBs
        public ActionResult Index()
        {
            return View(db.usuariosDB.ToList());
        }

        // GET: usuariosDBs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            usuariosDB usuariosDB = db.usuariosDB.Find(id);
            if (usuariosDB == null)
            {
                return HttpNotFound();
            }
            return View(usuariosDB);
        }

        // GET: usuariosDBs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: usuariosDBs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "usuarioID,nome")] usuariosDB usuariosDB)
        {
            if (ModelState.IsValid)
            {
                db.usuariosDB.Add(usuariosDB);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(usuariosDB);
        }

        // GET: usuariosDBs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            usuariosDB usuariosDB = db.usuariosDB.Find(id);
            if (usuariosDB == null)
            {
                return HttpNotFound();
            }
            return View(usuariosDB);
        }

        // POST: usuariosDBs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "usuarioID,nome")] usuariosDB usuariosDB)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuariosDB).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(usuariosDB);
        }

        // GET: usuariosDBs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            usuariosDB usuariosDB = db.usuariosDB.Find(id);
            if (usuariosDB == null)
            {
                return HttpNotFound();
            }
            return View(usuariosDB);
        }

        // POST: usuariosDBs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            usuariosDB usuariosDB = db.usuariosDB.Find(id);
            db.usuariosDB.Remove(usuariosDB);
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
