using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.TeamFoundation.SourceControl.WebApi;
using VSTSMonitor.Model;

namespace VSTSMonitor.Design
{
    public class DesignTFSService : ITFService
    {
        public bool HasConnection
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Task<bool> ConnectAsync()
        {
            return Task.FromResult<bool>(true);
        }

        public Task<List<VSTSChangeset>> GetLastestChangesetAsync(int skip, int top)
        {
            List<VSTSChangeset> test = new List<VSTSChangeset>();
            test.Add(new VSTSChangeset());
            test.Add(new VSTSChangeset());
            test.Add(new VSTSChangeset());
            
            var responseTask = Task.FromResult(test);
            return responseTask;
        }

        public Task<List<VSTSChange>> GetChangesetDetails(int changesetId)
        {
            List<VSTSChange> test = new List<VSTSChange>();
            test.Add(new VSTSChange());
            test.Add(new VSTSChange());
            test.Add(new VSTSChange());

            var responseTask = Task.FromResult(test);
            return responseTask;
        }

        public bool Connect()
        {
            throw new NotImplementedException();
        }
    }
}
