using System.Collections.ObjectModel;
using Echo_Mobile.Models;
using Echo_Mobile.Services;
using EchoUtility;
using Microsoft.AspNetCore.SignalR.Client;

namespace Echo_Mobile.Pages;

public partial class FileNavigator : ContentPage
{
    public ObservableCollection<FileItemMobile> ItemList = new();
    HubConnection Connection;

    public FileNavigator()
    {
        InitializeComponent();
        Connection = Services.SignalRClient.Build(5093);
        Connection.On<ObservableCollection<FileItemMobile>>("EXPLORER/FILE_LIST", HandlerRefreshFileList);
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        ListController.ItemsSource = ItemList;
        ItemList.Clear();
        await Connection.InvokeAsync("EXPLORER/LIST_FILES");
    }

    private void HandlerRefreshFileList(ObservableCollection<FileItemMobile> FileList)
    {
        ListController.Dispatcher.Dispatch(() =>
        {
            ListController.ItemsSource = FileList;
        });       
    }

    private void GoBack(object sender, EventArgs e)
    {
        Connection.InvokeAsync("EXPLORER/GO_BACK").Wait();
    }

}