using System.Globalization;
using System.IO;
using CsvHelper;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System;

namespace AvaloniaLiveChartsApp;

public partial class ViewModel : ObservableObject
{
  public ISeries[] Series { get; set; }

  public ViewModel()
  {
    var dataPoints = LoadDataFromCsv("data.csv");

    Series = new ISeries[]
    {
            new LineSeries<double>
            {
                Values = dataPoints.Select(dp => dp.Value).ToArray(),
                Fill = null
            }
    };
  }

  public class DataPoint
{
    public DateTime Date { get; set; }
    public double Value { get; set; }
}


  private List<DataPoint> LoadDataFromCsv(string filePath)
  {
    using var reader = new StreamReader(filePath);
    using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
    return csv.GetRecords<DataPoint>().ToList();
  }


}


