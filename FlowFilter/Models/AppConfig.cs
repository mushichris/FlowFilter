using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FlowFilter.Models
{
    [XmlRoot("Config", Namespace = "")]
    public class AppConfig
    {
        [XmlElement("Rule")]
        public virtual List<AppRule> Rules { get; set; }
    }

    public enum BackendCommand
    {
        Success,
        Updating,
        ClearStatistics
    }
}
