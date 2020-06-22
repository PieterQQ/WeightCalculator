using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeightCalculator.ViewModel;

namespace WeightCalculator.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Count(BmiVM BMI)
        {
            var Model = new BmiVM {
                Height=BMI.Height,
                DesiredWeight=BMI.DesiredWeight,
                InitWeight=BMI.InitWeight,
                StartDate=BMI.StartDate,
                EndDate=BMI.EndDate
            };
            return PartialView("_ResultView",Model);
        }

    }
}