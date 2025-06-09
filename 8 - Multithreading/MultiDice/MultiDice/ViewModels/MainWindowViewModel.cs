namespace MultiDice.ViewModels;

using System.Collections.Generic;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System;
using Avalonia;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using Avalonia.Threading;
using MultiDice.Models;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty]
    private Bitmap? dieOneImage;

    [ObservableProperty]
    private Bitmap? dieTwoImage;

    [ObservableProperty]
    private int result;

    private DiceGame _diceGame;
    
    private List<Bitmap> _images;

    public MainWindowViewModel()
    {
        _images = new List<Bitmap>();

        // TODO : Fill List with images using ImageHelper

          _images = [
            ImageHelper.LoadFromResource(new Uri ("avares://MultiDice/Assets/dice1.png")),
            ImageHelper.LoadFromResource(new Uri ("avares://MultiDice/Assets/dice2.png")),
            ImageHelper.LoadFromResource(new Uri ("avares://MultiDice/Assets/dice3.png")),
            ImageHelper.LoadFromResource(new Uri ("avares://MultiDice/Assets/dice4.png")),
            ImageHelper.LoadFromResource(new Uri ("avares://MultiDice/Assets/dice5.png")),
            ImageHelper.LoadFromResource(new Uri ("avares://MultiDice/Assets/dice6.png")),
             ];      
          
        _diceGame = new DiceGame(this);

        // TODO : Set both Die Images to One
        dieOneImage = _images[0];
        dieTwoImage = _images[0];
        
    }

    // TODO : start the dice game
    [RelayCommand]
    public async Task Start()
    {
       await _diceGame.Start();
    }

    // TODO : stop the dice game
    [RelayCommand]
    public void Stop()
    {
        _diceGame.Stop();
    }

    // TODO : update UI on UI Thread
    public async Task Update(int d1, int d2, int count)
    {
        await Dispatcher.UIThread.InvokeAsync( () =>
        {
            DieOneImage = _images[d1 - 1];
            DieTwoImage = _images[d2 - 1];
            Result = count;
        });
    }

}
