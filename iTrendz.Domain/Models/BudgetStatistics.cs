namespace iTrendz.Domain.Models;

public class BudgetStatistics
{
    public double[] BudgetHistoryData { get; set; }
    public string[] BudgetHistoryLabels { get; set; }

    public double[] BudgetAllocationData { get; set; }
    public string[] BudgetAllocationLabels { get; set; }
}
