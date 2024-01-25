using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MK.RequirementsApp.Domain
{
    public class Image
    {
        public int Id { get; set; }
        [JsonIgnore] public byte[] ProductImage { get; set; }
        public string Base64Image => Convert.ToBase64String(ProductImage);
        public int ProductId { get; set; }
    }
}
