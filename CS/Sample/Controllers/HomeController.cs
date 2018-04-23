using System.Web.Mvc;
using DevExpress.Web.Mvc;
using Sample.Models;

namespace Sample.Controllers {
    public class HomeController : Controller {
        PersonsList list = new PersonsList();

        public ActionResult Index() {
            return View(list.GetPersons());
        }

        public ActionResult GridViewTemplatePartial() {
            return PartialView(list.GetPersons());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult EditingAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] Person person) {
            if (ModelState.IsValid)
                list.AddPerson(person);
            return PartialView("GridViewTemplatePartial", list.GetPersons());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult EditingUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] Person personInfo) {
            if (ModelState.IsValid)
                list.UpdatePerson(personInfo);
            return PartialView("GridViewTemplatePartial", list.GetPersons());
        }

        public ActionResult EditingDelete(int personId) {
            list.DeletePerson(personId);
            return PartialView("GridViewTemplatePartial", list.GetPersons());
        }
    }
}