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
                return View("RetroItemsList", f.Provider.GetRetroItems());
            });
        }

        public ActionResult AddItem(string text)
        {
            return DoWithRetroItemsDataAccessFacade(f => 
            {
                f.Adder.AddRetroItem(text);
                return Index();
            });
        }

        private T DoWithRetroItemsDataAccessFacade<T>(Func<IRetroItemsDataAccessFacade, T> func)
        { 
            var retroItemsDataAccessFacade = new RetroItemsDataAccessFacade();
            return func(retroItemsDataAccessFacade);
        }
    }
}
