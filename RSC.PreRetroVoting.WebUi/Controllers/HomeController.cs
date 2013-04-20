using System;
using System.Web.Mvc;
using RSC.PreRetroVoting.DataAccess;

namespace RSC.PreRetroVoting.WebUi.Controllers
{
  public class HomeController : Controller
  {
    public HomeController(IRetroItemsRepository retroItemsRepository)
    {
      _retroItemsRepository = retroItemsRepository;
    }

    public ActionResult Index()
    {
      return View("RetroItemsList", _retroItemsRepository.GetRetroItems());
    }

    public ActionResult AddItem(string description)
    {
        _retroItemsRepository.AddRetroItem(new RetroItem { Description = description });
        return Index();
    }

    public ActionResult Vote(RetroItem retroItem)
    {
      return Index();
    }

    private IRetroItemsRepository _retroItemsRepository;
  }
}
