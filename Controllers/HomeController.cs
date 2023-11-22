using DatabaseFirst_Approach.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace DatabaseFirst_Approach.Controllers
{
    public class HomeController : Controller
    {
        DatabaseFirstEFEntities db = new DatabaseFirstEFEntities();
        // GET: Home
        public ActionResult Index()
        {
            var data = db.students.ToList();
            return View(data);
        }

        //create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(student s)
        {
            if(ModelState.IsValid == true)
            {
                db.students.Add(s);
                int a = db.SaveChanges();
                if (a > 0)
                {
                    TempData["InsertMessage"] = "<script>alert('Inserted !!')</script>";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["InsertMessage"] = "<script>alert('NOT Inserted !!')</script>";
                }

            }
            
            return View();
        }

        //edit functionality 

        public ActionResult Edit(int id)
        {
            var row = db.students.Where(model => model.id == id).FirstOrDefault();
            return View(row);
        }

        [HttpPost]
        public ActionResult Edit(student s)
        {
            if(ModelState.IsValid == true)
            {
                db.Entry(s).State = EntityState.Modified;
                int a = db.SaveChanges();
                if (a > 0)
                {
                    TempData["UpdateMessage"] = "<script>alert('Updated !!')</script>";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["UpdateMessage"] = "<script>alert('NOT Updated !!')</script>";
                }
            }
           
            return View();
        }

        //for delete

        public ActionResult Delete(int id)
        {
            var deletedRow = db.students.Where(model => model.id == id).FirstOrDefault(); 
            return View(deletedRow);
        }

        [HttpPost]
        public ActionResult Delete(student s)
        {
            if (ModelState.IsValid == true)
            {
                db.Entry(s).State = EntityState.Modified;
                var a = db.SaveChanges();
                if (a > 0)
                {
                    TempData["DeletedMessage"] = "<script>alert(Data Deleted)</script>";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["DeletedMessage"] = "<script>alert(Data not deleted)</script>";
                }
            }
        
            return View();
        }

        //for details 

        public ActionResult Details(int id)
        {
            var row = db.students.Where(model => model.id == id).FirstOrDefault();
            return View(row);
        }

    }
}