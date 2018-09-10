using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace FlowFilter.Models
{
    public class AppOperation
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        [XmlIgnore]
        public AppOperationType Type { get; set; }
        [XmlElement("Type"), NotMapped]
        public int TypeInt
        {
            get { return (int) Type; }
            set {  }
        }
        [XmlIgnore]
        public PROTOCOL_FIELD Field { get; set; }
        [XmlElement("Field"), NotMapped]
        public int FieldInt
        {
            get { return Field.GetHashCode(); }
            set {  }
        }
        [XmlElement("Level"), NotMapped]
        public int Level
        {
            get { return FieldInfo.AllFieldInfos[Field].Level; }
            set {  }
        }
        public UInt32 Para { get; set; }
        [XmlIgnore, JsonIgnore]
        public bool IsDeleted { get; set; }
        [XmlIgnore, JsonIgnore]
        public int AppRuleId { get; set; }
        [XmlIgnore, JsonIgnore]
        public AppRule AppRule { get; set; }
    }

    public enum AppOperationType
    {
        Greater = 0,
        Less,
        Equal,
        NotLess,
        NotGreater,
        Mask,
    }
}
