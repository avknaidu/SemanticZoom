using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace App7
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
        }

        ItemViewModel itemViewModel = new ItemViewModel();

        private void GridView_GotFocus(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            semanticView.StartBringIntoView();
        }
    }

    public class ItemViewModel
    {
        public ObservableCollection<Items> MyList { get; set; }
        public object Groups { get; }

        public ItemViewModel()
        {
            MyList = new ObservableCollection<Items>();
            for(int i = 1; i < 10; i++)
            {
                for(int j = 1; j < 10; j++)
                {
                    Items item = new Items();
                    item.ItemHeader = "Header" + i.ToString();
                    item.ItemValue = "Value" + j.ToString();
                    MyList.Add(item);
                }
            }
            Groups = from t in MyList group t by t.ItemHeader into g orderby g.Key select g;
        }
    }

    public class Items
    {
        public string ItemHeader { get; set; }
        public string ItemValue { get; set; }
    }
}
