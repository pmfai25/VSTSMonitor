using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.TeamFoundation.SourceControl.WebApi;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models;
using Microsoft.VisualStudio.Services.Client;
using VSTSMonitor.Setting;
using System.Threading;

namespace VSTSMonitor.Model
{
    public class TFService : ITFService
    {
        private static VssConnection _Conn;

        private VssConnection Conn
        {
            get
            {
                if (_Conn == null)
                    throw new InvalidOperationException("Connection to Visual Studio Team Service need to be initiated first.");

                return _Conn;
            }
        }

        public bool HasConnection
        {
            get
            {
                return _Conn != null;
            }
        }
        
        public TFService()
        {
            //if (!(string.IsNullOrEmpty(UserSetting.TFSCollectionUri) || string.IsNullOrEmpty(UserSetting.TFSProjectName) || string.IsNullOrEmpty(UserSetting.TFSUsername) || string.IsNullOrEmpty(UserSetting.TFSPassword)))
            //{
            //    conn = new VssConnection(new Uri(UserSetting.TFSCollectionUri), new VssAadCredential(UserSetting.TFSUsername, UserSetting.TFSPassword));
            //}
        }

        public bool Connect()
        {
            _Conn = new VssConnection(new Uri(UserSetting.TFSCollectionUri), new VssAadCredential(UserSetting.TFSUsername, UserSetting.TFSPassword));

            try
            {
                _Conn.ConnectAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> ConnectAsync()
        {
            _Conn = new VssConnection(new Uri(UserSetting.TFSCollectionUri), new VssAadCredential(UserSetting.TFSUsername, UserSetting.TFSPassword));

            try
            {
                await _Conn.ConnectAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<VSTSChangeset>> GetLastestChangesetAsync(int skip, int top)
        {
            List<VSTSChangeset> Changesets = new List<VSTSChangeset>();

            TfvcHttpClient vsClient = Conn.GetClient<TfvcHttpClient>();
            List<TfvcChangesetRef> ChangesetRefs = await vsClient.GetChangesetsAsync(UserSetting.TFSProjectName, null, true, true, null, true, skip, top);
            //TfvcChangeset Changeset = await vsClient.GetChangesetAsync(ChangesetRefs[0].ChangesetId, null, true, true, null, true);

            foreach (TfvcChangesetRef changesetRef in ChangesetRefs)
            {
                List<AssociatedWorkItem> workItems = await vsClient.GetChangesetWorkItemsAsync(changesetRef.ChangesetId);
                string WorkItemDisplayValue = "";

                foreach (var workitem in workItems)
                {
                    WorkItemDisplayValue += workitem.Id + " - " + workitem.Title + "\n";
                }

                if (WorkItemDisplayValue.Length > 2)
                    WorkItemDisplayValue = WorkItemDisplayValue.Substring(0, WorkItemDisplayValue.Length - 2);

                Changesets.Add(new VSTSChangeset()
                {
                    ChangesetId = changesetRef.ChangesetId,
                    Author = changesetRef.Author.DisplayName,
                    CheckedInBy = changesetRef.CheckedInBy.DisplayName,
                    Comment = changesetRef.Comment,
                    CreatedDate = changesetRef.CreatedDate,
                    Url = changesetRef.Url,
                    WorkItem = WorkItemDisplayValue,
                    Workitems = workItems
                });
            }

            return Changesets;
        }

        public async Task<List<VSTSChange>> GetChangesetDetails(int changesetId)
        {
            TfvcChangeset changeset = null;

            TfvcHttpClient vsClient = Conn.GetClient<TfvcHttpClient>();
            changeset = await vsClient.GetChangesetAsync(changesetId, null, true, true, null, true, null, null, null, null, null);

            List<TfvcChange> tfvchanges = await vsClient.GetChangesetChangesAsync(changesetId);
            List<VSTSChange> changes = new List<VSTSChange>();

            foreach (var tfvchange in tfvchanges)
            {
                VSTSChange change = new VSTSChange()
                {
                    ChangeType = tfvchange.ChangeType.ToString(),
                    FilePath = tfvchange.Item.Path
                };

                changes.Add(change);
            }

            return changes;
        }
    }
}
