using System;
using System.Collections.Generic;
using Foundation;
using RaysHotDogs.Core.Models;
using RaysHotDogs.iOs.Cells;
using UIKit;

namespace RaysHotDogs.iOs.Sources
{
    
    public class HotDogDataSource : UIKit.UITableViewSource
    {
        private IList<HotDog> _hotDogs;
        NSString _cellIdentifier = new NSString("HotDogCell");
        
        public HotDogDataSource(IList<HotDog> hotDogs, UITableViewController callingController)
        {
            _hotDogs = hotDogs;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            HotDogListCell cell = tableView.DequeueReusableCell(_cellIdentifier) as HotDogListCell;
            if (cell == null)
            {
                cell = new HotDogListCell(_cellIdentifier);
            }

          
            cell.UpdateCell(_hotDogs[indexPath.Row].Name, _hotDogs[indexPath.Row].Price.ToString(), UIImage.FromFile($"Images/hotdog{_hotDogs[indexPath.Row].HotDogId}.png"));
            
            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return _hotDogs.Count;
        }

      public HotDog GetItem(int row)
      {
        return _hotDogs[row];
      }
    }
}
