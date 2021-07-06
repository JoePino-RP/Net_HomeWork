using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCTarea.Models;
using MVCTarea.Models.ViewModels;

namespace MVCTarea.Controllers
{
    public class Tabla_DatosController : Controller
    {
        // GET: Tabla_Datos
        public ActionResult Index()
        {
            List<ListTablaViewModel> lst;
            using (CRUD_NETEntities1 db = new CRUD_NETEntities1())
            {
                lst = (from d in db.Tabla_Datos
                       select new ListTablaViewModel
                       {
                           Nombre = d.Nombre,
                           Edad = d.Edad,
                           Genero = d.Genero,
                           Cargo = d.Cargo,
                           Id = d.ID
                       }).ToList();
            }
            return View(lst);
        }

        public ActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(TablaViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (CRUD_NETEntities1 db = new CRUD_NETEntities1())
                    {
                        var oTabla = new Tabla_Datos();
                        oTabla.Nombre = model.Nombre;
                        oTabla.Edad = model.Edad;
                        oTabla.Genero = model.Genero;
                        oTabla.Cargo = model.Cargo;
                        oTabla.ID = model.Id;


                        db.Tabla_Datos.Add(oTabla);
                        db.SaveChanges();
                    }
                    return Redirect("~/Tabla_Datos");
                }
                return View(model);
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ActionResult Editar(int id)
        {
            TablaViewModel model = new TablaViewModel();
            using (CRUD_NETEntities1 db= new CRUD_NETEntities1())
            {
                var oTabla = db.Tabla_Datos.Find(id);
                model.Nombre = oTabla.Nombre;
                model.Edad = oTabla.Edad;
                model.Genero = oTabla.Genero;
                model.Cargo = oTabla.Cargo;
                model.Id = oTabla.ID;
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Editar(TablaViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (CRUD_NETEntities1 db = new CRUD_NETEntities1())
                    {
                        var oTabla = db.Tabla_Datos.Find(model.Id);
                        oTabla.Nombre = model.Nombre;
                        oTabla.Edad = model.Edad;
                        oTabla.Genero = model.Genero;
                        oTabla.Cargo = model.Cargo;
                        oTabla.ID = model.Id;


                        db.Entry(oTabla).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    return Redirect("~/Tabla_Datos/");
                }
                return View(model);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            TablaViewModel model = new TablaViewModel();
            using (CRUD_NETEntities1 db = new CRUD_NETEntities1())
            {
                var oTabla = db.Tabla_Datos.Find(id);
                db.Tabla_Datos.Remove(oTabla);
                db.SaveChanges();

            }
            return Redirect("~/Tabla_Datos");
        }


    }
}