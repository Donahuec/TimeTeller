using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TimeTeller.Models;
using Xamarin.Forms;

namespace TimeTeller.Views
{
    public partial class ListPage : ContentPage
    {
        public ListPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Retrieve all the tasks from the database, and set them as the
            // data source for the CollectionView.
            collectionView.ItemsSource = await App.Database.GetTaskEntriesAsync();
        }

        async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection != null)
            {
                // Navigate to the TaskeEntryPage, passing the ID as a query parameter.
                TaskEntry task = (TaskEntry)e.CurrentSelection.FirstOrDefault();
                await Shell.Current.GoToAsync($"{nameof(TaskEntryPage)}?{nameof(TaskEntryPage.ItemId)}={task.ID.ToString()}");
            }
        }

        async void OnAddClicked(object sender, EventArgs e)
        {
            // Navigate to the TaskEditPage, without passing any data.
            await Shell.Current.GoToAsync(nameof(TaskEditPage));
        }
    }
}