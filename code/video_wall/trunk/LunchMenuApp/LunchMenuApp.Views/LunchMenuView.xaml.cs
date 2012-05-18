using ViewModels.Lunch;

namespace Views.Xaml
{
    /// <summary>
    /// Interaction logic for LunchMenuView.xaml
    /// </summary>
    public partial class LunchMenuView
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LunchMenuView"/> class.
        /// </summary>
        public LunchMenuView(LunchMenuViewModel lunchMenuViewModel)
        {
            DataContext = lunchMenuViewModel;
            InitializeComponent();
        }
    }
}
