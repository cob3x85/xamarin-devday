using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using xamarin_devday.Entities;
using xamarin_devday.Interfaces;
using xamarin_devday.iOS.Service;
using System.Collections.ObjectModel;

[assembly:Dependency(typeof(Service_iOS))]
namespace xamarin_devday.iOS.Service
{
    public class Service_iOS : IService
    {
        public async Task<ObservableCollection<Note>> GetNotesAsync()
        {
            IEnumerable<Note> items = await AppDelegate.MobileService.GetTable<Note>().ToEnumerableAsync();
            return new ObservableCollection<Note>(items);
        }

        public async Task<bool> Log(string note, string noteType)
        {
            CurrentPlatform.Init();

            Note obj_note = new Note();
            obj_note.id = Guid.NewGuid().ToString();
            obj_note.note = note;
            obj_note.noteType = noteType;
            obj_note.device = "iOS Device";

            await AppDelegate.MobileService.GetTable<Note>().InsertAsync(obj_note);

            return true;
        }
    }
}