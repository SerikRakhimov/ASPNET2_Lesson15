using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Moneybox.Controllers
{
    public class HomeController : Controller
    {
        DataContext dataContext = new DataContext();
        Models.Moneybox moneybox;
        public int num = 1;

        public HomeController()
        {
            moneybox = dataContext.Moneyboxes.Find(num);
            if (moneybox == null)
            {
                moneybox = new Models.Moneybox { Id = num, Sum = 0 };
                dataContext.Moneyboxes.Add(moneybox);
            }

        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Moneybox()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Moneybox(int sum)
        {
            moneybox = dataContext.Moneyboxes.FirstOrDefault(m => m.Id == num);
            moneybox.Sum += sum;
            dataContext.SaveChanges();

            return Content("Данные ('" + sum.ToString() + "') добавлены");
        }

        public string GetSumItogo()
        {
            moneybox = dataContext.Moneyboxes.FirstOrDefault(m => m.Id == num);
            string result = moneybox.Sum.ToString();
            return result;
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}