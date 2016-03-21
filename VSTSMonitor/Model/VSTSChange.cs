namespace VSTSMonitor.Model
{
    public class VSTSChange : ModelBase
    {
        private string _ChangeType;
        private string _FilePath;

        public string ChangeType
        {
            get { return _ChangeType; }
            set
            {
                Set(ref _ChangeType, value, RaisePropertyChanged());
            }
        }

        public string FilePath
        {
            get { return _FilePath; }
            set
            {
                Set(ref _FilePath, value, RaisePropertyChanged());
            }
        }
    }
}