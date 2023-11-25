using System.Collections.ObjectModel;
using System.Diagnostics;
using Echo_Mobile.Models;
using EchoUtility;
using Microsoft.AspNetCore.SignalR.Client;

namespace Echo_Mobile.Pages;

public partial class FileNavigator : ContentPage
{
    public ObservableCollection<FileItemMobile> ItemList = new();
    HubConnection client = SignalRClient.Connect("https://ordinary-edge-production.up.railway.app/explorer");

    public FileNavigator()
    {
        InitializeComponent();
        try
        {
            client.On<ObservableCollection<FileItemMobile>>("EXPLORER/FILE_LIST", HandlerRefreshFileList);
            ListController.SelectionChanged += OnSelectItem;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
        }

    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        ListController.ItemsSource = ItemList;
        ItemList.Clear();
        await client.InvokeAsync("EXPLORER/LIST_FILES");
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
        client.InvokeAsync("EXPLORER/GO_BACK").Wait();
    }

    private async void OnSelectItem(object sender, SelectionChangedEventArgs e)
    {
        FileItemMobile item = (FileItemMobile)e.CurrentSelection[0];
        if (item.Type == FileType.directory)
        {
            await client.InvokeAsync("EXPLORER/NAVIGATE_TO", item.Name.Replace("\\", ""));
        }

    }

}