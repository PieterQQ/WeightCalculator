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
            int Height = BMI.Height;
            int InitWeight = BMI.InitWeight;
            int DesiredWeight = BMI.DesiredWeight;
            DateTime StartDate = BMI.StartDate;
            DateTime EndDate = BMI.EndDate;

            return View();
        }

    }
}