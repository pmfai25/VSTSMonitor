using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VSTSMonitor.Setting
{
    internal static class UserSetting
    {
        internal static string TFSCollectionUri
        {
            get
            {
                return VSTSMonitor.Properties.Settings.Default.TFSCollectionUri;
            }
            set
            {
                VSTSMonitor.Properties.Settings.Default.TFSCollectionUri = value;
                VSTSMonitor.Properties.Settings.Default.Save();
            }
        }

        internal static string TFSProjectName
        {
            get
            {
                return VSTSMonitor.Properties.Settings.Default.TFSProjectName;
            }
            set
            {
                VSTSMonitor.Properties.Settings.Default.TFSProjectName = value;
                VSTSMonitor.Properties.Settings.Default.Save();
            }
        }

        internal static string TFSUsername
        {
            get
            {
                return VSTSMonitor.Properties.Settings.Default.TFSUsername;
            }
            set
            {
                VSTSMonitor.Properties.Settings.Default.TFSUsername = value;
                VSTSMonitor.Properties.Settings.Default.Save();
            }
        }

        internal static string TFSPassword
        {
            get
            {
                return VSTSMonitor.Properties.Settings.Default.TFSPassword;
            }
            set
            {
                VSTSMonitor.Properties.Settings.Default.TFSPassword = value;
                VSTSMonitor.Properties.Settings.Default.Save();
            }
        }
    }
}
