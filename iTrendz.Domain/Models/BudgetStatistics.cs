namespace iTrendz.Domain.Models;

public class BudgetStatistics
{
    public List<ChartSeries> BudgetHistoryData { get; set; }
    public string[] BudgetHistoryLabels { get; set; }

    public double[] BudgetAllocationData { get; set; }
    public string[] BudgetAllocationLabels { get; set; }
}

public class ChartSeries
{
    public string Name { get; set; }
    public double[] Data { get; set; }
    public bool Visible { get; set; } = true;
    public int Index { get; set; }
}