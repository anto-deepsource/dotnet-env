using System;
using System.Text;
using System.Collections.Generic;

public static class DecimalExtensions
{
    public static string ToCurrency(this decimal amount)
    {
        // Dummy implementation for converting decimal to currency string
        return amount.ToString("C");
    }
}

// Assuming a class structure for the items in result.Funding
public class FundingItem
{
    public string FundType { get; set; }
    public decimal FundAmount { get; set; }
    public string SourceDescription { get; set; }
    public DateTime CreatedDate { get; set; }
    public string ProjectNameFrom { get; set; }
    public string TransferReason { get; set; }
}

// Assuming a class structure for the result
public class Result
{
    public List<FundingItem> Funding { get; set; }
}

public class TruthyCheck
{
    public void ProcessFunding()
    {
        // Assuming result is defined and populated somewhere in your code
        Result result = new Result
        {
            Funding = new List<FundingItem>
            {
                new FundingItem
                {
                    FundType = "Grant",FundAmount = 1000.00m,
                    SourceDescription = "Government Grant",
                    CreatedDate = DateTime.Now,
                    ProjectNameFrom = "Project A",
                    TransferReason = "Initial Funding"
                }
                // Add more FundingItem objects as needed
            }
        };

        // Assuming fundingRow is a string template and fundingRows is a StringBuilder
        string fundingRow = "Template string with placeholders";
        StringBuilder fundingRows = new StringBuilder();

        foreach (var item in result.Funding)
        {
            fundingRows.AppendLine($"{fundingRow
                .Replace("$$FundingType$$", item.FundType)
                .Replace("$$FundingAmount$$", item.FundAmount.ToCurrency())
                .Replace("$$FundingDescription$$", item.SourceDescription)
                .Replace("$$FundingDate$$", item.CreatedDate.ToString("d"))
                .Replace("$$FundingTransferFrom$$", item.ProjectNameFrom)
                .Replace("$$FundingTransferReason$$", item.TransferReason)} ");
        }

        // Output the result for debugging
        Console.WriteLine(fundingRows.ToString());
    }
}
