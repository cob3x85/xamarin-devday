using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xamarin_devday.Entities;

namespace xamarin_devday.Interfaces
{
    public interface IService
    {
        Task<bool> Log(string note, string noteType);

        Task<ObservableCollection<Note>> GetNotesAsync();
    }
}
