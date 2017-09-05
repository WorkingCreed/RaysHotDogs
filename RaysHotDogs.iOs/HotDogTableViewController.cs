using Foundation;
using System;
using System.Collections.Generic;
using RaysHotDogs.Core.Models;
using UIKit;
using RaysHotDogs.Core.Services;
using RaysHotDogs.iOs.Sources;

namespace RaysHotDogs.iOs
{
  public partial class HotDogTableViewController : UITableViewController
  {
    HotDogDataService _service = new HotDogDataService();

    public HotDogTableViewController(IntPtr handle) : base(handle)
    {
    }

    public override void ViewDidLoad()
    {
      base.ViewDidLoad();
      IList<HotDog> hotDogs = _service.GetAllHotDogs();
      HotDogDataSource hotDogDataSource = new HotDogDataSource(hotDogs, this);
      TableView.Source = hotDogDataSource;
      NavigationItem.Title = "Ray's Hot Dog menu";
    }

    public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
    {
      base.PrepareForSegue(segue, sender);
      if (segue.Identifier == "HotDogDetailSegue")
      {
        HotDogDetailViewController hotDogDetailViewController = segue.DestinationViewController as HotDogDetailViewController;
        if (hotDogDetailViewController != null)
        {
          HotDogDataSource source = TableView.Source as HotDogDataSource;
          var row = TableView.IndexPathForSelectedRow;
          var item = source.GetItem(row.Row);
          hotDogDetailViewController.SelectedHotDog = item;

        }
      }
    }
  }
}  