using CommunityToolkit.Maui.Views;
using MeinAnki.Model;
using MeinAnki.ViewModel;
namespace MeinAnki.View;

public partial class NewBlockPopup : Popup
{
    private readonly NewBlockViewModel vm = new NewBlockViewModel();
    private bool _isPopupClosed = false;

    public NewBlockPopup()
    {
        InitializeComponent();
        BindingContext = vm;

        Mediator.Instance.DataChangedMessage += OnClosePopup;
    }

    private void OnClosePopup(object sender, ClosePopupMessage message)
    {

        if (message.ShouldClose && !_isPopupClosed)
        {
            _isPopupClosed = true; // Устанавливаем флаг, что попап закрыт
            Close(); // Закрытие Popup
        }
    }

}