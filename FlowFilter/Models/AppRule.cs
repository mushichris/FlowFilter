using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace FlowFilter.Models
{
    public class AppRule
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        [XmlIgnore]
        public PacketType PacketType { get; set; }
        [XmlElement("PacketType")]
        public int PacketTypeInt
        {
            get { return PacketType.GetHashCode(); }
            set {  }
        }
        [XmlElement("Operation")]
        public virtual List<AppOperation> Operations { get; set; }

        [XmlElement("Action")]
        public virtual List<AppAction> Actions { get; set; }
        [XmlIgnore]
        public bool Dump { get; set; }
        [XmlElement("Dump")]
        public int DumpInt
        {
            get { return Convert.ToInt32(Dump); }
            set { }
        }
        [XmlIgnore]
        public bool Drop { get; set; }
        [XmlElement("Drop")]
        public int DropInt
        {
            get { return Convert.ToInt32(Drop); }
            set { }
        }
        [XmlIgnore, JsonIgnore]
        public bool IsDeleted { get; set; } = false;

    }


}
