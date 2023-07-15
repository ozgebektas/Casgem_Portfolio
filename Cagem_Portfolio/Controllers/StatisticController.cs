using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cagem_Portfolio.Models.Entities;

namespace Cagem_Portfolio.Controllers
{
    public class StatisticController : Controller
    {
        CasgemPortfolioEntities1 db=new CasgemPortfolioEntities1();
        
        // GET: Statistic
        public ActionResult Index()
        {
            ViewBag.employeeCount = db.TblEmployee.Count();
            var salary = db.TblEmployee.Max(x => x.EmployeeSalary);
            ViewBag.maxSalaryEmployee = db.TblEmployee.Where(x => x.EmployeeSalary == salary).Select(y => y.EmployeeName + " " + y.EmployeeSurname).FirstOrDefault();

            ViewBag.totalCityCount = db.TblEmployee.Select(x=>x.EmployeeCity).Distinct().Count();
            ViewBag.avgEmployeeSalary=db.TblEmployee.Average(x=>x.EmployeeSalary);

            ViewBag.countSoftwareDepartment = db.TblEmployee.
                Where(x => x.EmployeeDepartment == db.TblDepartment.Where(z => z.DepartmentName == "Yazılım").
                Select(y => y.DepartmentID).FirstOrDefault()).Count();

            //Şehri adana ve ankara olanların toplam maaşı
            ViewBag.totalSalaryForTwoCities= db.TblEmployee.Where(x=>x.EmployeeCity=="Ankara" || x.EmployeeCity=="Adana").Sum(y=>y.EmployeeSalary);
            //
            ViewBag.sumSalarayFromSoftwareDepartment = db.TblEmployee.Where(x => x.EmployeeCity == "Ankara" && x.EmployeeDepartment == db.TblDepartment.
            Where(z => z.DepartmentName == "Yazılım").Select(y => y.DepartmentID).FirstOrDefault()).Sum(w => w.EmployeeSalary);            
            return View();
        }
    }
}