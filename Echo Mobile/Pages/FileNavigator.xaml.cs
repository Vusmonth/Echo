using System.Collections.ObjectModel;
using Echo_Mobile.Services;
using EchoUtility;
using Microsoft.AspNetCore.SignalR.Client;

namespace Echo_Mobile.Pages;

public partial class FileNavigator : ContentPage
{
    public ObservableCollection<FileItem> ItemList = new();
    HubConnection Connection;

    public FileNavigator()
	{
		InitializeComponent();
        Connection = SignalRClient.Build(5093);
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        ListController.ItemsSource = ItemList;
        try
        {
        Connection.On<List<FileItem>>("EXPLORER/FILE_LIST", HandlerRefreshFileList);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
        MockData();
    }

    private void HandlerRefreshFileList(List<FileItem> FileList)
    {
        //ItemList = FileList;
        Console.WriteLine(FileList);
    }

    public void MockData()
    {
        ItemList.Clear();
        ItemList.Add(new FileItem(FileType.directory, "/Documents", DateTime.Now));
        ItemList.Add(new FileItem(FileType.directory, "/Images", DateTime.Now));
        ItemList.Add(new FileItem(FileType.directory, "/Downloads", DateTime.Now));
        ItemList.Add(new FileItem(FileType.file, "Teste.png", DateTime.Now));

    }
}