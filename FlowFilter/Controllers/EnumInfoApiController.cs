using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using FlowFilter.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlowFilter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnumInfoApiController : ControllerBase
    {
        [Route("[action]")]
        public async Task<ActionResult<List<NameValuePair>>> GetEnum(string id)
        {
            string enumNameSpace = typeof(AppProtocol).Namespace;
            if (string.IsNullOrEmpty(id))
            {
                id = nameof(AppProtocol);
            }
            List<NameValuePair> pairDict = new List<NameValuePair>();
            try
            {
                var type = Type.GetType($"{enumNameSpace}.{id}");
                if (type != null)
                {
                    pairDict.AddRange(Enum.GetNames(type)
                        .Select(s =>
                            new NameValuePair()
                            {
                                Name = s,
                                Value = (int)Enum.Parse(type, s)
                            }));
                }
            }
            catch
            {
                return BadRequest("Can not get the request type.");
            }
            if (pairDict.Count == 0)
            {
                return BadRequest("Can not get the request type.");
            }
            return pairDict;
        }

        [Route("[action]")]
        public async Task<ActionResult<List<NameValuePair>>> GetPacketType(string protocol)
        {
            bool ret = AppProtocol.TryParse(protocol, true, out AppProtocol inputAppProtocol);
            if (ret != true)
            {
                return BadRequest("Can not get the request type.");
            }
            List<NameValuePair> pairDict = new List<NameValuePair>();
            var packetTypeList = Enum.GetNames(typeof(PacketType))
                .Where(s => s.StartsWith(inputAppProtocol.ToString(), true, CultureInfo.CurrentCulture)).Select(s =>
                    new NameValuePair()
                    {
                        Name = s,
                        Value = (int) Enum.Parse(typeof(PacketType), s)
                    });
            pairDict.AddRange(packetTypeList);
            if (pairDict.Count == 0)
            {
                return BadRequest("Can not get the request type.");
            }
            return pairDict;
        }

        [Route("[action]")]
        public async Task<ActionResult<List<NameValuePair>>> GetField(string packetType)
        {
            bool ret = PacketType.TryParse(packetType, true, out PacketType inputPacketType);
            if (ret != true)
            {
                return BadRequest("Can not get the request type.");
            }
            var pairDict = PacketInfo.AllPacketInfos[inputPacketType].AvaliableFields.Select(s => new NameValuePair()
            {
                Name = s.ToString(),
                Value = (int) s
            }).ToList();
            if (pairDict.Count == 0)
            {
                return BadRequest("Can not get the request type.");
            }
            return pairDict;
        }

        public class NameValuePair
        {
            public string Name { get; set; }
            public int Value { get; set; }
        }
    }
}