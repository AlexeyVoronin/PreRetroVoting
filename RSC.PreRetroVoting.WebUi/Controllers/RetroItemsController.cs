using System.Web.Mvc;
using RSC.PreRetroVoting.DataAccess;

namespace RSC.PreRetroVoting.WebUi.Controllers
{
    public class RetroItemsController : Controller
    {
        public ActionResult Index()
        {
            return View(new RetroItemsDataAccessFacade().Provider.GetRetroItems());
        }

        /*
        //
        // GET: /RetroItems/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /RetroItems/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /RetroItems/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /RetroItems/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /RetroItems/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /RetroItems/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /RetroItems/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
         */
    }
}
