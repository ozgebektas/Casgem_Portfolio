﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cagem_Portfolio.Models.Entities;

namespace Cagem_Portfolio.Controllers
{
    public class MessageController : Controller
    {
        CasgemPortfolioEntities1 db=new CasgemPortfolioEntities1();
        // GET: Message
        public ActionResult Index()
        {
            var values = db.TblMessage.ToList();
            return View(values);
        }
        public ActionResult DeleteMessage(int id) 
        {
            var value=db.TblMessage.Find(id);
            db.TblMessage.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MessageDetails(int id)
        {
            var value = db.TblMessage.Find(id);
            return View(value);
        }
    }
}