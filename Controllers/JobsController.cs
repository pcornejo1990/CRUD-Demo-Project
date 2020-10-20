using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUD_Demo_Project.Context;
using CRUD_Demo_Project.Models;
using CRUD_Demo_Project.Models.ViewModels;

namespace CRUD_Demo_Project.Controllers
{
    public class JobsController : Controller
    {
        // GET: Jobs
        public ActionResult Index()
        {
            List<ListJobTableViewModel> lst;
            using (CrudJobDbEntities db = new CrudJobDbEntities())
            {
                lst = (from d in db.JobTables
                           select new ListJobTableViewModel
                           {
                               Job = d.Job,
                               JobTile = d.JobTile,
                               JobDescription = d.JobDescription,
                               FromDate = d.FromDate,
                               ToDate = d.ToDate
                           }).ToList();
            }
                return View(lst);
        }

        // GET: Jobs/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Jobs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Jobs/Create
        [HttpPost]
        public ActionResult Create(JobTableViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (CrudJobDbEntities db = new CrudJobDbEntities())
                    {
                        var oJobsTable = new JobTable();
                        oJobsTable.Job = model.Job;
                        oJobsTable.JobTile = model.JobTile;
                        oJobsTable.JobDescription = model.JobDescription;
                        oJobsTable.FromDate = model.FromDate;
                        oJobsTable.ToDate = model.ToDate;

                        db.JobTables.Add(oJobsTable);
                        db.SaveChanges();
                    }

                    return Redirect("~/Jobs/Index");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // GET: Jobs/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Jobs/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Jobs/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Jobs/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
