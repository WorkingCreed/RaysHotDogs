using Android.OS;
using Android.Views;
using RaysHotDogs.Droid.Adapters;

namespace RaysHotDogs.Droid.Fragments
{
    public class VeggieLoversFragment : BaseFragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);

            FindViews();

            HandleEvents();

            HotDogs = HotDogDataService.GetHotDogsForGroup(2);
            ListView.Adapter = new HotDogListAdapter(this.Activity, HotDogs);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            return inflater.Inflate(Resource.Layout.VeggieLoversFragment, container, false);
        }
    }
}