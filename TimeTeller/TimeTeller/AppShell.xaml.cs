using TimeTeller.Views;
using Xamarin.Forms;

namespace TimeTeller
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(TimerPage), typeof(TimerPage));
            Routing.RegisterRoute(nameof(TaskEntryPage), typeof(TaskEntryPage));
            Routing.RegisterRoute(nameof(TaskEditPage), typeof(TaskEditPage));
        }
    }
}