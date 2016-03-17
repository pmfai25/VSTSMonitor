using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.TeamFoundation.SourceControl.WebApi;

namespace VSTSMonitor.Model
{
    public interface ITFService
    {
        bool HasConnection { get; }

        Task<List<VSTSChangeset>> GetLastestChangesetAsync(int skip, int top);

        bool Connect();
        Task<bool> ConnectAsync();

        Task<List<VSTSChange>> GetChangesetDetails(int changesetId);
    }
}
