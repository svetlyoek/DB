using System.Xml.Serialization;

namespace CarDealer.Dtos.Import
{
    [XmlRoot("parts")]
    public class ImportPartIdDto
    {
        [XmlAttribute("id")]
        public int PartId { get; set; }
    }
}
