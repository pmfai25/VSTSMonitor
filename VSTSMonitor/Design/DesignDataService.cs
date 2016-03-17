using System;
using VSTSMonitor.Model;

namespace VSTSMonitor.Design
{
    public class DesignDataService : IDataService
    {
        public void GetData(Action<DataItem, Exception> callback)
        {
            // Use this to create design time data

            var item = new DataItem("Welcome to MVVM Light2 [design]");
            callback(item, null);
        }
    }
}