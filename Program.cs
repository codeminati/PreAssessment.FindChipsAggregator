using PreAssessment.FindChipsAggregator.Services;

class Program
{
    static async Task Main(string[] args)
    {
        var scraper = new FindChipsScraper();
        var offers = await scraper.GetDistributorOffersAsync("2N222");

        Console.WriteLine($"Fetched {offers.Count} offers");

        var exporter = new ExcelExporter();
        exporter.ExportOffersToExcel(offers, "FindChips_Offers.xlsx");

        Console.WriteLine("Export complete. File saved as 'FindChips_Offers.xlsx'.");
    }
}
