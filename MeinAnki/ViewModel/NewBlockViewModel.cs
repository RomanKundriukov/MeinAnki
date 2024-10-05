using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MeinAnki.Model;
using MeinAnki.Service;

namespace MeinAnki.ViewModel
{
    public partial class NewBlockViewModel : BaseViewModel
    {
        //private readonly NewBlockPopup _blockPopup = new NewBlockPopup();
        //private readonly BlockView _block = new BlockView();
        [ObservableProperty]
        string? _blockName;

        [RelayCommand]
        public async void CreateBlock(string NameBlock)
        {
            if (NameBlock is null || NameBlock.Length == 0)
            {
                Task.Run(async () =>
                {
                    //    await Task.Delay(2000);
                    //    //App.AlertSvc.ShowConfirmation("Fehler", "Name darf nicht leer sein", (result =>
                    //    //{
                    //    //    App.AlertSvc.ShowAlert("Result", $"{result}");
                    //    //}));
                    App.AlertSvc.ShowAlert("Fehler", "Name darf nicht leer sein");
                });

            }
            else
            {
                await DB.SetDaten(NameBlock);

                Mediator.Instance.Notify(NameBlock);

                Mediator.Instance.Notify(new ClosePopupMessage(true));
            }
        }


    }
}
