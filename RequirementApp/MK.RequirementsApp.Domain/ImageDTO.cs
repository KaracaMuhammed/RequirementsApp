using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MK.RequirementsApp.Domain
{
    public class ImageDTO
    {
        public int Id { get; set; }
        public string ProductImage { get; set; }
        public int ProductId { get; set; }
    }
}
