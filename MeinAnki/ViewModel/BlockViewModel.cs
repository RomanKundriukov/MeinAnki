using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MeinAnki.Model;
using MeinAnki.Service;
using System.Collections.ObjectModel;

namespace MeinAnki.ViewModel
{
    public partial class BlockViewModel : BaseViewModel
    {

        public BlockViewModel()
        {

            Mediator.Instance.DataChangedString += OnDataChanged;
        }

        private async void RefreshData(string blockName)
        {

            //var deleteData = BlockCollection.FirstOrDefault(x => x.Name == blockName);
            //if (deleteData != null)
            //{
            //    BlockCollection.Remove(deleteData);
            //}

            var blocks = await DB.GetAll();
            BlockCollection.Clear();

            if (blocks.Count > 0) // Убедись, что первый элемент не null
            {
                IsVisible = false;

                for (int i = 0; i < blocks.Count; i++)
                {
                    BlockCollection.Add(new BlockViewModel { Name = blocks[i].Name });
                }

            }


            OnPropertyChanged(nameof(BlockCollection));

        }

        private void OnDataChanged(object sender, string newData)
        {

            IsVisible = false;

            //var data = BlockCollection.FirstOrDefault(x => Name == newData);
            if (BlockCollection.FirstOrDefault(x => x.Name == newData) == null)
            {
                BlockCollection.Add(new BlockViewModel { Name = newData });
            }




            OnPropertyChanged(nameof(BlockCollection));
        }

        public async Task<int> initialBlock()
        {
            var blocks = await DB.GetAll();
            BlockCollection.Clear();

            if (blocks.Count > 0) // Убедись, что первый элемент не null
            {
                IsVisible = false;

                for (int i = 0; i < blocks.Count; i++)
                {
                    BlockCollection.Add(new BlockViewModel { Name = blocks[i].Name });
                }

            }
            else
            {
                Name = "Keine Daten";
            }
            return blocks.Count;
        }

        [ObservableProperty]
        static ObservableCollection<BlockViewModel> _blockCollection = new ObservableCollection<BlockViewModel>();

        [ObservableProperty]
        string? _name;

        [ObservableProperty]
        bool _isVisible = true;

        [RelayCommand]
        public async void DeleteBlock(string NameBlock)
        {
            if (string.IsNullOrWhiteSpace(NameBlock))
            {
                App.AlertSvc.ShowAlert("Fehler", "Name darf nicht leer sein");
                return;
            }

            // Сначала удаляем блок из базы данных
            await DB.DelDaten(NameBlock);

            //Mediator.Instance.Notify(NameBlock);
            RefreshData(NameBlock);
        }

        [RelayCommand]
        public async void UpdateBlock(string NameBlock)
        {
            if (NameBlock is null || NameBlock.Length == 0)
            {
                Task.Run(async () =>
                {
                    App.AlertSvc.ShowAlert("Fehler", "Name darf nicht leer sein");
                });

            }
            else
            {
                await DB.UpDaten(NameBlock);
                //Mediator.Instance.Notify(NameBlock);
                //Mediator.Instance.Notify(new ClosePopupMessage(true));
            }
        }
    }
}
