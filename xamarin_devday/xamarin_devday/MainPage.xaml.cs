using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using xamarin_devday.Entities;
using xamarin_devday.Manager;

namespace xamarin_devday
{
    public partial class MainPage : ContentPage
    {
        List<Note> notes = new List<Note>();

        public MainPage()
        {
            InitializeComponent();                
        }

        protected async void OnAppearing(object sender, EventArgs args)
        {
            lsvNotes.ItemsSource = await ServiceManager.GetNotesAsync();
        }

        protected async void OnRefreshing(object sender, EventArgs args)
        {
            var list = (ListView)sender;
            lsvNotes.ItemsSource = await ServiceManager.GetNotesAsync();
            list.EndRefresh();
        }

        protected async void OnClicked(object sender, EventArgs args)
        {
            await ServiceManager.LogAsync(txtNote.Text, pckNote.Items[pckNote.SelectedIndex]);
            txtNote.Text = string.Empty;
            lsvNotes.ItemsSource = await ServiceManager.GetNotesAsync();
        }
    }
}
