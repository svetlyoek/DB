using System.Xml.Serialization;

namespace CarDealer.Dtos.Import
{
    [XmlRoot("parts")]
    public class ImportPartsDto
    {
        [XmlElement("partId")]
        public ImportPartIdDto[] PartsId { get; set; }
    }
}
