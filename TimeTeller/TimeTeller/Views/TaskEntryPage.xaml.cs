using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTeller.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TimeTeller.Views
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public partial class TaskEntryPage : ContentPage
    {
        public string ItemId
        {
            set
            {
                LoadTask(value);
            }
        }

        int taskId;

        public TaskEntryPage()
        {
            InitializeComponent();

            // Set the BindingContext of the page to a new Note.
            BindingContext = new TaskEntry();
        }

        async void LoadTask(string itemId)
        {
            try
            {
                int id = Convert.ToInt32(itemId);
                // Retrieve the note and set it as the BindingContext of the page.
                TaskEntry task = await App.Database.GetTaskEntryAsync(id);
                taskId = task.ID;
                BindingContext = task;
                timeCollectionView.ItemsSource = await App.Database.GetTimeEntriesForTaskAsync(task.ID);
            }
            catch (Exception)
            {
                Console.WriteLine("Failed to load task.");
            }
        }

        async void OnAddClicked(object sender, EventArgs e)
        {
            // Navigate to the TaskEditPage, without passing any data.
            await Shell.Current.GoToAsync($"{nameof(TimerPage)}?{nameof(TimerPage.ItemId)}={taskId}");
        }

        async void OnEditClicked(object sender, EventArgs e)
        {

            // Navigate to the TaskEditPage, without passing any data.
            await Shell.Current.GoToAsync($"{nameof(TaskEditPage)}?{nameof(TaskEditPage.ItemId)}={taskId}");
        }
    }
}