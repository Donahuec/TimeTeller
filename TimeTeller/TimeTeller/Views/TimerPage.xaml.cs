using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTeller.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TimeTeller.Views
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public partial class TimerPage : ContentPage
    {
        Stopwatch stopwatch;
        int taskId;

        public string ItemId
        {
            set
            {
                LoadTask(value);
            }
        }

        public TimerPage()
        {
            InitializeComponent();
            stopwatch = new Stopwatch();

            lblTimer.Text = "00:00:00";
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
            }
            catch (Exception)
            {
                Console.WriteLine("Failed to load task.");
            }
        }


        protected void OnStartButtonClicked(object sender, EventArgs e)
        {
            if (!stopwatch.IsRunning)
            {
                stopwatch.Start();

                Device.StartTimer(TimeSpan.FromMilliseconds(100), () =>
                {
                    lblTimer.Text = stopwatch.Elapsed.ToString(@"hh\:mm\:ss");

                    if (!stopwatch.IsRunning)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                });
            }
        }

        protected void OnStopButtonClicked(object sender, EventArgs e)
        {
            stopwatch.Stop();
        }

        protected void OnResetButtonClicked(object sender, EventArgs e)
        {
            lblTimer.Text = "00:00:00";
            stopwatch.Reset();
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var timeEntry = new TimeEntry()
            {
                TaskId = Convert.ToInt32(taskId),
                Time = stopwatch.Elapsed,
                RecordedTime = DateTime.Now
            };

            await App.Database.SaveTimeEntryAsync(timeEntry);

            // Navigate backwards
            await Shell.Current.GoToAsync("..");
        }
    }
}