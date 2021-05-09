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
    public partial class TaskEditPage : ContentPage
    {
        public string ItemId
        {
            set
            {
                LoadTask(value);
            }
        }

        public TaskEditPage()
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
                BindingContext = task;
            }
            catch (Exception)
            {
                Console.WriteLine("Failed to load task.");
            }
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var task = (TaskEntry)BindingContext;
            if (!string.IsNullOrWhiteSpace(task.Name))
            {
                await App.Database.SaveTaskEntryAsync(task);
            }

            // Navigate backwards
            await Shell.Current.GoToAsync("..");
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var note = (TaskEntry)BindingContext;
            await App.Database.DeleteTaskEntryAsync(note);

            // Navigate backwards
            await Shell.Current.GoToAsync("..");
        }
    }
}