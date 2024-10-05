using MeinAnki.ViewModel;

namespace MeinAnki.View;

public partial class LernenView : ContentPage
{
    private readonly LernenViewModel vm = new LernenViewModel();
    public LernenView()
    {
        InitializeComponent();
        BindingContext = vm;
    }
}