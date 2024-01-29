using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MK.RequirementsApp.Domain
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public Importance Importance { get; set; }
        public Status Status { get; set; }
        public List<int> CompaniesIds { get; set; }

    }
}
