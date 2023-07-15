using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cagem_Portfolio.Models.Entities;

namespace Cagem_Portfolio.Controllers
{
    public class PortfolioController : Controller
    {
        CasgemPortfolioEntities1 db= new CasgemPortfolioEntities1();
        // GET: Portfolio
        public ActionResult Index()
        {
          /*  ArrayList xvalue=new ArrayList();
            var values = db.TblDepartment.ToList();
            values.ToList().ForEach(x=>xvalue.Add(x.DepartmentName));*/
            return View();
        }
        public PartialViewResult PartialHead()
        {
            return PartialView();
        }
        public PartialViewResult PartialNavbar()
        {
            return PartialView();
        }
        public PartialViewResult PartialFeature()
        {
            ViewBag.featureTitle=db.TblFeature.Select(x=>x.FeatureTitle).FirstOrDefault();
            ViewBag.featureDescription=db.TblFeature.Select(x=>x.FeatureDescription).FirstOrDefault();
            ViewBag.featureImageURL=db.TblFeature.Select(x=>x.FeatureImageURL).FirstOrDefault();

            
            return PartialView();
        }
        public PartialViewResult MyResume()
        {
            var values=db.TBLResume.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialStatistic()
        {
            ViewBag.totalService=db.TBLService.Count();
            ViewBag.totalMessage=db.TblMessage.Count();
            ViewBag.totalThanksMessage = db.TblMessage.Where(x => x.MessageSubject == "Teşekkür").Count();
           // ViewBag.happyCustomer
            return PartialView();
        }
        [HttpGet]
        public FileResult DownloadMyCv()
        {
            byte[] fileBytes = System.IO.File.ReadAllBytes(this.Server.MapPath("\\Content\\pdf\\Ozgebektas.pdf"));
            string fileName = "Ozgebektas.pdf";
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }

    }
}