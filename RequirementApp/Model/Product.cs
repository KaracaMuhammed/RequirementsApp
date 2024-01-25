using System.Text.Json.Serialization;

namespace MK.RequirementsApp.Domain
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Importance Importance { get; set; }
        public Status Status { get; set; }
        public List<Company> Companies { get; set; }
        public string? Image { get; set; }

    }

    public enum Importance
    { 
        Medium,
        Important,
        Small
    }

    public enum Status
    {
        NotPurchased,
        InProgress,
        Purchased
    }
}