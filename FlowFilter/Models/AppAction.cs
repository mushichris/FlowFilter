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
    public class AppAction
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        [XmlIgnore]
        public AppActionType Type { get; set; }
        [XmlElement("Type"), NotMapped]
        public int TypeInt
        {
            get { return (int)Type; }
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
            set { }
        }
        public UInt32 Para { get; set; }
        [XmlIgnore, JsonIgnore]
        public bool IsDeleted { get; set; }
        [XmlIgnore, JsonIgnore]
        public int AppRuleId { get; set; }
        [XmlIgnore, JsonIgnore]
        public AppRule AppRule { get; set; }
    }

    public enum AppActionType
    {
        //Drop,
        Set,
        //DumpPcap,
    }

    public class AppActionTypeInfo
    {
        public AppActionType AppActionType { get; set; }
        public string Description { get; set; }

        public static Dictionary<AppActionType, AppActionTypeInfo> AllAppActionTypeInfos = new Dictionary<AppActionType, AppActionTypeInfo>()
        {
            //{AppActionType.Drop, new AppActionTypeInfo(){ AppActionType = AppActionType.Drop, Description = "丢弃"} },
            {AppActionType.Set, new AppActionTypeInfo(){ AppActionType = AppActionType.Set, Description = "修改后转发"} },
            //{AppActionType.DumpPcap, new AppActionTypeInfo(){ AppActionType = AppActionType.DumpPcap, Description = "转储PCAP数据包"} },
        };
    }
}
