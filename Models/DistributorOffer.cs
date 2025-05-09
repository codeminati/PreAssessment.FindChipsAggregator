namespace PreAssessment.FindChipsAggregator.Models
{
    public class DistributorOffer
    {
        public string DistributorName { get; set; }
        public string SellerName { get; set; }
        public int MOQ { get; set; }
        public int SPQ { get; set; }
        public decimal UnitPrice { get; set; }
        public string Currency { get; set; }
        public string OfferUrl { get; set; }
        public DateTime Timestamp { get; set; }
    }


}
