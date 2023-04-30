namespace ResolutionSelector
{
    public partial class ResolutionsModal : Form
    {
        public ResolutionsModal()
        {
            InitializeComponent();
        }

        private ResolutionsShoutyModel? model = null;
        public ResolutionsShoutyModel? Model
        {
            get => model;
            set
            {
                tearDownOldModelWiring();
                model = value;
                setupModel();
            }
        }

        void tearDownOldModelWiring()
        {
            if(model != null) 
            {
                // unsubscribe from events
            }
        }

        void setupModel()
        {
            if(model is null)
            {
                tearDownOldModelWiring();
            }
            else
            {
                // subscribe to events
            }
        }

    }
}