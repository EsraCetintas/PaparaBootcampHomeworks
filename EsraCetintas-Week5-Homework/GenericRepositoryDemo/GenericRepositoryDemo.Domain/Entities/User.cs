using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepositoryDemo.Domain.Entities
{
    public class User : BaseEntity
    {
        [JsonProperty("UserId")]
        public int userId { get; set; }

        [JsonProperty("Title")]

        public string title { get; set; }

        [JsonProperty("Body")]
        public string body { get; set; }
    }
}
