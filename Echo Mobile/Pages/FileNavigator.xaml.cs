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
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        ListController.ItemsSource = ItemList;
        try
        {
            Connection.On<List<FileItemMobile>>("EXPLORER/FILE_LIST", HandlerRefreshFileList);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
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

}