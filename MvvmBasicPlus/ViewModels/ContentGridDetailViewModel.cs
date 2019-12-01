using MvvmBasicPlus.Core.Models;
using MvvmBasicPlus.Core.Services;
using MvvmBasicPlus.Helpers;
using System.Linq;
using System.Threading.Tasks;

namespace MvvmBasicPlus.ViewModels
{
    public class ContentGridDetailViewModel : Observable
    {
        private SampleOrder _item;

        public SampleOrder Item
        {
            get { return _item; }
            set { Set(ref _item, value); }
        }

        public ContentGridDetailViewModel()
        {
        }

        public async Task InitializeAsync(long orderID)
        {
            var data = await new SampleDataService().GetContentGridDataAsync();
            Item = data.First(i => i.OrderID == orderID);
        }
    }
}
