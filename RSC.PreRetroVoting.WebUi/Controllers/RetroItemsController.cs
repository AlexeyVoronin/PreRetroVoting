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
        return View(
            RetroItemsViewName,
            _retroItemsRepository.GetRetroItems()
                                 .OrderBy(i => i.VoterNames.Count())
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
        _retroItemsRepository.Vote(retroItem.Id, User.Identity.Name);
      return List();
    }

    private readonly IRetroItemsRepository _retroItemsRepository;

    private const string RetroItemsViewName = "List";
  }
}
