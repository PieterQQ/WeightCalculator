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
            if (ModelState.IsValidField("StartDate") && ModelState.IsValidField("EndDate"))
            {  if (Model.StartDate.Date < DateTime.Now.Date || Model.EndDate.Date < DateTime.Now.Date)
                {
                    ModelState.AddModelError("StartDate", "Back To the future?");
                }
                else if (Model.StartDate.Date >= Model.EndDate.Date)
                {
                    ModelState.AddModelError("StartDate", "Start date should be lower than End Date");
                }
               
             
            }
            if (ModelState.IsValidField("InitWeight") && ModelState.IsValidField("DesiredWeight") && Model.InitWeight == Model.DesiredWeight)
            {
                ModelState.AddModelError("InitWeight", "Initial Weight and Desired Weight cant be same");
            }
            if (!ModelState.IsValid)
            {
                var errorList = (from item in ModelState
                                 where item.Value.Errors.Any()
                                 select item.Value.Errors[0].ErrorMessage).ToList();
                return Content(errorList.First().ToString());
            }
            else
            return PartialView("_ResultView",Model);
        }

    }
}