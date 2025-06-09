namespace MultiDice.Models;

using MultiDice.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;

using Avalonia;
using Avalonia.Media.Imaging; 


public class DiceGame 
{

    private bool _isRunning = false;
    private MainWindowViewModel _viewModel;

    public DiceGame(MainWindowViewModel viewModel)
    {
        _viewModel = viewModel;
    }

    // TODO : Start rolling the dice
    public async Task Start()
    {
          if (_isRunning) return;
        else _isRunning = true;

        await DiceRolling();
    }

    // TODO : Stop rolling the dice
    public void Stop()
    {
        _isRunning = false;
    }

    // TODO : Start a new DiceRolling Task that rolls 2 dice until either the User presses Stop or 
    // both dice show a 6. Continously Update the UI through the View Model.
    private Task DiceRolling()
    {
        return Task.Run(async () =>
        {
          try{
            Dice dice = new Dice();
            while (_isRunning && !dice.EqualsMax()){
              await Task.Delay(200);
              dice.ThrowDice();

              await _viewModel.Update(dice.Die1, dice.Die2, dice.Count);
            }

            Stop();
          }

          catch(Exception ex){
            Console.WriteLine($"DiceGame Task Error: {ex.Message}");
          }



        }
        
        );
  
    }

}