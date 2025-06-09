using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using Avalonia.Interactivity;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ContactListMVVM.Models;

namespace ContactListMVVM.ViewModels;

public partial class MainWindowViewModel : ObservableObject
{
    public ObservableCollection<Contact> Contacts { get; } = new();

    private IContactRepository _contactRepository = new JSONContactRepository();

    [ObservableProperty]
    private string? newContactName;

    [ObservableProperty]
    private string? newContactEmail;

    [ObservableProperty]
    private Contact? selectedContact;

    public MainWindowViewModel()
    {
        Contacts = _contactRepository.Load("contacts.json");
    }

    [RelayCommand]
    public void AddContact()
    {
        if (string.IsNullOrWhiteSpace(NewContactName) || string.IsNullOrWhiteSpace(NewContactEmail))
        {
            return;
        }

        Contacts.Add(new Contact { Name = NewContactName!, Email = NewContactEmail! });
        NewContactName = NewContactEmail = null;
    }

    [RelayCommand]
    public void DeleteContact()
    {
        if (SelectedContact is not null)
        {
            Contacts.Remove(SelectedContact);
        }
    }

    [RelayCommand]
    public void SaveDataCommand()
    {
        _contactRepository.Save("contacts.json", Contacts);
    }
}
