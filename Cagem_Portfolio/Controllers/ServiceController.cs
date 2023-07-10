using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cagem_Portfolio.Models.Entities;
public class ServiceController : Controller
{
    // GET: Service
    CasgemPortfolioEntities1 db = new CasgemPortfolioEntities1();
    public ActionResult Index()
    {
        var values = db.TBLService.ToList();
        return View(values);
    }
    [HttpGet]
    public ActionResult AddService()
    {
        return View();
    }
    [HttpPost]
    public ActionResult AddService(TBLService p)
    {
        db.TBLService.Add(p);
        db.SaveChanges();
        return RedirectToAction("Index");
    }
    
    public ActionResult DeleteService(int id)
    {
        var value=db.TBLService.Find(id);
        db.TBLService.Remove(value);
        db.SaveChanges();
        return RedirectToAction("Index");

    }
    [HttpGet]
    public ActionResult UpdateService(int id)
    {
        var value = db.TBLService.Find(id);
        return View(value);
    }
    [HttpPost]
    public ActionResult UpdateService(TBLService p)
    {
        var value = db.TBLService.Find(p.ServiceID);
        value.ServiceTitle = p.ServiceTitle;
        value.ServiceIcon= p.ServiceIcon;
        value.ServiceNumber = p.ServiceNumber;
        value.ServiceContext= p.ServiceContext;
        db.SaveChanges();
        return RedirectToAction("Index");
    }
}

