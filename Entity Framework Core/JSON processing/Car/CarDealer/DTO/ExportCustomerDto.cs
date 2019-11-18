namespace CarDealer.DTO
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class ExportCustomerDto
    {
        [JsonProperty("fullName")]
        public string Fullname { get; set; }

        [JsonProperty("boughtCars")]
        public int BoughtCars { get; set; }

        [JsonProperty("spentMoney")]
        public decimal SpentMoney { get; set; }
    }
}
