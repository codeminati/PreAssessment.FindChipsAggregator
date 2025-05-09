
using HtmlAgilityPack;
using Newtonsoft.Json;
using PreAssessment.FindChipsAggregator.Models;

namespace PreAssessment.FindChipsAggregator.Services
{
    public class FindChipsScraper
    {
        private static readonly HttpClient _httpClient = new();

        public async Task<List<DistributorOffer>> GetDistributorOffersAsync(string partNumber)
        {
            var offers = new List<DistributorOffer>();
            var url = $"https://www.findchips.com/search/{partNumber}";
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                throw new Exception("Unable to fetch FindChips page");

            var html = await response.Content.ReadAsStringAsync();
            var doc = new HtmlDocument();
            doc.LoadHtml(html);

            var offerRows = doc.DocumentNode.SelectNodes("//tr[@data-id]");
            if (offerRows == null) return offers;

            foreach (var row in offerRows)
            {
                try
                {
                    var distributorName = row.GetAttributeValue("data-distributor_name", "Unknown");
                    var sellerName = row.GetAttributeValue("data-mfr", "Unknown");

                    var encodedPriceJson = row.GetAttributeValue("data-price", "");
                    var priceJson = System.Net.WebUtility.HtmlDecode(encodedPriceJson);

                    var priceList = JsonConvert.DeserializeObject<List<List<string>>>(priceJson);
                    if (priceList == null) continue;

                    foreach (var priceEntry in priceList)
                    {
                        if (priceEntry.Count < 3) continue;

                        int moq = int.TryParse(priceEntry[0], out var m) ? m : 0;
                        string currency = priceEntry[1];
                        decimal unitPrice = decimal.TryParse(priceEntry[2], out var p) ? p : 0;

                        offers.Add(new DistributorOffer
                        {
                            DistributorName = distributorName,
                            SellerName = sellerName,
                            MOQ = moq,
                            SPQ = 0, // SPQ not available in the provided HTML
                            UnitPrice = unitPrice,
                            Currency = currency,
                            OfferUrl = "", // Offer URL not available in the provided HTML
                            Timestamp = DateTime.Now
                        });
                    }
                }
                catch
                {
                    continue;
                }
            }

            return offers;
        }
    }
}
