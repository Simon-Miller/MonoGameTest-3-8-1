namespace ResolutionSelector
{
    public class ResolutionsShoutyModel
    {
        IEnumerable<string> resolutions = null!;
        public IEnumerable<string> Resolutions
        {
            get => resolutions;
            set
            {
                resolutions = value;
                ResolutionsChanged?.Invoke(value);
            }
        }
        public event Action<IEnumerable<string>?>? ResolutionsChanged;

        bool wantFullScreen = false;
        public bool WantFullScreen
        {
            get => wantFullScreen;
            set
            {
                wantFullScreen = value;
                WantFullScreenChanged?.Invoke(value);
            }
        }
        public event Action<bool>? WantFullScreenChanged;

        int? selectedResolution = null;
        public int? SelectedResolution
        {
            get => selectedResolution;
            set
            {
                selectedResolution = value;
                SelectedResolutionChanged?.Invoke(value);
            }
        }
        public event Action<int?>? SelectedResolutionChanged;
    }
}
