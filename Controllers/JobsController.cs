﻿using System;
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
        public ActionResult Edit(string Id)
        {
            JobTableViewModel model = new JobTableViewModel();

            using (CrudJobDbEntities db = new CrudJobDbEntities())
            {
                var oJobsTable = db.JobTables.Find(Id);
                model.Job = oJobsTable.Job;
                model.JobTile = oJobsTable.JobTile;
                model.JobDescription = oJobsTable.JobDescription;
                model.FromDate = oJobsTable.FromDate;
                model.ToDate = oJobsTable.ToDate;

            }

            return View(model);
        }

        // POST: Jobs/Edit/5
        [HttpPost]
        public ActionResult Edit(JobTableViewModel model)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    using (CrudJobDbEntities db = new CrudJobDbEntities())
                    {
                        var oJobsTable = db.JobTables.Find(model.Job); ;
                        oJobsTable.Job = model.Job;
                        oJobsTable.JobTile = model.JobTile;
                        oJobsTable.JobDescription = model.JobDescription;
                        oJobsTable.FromDate = model.FromDate;
                        oJobsTable.ToDate = model.ToDate;

                        db.Entry(oJobsTable).State = System.Data.Entity.EntityState.Modified;
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

        // GET: Jobs/Delete/5
        [HttpGet]
        public ActionResult Delete(string Id)
        {
            using (CrudJobDbEntities db = new CrudJobDbEntities())
            {
                var oJobsTable = db.JobTables.Find(Id);
                db.JobTables.Remove(oJobsTable);
                db.SaveChanges();
            }

            return Redirect("~/Jobs/Index");
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
