Objective:
Scrape offer data for the electronic part “2N222” from FindChips (https://www.findchips.com), focusing on extracting structured offer information from up to 5 distributors.

Data to Extract:

Distributor Name

Seller Name (if available)

MOQ (Minimum Order Quantity)

SPQ (not provided, use 0 as default)

Unit Price

Currency

Timestamp

Offer URL (not available, leave as empty string)

Tech Stack:

.NET 6 or above

HtmlAgilityPack

Newtonsoft.Json

Folder Structure:
PreAssessment.FindChipsAggregator/

Models/

DistributorOffer.cs

Services/

FindChipsScraper.cs

Program.cs

How It Works:

Sends an HTTP GET request to https://www.findchips.com/search/2N222.

Parses the HTML using HtmlAgilityPack.

For each offer row with "data-id":

Extracts JSON string from the "data-price" attribute.

Decodes HTML-encoded characters.

Parses into a list of price tiers.

Creates DistributorOffer objects for each tier.

Edge Case Handling:

Handles malformed JSON by decoding HTML entities.

Missing or invalid values are skipped or defaulted.

Errors in processing individual rows don’t stop execution.

Example Usage:
var scraper = new FindChipsScraper();
var offers = await scraper.GetDistributorOffersAsync("2N222");

Example Output:
[
{
"DistributorName": "Mouser",
"SellerName": "ON Semi",
"MOQ": 100,
"SPQ": 0,
"UnitPrice": 0.35,
"Currency": "USD",
"OfferUrl": "",
"Timestamp": "2025-05-09T12:30:00"
}
]

