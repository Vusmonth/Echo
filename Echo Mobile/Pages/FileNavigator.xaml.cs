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
        Connection.On<List<FileItemMobile>>("EXPLORER/FILE_LIST", HandlerRefreshFileList);
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        ListController.ItemsSource = ItemList;
        Connection.InvokeAsync("EXPLORER/LIST_FILES").Wait();
    }

    private void HandlerRefreshFileList(List<FileItemMobile> FileList)
    {
        ItemList.Clear();
        foreach (FileItemMobile Item in FileList)
        {
            ItemList.Add(Item);
        }
        
    }

    private void GoBack(object sender, EventArgs e)
    {
        Connection.InvokeAsync("EXPLORER/GO_BACK").Wait();
    }

}