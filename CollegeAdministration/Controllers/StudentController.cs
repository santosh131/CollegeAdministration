using CollegeAdministration.Infrastructure;
using CollegeAdministration.Models;
using CollegeAdministration.Providers;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CollegeAdministration.Controllers
{
    [CustomAuthorization]
    public class StudentController : Controller
    {
        MongoDBContext mc = new MongoDBContext();
        // GET: Student
        public ActionResult Index()
        {
            var students = mc._db.GetCollection<Student>("Student").FindAll().ToList();

            return View(students);
        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            var students = mc._db.GetCollection<Student>("Student");
            var query = Query<Student>.EQ(p => p.StudentId, id);
            var stud = students.FindOne(query);
            return View();
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(Student student)
        {
            try
            {
                // TODO: Add insert logic here
                var students = mc._db.GetCollection<Student>("Student");
                var maxStudId = 1;
                if (students.FindAll().Count() > 0)
                {
                    maxStudId = students.Find(Query.Empty).Max(x => x.StudentId);
                }
                var query = Query.And(Query.EQ("Name", student.Name));
                var count = students.FindAs<Student>(query).Count();
                if (count == 0)
                {
                    student.StudentId = maxStudId + 1;
                    students.Insert<Student>(student);
                }
                else
                {
                    ViewBag.ErrorMessage = "Student already exists";
                    return View("Create", student);
                }

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ViewBag.ErrorMessage = "Insert Student: " + ex.Message;
                return View();
            }
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            var students = mc._db.GetCollection<Student>("Student");
            var query = Query<Student>.EQ(p => p.StudentId , id);
            var stud = students.FindOne(query);
            return View(stud);
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Student student)
        {
            try
            { 
                var students = mc._db.GetCollection<Student>("Student");
                var query = Query<Student>.EQ(p => p.StudentId, id);
                var stud=students.FindOne(query);
                student.Id = stud.Id;
                students.Update(query, Update.Replace(student),UpdateFlags.None,WriteConcern.Acknowledged);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ViewBag.ErrorMessage = "Update Student: "+ex.Message;
                return View();
            }
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            var students = mc._db.GetCollection<Student>("Student");
            var query = Query<Student>.EQ(p => p.StudentId, id);
            var stud = students.FindOne(query);
            return View(stud);
        }

        // POST: Student/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var students = mc._db.GetCollection<Student>("Student");
                var query = Query<Student>.EQ(p => p.StudentId, id);
                var result = students.Remove(query);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Delete Student: " + ex.Message;
                return View();
            }
        }
    }
}
