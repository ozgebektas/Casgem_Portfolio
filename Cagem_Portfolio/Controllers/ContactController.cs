﻿using Cagem_Portfolio.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace Cagem_Portfolio.Controllers
{
    public class ContactController : Controller
    {
        CasgemPortfolioEntities1 db=new CasgemPortfolioEntities1();
        // GET: Contact
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.email = db.TblContact.Select(x => x.Email).FirstOrDefault();
            ViewBag.phone = db.TblContact.Select(x => x.Phone).FirstOrDefault();
            ViewBag.location = db.TblContact.Select(x => x.Location).FirstOrDefault();
            return View();
        }
        [HttpPost]
        public ActionResult Index(TblMessage p)
        {
            db.TblMessage.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index","Portfolio");
        }
       
    }
}