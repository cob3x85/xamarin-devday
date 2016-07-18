using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using xamarin_devday.Entities;
using xamarin_devday.Interfaces;

namespace xamarin_devday.Manager
{
    public class ServiceManager
    {
        public static async Task<bool> LogAsync(string note, string noteType)
        {
            return await DependencyService.Get<IService>().Log(note, noteType);
        }

        public static async Task<ObservableCollection<Note>> GetNotesAsync()
        {
            return await DependencyService.Get<IService>().GetNotesAsync();
        }
    }
}
