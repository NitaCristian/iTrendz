namespace iTrendz.Domain.Models;

public class BudgetStatistics
{
    public double InitialBudget { get; set; }
    public double RemainingBudget { get; set; }
    public double[] BudgetHistoryData { get; set; }
    public string[] BudgetHistoryLabels { get; set; }

    public double[] BudgetAllocationData { get; set; }
    public string[] BudgetAllocationLabels { get; set; }
}
