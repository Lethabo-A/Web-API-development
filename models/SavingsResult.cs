using System.Diagnostics;

public class SavingsResult
{
    public int TotalHumanTimeSaved { get; set; }
    public decimal TotalCostSaved { get; set; }
    public List<Process> Processes { get; set; } // Include this if you need process details
}
