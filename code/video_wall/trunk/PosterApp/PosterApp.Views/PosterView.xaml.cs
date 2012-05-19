using PosterApp.ViewModels;

namespace Views.Xaml
{
    /// <summary>
    /// Interaction logic for PosterView.xaml
    /// </summary>
    public partial class PosterView
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PosterView"/> class.
        /// </summary>
        public PosterView(PosterViewModel posterViewModel)
        {
            DataContext = posterViewModel;
            InitializeComponent();
        }
    }
}
