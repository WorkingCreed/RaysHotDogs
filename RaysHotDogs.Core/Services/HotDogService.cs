using System.Collections.Generic;
using RaysHotDogs.Core.Gateways;
using RaysHotDogs.Core.Models;

namespace RaysHotDogs.Core.Services
{
  public class HotDogDataService
  {
    //private static HotDogWebRepository hotDogRepository = new HotDogWebRepository();
    private static readonly HotDogGateway gateway = new HotDogGateway();

    public HotDogDataService()
    {
    }

    public List<HotDog> GetAllHotDogs()
    {
      return gateway.GetAllHotDogs();
    }

    public List<HotDogGroup> GetGroupedHotDogs()
    {
      return gateway.GetGroupedHotDogs();
    }

    public IList<HotDog> GetHotDogsForGroup(int hotDogGroupId)
    {
      return gateway.GetHotDogsForGroup(hotDogGroupId);
    }

    public List<HotDog> GetFavoriteHotDogs()
    {
      return gateway.GetFavoriteHotDogs();
    }

    public HotDog GetHotDogById(int hotDogId)
    {
      return gateway.GetHotDogById(hotDogId);
    }

  }
}

