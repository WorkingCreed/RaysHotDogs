using System.Collections;
using System.Collections.Generic;

namespace RaysHotDogs.Core.Models
{
  public class HotDog
  {
    public int HotDogId { get; set; }
    public string Name { get; set; }
    public string ShortDescription { get; set; }
    public string Description { get; set; }
    public string ImagePath { get; set; }
    public int Price { get; set; }
    public bool Available { get; set; }
    public int PrepTime { get; set; }
    public IList<string> Ingredients { get; set; }
    public bool IsFavorite { get; set; }
    public string GroupName { get; set; }
  }
}