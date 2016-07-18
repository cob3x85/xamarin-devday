using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using xamarin_devday.Interfaces;
using Xamarin.Forms;
using xamarin_devday.Droid.Service;
using Microsoft.WindowsAzure.MobileServices;
using xamarin_devday.Entities;
using System.Collections.ObjectModel;

[assembly:Dependency(typeof(Service_Droid))]
namespace xamarin_devday.Droid.Service
{
    public class Service_Droid : IService
    {
        public async Task<ObservableCollection<Note>> GetNotesAsync()
        {
            IEnumerable<Note> items = await MainActivity.MobileService.GetTable<Note>().ToEnumerableAsync();
            return new ObservableCollection<Note>(items);
        }

        public async Task<bool> Log(string note, string noteType)
        {
            CurrentPlatform.Init();

            Note obj_note = new Note();
            obj_note.id = Guid.NewGuid().ToString();
            obj_note.note = note;
            obj_note.noteType = noteType;
            obj_note.device = "Droid Device";

            await MainActivity.MobileService.GetTable<Note>().InsertAsync(obj_note);

            return true;
        }
    }
}