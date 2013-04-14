using System;
using System.Web.Mvc;
using RSC.PreRetroVoting.DataAccess;

namespace RSC.PreRetroVoting.WebUi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return DoWithRetroItemsDataAccessFacade(f =>
            {
                return View("RetroItemsList", f.RetroItemsRepository.GetRetroItems());
            });
        }

        public ActionResult AddItem(string description)
        {
            return DoWithRetroItemsDataAccessFacade(f => 
            {
                f.RetroItemsRepository.AddRetroItem(new RetroItem { Description = description });
                return Index();
            });
        }

        public ActionResult Vote(RetroItem retroItem)
        {

            return Index();
        }

        private T DoWithRetroItemsDataAccessFacade<T>(Func<IDataAccessFacade, T> func)
        { 
            var retroItemsDataAccessFacade = new DataAccessFacade();
            return func(retroItemsDataAccessFacade);
        }
    }
}
