﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MK.RequirementsApp.Domain
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore] public List<Product> Products { get; set; }

    }
}
