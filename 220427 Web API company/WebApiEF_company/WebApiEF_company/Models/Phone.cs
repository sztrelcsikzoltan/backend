using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace WebApiEF_company.Models
{
    public partial class Phone
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Type { get; set; }
        [JsonIgnore]
        public int CoworkerId { get; set; }
        [JsonIgnore]
        public virtual Coworker Coworker { get; set; }
    }
}
