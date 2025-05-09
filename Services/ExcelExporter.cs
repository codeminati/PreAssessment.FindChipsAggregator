
using OfficeOpenXml;
using PreAssessment.FindChipsAggregator.Models;

namespace PreAssessment.FindChipsAggregator.Services
{
    public class ExcelExporter
    {
        public void ExportOffersToExcel(List<DistributorOffer> offers, string filePath)
        {
            ExcelPackage.License.SetNonCommercialPersonal("Name");
            using var package = new ExcelPackage();
            var worksheet = package.Workbook.Worksheets.Add("Distributor Offers");

            // Headers
            worksheet.Cells[1, 1].Value = "Distributor Name";
            worksheet.Cells[1, 2].Value = "Seller Name";
            worksheet.Cells[1, 3].Value = "MOQ";
            worksheet.Cells[1, 4].Value = "SPQ";
            worksheet.Cells[1, 5].Value = "Unit Price";
            worksheet.Cells[1, 6].Value = "Currency";
            worksheet.Cells[1, 7].Value = "Offer URL";
            worksheet.Cells[1, 8].Value = "Timestamp";

            // Data
            for (int i = 0; i < offers.Count; i++)
            {
                var offer = offers[i];
                worksheet.Cells[i + 2, 1].Value = offer.DistributorName;
                worksheet.Cells[i + 2, 2].Value = offer.SellerName;
                worksheet.Cells[i + 2, 3].Value = offer.MOQ;
                worksheet.Cells[i + 2, 4].Value = offer.SPQ;
                worksheet.Cells[i + 2, 5].Value = offer.UnitPrice;
                worksheet.Cells[i + 2, 6].Value = offer.Currency;
                worksheet.Cells[i + 2, 7].Value = offer.OfferUrl;
                worksheet.Cells[i + 2, 8].Value = offer.Timestamp.ToString("g");
            }

            package.SaveAs(new FileInfo(filePath));
        }
    }

}

//public class ExcelExporter
//{
//    public void Export(List<DistributorOffer> offers, string filePath)
//    {
//        ExcelPackage.License.SetNonCommercialPersonal("Name");
//        using var package = new ExcelPackage();
//        var worksheet = package.Workbook.Worksheets.Add("Offers");

//        // Header
//        var headers = new[] { "Distributor", "Seller", "MOQ", "SPQ", "Unit Price", "Currency", "Offer URL", "Timestamp" };
//        for (int i = 0; i < headers.Length; i++)
//            worksheet.Cells[1, i + 1].Value = headers[i];

//        // Data
//        for (int i = 0; i < offers.Count; i++)
//        {
//            var o = offers[i];
//            worksheet.Cells[i + 2, 1].Value = o.DistributorName;
//            worksheet.Cells[i + 2, 2].Value = o.SellerName;
//            worksheet.Cells[i + 2, 3].Value = o.MOQ;
//            worksheet.Cells[i + 2, 4].Value = o.SPQ;
//            worksheet.Cells[i + 2, 5].Value = o.UnitPrice;
//            worksheet.Cells[i + 2, 6].Value = o.Currency;
//            worksheet.Cells[i + 2, 7].Value = o.OfferUrl;
//            worksheet.Cells[i + 2, 8].Value = o.Timestamp;
//        }

//        worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();
//        File.WriteAllBytes(filePath, package.GetAsByteArray());
//    }
//}



