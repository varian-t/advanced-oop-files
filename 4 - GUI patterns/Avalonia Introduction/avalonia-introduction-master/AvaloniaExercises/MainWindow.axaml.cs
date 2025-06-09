using System;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media.Imaging;
using Avalonia.Platform;

namespace AvaloniaExercises;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        this.Width = 600; 
        this.Height = 500;
    }
    private void Exercise2ShowOutput_Click(object sender, RoutedEventArgs e)
    {
        var textBox = this.FindControl<TextBox>("Exercise2TextBox");
        var comboBox = this.FindControl<ComboBox>("Exercise2ComboBox");
        var checkBox = this.FindControl<CheckBox>("Exercise2CheckBox");
        var outputTextBlock = this.FindControl<TextBlock>("OutputTextBlock");

        string output = $"TextBox: {textBox.Text}, ComboBox: {comboBox.SelectionBoxItem}, CheckBox: {checkBox.IsChecked}";
        outputTextBlock.Text = output;
    }
    
    private void Exercise3ShowImage_Click(object sender, RoutedEventArgs e)
    {
        var catRadioButton = this.FindControl<RadioButton>("CatRadioButton");
        var dogRadioButton = this.FindControl<RadioButton>("DogRadioButton");
        var birdRadioButton = this.FindControl<RadioButton>("BirdRadioButton");
        var animalImage = this.FindControl<Image>("AnimalImage");

        if (catRadioButton.IsChecked == true){ 
          animalImage.Source =  new Bitmap(AssetLoader.Open(new Uri("avares://AvaloniaExercises/Assets/cat.jpg")));

        } else if (dogRadioButton.IsChecked == true){
          animalImage.Source = new Bitmap(AssetLoader.Open(new Uri("avares://AvaloniaExercises/Assets/dog.jpg")));

        }else if (birdRadioButton.IsChecked == true){
          animalImage.Source = new Bitmap(AssetLoader.Open(new Uri("avares://AvaloniaExercises/Assets/bird.jpg")));
          
        }
     
    }



    private void AddClick(object sender, RoutedEventArgs e){
        var number1 = this.FindControl<TextBox>("Number1");
        var number2 = this.FindControl<TextBox>("Number2");
        var result = this.FindControl<TextBox>("Result");

        int ResultNumber;

        int num1 = int.Parse(number1.Text);
        int num2 = int.Parse(number2.Text);
        ResultNumber = num1 + num2;

        result.Text = ResultNumber.ToString();

    }

    private void SubtractClick(object sender, RoutedEventArgs e){
        var number1 = this.FindControl<TextBox>("Number1");
        var number2 = this.FindControl<TextBox>("Number2");
        var result = this.FindControl<TextBox>("Result");

        int ResultNumber;

        int num1 = int.Parse(number1.Text);
        int num2 = int.Parse(number2.Text);
        ResultNumber = num1 - num2;

        result.Text = ResultNumber.ToString();

    }

    private void MultiplyClick(object sender, RoutedEventArgs e){
        var number1 = this.FindControl<TextBox>("Number1");
        var number2 = this.FindControl<TextBox>("Number2");
        var result = this.FindControl<TextBox>("Result");

        int ResultNumber;

        int num1 = int.Parse(number1.Text);
        int num2 = int.Parse(number2.Text);
        ResultNumber = num1 * num2;

        result.Text = ResultNumber.ToString();

    }
}
