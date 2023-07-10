﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cagem_Portfolio.Models.Entities;

namespace Cagem_Portfolio.Controllers
{
    public class ProjectController : Controller
    {
        CasgemPortfolioEntities1 db=new CasgemPortfolioEntities1();
        // GET: Project
        public ActionResult Index()
        {
            var values=db.TblProject.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddProject() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddProject(TblProject p)
        {
            db.TblProject.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteProject(int id)
        { 
            var value=db.TblProject.Find(id);
            db.TblProject.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateProject(int id)
        {
            var value=db.TblProject.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateProject(TblProject p)
        {
            var value = db.TblProject.Find(p.ProjectID);
            value.ProjectName = p.ProjectName;
            value.ProjectContent = p.ProjectContent;
            value.ProjectUrl = p.ProjectUrl;

            db.SaveChanges();
            return RedirectToAction("Index");
        }

       
    }
}