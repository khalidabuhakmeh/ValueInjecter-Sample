using System.Web.Mvc;
using ValueInjector.Infrastructure;
using ValueInjector.Models;

namespace ValueInjector.Controllers
{
    public class PersonController : Controller
    {
        Person Current {
            get { return Session["Person"] as Person; }
            set { Session["Person"] = value; }
        }

        [HttpGet]
        public ActionResult Index() {
            var model = Current.ToViewModel<PersonViewModel>();
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(PersonViewModel model) {
            Current = model.ToDomain(Current).Audit();
            return RedirectToAction("Index");
        }

    }
}
