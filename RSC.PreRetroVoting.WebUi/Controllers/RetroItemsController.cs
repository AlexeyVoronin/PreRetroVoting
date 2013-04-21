using System;
using System.Web.Mvc;
using RSC.PreRetroVoting.DataAccess;

namespace RSC.PreRetroVoting.WebUi.Controllers
{
  public class RetroItemsController : Controller
  {
    public RetroItemsController(IRetroItemsRepository retroItemsRepository)
    {
      _retroItemsRepository = retroItemsRepository;
    }

    public ActionResult List()
    {
      return View(_retroItemsRepository.GetRetroItems());
    }

    public ActionResult AddItem(string description)
    {
        _retroItemsRepository.AddRetroItem(new RetroItem { Description = description });
        return List();
    }

    public ActionResult Vote(RetroItem retroItem)
    {
      return List();
    }

    private IRetroItemsRepository _retroItemsRepository;
  }
}
