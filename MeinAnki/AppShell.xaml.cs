using MeinAnki.View;

namespace MeinAnki
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(BlockView), typeof(BlockView));
            Routing.RegisterRoute(nameof(LernenView), typeof(LernenView));
        }
    }
}
