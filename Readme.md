FindChips Distributor Data Aggregation Tool

Objective:
Scrape distributor offers from FindChips for a specific part number (“2N222”), and export structured results to Excel. Test ability to work with external sites, asynchronous programming, and data export.

Features:

Retrieves offers from up to 5 distributors

Extracts key fields per offer:

Distributor Name

Seller Name

MOQ

SPQ (if not found, default to 0)

Unit Price

Currency

Offer URL (if available)

Timestamp

Technologies:

.NET Core or .NET 6/8 Console App

HtmlAgilityPack for scraping

Newtonsoft.Json for parsing embedded JSON

ClosedXML for Excel export

Asynchronous HTTP with HttpClient

Steps:

Make an HTTP GET request to: https://www.findchips.com/search/2N222

Parse HTML using HtmlAgilityPack

Extract offer rows containing data-id and data-price attributes

Decode and deserialize JSON price entries

Store results in a list of custom objects

Export to Excel using ClosedXML

Asynchronous Handling:

All web requests and parsing are performed asynchronously

Resilient to timeouts and partial failures

Excel Output Columns:

DistributorName

SellerName

MOQ

SPQ

UnitPrice

Currency

OfferUrl

Timestamp

Example Output:
Distributor: Mouser
MOQ: 100
Price: 32.00
Currency: INR
Timestamp: 2025-05-09 14:00:00

Testing Instructions:

Run from console

Open Excel file to verify structure

Validate prices, fields, and formatting

Edge Cases:

Missing JSON or malformed price list skipped

Duplicate entries avoided

Fails gracefully if site structure changes
