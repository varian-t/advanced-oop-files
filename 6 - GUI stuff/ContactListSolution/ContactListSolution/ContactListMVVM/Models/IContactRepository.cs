using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ContactListMVVM.Models;

public interface IContactRepository
{
    public abstract void Save(string filename, ObservableCollection<Contact> data);
    public abstract ObservableCollection<Contact> Load(string filename);
}