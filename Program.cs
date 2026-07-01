using IntelligencePipeline.Models.Reports;
using System;
namespace IntelligencePipeline;

class Program
{
    static void Main()
    {
        SignalReport signal1 = new SignalReport(1, DateTime.Now, 23.0050, 58.0588, "all him", 850, "ioio attack?", Models.Enums.Language.English,-101);
        signal1.ReliabilityScore = signal1.CalculateReliabilityScore();
        Console.WriteLine(signal1.ToString());
    }
}