using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CompanyAPI.Models
{
    public class EntrepreneurModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        [JsonIgnore]
        public ICollection<CompanyModel> Companies { get; set; }
    }
}