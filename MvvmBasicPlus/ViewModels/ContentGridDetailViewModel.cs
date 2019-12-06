using MvvmBasicPlus.Core.Events;
using MvvmBasicPlus.Core.Helpers;
using MvvmBasicPlus.Core.Models;
using MvvmBasicPlus.Core.Services;
using MvvmBasicPlus.Helpers;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MvvmBasicPlus.ViewModels
{
    public class ContentGridDetailViewModel : Observable, IDisposable
    {
        private ISampleDataService _sampleDataService;
        private SampleOrder _item;

        public SampleOrder Item
        {
            get { return _item; }
            set
            {
                Set(ref _item, value);
                Messenger<SampleOrderViewEvent>.Instance.Publish(this, new SampleOrderViewEvent { Name = _item.ToString() });
            }
        }

        public ContentGridDetailViewModel(ISampleDataService sampleDataService)
        {
            _sampleDataService = sampleDataService;
            Messenger<SampleOrderViewEvent>.Instance.Event += DisplayMessage;
        }

        public async Task InitializeAsync(long orderID)
        {
            var data = await _sampleDataService.GetContentGridDataAsync();
            Item = data.First(i => i.OrderID == orderID);
        }

        private void DisplayMessage(object sender, SampleOrderViewEvent info)
        {
            Console.WriteLine($"Sample Order {info.Name} event thrown.");
        }

        public void Dispose()
        {
            Messenger<SampleOrderViewEvent>.Instance.Event -= DisplayMessage;
        }
    }
}
