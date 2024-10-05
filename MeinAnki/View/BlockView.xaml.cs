using CommunityToolkit.Maui.Views;
using MeinAnki.ViewModel;

namespace MeinAnki.View;

public partial class BlockView : ContentPage
{
    private readonly BlockViewModel vm = new BlockViewModel();

    public BlockView()
    {
        InitializeComponent();
        BindingContext = vm;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        // Ожидаем завершения асинхронной операции
        var blockCount = await vm.initialBlock();


    }

    public void OnShowPopup(object sender, EventArgs e)
    {
        this.ShowPopup(new NewBlockPopup());
    }


}