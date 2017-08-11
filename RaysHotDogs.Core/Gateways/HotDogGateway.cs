using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RaysHotDogs.Core.Models;

namespace RaysHotDogs.Core.Gateways
{

 
  public class HotDogGateway
  {
    private static List<HotDogGroup> hotDogGroups = new List<HotDogGroup>();
    private string url = "http://gillcleerenpluralsight.blob.core.windows.net/files/hotdogs.json";
    private HttpClient httpClient;
    public HotDogGateway()
    {
      Task.Run(()=> LoadDataAsync(url));
    }

    private async Task LoadDataAsync(string url)
    {
      if (hotDogGroups != null)
      {
        string responseJsonString = null;
        try
        {
          using (HttpClient httpClient = new HttpClient())
          {
            Task<HttpResponseMessage> getResponse = httpClient.GetAsync(url);
            HttpResponseMessage response = await getResponse;
            responseJsonString = await response.Content.ReadAsStringAsync();
            hotDogGroups = JsonConvert.DeserializeObject<List<HotDogGroup>>(responseJsonString);
          }

            
        }
        catch (KeyNotFoundException e)
        {
          
        }
      }
    }

    public List<HotDog> GetAllHotDogs()
    {
      IEnumerable<HotDog> hotDogs =
        from hotDogGroup in hotDogGroups
        from hotDog in hotDogGroup.HotDogs

        select hotDog;
      return hotDogs.ToList<HotDog>();
    }

    public List<HotDogGroup> GetGroupedHotDogs()
    {
      return hotDogGroups;
    }

    public IList<HotDog> GetHotDogsForGroup(int hotDogGroupId)
    {
      HotDogGroup group = hotDogGroups.FirstOrDefault(h => h.HotDogGroupId == hotDogGroupId);

      return group?.HotDogs;
    }

    public List<HotDog> GetFavoriteHotDogs()
    {
      IEnumerable<HotDog> hotDogs =
        from hotDogGroup in hotDogGroups
        from hotDog in hotDogGroup.HotDogs
        where hotDog.IsFavorite
        select hotDog;

      return hotDogs.ToList<HotDog>();
    }

    public HotDog GetHotDogById(int hotDogId)
    {
      IEnumerable<HotDog> hotDogs =
        from hotDogGroup in hotDogGroups
        from hotDog in hotDogGroup.HotDogs
        where hotDog.HotDogId == hotDogId
        select hotDog;

      return hotDogs.FirstOrDefault();
    }

    
  }
}