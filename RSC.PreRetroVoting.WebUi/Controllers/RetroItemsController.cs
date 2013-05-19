using System;
using System.Linq;
using System.Web.Mvc;
using RSC.PreRetroVoting.DataAccess.Model;

namespace RSC.PreRetroVoting.WebUi.Controllers
{
  public class RetroItemsController : Controller
  {
    public RetroItemsController(IRetroItemsRepository retroItemsRepository)
    {
      _retroItemsRepository = retroItemsRepository;
    }

    public ViewResult List()
    {
      return View(RetroItemsViewName, _retroItemsRepository.GetRetroItems()
        .OrderBy(i => i.VoterNames == null ? 0 : i.VoterNames.Count())
        .Reverse());
    }

    public ViewResult AddItem(string description)
    {
        _retroItemsRepository.AddRetroItem(
          new RetroItem 
          {
            Id = Guid.NewGuid(), 
            Description = description
          });
        return List();
    }

    public ViewResult Vote(RetroItem retroItem)
    {
      return List();
    }

    private IRetroItemsRepository _retroItemsRepository;
    private const string RetroItemsViewName = "List";
  }
}
