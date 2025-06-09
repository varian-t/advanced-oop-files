
using System;
using System.Collections.ObjectModel;
using System.Text.Json;
using System.IO;

namespace ContactListMVVM.Models {
    public class JSONContactRepository : IContactRepository
    {
        public void Save(string filename, ObservableCollection<Contact> data)
        {
            File.WriteAllText(filename, JsonSerializer.Serialize(data));
        }

        public ObservableCollection<Contact> Load(string filename)
        {
            if (!File.Exists(filename))
            {
                return new ObservableCollection<Contact>();
            }
            return JsonSerializer.Deserialize<ObservableCollection<Contact>>(File.ReadAllText(filename))!;
        }
    }
}