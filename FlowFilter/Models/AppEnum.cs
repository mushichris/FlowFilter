using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowFilter.Models
{
    public enum AppProtocol
    {
        OSPFv2,
        OSPFv3,
        ISIS,
    }

    public enum PacketType
    {
        OSPFv2_HEADER = 0,
        OSPFv2_HELLO,
        OSPFv2_DD,
        OSPFv2_LSR,
        OSPFv2_LSU,
        OSPFv2_LSACK,
        OSPFv2_LSA_HEADER,
        OSPFv2_ROUTER_LSA,
        OSPFv2_NETWORK_LSA,
        OSPFv2_NETWORK_SUMMARY_LSA,
        OSPFv2_ASBR_SUMMARY_LSA,
        OSPFv2_AS_EXTERNAL_LSA,

        OSPFv3_HEADER,          //12
        OSPFv3_HELLO,
        OSPFv3_DD,
        OSPFv3_LSR,
        OSPFv3_LSU,
        OSPFv3_LSACK,
        OSPFv3_LSA_HEADER,
        OSPFv3_ROUTER_LSA,              //19
        OSPFv3_NETWORK_LSA,
        OSPFv3_INTER_AREA_PREFIX_LSA,
        OSPFv3_INTER_AREA_ROUTER_LSA,
        OSPFv3_AS_EXTERNAL_LSA,
        //OSPFv3_GROUP_MEMBERSHIP_LSA,
        //OSPFv3_AS_TYPE7_LSA,
        OSPFv3_LINK_LSA = 26,
        OSPFv3_INTRA_AREA_PREFIX_LSA,

        ISIS_PDUHDR = 100,
        ISIS_LAN_HELLO,
        ISIS_POINT_TO_POINT_HELLO,
        ISIS_LSP,
        ISIS_CSNP,
        ISIS_PSNP,
        ISIS_TLV,

    }

    public enum PROTOCOL_FIELD
    {
        OSPFv2_HEADER_VERSION = 0,
        OSPFv2_HEADER_TYPE,
        OSPFv2_HEADER_PACKET_LENGTH,
        OSPFv2_HEADER_ROUTER_ID,
        OSPFv2_HEADER_AREA_ID,
        OSPFv2_HEADER_CHECKSUM,
        OSPFv2_HEADER_AUTH_TYPE,
        OSPFv2_HEADER_AUTH_DATA_1,   
        OSPFv2_HEADER_AUTH_DATA_2,

        OSPFv2_HELLO_NETWORK_MASK,                                                      
        OSPFv2_HELLO_HELLO_INTERVAL,
        OSPFv2_HELLO_OPTIONS,
        OSPFv2_HELLO_ROUTER_PRIORITY,
        OSPFv2_HELLO_ROUTER_DEAD_INTERVAL,
        OSPFv2_HELLO_DESIGNATED_ROUTER,
        OSPFv2_HELLO_BACKUP_DESIGNATED_ROUTER,
        OSPFv2_HELLO_NEIGHBOR,      

        OSPFv2_DD_INTERFACE_MTU,              
        OSPFv2_DD_OPTIONS,
        OSPFv2_DD_BIT_00000_I_M_MS,
        OSPFv2_DD_SEQUENCE_NUMBER,

        OSPFv2_LSR_LS_TYPE,            
        OSPFv2_LSR_LS_ID,
        OSPFv2_LSR_ADVERTISING_ROUTER,

        OSPFv2_LSU_NUMBER_OF_LSAS,            

        OSPFv2_LSA_LS_AGE,             
        OSPFv2_LSA_OPTIONS,
        OSPFv2_LSA_LS_TYPE,
        OSPFv2_LSA_LS_ID,
        OSPFv2_LSA_ADVERTISING_ROUTER,
        OSPFv2_LSA_SEQUENCE_NUMBER,
        OSPFv2_LSA_LS_CHECKSUM,
        OSPFv2_LSA_LENGTH,
                                                           
        OSPFv2_RLSA_BIT_00000_V_E_B,      
        OSPFv2_RLSA_NUMBER_OF_LINKS,
        OSPFv2_RLSA_LINK_ID,                    
        OSPFv2_RLSA_LINK_DATA,
        OSPFv2_RLSA_TYPE,
        OSPFv2_RLSA_NUMBER_OF_TOS,
        OSPFv2_RLSA_METRIC,       
        OSPFv2_RLSA_TOS_TOS,
        OSPFv2_RLSA_TOS_METRIC,   

        OSPFv2_NLSA_NETWORK_MASK,         
        OSPFv2_NLSA_ATTACHED_ROUTER,

        OSPFv2_NSLSA_NETWORK_MASK,         
        OSPFv2_NSLSA_METRIC,       
        OSPFv2_NSLSA_TOS_TOS,
        OSPFv2_NSLSA_TOS_METRIC,   

        OSPFv2_ASBRSLSA_NETWORK_MASK,       
        OSPFv2_ASBRSLSA_METRIC,     
        OSPFv2_ASBRSLSA_TOS_TOS,
        OSPFv2_ASBRSLSA_TOS_METRIC,         

        OSPFv2_EXLSA_NETWORK_MASK,            
        OSPFv2_EXLSA_BIT_E_0000000,               
        OSPFv2_EXLSA_METRIC,          
        OSPFv2_EXLSA_FORWARD_ADDRESS,
        OSPFv2_EXLSA_EXTERNAL_ROUTE_TAG,
        OSPFv2_EXLSA_TOS_BIT_E_TOS,        
        OSPFv2_EXLSA_TOS_METRIC,                
        OSPFv2_EXLSA_TOS_FORWARD_ADDRRESS,
        OSPFv2_EXLSA_TOS_EXTERNAL_ROUTE_TAG,

        //////////////OSPF IPv6////////////////
        OSPFv3_HEADER_VERSION,          //61
        OSPFv3_HEADER_TYPE,
        OSPFv3_HEADER_PACKET_LENGTH,
        OSPFv3_HEADER_ROUTER_ID,
        OSPFv3_HEADER_AREA_ID,
        OSPFv3_HEADER_CHECKSUM,
        OSPFv3_HEADER_INSTANCE_ID,
        //OSPFv3_HEADER_0,				

        OSPFv3_HELLO_INTERFACE_ID,             //68
        OSPFv3_HELLO_ROUTER_PRIORITY,
        OSPFv3_HELLO_OPTIONS,
        OSPFv3_HELLO_HELLO_INTERVAL,
        OSPFv3_HELLO_ROUTER_DEAD_INTERVAL,
        OSPFv3_HELLO_DESIGNATED_ROUTER,
        OSPFv3_HELLO_BACKUP_DESIGNATED_ROUTER,
        OSPFv3_HELLO_NEIGHBOR,

        //OSPFv3_DD_0,
        OSPFv3_DD_OPTIONS,                       //76
        OSPFv3_DD_INTERFACE_MTU,	
        OSPFv3_DD_BIT_00000_I_M_MS,
        OSPFv3_DD_SEQUENCE_NUMBER,

        //OSPFv3_LSR_0,
        OSPFv3_LSR_LS_TYPE,             //80
        OSPFv3_LSR_LS_ID,
        OSPFv3_LSR_ADVERTISING_ROUTER,

        OSPFv3_LSU_NUMBER_OF_LSAS,              //83

        OSPFv3_LSA_LS_AGE,              //84
        OSPFv3_LSA_LS_TYPE,
        OSPFv3_LSA_LS_ID,
        OSPFv3_LSA_ADVERTISING_ROUTER,
        OSPFv3_LSA_SEQUENCE_NUMBER,
        OSPFv3_LSA_LS_CHECKSUM,
        OSPFv3_LSA_LENGTH,

        OSPFv3_1LSA_BIT_0000_W_V_E_B,       //91
        OSPFv3_1LSA_OPTIONS,
        OSPFv3_1LSA_TYPE,
        OSPFv3_1LSA_METRIC,
        OSPFv3_1LSA_INTERFACE_ID,
        OSPFv3_1LSA_NEIGHBOR_INTERFACE_ID,
        OSPFv3_1LSA_NEIGHBOR_ROUTER_ID,

        //OSPFv3_2LSA_0,
        OSPFv3_2LSA_OPTIONS,            //98
        OSPFv3_2LSA_ATTACHED_ROUTER,


        OSPFv3_3LSA_METRIC,             //100
        OSPFv3_3LSA_PREFIX_LENGTH,
        OSPFv3_3LSA_PREFIX_OPTIONS,
        OSPFv3_3LSA_ADDRESS_PREFIX_1,       //IPv6地址,拆成4个32位,后面几个可能不存在
        OSPFv3_3LSA_ADDRESS_PREFIX_2,
        OSPFv3_3LSA_ADDRESS_PREFIX_3,
        OSPFv3_3LSA_ADDRESS_PREFIX_4,

        //OSPFv3_4LSA_0,
        OSPFv3_4LSA_OPTIONS,              //107
        OSPFv3_4LSA_METRIC,
        OSPFv3_4LSA_DESTINATION_ROUTER_ID,

        OSPFv3_5LSA_BIT_00000_E_F_T,        //110
        OSPFv3_5LSA_METRIC,
        OSPFv3_5LSA_PREFIX_LENGTH,
        OSPFv3_5LSA_PREFIX_OPTIONS,
        OSPFv3_5LSA_REFERENCED_LS_TYPE,
        OSPFv3_5LSA_ADDRESS_PREFIX_1,           //OSPFv3_5LSA_PREFIX_LENGTH>0
        OSPFv3_5LSA_ADDRESS_PREFIX_2,           //OSPFv3_5LSA_PREFIX_LENGTH>32
        OSPFv3_5LSA_ADDRESS_PREFIX_3,           //OSPFv3_5LSA_PREFIX_LENGTH>64
        OSPFv3_5LSA_ADDRESS_PREFIX_4,           //OSPFv3_5LSA_PREFIX_LENGTH>96
        OSPFv3_5LSA_FORWARDING_ADDRESS_1,       //可选,OSPFv3_5LSA_BIT_00000_E_F_T,F=1
        OSPFv3_5LSA_FORWARDING_ADDRESS_2,       //可选,OSPFv3_5LSA_BIT_00000_E_F_T,F=1
        OSPFv3_5LSA_FORWARDING_ADDRESS_3,       //可选,OSPFv3_5LSA_BIT_00000_E_F_T,F=1
        OSPFv3_5LSA_FORWARDING_ADDRESS_4,       //可选,OSPFv3_5LSA_BIT_00000_E_F_T,F=1
        OSPFv3_5LSA_EXTERNAL_ROUTE_TAG,         //可选,OSPFv3_5LSA_BIT_00000_E_F_T,E=1
        OSPFv3_5LSA_REFERENCED_LS_ID,           //可选,OSPFv3_5LSA_BIT_00000_E_F_T,T=1
                                                //6、7未在RFC2740中,暂时不列出
        OSPFv3_8LSA_ROUTER_PRIORITY,                     //125
        OSPFv3_8LSA_ROUTER_OPTIONS,
        OSPFv3_8LSA_LINK_LOCAL_INTERFACE_ADDRESS_1,
        OSPFv3_8LSA_LINK_LOCAL_INTERFACE_ADDRESS_2,
        OSPFv3_8LSA_LINK_LOCAL_INTERFACE_ADDRESS_3,
        OSPFv3_8LSA_LINK_LOCAL_INTERFACE_ADDRESS_4,
        OSPFv3_8LSA_NUMBER_OF_PREFIXES,
        OSPFv3_8LSA_PREFIX_LENGTH,
        OSPFv3_8LSA_PREFIX_OPTIONS,
        OSPFv3_8LSA_ADDRESS_PREFIX_1,                   //OSPFv3_8LSA_PREFIX_LENGTH>0
        OSPFv3_8LSA_ADDRESS_PREFIX_2,                   //OSPFv3_8LSA_PREFIX_LENGTH>32
        OSPFv3_8LSA_ADDRESS_PREFIX_3,                   //OSPFv3_8LSA_PREFIX_LENGTH>64
        OSPFv3_8LSA_ADDRESS_PREFIX_4,                   //OSPFv3_8LSA_PREFIX_LENGTH>96

        OSPFv3_9LSA_NUMBER_OF_PREFIXES,                     //138
        OSPFv3_9LSA_REFERENCED_LS_TYPE,
        OSPFv3_9LSA_REFERENCED_LS_ID,
        OSPFv3_9LSA_REFERENCED_ADVERTISING_ROUTER,
        OSPFv3_9LSA_PREFIX_LENGTH,
        OSPFv3_9LSA_PREFIX_OPTIONS,
        OSPFv3_9LSA_METRIC,
        OSPFv3_9LSA_ADDRESS_PREFIX_1,                   //OSPFv3_9LSA_PREFIX_LENGTH>0
        OSPFv3_9LSA_ADDRESS_PREFIX_2,                   //OSPFv3_9LSA_PREFIX_LENGTH>32
        OSPFv3_9LSA_ADDRESS_PREFIX_3,                   //OSPFv3_9LSA_PREFIX_LENGTH>64
        OSPFv3_9LSA_ADDRESS_PREFIX_4,		            //OSPFv3_9LSA_PREFIX_LENGTH>96	

        OSPF_FIELD_MAX = 200,


        //===========================================================================
        ISIS_PDUHDR_IRPD = 1000,
        ISIS_PDUHDR_LEN_ID,
        ISIS_PDUHDR_VER_ID,
        ISIS_PDUHDR_ID_LEN,
        ISIS_PDUHDR_PDU_TYPE,
        ISIS_PDUHDR_VERSION,
        ISIS_PDUHDR_RESERVED,
        ISIS_PDUHDR_MAX_AREA_ADDR,

        ISIS_LAN_HELLO_CIRCUIT_TYPE,
        ISIS_LAN_HELLO_SRC_SYSID_1,
        ISIS_LAN_HELLO_SRC_SYSID_2,
        ISIS_LAN_HELLO_HOLD_TIME,
        ISIS_LAN_HELLO_PDU_LEN,
        ISIS_LAN_HELLO_PRIORITY,
        ISIS_LAN_HELLO_DESI_SYSID_1,
        ISIS_LAN_HELLO_DESI_SYSID_2,

        ISIS_P2P_HELLO_CIRCUIT_TYPE,
        ISIS_P2P_HELLO_SRC_SYSID_1,
        ISIS_P2P_HELLO_SRC_SYSID_2,
        ISIS_P2P_HELLO_HOLD_TIME,
        ISIS_P2P_HELLO_PDU_LEN,
        ISIS_P2P_HELLO_LOCAL_ID,

        ISIS_LSP_PDU_LEN,
        ISIS_LSP_REMAIN_LIFE_TIME,
        ISIS_LSP_ID_1,
        ISIS_LSP_ID_2,
        ISIS_LSP_SEQNUM,
        ISIS_LSP_CHECKSUM,
        ISIS_LSP_TYPE_BLOCK,

        ISIS_CSNP_PDU_LEN,
        ISIS_CSNP_SRC_SYSID_1,
        ISIS_CSNP_SRC_SYSID_2,
        ISIS_CSNP_START_LSPID_1,
        ISIS_CSNP_START_LSPID_2,
        ISIS_CSNP_END_LSPID_1,
        ISIS_CSNP_END_LSPID_2,

        ISIS_PSNP_PDU_LEN,
        ISIS_PSNP_SRC_SYSID_1,
        ISIS_PSNP_SRC_SYSID_2,

        ISIS_TLV_TYPE,
        ISIS_TLV_LEN,

        ISIS_TLV_TYPE_AREA_ADDR_ADDRLEN,
        ISIS_TLV_TYPE_AREA_ADDR_VALUE,

        ISIS_TLV_TYPE_IS_REACH_RESERVED,
        ISIS_TLV_TYPE_IS_REACH_DEFAULT_METRIC,
        ISIS_TLV_TYPE_IS_REACH_DELAY_METRIC,
        ISIS_TLV_TYPE_IS_REACH_EXPENSE_METRIC,
        ISIS_TLV_TYPE_IS_REACH_ERROR_METRIC,
        ISIS_TLV_TYPE_IS_REACH_NEIGHBOR_ID_1,
        ISIS_TLV_TYPE_IS_REACH_NEIGHBOR_ID_2,

        ISIS_TLV_TYPE_IS_NEIGHBOR_ADDR_1,
        ISIS_TLV_TYPE_IS_NEIGHBOR_ADDR_2,

        ISIS_TLV_TYPE_IS_PADDING,

        ISIS_TLV_TYPE_LSP_ENTRY_REMAINLIFETIME,
        ISIS_TLV_TYPE_LSP_ENTRY_LSPID_1,
        ISIS_TLV_TYPE_LSP_ENTRY_LSPID_2,
        ISIS_TLV_TYPE_LSP_ENTRY_SEQNUM,
        ISIS_TLV_TYPE_LSP_ENTRY_CHECKSUM,

        ISIS_TLV_TYPE_IS_AUTH_AUTHTYPE,
        ISIS_TLV_TYPE_IS_AUTH_AUTHVALUE,

        ISIS_TLV_TYPE_IP_INTERNAL_REACH_DEFAULT_METRIC,
        ISIS_TLV_TYPE_IP_INTERNAL_REACH_DELAY_METRIC,
        ISIS_TLV_TYPE_IP_INTERNAL_REACH_EXPENSE_METRIC,
        ISIS_TLV_TYPE_IP_INTERNAL_REACH_ERROR_METRIC,
        ISIS_TLV_TYPE_IP_INTERNAL_REACH_IPADDR,
        ISIS_TLV_TYPE_IP_INTERNAL_REACH_SUBNETMASK,

        ISIS_TLV_TYPE_PROTO_SUPPORT_NLPID,

        ISIS_TLV_TYPE_IP_EXTERNAL_REACH_DEFAULT_METRIC,
        ISIS_TLV_TYPE_IP_EXTERNAL_REACH_DELAY_METRIC,
        ISIS_TLV_TYPE_IP_EXTERNAL_REACH_EXPENSE_METRIC,
        ISIS_TLV_TYPE_IP_EXTERNAL_REACH_ERROR_METRIC,
        ISIS_TLV_TYPE_IP_EXTERNAL_REACH_IPADDR,
        ISIS_TLV_TYPE_IP_EXTERNAL_REACH_SUBNETMASK,

        ISIS_TLV_TYPE_IP_INTERFACE_ADDR_IPADDR,

        ISIS_TLV_TYPE_HOSTNAME,

        ISIS_TLV_TYPE_RESTART_SIGNAL,

        ISIS_TLV_TYPE_IPv6_INTERFACE_ADDR_IPADDR_1,
        ISIS_TLV_TYPE_IPv6_INTERFACE_ADDR_IPADDR_2,
        ISIS_TLV_TYPE_IPv6_INTERFACE_ADDR_IPADDR_3,
        ISIS_TLV_TYPE_IPv6_INTERFACE_ADDR_IPADDR_4,

        ISIS_TLV_TYPE_IPv6_REACH_METRIC,
        ISIS_TLV_TYPE_IPv6_REACH_FLAG,
        ISIS_TLV_TYPE_IPv6_REACH_PREFIXLEN,
        ISIS_TLV_TYPE_IPv6_REACH_PREFIX_1,
        ISIS_TLV_TYPE_IPv6_REACH_PREFIX_2,
        ISIS_TLV_TYPE_IPv6_REACH_PREFIX_3,
        ISIS_TLV_TYPE_IPv6_REACH_PREFIX_4,
        ISIS_TLV_TYPE_IPv6_REACH_SUBTLVLEN,
        ISIS_TLV_TYPE_IPv6_REACH_SUBTLV,
        //===========================================================================        
    }

    public class FieldInfo
    {
        public PROTOCOL_FIELD Field { get; set; }
        public PacketType PacketType { get; set; }
        public int Level { get; set; }
        public static Dictionary<PROTOCOL_FIELD, FieldInfo> AllFieldInfos = new Dictionary<PROTOCOL_FIELD, FieldInfo>()
        {
            //OSPFv2_HEADER
            { PROTOCOL_FIELD.OSPFv2_HEADER_VERSION,  new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv2_HEADER_VERSION,  Level = 0, PacketType = PacketType.OSPFv2_HEADER}},
            { PROTOCOL_FIELD.OSPFv2_HEADER_TYPE,     new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv2_HEADER_TYPE,     Level = 0, PacketType = PacketType.OSPFv2_HEADER}},
            { PROTOCOL_FIELD.OSPFv2_HEADER_PACKET_LENGTH,      new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv2_HEADER_PACKET_LENGTH,      Level = 0, PacketType = PacketType.OSPFv2_HEADER}},
            { PROTOCOL_FIELD.OSPFv2_HEADER_ROUTER_ID,      new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv2_HEADER_ROUTER_ID,      Level = 0, PacketType = PacketType.OSPFv2_HEADER}},
            { PROTOCOL_FIELD.OSPFv2_HEADER_AREA_ID,      new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv2_HEADER_AREA_ID,      Level = 0, PacketType = PacketType.OSPFv2_HEADER}},
            { PROTOCOL_FIELD.OSPFv2_HEADER_CHECKSUM,    new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv2_HEADER_CHECKSUM,    Level = 0, PacketType = PacketType.OSPFv2_HEADER}},
            { PROTOCOL_FIELD.OSPFv2_HEADER_AUTH_TYPE, new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv2_HEADER_AUTH_TYPE, Level = 0, PacketType = PacketType.OSPFv2_HEADER}},
            { PROTOCOL_FIELD.OSPFv2_HEADER_AUTH_DATA_1,   new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv2_HEADER_AUTH_DATA_1,   Level = 0, PacketType = PacketType.OSPFv2_HEADER}},
            { PROTOCOL_FIELD.OSPFv2_HEADER_AUTH_DATA_2,   new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv2_HEADER_AUTH_DATA_2,   Level = 0, PacketType = PacketType.OSPFv2_HEADER}},

            //OSPFv2_HELLO
            { PROTOCOL_FIELD.OSPFv2_HELLO_NETWORK_MASK,  new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv2_HELLO_NETWORK_MASK,  Level = 0, PacketType = PacketType.OSPFv2_HELLO}},
            { PROTOCOL_FIELD.OSPFv2_HELLO_HELLO_INTERVAL,    new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv2_HELLO_HELLO_INTERVAL,    Level = 0, PacketType = PacketType.OSPFv2_HELLO}},
            { PROTOCOL_FIELD.OSPFv2_HELLO_OPTIONS,     new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv2_HELLO_OPTIONS,     Level = 0, PacketType = PacketType.OSPFv2_HELLO}},
            { PROTOCOL_FIELD.OSPFv2_HELLO_ROUTER_PRIORITY,     new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv2_HELLO_ROUTER_PRIORITY,     Level = 0, PacketType = PacketType.OSPFv2_HELLO}},
            { PROTOCOL_FIELD.OSPFv2_HELLO_ROUTER_DEAD_INTERVAL,   new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv2_HELLO_ROUTER_DEAD_INTERVAL,   Level = 0, PacketType = PacketType.OSPFv2_HELLO}},
            { PROTOCOL_FIELD.OSPFv2_HELLO_DESIGNATED_ROUTER,     new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv2_HELLO_DESIGNATED_ROUTER,     Level = 0, PacketType = PacketType.OSPFv2_HELLO}},
            { PROTOCOL_FIELD.OSPFv2_HELLO_BACKUP_DESIGNATED_ROUTER,     new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv2_HELLO_BACKUP_DESIGNATED_ROUTER,     Level = 0, PacketType = PacketType.OSPFv2_HELLO}},
            { PROTOCOL_FIELD.OSPFv2_HELLO_NEIGHBOR, new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv2_HELLO_NEIGHBOR, Level = 1, PacketType = PacketType.OSPFv2_HELLO}},

            //OSPFv2_DD
            { PROTOCOL_FIELD.OSPFv2_DD_INTERFACE_MTU,  new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv2_DD_INTERFACE_MTU,   Level = 0, PacketType = PacketType.OSPFv2_DD}},
            { PROTOCOL_FIELD.OSPFv2_DD_OPTIONS, new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv2_DD_OPTIONS,  Level = 0, PacketType = PacketType.OSPFv2_DD}},
            { PROTOCOL_FIELD.OSPFv2_DD_BIT_00000_I_M_MS, new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv2_DD_BIT_00000_I_M_MS,  Level = 0, PacketType = PacketType.OSPFv2_DD}},
            { PROTOCOL_FIELD.OSPFv2_DD_SEQUENCE_NUMBER,  new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv2_DD_SEQUENCE_NUMBER,   Level = 0, PacketType = PacketType.OSPFv2_DD}},

            //OSPFv2_LSR
            { PROTOCOL_FIELD.OSPFv2_LSR_LS_TYPE, new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv2_LSR_LS_TYPE,  Level = 1, PacketType = PacketType.OSPFv2_LSR}},
            { PROTOCOL_FIELD.OSPFv2_LSR_LS_ID, new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv2_LSR_LS_ID,  Level = 1, PacketType = PacketType.OSPFv2_LSR}},
            { PROTOCOL_FIELD.OSPFv2_LSR_ADVERTISING_ROUTER,  new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv2_LSR_ADVERTISING_ROUTER,   Level = 1, PacketType = PacketType.OSPFv2_LSR}},

            //OSPFv2_LSU
            { PROTOCOL_FIELD.OSPFv2_LSU_NUMBER_OF_LSAS, new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv2_LSU_NUMBER_OF_LSAS,  Level = 0, PacketType = PacketType.OSPFv2_LSU}},

            //OSPFv2_LSA_HEADER
            { PROTOCOL_FIELD.OSPFv2_LSA_LS_AGE,   new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv2_LSA_LS_AGE,    Level = 1, PacketType = PacketType.OSPFv2_LSA_HEADER}},
            { PROTOCOL_FIELD.OSPFv2_LSA_OPTIONS,  new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv2_LSA_OPTIONS,   Level = 1, PacketType = PacketType.OSPFv2_LSA_HEADER}},
            { PROTOCOL_FIELD.OSPFv2_LSA_LS_TYPE,  new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv2_LSA_LS_TYPE,   Level = 1, PacketType = PacketType.OSPFv2_LSA_HEADER}},
            { PROTOCOL_FIELD.OSPFv2_LSA_LS_ID,  new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv2_LSA_LS_ID,   Level = 1, PacketType = PacketType.OSPFv2_LSA_HEADER}},
            { PROTOCOL_FIELD.OSPFv2_LSA_ADVERTISING_ROUTER,   new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv2_LSA_ADVERTISING_ROUTER,    Level = 1, PacketType = PacketType.OSPFv2_LSA_HEADER}},
            { PROTOCOL_FIELD.OSPFv2_LSA_SEQUENCE_NUMBER,   new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv2_LSA_SEQUENCE_NUMBER,    Level = 1, PacketType = PacketType.OSPFv2_LSA_HEADER}},
            { PROTOCOL_FIELD.OSPFv2_LSA_LS_CHECKSUM, new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv2_LSA_LS_CHECKSUM,  Level = 1, PacketType = PacketType.OSPFv2_LSA_HEADER}},
            { PROTOCOL_FIELD.OSPFv2_LSA_LENGTH,   new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv2_LSA_LENGTH,    Level = 1, PacketType = PacketType.OSPFv2_LSA_HEADER}},

            //OSPFv2_ROUTER_LSA
            { PROTOCOL_FIELD.OSPFv2_RLSA_BIT_00000_V_E_B,       new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv2_RLSA_BIT_00000_V_E_B,        Level = 1, PacketType = PacketType.OSPFv2_ROUTER_LSA}},
            { PROTOCOL_FIELD.OSPFv2_RLSA_NUMBER_OF_LINKS,     new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv2_RLSA_NUMBER_OF_LINKS,      Level = 1, PacketType = PacketType.OSPFv2_ROUTER_LSA}},
            { PROTOCOL_FIELD.OSPFv2_RLSA_LINK_ID,        new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv2_RLSA_LINK_ID,         Level = 2, PacketType = PacketType.OSPFv2_ROUTER_LSA}},
            { PROTOCOL_FIELD.OSPFv2_RLSA_LINK_DATA,       new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv2_RLSA_LINK_DATA,        Level = 2, PacketType = PacketType.OSPFv2_ROUTER_LSA}},
            { PROTOCOL_FIELD.OSPFv2_RLSA_TYPE,       new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv2_RLSA_TYPE,        Level = 2, PacketType = PacketType.OSPFv2_ROUTER_LSA}},
            { PROTOCOL_FIELD.OSPFv2_RLSA_NUMBER_OF_TOS,       new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv2_RLSA_NUMBER_OF_TOS,        Level = 2, PacketType = PacketType.OSPFv2_ROUTER_LSA}},
            { PROTOCOL_FIELD.OSPFv2_RLSA_METRIC,     new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv2_RLSA_METRIC,      Level = 2, PacketType = PacketType.OSPFv2_ROUTER_LSA}},
            { PROTOCOL_FIELD.OSPFv2_RLSA_TOS_TOS,    new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv2_RLSA_TOS_TOS,     Level = 3, PacketType = PacketType.OSPFv2_ROUTER_LSA}},
            { PROTOCOL_FIELD.OSPFv2_RLSA_TOS_METRIC, new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv2_RLSA_TOS_METRIC,  Level = 3, PacketType = PacketType.OSPFv2_ROUTER_LSA}},

            //OSPFv2_NETWORK_LSA
            { PROTOCOL_FIELD.OSPFv2_NLSA_NETWORK_MASK, new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv2_NLSA_NETWORK_MASK,      Level = 1, PacketType = PacketType.OSPFv2_NETWORK_LSA}},
            { PROTOCOL_FIELD.OSPFv2_NLSA_ATTACHED_ROUTER,  new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv2_NLSA_ATTACHED_ROUTER,       Level = 2, PacketType = PacketType.OSPFv2_NETWORK_LSA}},

            //OSPF_LSA_SLINK
            { PROTOCOL_FIELD.OSPFv2_NSLSA_NETWORK_MASK,       new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv2_NSLSA_NETWORK_MASK,        Level = 1, PacketType = PacketType.OSPFv2_NETWORK_SUMMARY_LSA}},
            { PROTOCOL_FIELD.OSPFv2_NSLSA_METRIC,     new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv2_NSLSA_METRIC,      Level = 1, PacketType = PacketType.OSPFv2_NETWORK_SUMMARY_LSA}},
            { PROTOCOL_FIELD.OSPFv2_NSLSA_TOS_TOS,    new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv2_NSLSA_TOS_TOS,     Level = 2, PacketType = PacketType.OSPFv2_NETWORK_SUMMARY_LSA}},
            { PROTOCOL_FIELD.OSPFv2_NSLSA_TOS_METRIC, new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv2_NSLSA_TOS_METRIC,  Level = 2, PacketType = PacketType.OSPFv2_NETWORK_SUMMARY_LSA}},

            //OSPFv2_ASBR_SUMMARY_LSA
            { PROTOCOL_FIELD.OSPFv2_ASBRSLSA_NETWORK_MASK,       new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv2_ASBRSLSA_NETWORK_MASK,        Level = 1, PacketType = PacketType.OSPFv2_ASBR_SUMMARY_LSA}},
            { PROTOCOL_FIELD.OSPFv2_ASBRSLSA_METRIC,             new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv2_ASBRSLSA_METRIC,              Level = 1, PacketType = PacketType.OSPFv2_ASBR_SUMMARY_LSA}},
            { PROTOCOL_FIELD.OSPFv2_ASBRSLSA_TOS_TOS,            new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv2_ASBRSLSA_TOS_TOS,             Level = 2, PacketType = PacketType.OSPFv2_ASBR_SUMMARY_LSA}},
            { PROTOCOL_FIELD.OSPFv2_ASBRSLSA_TOS_METRIC,         new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv2_ASBRSLSA_TOS_METRIC,          Level = 2, PacketType = PacketType.OSPFv2_ASBR_SUMMARY_LSA}},

            //OSPFv2_AS_EXTERNAL_LSA
            { PROTOCOL_FIELD.OSPFv2_EXLSA_NETWORK_MASK,            new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv2_EXLSA_NETWORK_MASK,             Level = 1, PacketType = PacketType.OSPFv2_AS_EXTERNAL_LSA}},
            { PROTOCOL_FIELD.OSPFv2_EXLSA_BIT_E_0000000,               new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv2_EXLSA_BIT_E_0000000,                Level = 1, PacketType = PacketType.OSPFv2_AS_EXTERNAL_LSA}},
            { PROTOCOL_FIELD.OSPFv2_EXLSA_METRIC,          new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv2_EXLSA_METRIC,           Level = 1, PacketType = PacketType.OSPFv2_AS_EXTERNAL_LSA}},
            { PROTOCOL_FIELD.OSPFv2_EXLSA_FORWARD_ADDRESS,     new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv2_EXLSA_FORWARD_ADDRESS,      Level = 1, PacketType = PacketType.OSPFv2_AS_EXTERNAL_LSA}},
            { PROTOCOL_FIELD.OSPFv2_EXLSA_EXTERNAL_ROUTE_TAG,        new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv2_EXLSA_EXTERNAL_ROUTE_TAG,         Level = 1, PacketType = PacketType.OSPFv2_AS_EXTERNAL_LSA}},
            { PROTOCOL_FIELD.OSPFv2_EXLSA_TOS_BIT_E_TOS,        new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv2_EXLSA_TOS_BIT_E_TOS,         Level = 2, PacketType = PacketType.OSPFv2_AS_EXTERNAL_LSA}},
            { PROTOCOL_FIELD.OSPFv2_EXLSA_TOS_METRIC,      new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv2_EXLSA_TOS_METRIC,       Level = 2, PacketType = PacketType.OSPFv2_AS_EXTERNAL_LSA}},
            { PROTOCOL_FIELD.OSPFv2_EXLSA_TOS_FORWARD_ADDRRESS, new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv2_EXLSA_TOS_FORWARD_ADDRRESS,  Level = 2, PacketType = PacketType.OSPFv2_AS_EXTERNAL_LSA}},
            { PROTOCOL_FIELD.OSPFv2_EXLSA_TOS_EXTERNAL_ROUTE_TAG,    new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv2_EXLSA_TOS_EXTERNAL_ROUTE_TAG,     Level = 2, PacketType = PacketType.OSPFv2_AS_EXTERNAL_LSA}},

            //OSPFv3_HEADER
            { PROTOCOL_FIELD.OSPFv3_HEADER_VERSION,             new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv3_HEADER_VERSION,            Level = 0, PacketType = PacketType.OSPFv3_HEADER}},
            { PROTOCOL_FIELD.OSPFv3_HEADER_TYPE,                new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv3_HEADER_TYPE,               Level = 0, PacketType = PacketType.OSPFv3_HEADER}},
            { PROTOCOL_FIELD.OSPFv3_HEADER_PACKET_LENGTH,       new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv3_HEADER_PACKET_LENGTH,      Level = 0, PacketType = PacketType.OSPFv3_HEADER}},
            { PROTOCOL_FIELD.OSPFv3_HEADER_ROUTER_ID,           new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv3_HEADER_ROUTER_ID,          Level = 0, PacketType = PacketType.OSPFv3_HEADER}},
            { PROTOCOL_FIELD.OSPFv3_HEADER_AREA_ID,             new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv3_HEADER_AREA_ID,            Level = 0, PacketType = PacketType.OSPFv3_HEADER}},
            { PROTOCOL_FIELD.OSPFv3_HEADER_CHECKSUM,            new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv3_HEADER_CHECKSUM,           Level = 0, PacketType = PacketType.OSPFv3_HEADER}},
            { PROTOCOL_FIELD.OSPFv3_HEADER_INSTANCE_ID,         new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv3_HEADER_INSTANCE_ID,        Level = 0, PacketType = PacketType.OSPFv3_HEADER}},

            //OSPFv3_HELLO
            { PROTOCOL_FIELD.OSPFv3_HELLO_INTERFACE_ID,                   new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv3_HELLO_INTERFACE_ID,                   Level = 0, PacketType = PacketType.OSPFv3_HELLO}},
            { PROTOCOL_FIELD.OSPFv3_HELLO_ROUTER_PRIORITY,                new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv3_HELLO_ROUTER_PRIORITY,                Level = 0, PacketType = PacketType.OSPFv3_HELLO}},
            { PROTOCOL_FIELD.OSPFv3_HELLO_OPTIONS,                        new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv3_HELLO_OPTIONS,                        Level = 0, PacketType = PacketType.OSPFv3_HELLO}},
            { PROTOCOL_FIELD.OSPFv3_HELLO_HELLO_INTERVAL,                 new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv3_HELLO_HELLO_INTERVAL,                 Level = 0, PacketType = PacketType.OSPFv3_HELLO}},
            { PROTOCOL_FIELD.OSPFv3_HELLO_ROUTER_DEAD_INTERVAL,           new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv3_HELLO_ROUTER_DEAD_INTERVAL,           Level = 0, PacketType = PacketType.OSPFv3_HELLO}},
            { PROTOCOL_FIELD.OSPFv3_HELLO_DESIGNATED_ROUTER,              new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv3_HELLO_DESIGNATED_ROUTER,              Level = 0, PacketType = PacketType.OSPFv3_HELLO}},
            { PROTOCOL_FIELD.OSPFv3_HELLO_BACKUP_DESIGNATED_ROUTER,       new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv3_HELLO_BACKUP_DESIGNATED_ROUTER,       Level = 0, PacketType = PacketType.OSPFv3_HELLO}},
            { PROTOCOL_FIELD.OSPFv3_HELLO_NEIGHBOR,                       new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv3_HELLO_NEIGHBOR,                       Level = 1, PacketType = PacketType.OSPFv3_HELLO}},

            //OSPFv3_DD
            { PROTOCOL_FIELD.OSPFv3_DD_OPTIONS,                 new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv3_DD_OPTIONS,                 Level = 0, PacketType = PacketType.OSPFv3_DD}},
            { PROTOCOL_FIELD.OSPFv3_DD_INTERFACE_MTU,	        new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv3_DD_INTERFACE_MTU,	        Level = 0, PacketType = PacketType.OSPFv3_DD}},
            { PROTOCOL_FIELD.OSPFv3_DD_BIT_00000_I_M_MS,        new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv3_DD_BIT_00000_I_M_MS,        Level = 0, PacketType = PacketType.OSPFv3_DD}},
            { PROTOCOL_FIELD.OSPFv3_DD_SEQUENCE_NUMBER,         new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv3_DD_SEQUENCE_NUMBER,         Level = 0, PacketType = PacketType.OSPFv3_DD}},

            //OSPFv3_LSR
            { PROTOCOL_FIELD.OSPFv3_LSR_LS_TYPE,                   new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv3_LSR_LS_TYPE,                   Level = 1, PacketType = PacketType.OSPFv3_LSR}},
            { PROTOCOL_FIELD.OSPFv3_LSR_LS_ID,                     new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv3_LSR_LS_ID,                     Level = 1, PacketType = PacketType.OSPFv3_LSR}},
            { PROTOCOL_FIELD.OSPFv3_LSR_ADVERTISING_ROUTER,        new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv3_LSR_ADVERTISING_ROUTER,        Level = 1, PacketType = PacketType.OSPFv3_LSR}},

            //OSPFv3_LSU
            { PROTOCOL_FIELD.OSPFv3_LSU_NUMBER_OF_LSAS,         new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv3_LSU_NUMBER_OF_LSAS,         Level = 0, PacketType = PacketType.OSPFv3_LSU}},

            //OSPFv3_LSA_HEADER
            { PROTOCOL_FIELD.OSPFv3_LSA_LS_AGE,                   new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv3_LSA_LS_AGE,                   Level = 1, PacketType = PacketType.OSPFv3_LSA_HEADER}},
            { PROTOCOL_FIELD.OSPFv3_LSA_LS_TYPE,                  new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv3_LSA_LS_TYPE,                  Level = 1, PacketType = PacketType.OSPFv3_LSA_HEADER}},
            { PROTOCOL_FIELD.OSPFv3_LSA_LS_ID,                    new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv3_LSA_LS_ID,                    Level = 1, PacketType = PacketType.OSPFv3_LSA_HEADER}},
            { PROTOCOL_FIELD.OSPFv3_LSA_ADVERTISING_ROUTER,       new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv3_LSA_ADVERTISING_ROUTER,       Level = 1, PacketType = PacketType.OSPFv3_LSA_HEADER}},
            { PROTOCOL_FIELD.OSPFv3_LSA_SEQUENCE_NUMBER,          new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv3_LSA_SEQUENCE_NUMBER,          Level = 1, PacketType = PacketType.OSPFv3_LSA_HEADER}},
            { PROTOCOL_FIELD.OSPFv3_LSA_LS_CHECKSUM,              new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv3_LSA_LS_CHECKSUM,              Level = 1, PacketType = PacketType.OSPFv3_LSA_HEADER}},
            { PROTOCOL_FIELD.OSPFv3_LSA_LENGTH,                   new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv3_LSA_LENGTH,                   Level = 1, PacketType = PacketType.OSPFv3_LSA_HEADER}},

            //OSPFv3_ROUTER_LSA
            { PROTOCOL_FIELD.OSPFv3_1LSA_BIT_0000_W_V_E_B,            new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv3_1LSA_BIT_0000_W_V_E_B,            Level = 1, PacketType = PacketType.OSPFv3_ROUTER_LSA}},
            { PROTOCOL_FIELD.OSPFv3_1LSA_OPTIONS,                     new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv3_1LSA_OPTIONS,                     Level = 1, PacketType = PacketType.OSPFv3_ROUTER_LSA}},
            { PROTOCOL_FIELD.OSPFv3_1LSA_TYPE,                        new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv3_1LSA_TYPE,                        Level = 2, PacketType = PacketType.OSPFv3_ROUTER_LSA}},
            { PROTOCOL_FIELD.OSPFv3_1LSA_METRIC,                      new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv3_1LSA_METRIC,                      Level = 2, PacketType = PacketType.OSPFv3_ROUTER_LSA}},
            { PROTOCOL_FIELD.OSPFv3_1LSA_INTERFACE_ID,                new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv3_1LSA_INTERFACE_ID,                Level = 2, PacketType = PacketType.OSPFv3_ROUTER_LSA}},
            { PROTOCOL_FIELD.OSPFv3_1LSA_NEIGHBOR_INTERFACE_ID,       new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv3_1LSA_NEIGHBOR_INTERFACE_ID,       Level = 2, PacketType = PacketType.OSPFv3_ROUTER_LSA}},
            { PROTOCOL_FIELD.OSPFv3_1LSA_NEIGHBOR_ROUTER_ID,          new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv3_1LSA_NEIGHBOR_ROUTER_ID,          Level = 2, PacketType = PacketType.OSPFv3_ROUTER_LSA}},

            //OSPFv3_NETWORK_LSA
            { PROTOCOL_FIELD.OSPFv3_2LSA_OPTIONS,                    new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv3_2LSA_OPTIONS,                    Level = 1, PacketType = PacketType.OSPFv3_NETWORK_LSA}},
            { PROTOCOL_FIELD.OSPFv3_2LSA_ATTACHED_ROUTER,            new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv3_2LSA_ATTACHED_ROUTER,            Level = 2, PacketType = PacketType.OSPFv3_NETWORK_LSA}},

            //OSPFv3_INTER_AREA_PREFIX_LSA
            { PROTOCOL_FIELD.OSPFv3_3LSA_METRIC,                 new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv3_3LSA_METRIC,                 Level = 1, PacketType = PacketType.OSPFv3_INTER_AREA_PREFIX_LSA}},
            { PROTOCOL_FIELD.OSPFv3_3LSA_PREFIX_LENGTH,          new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv3_3LSA_PREFIX_LENGTH,          Level = 1, PacketType = PacketType.OSPFv3_INTER_AREA_PREFIX_LSA}},
            { PROTOCOL_FIELD.OSPFv3_3LSA_PREFIX_OPTIONS,         new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv3_3LSA_PREFIX_OPTIONS,         Level = 1, PacketType = PacketType.OSPFv3_INTER_AREA_PREFIX_LSA}},
            { PROTOCOL_FIELD.OSPFv3_3LSA_ADDRESS_PREFIX_1,       new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv3_3LSA_ADDRESS_PREFIX_1,       Level = 1, PacketType = PacketType.OSPFv3_INTER_AREA_PREFIX_LSA}},
            { PROTOCOL_FIELD.OSPFv3_3LSA_ADDRESS_PREFIX_2,       new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv3_3LSA_ADDRESS_PREFIX_2,       Level = 1, PacketType = PacketType.OSPFv3_INTER_AREA_PREFIX_LSA}},
            { PROTOCOL_FIELD.OSPFv3_3LSA_ADDRESS_PREFIX_3,       new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv3_3LSA_ADDRESS_PREFIX_3,       Level = 1, PacketType = PacketType.OSPFv3_INTER_AREA_PREFIX_LSA}},
            { PROTOCOL_FIELD.OSPFv3_3LSA_ADDRESS_PREFIX_4,       new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv3_3LSA_ADDRESS_PREFIX_4,       Level = 1, PacketType = PacketType.OSPFv3_INTER_AREA_PREFIX_LSA}},

            //OSPFv3_INTER_AREA_ROUTER_LSA
            { PROTOCOL_FIELD.OSPFv3_4LSA_OPTIONS,                     new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv3_4LSA_OPTIONS,                     Level = 1, PacketType = PacketType.OSPFv3_INTER_AREA_ROUTER_LSA}},
            { PROTOCOL_FIELD.OSPFv3_4LSA_METRIC,                      new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv3_4LSA_METRIC,                      Level = 1, PacketType = PacketType.OSPFv3_INTER_AREA_ROUTER_LSA}},
            { PROTOCOL_FIELD.OSPFv3_4LSA_DESTINATION_ROUTER_ID,       new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv3_4LSA_DESTINATION_ROUTER_ID,       Level = 1, PacketType = PacketType.OSPFv3_INTER_AREA_ROUTER_LSA}},

            //OSPFv3_AS_EXTERNAL_LSA
            { PROTOCOL_FIELD.OSPFv3_5LSA_BIT_00000_E_F_T,            new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv3_5LSA_BIT_00000_E_F_T,            Level = 1, PacketType = PacketType.OSPFv3_AS_EXTERNAL_LSA}},
            { PROTOCOL_FIELD.OSPFv3_5LSA_METRIC,                     new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv3_5LSA_METRIC,                     Level = 1, PacketType = PacketType.OSPFv3_AS_EXTERNAL_LSA}},
            { PROTOCOL_FIELD.OSPFv3_5LSA_PREFIX_LENGTH,              new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv3_5LSA_PREFIX_LENGTH,              Level = 1, PacketType = PacketType.OSPFv3_AS_EXTERNAL_LSA}},
            { PROTOCOL_FIELD.OSPFv3_5LSA_PREFIX_OPTIONS,             new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv3_5LSA_PREFIX_OPTIONS,             Level = 1, PacketType = PacketType.OSPFv3_AS_EXTERNAL_LSA}},
            { PROTOCOL_FIELD.OSPFv3_5LSA_REFERENCED_LS_TYPE,         new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv3_5LSA_REFERENCED_LS_TYPE,         Level = 1, PacketType = PacketType.OSPFv3_AS_EXTERNAL_LSA}},
            { PROTOCOL_FIELD.OSPFv3_5LSA_ADDRESS_PREFIX_1,           new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv3_5LSA_ADDRESS_PREFIX_1,           Level = 1, PacketType = PacketType.OSPFv3_AS_EXTERNAL_LSA}},
            { PROTOCOL_FIELD.OSPFv3_5LSA_ADDRESS_PREFIX_2,           new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv3_5LSA_ADDRESS_PREFIX_2,           Level = 1, PacketType = PacketType.OSPFv3_AS_EXTERNAL_LSA}},
            { PROTOCOL_FIELD.OSPFv3_5LSA_ADDRESS_PREFIX_3,           new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv3_5LSA_ADDRESS_PREFIX_3,           Level = 1, PacketType = PacketType.OSPFv3_AS_EXTERNAL_LSA}},
            { PROTOCOL_FIELD.OSPFv3_5LSA_ADDRESS_PREFIX_4,           new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv3_5LSA_ADDRESS_PREFIX_4,           Level = 1, PacketType = PacketType.OSPFv3_AS_EXTERNAL_LSA}},
            { PROTOCOL_FIELD.OSPFv3_5LSA_FORWARDING_ADDRESS_1,       new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv3_5LSA_FORWARDING_ADDRESS_1,       Level = 1, PacketType = PacketType.OSPFv3_AS_EXTERNAL_LSA}},
            { PROTOCOL_FIELD.OSPFv3_5LSA_FORWARDING_ADDRESS_2,       new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv3_5LSA_FORWARDING_ADDRESS_2,       Level = 1, PacketType = PacketType.OSPFv3_AS_EXTERNAL_LSA}},
            { PROTOCOL_FIELD.OSPFv3_5LSA_FORWARDING_ADDRESS_3,       new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv3_5LSA_FORWARDING_ADDRESS_3,       Level = 1, PacketType = PacketType.OSPFv3_AS_EXTERNAL_LSA}},
            { PROTOCOL_FIELD.OSPFv3_5LSA_FORWARDING_ADDRESS_4,       new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv3_5LSA_FORWARDING_ADDRESS_4,       Level = 1, PacketType = PacketType.OSPFv3_AS_EXTERNAL_LSA}},
            { PROTOCOL_FIELD.OSPFv3_5LSA_EXTERNAL_ROUTE_TAG,         new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv3_5LSA_EXTERNAL_ROUTE_TAG,         Level = 1, PacketType = PacketType.OSPFv3_AS_EXTERNAL_LSA}},
            { PROTOCOL_FIELD.OSPFv3_5LSA_REFERENCED_LS_ID,           new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv3_5LSA_REFERENCED_LS_ID,           Level = 1, PacketType = PacketType.OSPFv3_AS_EXTERNAL_LSA}},

            //OSPFv3_LINK_LSA
            { PROTOCOL_FIELD.OSPFv3_8LSA_ROUTER_PRIORITY,                      new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv3_8LSA_ROUTER_PRIORITY,                      Level = 1, PacketType = PacketType.OSPFv3_LINK_LSA}},
            { PROTOCOL_FIELD.OSPFv3_8LSA_ROUTER_OPTIONS,                       new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv3_8LSA_ROUTER_OPTIONS,                       Level = 1, PacketType = PacketType.OSPFv3_LINK_LSA}},
            { PROTOCOL_FIELD.OSPFv3_8LSA_LINK_LOCAL_INTERFACE_ADDRESS_1,       new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv3_8LSA_LINK_LOCAL_INTERFACE_ADDRESS_1,       Level = 1, PacketType = PacketType.OSPFv3_LINK_LSA}},
            { PROTOCOL_FIELD.OSPFv3_8LSA_LINK_LOCAL_INTERFACE_ADDRESS_2,       new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv3_8LSA_LINK_LOCAL_INTERFACE_ADDRESS_2,       Level = 1, PacketType = PacketType.OSPFv3_LINK_LSA}},
            { PROTOCOL_FIELD.OSPFv3_8LSA_LINK_LOCAL_INTERFACE_ADDRESS_3,       new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv3_8LSA_LINK_LOCAL_INTERFACE_ADDRESS_3,       Level = 1, PacketType = PacketType.OSPFv3_LINK_LSA}},
            { PROTOCOL_FIELD.OSPFv3_8LSA_LINK_LOCAL_INTERFACE_ADDRESS_4,       new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv3_8LSA_LINK_LOCAL_INTERFACE_ADDRESS_4,       Level = 1, PacketType = PacketType.OSPFv3_LINK_LSA}},
            { PROTOCOL_FIELD.OSPFv3_8LSA_NUMBER_OF_PREFIXES,                   new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv3_8LSA_NUMBER_OF_PREFIXES,                   Level = 1, PacketType = PacketType.OSPFv3_LINK_LSA}},
            { PROTOCOL_FIELD.OSPFv3_8LSA_PREFIX_LENGTH,                        new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv3_8LSA_PREFIX_LENGTH,                        Level = 2, PacketType = PacketType.OSPFv3_LINK_LSA}},
            { PROTOCOL_FIELD.OSPFv3_8LSA_PREFIX_OPTIONS,                       new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv3_8LSA_PREFIX_OPTIONS,                       Level = 2, PacketType = PacketType.OSPFv3_LINK_LSA}},
            { PROTOCOL_FIELD.OSPFv3_8LSA_ADDRESS_PREFIX_1,                     new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv3_8LSA_ADDRESS_PREFIX_1,                     Level = 2, PacketType = PacketType.OSPFv3_LINK_LSA}},
            { PROTOCOL_FIELD.OSPFv3_8LSA_ADDRESS_PREFIX_2,                     new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv3_8LSA_ADDRESS_PREFIX_2,                     Level = 2, PacketType = PacketType.OSPFv3_LINK_LSA}},
            { PROTOCOL_FIELD.OSPFv3_8LSA_ADDRESS_PREFIX_3,                     new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv3_8LSA_ADDRESS_PREFIX_3,                     Level = 2, PacketType = PacketType.OSPFv3_LINK_LSA}},
            { PROTOCOL_FIELD.OSPFv3_8LSA_ADDRESS_PREFIX_4,                     new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv3_8LSA_ADDRESS_PREFIX_4,                     Level = 2, PacketType = PacketType.OSPFv3_LINK_LSA}},

            //OSPFv3_INTRA_AREA_PREFIX_LSA
            { PROTOCOL_FIELD.OSPFv3_9LSA_NUMBER_OF_PREFIXES,                  new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv3_9LSA_NUMBER_OF_PREFIXES,                  Level = 1, PacketType = PacketType.OSPFv3_INTRA_AREA_PREFIX_LSA}},
            { PROTOCOL_FIELD.OSPFv3_9LSA_REFERENCED_LS_TYPE,                  new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv3_9LSA_REFERENCED_LS_TYPE,                  Level = 1, PacketType = PacketType.OSPFv3_INTRA_AREA_PREFIX_LSA}},
            { PROTOCOL_FIELD.OSPFv3_9LSA_REFERENCED_LS_ID,                    new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv3_9LSA_REFERENCED_LS_ID,                    Level = 1, PacketType = PacketType.OSPFv3_INTRA_AREA_PREFIX_LSA}},
            { PROTOCOL_FIELD.OSPFv3_9LSA_REFERENCED_ADVERTISING_ROUTER,       new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv3_9LSA_REFERENCED_ADVERTISING_ROUTER,       Level = 1, PacketType = PacketType.OSPFv3_INTRA_AREA_PREFIX_LSA}},
            { PROTOCOL_FIELD.OSPFv3_9LSA_PREFIX_LENGTH,                       new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv3_9LSA_PREFIX_LENGTH,                       Level = 2, PacketType = PacketType.OSPFv3_INTRA_AREA_PREFIX_LSA}},
            { PROTOCOL_FIELD.OSPFv3_9LSA_PREFIX_OPTIONS,                      new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv3_9LSA_PREFIX_OPTIONS,                      Level = 2, PacketType = PacketType.OSPFv3_INTRA_AREA_PREFIX_LSA}},
            { PROTOCOL_FIELD.OSPFv3_9LSA_METRIC,                              new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv3_9LSA_METRIC,                              Level = 2, PacketType = PacketType.OSPFv3_INTRA_AREA_PREFIX_LSA}},
            { PROTOCOL_FIELD.OSPFv3_9LSA_ADDRESS_PREFIX_1,                    new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv3_9LSA_ADDRESS_PREFIX_1,                    Level = 2, PacketType = PacketType.OSPFv3_INTRA_AREA_PREFIX_LSA}},
            { PROTOCOL_FIELD.OSPFv3_9LSA_ADDRESS_PREFIX_2,                    new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv3_9LSA_ADDRESS_PREFIX_2,                    Level = 2, PacketType = PacketType.OSPFv3_INTRA_AREA_PREFIX_LSA}},
            { PROTOCOL_FIELD.OSPFv3_9LSA_ADDRESS_PREFIX_3,                    new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv3_9LSA_ADDRESS_PREFIX_3,                    Level = 2, PacketType = PacketType.OSPFv3_INTRA_AREA_PREFIX_LSA}},
            { PROTOCOL_FIELD.OSPFv3_9LSA_ADDRESS_PREFIX_4,                    new FieldInfo(){ Field = PROTOCOL_FIELD.OSPFv3_9LSA_ADDRESS_PREFIX_4,                    Level = 2, PacketType = PacketType.OSPFv3_INTRA_AREA_PREFIX_LSA}},


            //================================================================================================================
            //ISIS_PDUHDR
            { PROTOCOL_FIELD.ISIS_PDUHDR_IRPD,              new FieldInfo(){ Field = PROTOCOL_FIELD.ISIS_PDUHDR_IRPD,               Level = 0, PacketType = PacketType.ISIS_PDUHDR}},
            { PROTOCOL_FIELD.ISIS_PDUHDR_LEN_ID,            new FieldInfo(){ Field = PROTOCOL_FIELD.ISIS_PDUHDR_LEN_ID,             Level = 0, PacketType = PacketType.ISIS_PDUHDR}},
            { PROTOCOL_FIELD.ISIS_PDUHDR_VER_ID,            new FieldInfo(){ Field = PROTOCOL_FIELD.ISIS_PDUHDR_VER_ID,             Level = 0, PacketType = PacketType.ISIS_PDUHDR}},
            { PROTOCOL_FIELD.ISIS_PDUHDR_ID_LEN,            new FieldInfo(){ Field = PROTOCOL_FIELD.ISIS_PDUHDR_ID_LEN,             Level = 0, PacketType = PacketType.ISIS_PDUHDR}},
            { PROTOCOL_FIELD.ISIS_PDUHDR_PDU_TYPE,          new FieldInfo(){ Field = PROTOCOL_FIELD.ISIS_PDUHDR_PDU_TYPE,           Level = 0, PacketType = PacketType.ISIS_PDUHDR}},
            { PROTOCOL_FIELD.ISIS_PDUHDR_VERSION,           new FieldInfo(){ Field = PROTOCOL_FIELD.ISIS_PDUHDR_VERSION,            Level = 0, PacketType = PacketType.ISIS_PDUHDR}},
            { PROTOCOL_FIELD.ISIS_PDUHDR_RESERVED,          new FieldInfo(){ Field = PROTOCOL_FIELD.ISIS_PDUHDR_RESERVED,           Level = 0, PacketType = PacketType.ISIS_PDUHDR}},
            { PROTOCOL_FIELD.ISIS_PDUHDR_MAX_AREA_ADDR,     new FieldInfo(){ Field = PROTOCOL_FIELD.ISIS_PDUHDR_MAX_AREA_ADDR,      Level = 0, PacketType = PacketType.ISIS_PDUHDR}},

            //ISIS_LAN_HELLO
            { PROTOCOL_FIELD.ISIS_LAN_HELLO_CIRCUIT_TYPE,   new FieldInfo(){ Field = PROTOCOL_FIELD.ISIS_LAN_HELLO_CIRCUIT_TYPE,    Level = 0, PacketType = PacketType.ISIS_LAN_HELLO}},
            { PROTOCOL_FIELD.ISIS_LAN_HELLO_SRC_SYSID_1,    new FieldInfo(){ Field = PROTOCOL_FIELD.ISIS_LAN_HELLO_SRC_SYSID_1,     Level = 0, PacketType = PacketType.ISIS_LAN_HELLO}},
            { PROTOCOL_FIELD.ISIS_LAN_HELLO_SRC_SYSID_2,    new FieldInfo(){ Field = PROTOCOL_FIELD.ISIS_LAN_HELLO_SRC_SYSID_2,     Level = 0, PacketType = PacketType.ISIS_LAN_HELLO}},
            { PROTOCOL_FIELD.ISIS_LAN_HELLO_HOLD_TIME,      new FieldInfo(){ Field = PROTOCOL_FIELD.ISIS_LAN_HELLO_HOLD_TIME,       Level = 0, PacketType = PacketType.ISIS_LAN_HELLO}},
            { PROTOCOL_FIELD.ISIS_LAN_HELLO_PDU_LEN,        new FieldInfo(){ Field = PROTOCOL_FIELD.ISIS_LAN_HELLO_PDU_LEN,         Level = 0, PacketType = PacketType.ISIS_LAN_HELLO}},
            { PROTOCOL_FIELD.ISIS_LAN_HELLO_PRIORITY,       new FieldInfo(){ Field = PROTOCOL_FIELD.ISIS_LAN_HELLO_PRIORITY,        Level = 0, PacketType = PacketType.ISIS_LAN_HELLO}},
            { PROTOCOL_FIELD.ISIS_LAN_HELLO_DESI_SYSID_1,   new FieldInfo(){ Field = PROTOCOL_FIELD.ISIS_LAN_HELLO_DESI_SYSID_1,    Level = 0, PacketType = PacketType.ISIS_LAN_HELLO}},
            { PROTOCOL_FIELD.ISIS_LAN_HELLO_DESI_SYSID_2,   new FieldInfo(){ Field = PROTOCOL_FIELD.ISIS_LAN_HELLO_DESI_SYSID_2,    Level = 0, PacketType = PacketType.ISIS_LAN_HELLO}},
                                                                                                                                            
            //ISIS_P2P_HELLO                                                                                                                
            { PROTOCOL_FIELD.ISIS_P2P_HELLO_CIRCUIT_TYPE,   new FieldInfo(){ Field = PROTOCOL_FIELD.ISIS_P2P_HELLO_CIRCUIT_TYPE,    Level = 0, PacketType = PacketType.ISIS_POINT_TO_POINT_HELLO}},
            { PROTOCOL_FIELD.ISIS_P2P_HELLO_SRC_SYSID_1,    new FieldInfo(){ Field = PROTOCOL_FIELD.ISIS_P2P_HELLO_SRC_SYSID_1,     Level = 0, PacketType = PacketType.ISIS_POINT_TO_POINT_HELLO}},
            { PROTOCOL_FIELD.ISIS_P2P_HELLO_SRC_SYSID_2,    new FieldInfo(){ Field = PROTOCOL_FIELD.ISIS_P2P_HELLO_SRC_SYSID_2,     Level = 0, PacketType = PacketType.ISIS_POINT_TO_POINT_HELLO}},
            { PROTOCOL_FIELD.ISIS_P2P_HELLO_HOLD_TIME,      new FieldInfo(){ Field = PROTOCOL_FIELD.ISIS_P2P_HELLO_HOLD_TIME,       Level = 0, PacketType = PacketType.ISIS_POINT_TO_POINT_HELLO}},
            { PROTOCOL_FIELD.ISIS_P2P_HELLO_PDU_LEN,        new FieldInfo(){ Field = PROTOCOL_FIELD.ISIS_P2P_HELLO_PDU_LEN,         Level = 0, PacketType = PacketType.ISIS_POINT_TO_POINT_HELLO}},
            { PROTOCOL_FIELD.ISIS_P2P_HELLO_LOCAL_ID,       new FieldInfo(){ Field = PROTOCOL_FIELD.ISIS_P2P_HELLO_LOCAL_ID,        Level = 0, PacketType = PacketType.ISIS_POINT_TO_POINT_HELLO}},
                                                                                                                                            
            //ISIS_LSP                                                                                                                      
            { PROTOCOL_FIELD.ISIS_LSP_PDU_LEN,              new FieldInfo(){ Field = PROTOCOL_FIELD.ISIS_LSP_PDU_LEN,               Level = 0, PacketType = PacketType.ISIS_LSP}},
            { PROTOCOL_FIELD.ISIS_LSP_REMAIN_LIFE_TIME,     new FieldInfo(){ Field = PROTOCOL_FIELD.ISIS_LSP_REMAIN_LIFE_TIME,      Level = 0, PacketType = PacketType.ISIS_LSP}},
            { PROTOCOL_FIELD.ISIS_LSP_ID_1,                 new FieldInfo(){ Field = PROTOCOL_FIELD.ISIS_LSP_ID_1,                  Level = 0, PacketType = PacketType.ISIS_LSP}},
            { PROTOCOL_FIELD.ISIS_LSP_ID_2,                 new FieldInfo(){ Field = PROTOCOL_FIELD.ISIS_LSP_ID_2,                  Level = 0, PacketType = PacketType.ISIS_LSP}},
            { PROTOCOL_FIELD.ISIS_LSP_SEQNUM,               new FieldInfo(){ Field = PROTOCOL_FIELD.ISIS_LSP_SEQNUM,                Level = 0, PacketType = PacketType.ISIS_LSP}},
            { PROTOCOL_FIELD.ISIS_LSP_CHECKSUM,             new FieldInfo(){ Field = PROTOCOL_FIELD.ISIS_LSP_CHECKSUM,              Level = 0, PacketType = PacketType.ISIS_LSP}},
            { PROTOCOL_FIELD.ISIS_LSP_TYPE_BLOCK,           new FieldInfo(){ Field = PROTOCOL_FIELD.ISIS_LSP_TYPE_BLOCK,            Level = 0, PacketType = PacketType.ISIS_LSP}},
                                                                                                                                            
            //ISIS_CSNP                                                                                                                     
            { PROTOCOL_FIELD.ISIS_CSNP_PDU_LEN,             new FieldInfo(){ Field = PROTOCOL_FIELD.ISIS_CSNP_PDU_LEN,              Level = 0, PacketType = PacketType.ISIS_CSNP}},
            { PROTOCOL_FIELD.ISIS_CSNP_SRC_SYSID_1,         new FieldInfo(){ Field = PROTOCOL_FIELD.ISIS_CSNP_SRC_SYSID_1,          Level = 0, PacketType = PacketType.ISIS_CSNP}},
            { PROTOCOL_FIELD.ISIS_CSNP_SRC_SYSID_2,         new FieldInfo(){ Field = PROTOCOL_FIELD.ISIS_CSNP_SRC_SYSID_2,          Level = 0, PacketType = PacketType.ISIS_CSNP}},
            { PROTOCOL_FIELD.ISIS_CSNP_START_LSPID_1,       new FieldInfo(){ Field = PROTOCOL_FIELD.ISIS_CSNP_START_LSPID_1,        Level = 0, PacketType = PacketType.ISIS_CSNP}},
            { PROTOCOL_FIELD.ISIS_CSNP_START_LSPID_2,       new FieldInfo(){ Field = PROTOCOL_FIELD.ISIS_CSNP_START_LSPID_2,        Level = 0, PacketType = PacketType.ISIS_CSNP}},
            { PROTOCOL_FIELD.ISIS_CSNP_END_LSPID_1,         new FieldInfo(){ Field = PROTOCOL_FIELD.ISIS_CSNP_END_LSPID_1,          Level = 0, PacketType = PacketType.ISIS_CSNP}},
            { PROTOCOL_FIELD.ISIS_CSNP_END_LSPID_2,         new FieldInfo(){ Field = PROTOCOL_FIELD.ISIS_CSNP_END_LSPID_2,          Level = 0, PacketType = PacketType.ISIS_CSNP}},
                                                                                                                                            
            //ISIS_PSNP                                                                                                                     
            { PROTOCOL_FIELD.ISIS_PSNP_PDU_LEN,             new FieldInfo(){ Field = PROTOCOL_FIELD.ISIS_PSNP_PDU_LEN,              Level = 0, PacketType = PacketType.ISIS_PSNP}},
            { PROTOCOL_FIELD.ISIS_PSNP_SRC_SYSID_1,         new FieldInfo(){ Field = PROTOCOL_FIELD.ISIS_PSNP_SRC_SYSID_1,          Level = 0, PacketType = PacketType.ISIS_PSNP}},
            { PROTOCOL_FIELD.ISIS_PSNP_SRC_SYSID_2,         new FieldInfo(){ Field = PROTOCOL_FIELD.ISIS_PSNP_SRC_SYSID_2,          Level = 0, PacketType = PacketType.ISIS_PSNP}},

            //ISIS_TLV
            { PROTOCOL_FIELD.ISIS_TLV_TYPE,                                      new FieldInfo(){ Field = PROTOCOL_FIELD.ISIS_TLV_TYPE,                                                   Level = 1, PacketType = PacketType.ISIS_TLV}},
            { PROTOCOL_FIELD.ISIS_TLV_LEN,                                       new FieldInfo(){ Field = PROTOCOL_FIELD.ISIS_TLV_LEN,                                                    Level = 1, PacketType = PacketType.ISIS_TLV}},

            { PROTOCOL_FIELD.ISIS_TLV_TYPE_AREA_ADDR_ADDRLEN,                    new FieldInfo(){ Field = PROTOCOL_FIELD.ISIS_TLV_TYPE_AREA_ADDR_ADDRLEN,                                 Level = 2, PacketType = PacketType.ISIS_TLV}},
            { PROTOCOL_FIELD.ISIS_TLV_TYPE_AREA_ADDR_VALUE,                      new FieldInfo(){ Field = PROTOCOL_FIELD.ISIS_TLV_TYPE_AREA_ADDR_VALUE,                                   Level = 2, PacketType = PacketType.ISIS_TLV}},

            { PROTOCOL_FIELD.ISIS_TLV_TYPE_IS_REACH_RESERVED,                    new FieldInfo(){ Field = PROTOCOL_FIELD.ISIS_TLV_TYPE_IS_REACH_RESERVED,                                 Level = 2, PacketType = PacketType.ISIS_TLV}},
            { PROTOCOL_FIELD.ISIS_TLV_TYPE_IS_REACH_DEFAULT_METRIC,              new FieldInfo(){ Field = PROTOCOL_FIELD.ISIS_TLV_TYPE_IS_REACH_DEFAULT_METRIC,                           Level = 2, PacketType = PacketType.ISIS_TLV}},
            { PROTOCOL_FIELD.ISIS_TLV_TYPE_IS_REACH_DELAY_METRIC,                new FieldInfo(){ Field = PROTOCOL_FIELD.ISIS_TLV_TYPE_IS_REACH_DELAY_METRIC,                             Level = 2, PacketType = PacketType.ISIS_TLV}},
            { PROTOCOL_FIELD.ISIS_TLV_TYPE_IS_REACH_EXPENSE_METRIC,              new FieldInfo(){ Field = PROTOCOL_FIELD.ISIS_TLV_TYPE_IS_REACH_EXPENSE_METRIC,                           Level = 2, PacketType = PacketType.ISIS_TLV}},
            { PROTOCOL_FIELD.ISIS_TLV_TYPE_IS_REACH_ERROR_METRIC,                new FieldInfo(){ Field = PROTOCOL_FIELD.ISIS_TLV_TYPE_IS_REACH_ERROR_METRIC,                             Level = 2, PacketType = PacketType.ISIS_TLV}},
            { PROTOCOL_FIELD.ISIS_TLV_TYPE_IS_REACH_NEIGHBOR_ID_1,               new FieldInfo(){ Field = PROTOCOL_FIELD.ISIS_TLV_TYPE_IS_REACH_NEIGHBOR_ID_1,                            Level = 2, PacketType = PacketType.ISIS_TLV}},
            { PROTOCOL_FIELD.ISIS_TLV_TYPE_IS_REACH_NEIGHBOR_ID_2,               new FieldInfo(){ Field = PROTOCOL_FIELD.ISIS_TLV_TYPE_IS_REACH_NEIGHBOR_ID_2,                            Level = 2, PacketType = PacketType.ISIS_TLV}},

            { PROTOCOL_FIELD.ISIS_TLV_TYPE_IS_NEIGHBOR_ADDR_1,                   new FieldInfo(){ Field = PROTOCOL_FIELD.ISIS_TLV_TYPE_IS_NEIGHBOR_ADDR_1,                                Level = 2, PacketType = PacketType.ISIS_TLV}},
            { PROTOCOL_FIELD.ISIS_TLV_TYPE_IS_NEIGHBOR_ADDR_2,                   new FieldInfo(){ Field = PROTOCOL_FIELD.ISIS_TLV_TYPE_IS_NEIGHBOR_ADDR_2,                                Level = 2, PacketType = PacketType.ISIS_TLV}},

            { PROTOCOL_FIELD.ISIS_TLV_TYPE_IS_PADDING,                           new FieldInfo(){ Field = PROTOCOL_FIELD.ISIS_TLV_TYPE_IS_PADDING,                                        Level = 2, PacketType = PacketType.ISIS_TLV}},

            { PROTOCOL_FIELD.ISIS_TLV_TYPE_LSP_ENTRY_REMAINLIFETIME,             new FieldInfo(){ Field = PROTOCOL_FIELD.ISIS_TLV_TYPE_LSP_ENTRY_REMAINLIFETIME,                          Level = 2, PacketType = PacketType.ISIS_TLV}},
            { PROTOCOL_FIELD.ISIS_TLV_TYPE_LSP_ENTRY_LSPID_1,                    new FieldInfo(){ Field = PROTOCOL_FIELD.ISIS_TLV_TYPE_LSP_ENTRY_LSPID_1,                                 Level = 2, PacketType = PacketType.ISIS_TLV}},
            { PROTOCOL_FIELD.ISIS_TLV_TYPE_LSP_ENTRY_LSPID_2,                    new FieldInfo(){ Field = PROTOCOL_FIELD.ISIS_TLV_TYPE_LSP_ENTRY_LSPID_2,                                 Level = 2, PacketType = PacketType.ISIS_TLV}},
            { PROTOCOL_FIELD.ISIS_TLV_TYPE_LSP_ENTRY_SEQNUM,                     new FieldInfo(){ Field = PROTOCOL_FIELD.ISIS_TLV_TYPE_LSP_ENTRY_SEQNUM,                                  Level = 2, PacketType = PacketType.ISIS_TLV}},
            { PROTOCOL_FIELD.ISIS_TLV_TYPE_LSP_ENTRY_CHECKSUM,                   new FieldInfo(){ Field = PROTOCOL_FIELD.ISIS_TLV_TYPE_LSP_ENTRY_CHECKSUM,                                Level = 2, PacketType = PacketType.ISIS_TLV}},

            { PROTOCOL_FIELD.ISIS_TLV_TYPE_IS_AUTH_AUTHTYPE,                     new FieldInfo(){ Field = PROTOCOL_FIELD.ISIS_TLV_TYPE_IS_AUTH_AUTHTYPE,                                  Level = 2, PacketType = PacketType.ISIS_TLV}},
            { PROTOCOL_FIELD.ISIS_TLV_TYPE_IS_AUTH_AUTHVALUE,                    new FieldInfo(){ Field = PROTOCOL_FIELD.ISIS_TLV_TYPE_IS_AUTH_AUTHVALUE,                                 Level = 2, PacketType = PacketType.ISIS_TLV}},

            { PROTOCOL_FIELD.ISIS_TLV_TYPE_IP_INTERNAL_REACH_DEFAULT_METRIC,     new FieldInfo(){ Field = PROTOCOL_FIELD.ISIS_TLV_TYPE_IP_INTERNAL_REACH_DEFAULT_METRIC,                  Level = 2, PacketType = PacketType.ISIS_TLV}},
            { PROTOCOL_FIELD.ISIS_TLV_TYPE_IP_INTERNAL_REACH_DELAY_METRIC,       new FieldInfo(){ Field = PROTOCOL_FIELD.ISIS_TLV_TYPE_IP_INTERNAL_REACH_DELAY_METRIC,                    Level = 2, PacketType = PacketType.ISIS_TLV}},
            { PROTOCOL_FIELD.ISIS_TLV_TYPE_IP_INTERNAL_REACH_EXPENSE_METRIC,     new FieldInfo(){ Field = PROTOCOL_FIELD.ISIS_TLV_TYPE_IP_INTERNAL_REACH_EXPENSE_METRIC,                  Level = 2, PacketType = PacketType.ISIS_TLV}},
            { PROTOCOL_FIELD.ISIS_TLV_TYPE_IP_INTERNAL_REACH_ERROR_METRIC,       new FieldInfo(){ Field = PROTOCOL_FIELD.ISIS_TLV_TYPE_IP_INTERNAL_REACH_ERROR_METRIC,                    Level = 2, PacketType = PacketType.ISIS_TLV}},
            { PROTOCOL_FIELD.ISIS_TLV_TYPE_IP_INTERNAL_REACH_IPADDR,             new FieldInfo(){ Field = PROTOCOL_FIELD.ISIS_TLV_TYPE_IP_INTERNAL_REACH_IPADDR,                          Level = 2, PacketType = PacketType.ISIS_TLV}},
            { PROTOCOL_FIELD.ISIS_TLV_TYPE_IP_INTERNAL_REACH_SUBNETMASK,         new FieldInfo(){ Field = PROTOCOL_FIELD.ISIS_TLV_TYPE_IP_INTERNAL_REACH_SUBNETMASK,                      Level = 2, PacketType = PacketType.ISIS_TLV}},

            { PROTOCOL_FIELD.ISIS_TLV_TYPE_PROTO_SUPPORT_NLPID,                  new FieldInfo(){ Field = PROTOCOL_FIELD.ISIS_TLV_TYPE_PROTO_SUPPORT_NLPID,                               Level = 2, PacketType = PacketType.ISIS_TLV}},

            { PROTOCOL_FIELD.ISIS_TLV_TYPE_IP_EXTERNAL_REACH_DEFAULT_METRIC,     new FieldInfo(){ Field = PROTOCOL_FIELD.ISIS_TLV_TYPE_IP_EXTERNAL_REACH_DEFAULT_METRIC,                  Level = 2, PacketType = PacketType.ISIS_TLV}},
            { PROTOCOL_FIELD.ISIS_TLV_TYPE_IP_EXTERNAL_REACH_DELAY_METRIC,       new FieldInfo(){ Field = PROTOCOL_FIELD.ISIS_TLV_TYPE_IP_EXTERNAL_REACH_DELAY_METRIC,                    Level = 2, PacketType = PacketType.ISIS_TLV}},
            { PROTOCOL_FIELD.ISIS_TLV_TYPE_IP_EXTERNAL_REACH_EXPENSE_METRIC,     new FieldInfo(){ Field = PROTOCOL_FIELD.ISIS_TLV_TYPE_IP_EXTERNAL_REACH_EXPENSE_METRIC,                  Level = 2, PacketType = PacketType.ISIS_TLV}},
            { PROTOCOL_FIELD.ISIS_TLV_TYPE_IP_EXTERNAL_REACH_ERROR_METRIC,       new FieldInfo(){ Field = PROTOCOL_FIELD.ISIS_TLV_TYPE_IP_EXTERNAL_REACH_ERROR_METRIC,                    Level = 2, PacketType = PacketType.ISIS_TLV}},
            { PROTOCOL_FIELD.ISIS_TLV_TYPE_IP_EXTERNAL_REACH_IPADDR,             new FieldInfo(){ Field = PROTOCOL_FIELD.ISIS_TLV_TYPE_IP_EXTERNAL_REACH_IPADDR,                          Level = 2, PacketType = PacketType.ISIS_TLV}},
            { PROTOCOL_FIELD.ISIS_TLV_TYPE_IP_EXTERNAL_REACH_SUBNETMASK,         new FieldInfo(){ Field = PROTOCOL_FIELD.ISIS_TLV_TYPE_IP_EXTERNAL_REACH_SUBNETMASK,                      Level = 2, PacketType = PacketType.ISIS_TLV}},

            { PROTOCOL_FIELD.ISIS_TLV_TYPE_IP_INTERFACE_ADDR_IPADDR,             new FieldInfo(){ Field = PROTOCOL_FIELD.ISIS_TLV_TYPE_IP_INTERFACE_ADDR_IPADDR,                          Level = 2, PacketType = PacketType.ISIS_TLV}},

            { PROTOCOL_FIELD.ISIS_TLV_TYPE_HOSTNAME,                             new FieldInfo(){ Field = PROTOCOL_FIELD.ISIS_TLV_TYPE_HOSTNAME,                                          Level = 2, PacketType = PacketType.ISIS_TLV}},

            { PROTOCOL_FIELD.ISIS_TLV_TYPE_RESTART_SIGNAL,                       new FieldInfo(){ Field = PROTOCOL_FIELD.ISIS_TLV_TYPE_RESTART_SIGNAL,                                    Level = 2, PacketType = PacketType.ISIS_TLV}},

            { PROTOCOL_FIELD.ISIS_TLV_TYPE_IPv6_INTERFACE_ADDR_IPADDR_1,         new FieldInfo(){ Field = PROTOCOL_FIELD.ISIS_TLV_TYPE_IPv6_INTERFACE_ADDR_IPADDR_1,                      Level = 2, PacketType = PacketType.ISIS_TLV}},
            { PROTOCOL_FIELD.ISIS_TLV_TYPE_IPv6_INTERFACE_ADDR_IPADDR_2,         new FieldInfo(){ Field = PROTOCOL_FIELD.ISIS_TLV_TYPE_IPv6_INTERFACE_ADDR_IPADDR_2,                      Level = 2, PacketType = PacketType.ISIS_TLV}},
            { PROTOCOL_FIELD.ISIS_TLV_TYPE_IPv6_INTERFACE_ADDR_IPADDR_3,         new FieldInfo(){ Field = PROTOCOL_FIELD.ISIS_TLV_TYPE_IPv6_INTERFACE_ADDR_IPADDR_3,                      Level = 2, PacketType = PacketType.ISIS_TLV}},
            { PROTOCOL_FIELD.ISIS_TLV_TYPE_IPv6_INTERFACE_ADDR_IPADDR_4,         new FieldInfo(){ Field = PROTOCOL_FIELD.ISIS_TLV_TYPE_IPv6_INTERFACE_ADDR_IPADDR_4,                      Level = 2, PacketType = PacketType.ISIS_TLV}},

            { PROTOCOL_FIELD.ISIS_TLV_TYPE_IPv6_REACH_METRIC,                    new FieldInfo(){ Field = PROTOCOL_FIELD.ISIS_TLV_TYPE_IPv6_REACH_METRIC,                                 Level = 2, PacketType = PacketType.ISIS_TLV}},
            { PROTOCOL_FIELD.ISIS_TLV_TYPE_IPv6_REACH_FLAG,                      new FieldInfo(){ Field = PROTOCOL_FIELD.ISIS_TLV_TYPE_IPv6_REACH_FLAG,                                   Level = 2, PacketType = PacketType.ISIS_TLV}},
            { PROTOCOL_FIELD.ISIS_TLV_TYPE_IPv6_REACH_PREFIXLEN,                 new FieldInfo(){ Field = PROTOCOL_FIELD.ISIS_TLV_TYPE_IPv6_REACH_PREFIXLEN,                              Level = 2, PacketType = PacketType.ISIS_TLV}},
            { PROTOCOL_FIELD.ISIS_TLV_TYPE_IPv6_REACH_PREFIX_1,                  new FieldInfo(){ Field = PROTOCOL_FIELD.ISIS_TLV_TYPE_IPv6_REACH_PREFIX_1,                               Level = 2, PacketType = PacketType.ISIS_TLV}},
            { PROTOCOL_FIELD.ISIS_TLV_TYPE_IPv6_REACH_PREFIX_2,                  new FieldInfo(){ Field = PROTOCOL_FIELD.ISIS_TLV_TYPE_IPv6_REACH_PREFIX_2,                               Level = 2, PacketType = PacketType.ISIS_TLV}},
            { PROTOCOL_FIELD.ISIS_TLV_TYPE_IPv6_REACH_PREFIX_3,                  new FieldInfo(){ Field = PROTOCOL_FIELD.ISIS_TLV_TYPE_IPv6_REACH_PREFIX_3,                               Level = 2, PacketType = PacketType.ISIS_TLV}},
            { PROTOCOL_FIELD.ISIS_TLV_TYPE_IPv6_REACH_PREFIX_4,                  new FieldInfo(){ Field = PROTOCOL_FIELD.ISIS_TLV_TYPE_IPv6_REACH_PREFIX_4,                               Level = 2, PacketType = PacketType.ISIS_TLV}},
            { PROTOCOL_FIELD.ISIS_TLV_TYPE_IPv6_REACH_SUBTLVLEN,                 new FieldInfo(){ Field = PROTOCOL_FIELD.ISIS_TLV_TYPE_IPv6_REACH_SUBTLVLEN,                              Level = 2, PacketType = PacketType.ISIS_TLV}},
            { PROTOCOL_FIELD.ISIS_TLV_TYPE_IPv6_REACH_SUBTLV,                    new FieldInfo(){ Field = PROTOCOL_FIELD.ISIS_TLV_TYPE_IPv6_REACH_SUBTLV,                                 Level = 2, PacketType = PacketType.ISIS_TLV}},
            //================================================================================================================
        };

        
    }

    public class PacketInfo
    {
        public PacketType PacketType { get; set; }
        public List<PROTOCOL_FIELD> AvaliableFields { get; set; }

        public static Dictionary<PacketType, PacketInfo> AllPacketInfos = new Dictionary<PacketType, PacketInfo>()
        {
            {
                PacketType.OSPFv2_HEADER,
                new PacketInfo()
                {
                    PacketType = PacketType.OSPFv2_HEADER,
                    AvaliableFields = FieldInfo.AllFieldInfos.Values.Where(s=>s.PacketType == PacketType.OSPFv2_HEADER).Select(s=>s.Field).ToList()
                }
            },

            {
                PacketType.OSPFv2_HELLO,
                new PacketInfo()
                {
                    PacketType = PacketType.OSPFv2_HELLO,
                    AvaliableFields = FieldInfo.AllFieldInfos.Values.Where(s=>s.PacketType == PacketType.OSPFv2_HEADER || s.PacketType == PacketType.OSPFv2_HELLO).Select(s=>s.Field).ToList()
                }
            },

            {
                PacketType.OSPFv2_DD,
                new PacketInfo()
                {
                    PacketType = PacketType.OSPFv2_DD,
                    AvaliableFields = FieldInfo.AllFieldInfos.Values.Where(s=>s.PacketType == PacketType.OSPFv2_HEADER || s.PacketType == PacketType.OSPFv2_DD || s.PacketType == PacketType.OSPFv2_LSA_HEADER).Select(s=>s.Field).ToList()
                }
            },

            {
                PacketType.OSPFv2_LSR,
                new PacketInfo()
                {
                    PacketType = PacketType.OSPFv2_LSR,
                    AvaliableFields = FieldInfo.AllFieldInfos.Values.Where(s=>s.PacketType == PacketType.OSPFv2_HEADER || s.PacketType == PacketType.OSPFv2_LSR).Select(s=>s.Field).ToList()
                }
            },

            {
                PacketType.OSPFv2_LSU,
                new PacketInfo()
                {
                    PacketType = PacketType.OSPFv2_LSU,
                    AvaliableFields = FieldInfo.AllFieldInfos.Values.Where(s=>s.PacketType == PacketType.OSPFv2_HEADER || s.PacketType == PacketType.OSPFv2_LSU).Select(s=>s.Field).ToList()
                }
            },

            {
                PacketType.OSPFv2_LSACK,
                new PacketInfo()
                {
                    PacketType = PacketType.OSPFv2_LSACK,
                    AvaliableFields = FieldInfo.AllFieldInfos.Values.Where(s=>s.PacketType == PacketType.OSPFv2_HEADER || s.PacketType == PacketType.OSPFv2_LSACK || s.PacketType == PacketType.OSPFv2_LSA_HEADER).Select(s=>s.Field).ToList()
                }
            },

            {
                PacketType.OSPFv2_LSA_HEADER,
                new PacketInfo()
                {
                    PacketType = PacketType.OSPFv2_LSA_HEADER,
                    AvaliableFields = FieldInfo.AllFieldInfos.Values.Where(s=>s.PacketType == PacketType.OSPFv2_HEADER || s.PacketType == PacketType.OSPFv2_LSA_HEADER).Select(s=>s.Field).ToList()
                }
            },

            {
                PacketType.OSPFv2_ROUTER_LSA,
                new PacketInfo()
                {
                    PacketType = PacketType.OSPFv2_ROUTER_LSA,
                    AvaliableFields = FieldInfo.AllFieldInfos.Values.Where(s=>s.PacketType == PacketType.OSPFv2_HEADER || s.PacketType == PacketType.OSPFv2_LSA_HEADER || s.PacketType == PacketType.OSPFv2_ROUTER_LSA).Select(s=>s.Field).ToList()
                }
            },

            {
                PacketType.OSPFv2_NETWORK_LSA,
                new PacketInfo()
                {
                    PacketType = PacketType.OSPFv2_NETWORK_LSA,
                    AvaliableFields = FieldInfo.AllFieldInfos.Values.Where(s=>s.PacketType == PacketType.OSPFv2_HEADER || s.PacketType == PacketType.OSPFv2_LSA_HEADER || s.PacketType == PacketType.OSPFv2_NETWORK_LSA).Select(s=>s.Field).ToList()
                }
            },

            {
                PacketType.OSPFv2_NETWORK_SUMMARY_LSA,
                new PacketInfo()
                {
                    PacketType = PacketType.OSPFv2_NETWORK_SUMMARY_LSA,
                    AvaliableFields = FieldInfo.AllFieldInfos.Values.Where(s=>s.PacketType == PacketType.OSPFv2_HEADER || s.PacketType == PacketType.OSPFv2_LSA_HEADER || s.PacketType == PacketType.OSPFv2_NETWORK_SUMMARY_LSA).Select(s=>s.Field).ToList()
                }
            },

            {
                PacketType.OSPFv2_ASBR_SUMMARY_LSA,
                new PacketInfo()
                {
                    PacketType = PacketType.OSPFv2_ASBR_SUMMARY_LSA,
                    AvaliableFields = FieldInfo.AllFieldInfos.Values.Where(s=>s.PacketType == PacketType.OSPFv2_HEADER || s.PacketType == PacketType.OSPFv2_LSA_HEADER || s.PacketType == PacketType.OSPFv2_ASBR_SUMMARY_LSA).Select(s=>s.Field).ToList()
                }
            },

            {
                PacketType.OSPFv2_AS_EXTERNAL_LSA,
                new PacketInfo()
                {
                    PacketType = PacketType.OSPFv2_AS_EXTERNAL_LSA,
                    AvaliableFields = FieldInfo.AllFieldInfos.Values.Where(s=>s.PacketType == PacketType.OSPFv2_HEADER || s.PacketType == PacketType.OSPFv2_LSA_HEADER || s.PacketType == PacketType.OSPFv2_AS_EXTERNAL_LSA).Select(s=>s.Field).ToList()
                }
            },

            {
                PacketType.OSPFv3_HEADER,
                new PacketInfo()
                {
                    PacketType = PacketType.OSPFv3_HEADER,
                    AvaliableFields = FieldInfo.AllFieldInfos.Values.Where(s=>s.PacketType == PacketType.OSPFv3_HEADER).Select(s=>s.Field).ToList()
                }
            },

            {
                PacketType.OSPFv3_HELLO,
                new PacketInfo()
                {
                    PacketType = PacketType.OSPFv3_HELLO,
                    AvaliableFields = FieldInfo.AllFieldInfos.Values.Where(s=>s.PacketType == PacketType.OSPFv3_HEADER || s.PacketType == Models.PacketType.OSPFv3_HELLO).Select(s=>s.Field).ToList()
                }
            },

            {
                PacketType.OSPFv3_DD,
                new PacketInfo()
                {
                    PacketType = PacketType.OSPFv3_DD,
                    AvaliableFields = FieldInfo.AllFieldInfos.Values.Where(s=>s.PacketType == PacketType.OSPFv3_HEADER || s.PacketType == Models.PacketType.OSPFv3_DD || s.PacketType == PacketType.OSPFv3_LSA_HEADER).Select(s=>s.Field).ToList()
                }
            },

            {
                PacketType.OSPFv3_LSR,
                new PacketInfo()
                {
                    PacketType = PacketType.OSPFv3_LSR,
                    AvaliableFields = FieldInfo.AllFieldInfos.Values.Where(s=>s.PacketType == PacketType.OSPFv3_HEADER || s.PacketType == PacketType.OSPFv3_LSR).Select(s=>s.Field).ToList()
                }
            },

            {
                PacketType.OSPFv3_LSU,
                new PacketInfo()
                {
                    PacketType = PacketType.OSPFv3_LSU,
                    AvaliableFields = FieldInfo.AllFieldInfos.Values.Where(s=>s.PacketType == PacketType.OSPFv3_HEADER || s.PacketType == PacketType.OSPFv3_LSU).Select(s=>s.Field).ToList()
                }
            },

            {
                PacketType.OSPFv3_LSACK,
                new PacketInfo()
                {
                    PacketType = PacketType.OSPFv3_LSACK,
                    AvaliableFields = FieldInfo.AllFieldInfos.Values.Where(s=>s.PacketType == PacketType.OSPFv3_HEADER || s.PacketType == PacketType.OSPFv3_LSACK || s.PacketType == PacketType.OSPFv3_LSA_HEADER).Select(s=>s.Field).ToList()
                }
            },

            {
                PacketType.OSPFv3_LSA_HEADER,
                new PacketInfo()
                {
                    PacketType = PacketType.OSPFv3_LSA_HEADER,
                    AvaliableFields = FieldInfo.AllFieldInfos.Values.Where(s=>s.PacketType == PacketType.OSPFv3_HEADER || s.PacketType == PacketType.OSPFv3_LSA_HEADER).Select(s=>s.Field).ToList()
                }
            },

            {
                PacketType.OSPFv3_ROUTER_LSA,
                new PacketInfo()
                {
                    PacketType = PacketType.OSPFv3_ROUTER_LSA,
                    AvaliableFields = FieldInfo.AllFieldInfos.Values.Where(s=>s.PacketType == PacketType.OSPFv3_HEADER || s.PacketType == PacketType.OSPFv3_LSA_HEADER || s.PacketType == PacketType.OSPFv3_ROUTER_LSA).Select(s=>s.Field).ToList()
                }
            },

            {
                PacketType.OSPFv3_NETWORK_LSA,
                new PacketInfo()
                {
                    PacketType = PacketType.OSPFv3_NETWORK_LSA,
                    AvaliableFields = FieldInfo.AllFieldInfos.Values.Where(s=>s.PacketType == PacketType.OSPFv3_HEADER || s.PacketType == PacketType.OSPFv3_LSA_HEADER || s.PacketType == PacketType.OSPFv3_NETWORK_LSA).Select(s=>s.Field).ToList()
                }
            },

            {
                PacketType.OSPFv3_INTER_AREA_PREFIX_LSA,
                new PacketInfo()
                {
                    PacketType = PacketType.OSPFv3_INTER_AREA_PREFIX_LSA,
                    AvaliableFields = FieldInfo.AllFieldInfos.Values.Where(s=>s.PacketType == PacketType.OSPFv3_HEADER || s.PacketType == PacketType.OSPFv3_LSA_HEADER || s.PacketType == PacketType.OSPFv3_INTER_AREA_PREFIX_LSA).Select(s=>s.Field).ToList()
                }
            },

            {
                PacketType.OSPFv3_INTER_AREA_ROUTER_LSA,
                new PacketInfo()
                {
                    PacketType = PacketType.OSPFv3_INTER_AREA_ROUTER_LSA,
                    AvaliableFields = FieldInfo.AllFieldInfos.Values.Where(s=>s.PacketType == PacketType.OSPFv3_HEADER || s.PacketType == PacketType.OSPFv3_LSA_HEADER || s.PacketType == PacketType.OSPFv3_INTER_AREA_ROUTER_LSA).Select(s=>s.Field).ToList()
                }
            },

            {
                PacketType.OSPFv3_AS_EXTERNAL_LSA,
                new PacketInfo()
                {
                    PacketType = PacketType.OSPFv3_AS_EXTERNAL_LSA,
                    AvaliableFields = FieldInfo.AllFieldInfos.Values.Where(s=>s.PacketType == PacketType.OSPFv3_HEADER || s.PacketType == PacketType.OSPFv3_LSA_HEADER || s.PacketType == PacketType.OSPFv3_AS_EXTERNAL_LSA).Select(s=>s.Field).ToList()
                }
            },

            {
                PacketType.OSPFv3_LINK_LSA,
                new PacketInfo()
                {
                    PacketType = PacketType.OSPFv3_LINK_LSA,
                    AvaliableFields = FieldInfo.AllFieldInfos.Values.Where(s=>s.PacketType == PacketType.OSPFv3_HEADER || s.PacketType == PacketType.OSPFv3_LSA_HEADER || s.PacketType == PacketType.OSPFv3_LINK_LSA).Select(s=>s.Field).ToList()
                }
            },

            {
                PacketType.OSPFv3_INTRA_AREA_PREFIX_LSA,
                new PacketInfo()
                {
                    PacketType = PacketType.OSPFv3_INTRA_AREA_PREFIX_LSA,
                    AvaliableFields = FieldInfo.AllFieldInfos.Values.Where(s=>s.PacketType == PacketType.OSPFv3_HEADER || s.PacketType == PacketType.OSPFv3_LSA_HEADER || s.PacketType == PacketType.OSPFv3_INTRA_AREA_PREFIX_LSA).Select(s=>s.Field).ToList()
                }
            },

            //====================================================================================================================================
            {
                PacketType.ISIS_PDUHDR,
                new PacketInfo()
                {
                    PacketType = PacketType.ISIS_PDUHDR,
                    AvaliableFields = FieldInfo.AllFieldInfos.Values.Where(s=>s.PacketType == PacketType.ISIS_PDUHDR).Select(s=>s.Field).ToList()
                }
            },

            {
                PacketType.ISIS_LAN_HELLO,
                new PacketInfo()
                {
                    PacketType = PacketType.ISIS_LAN_HELLO,
                    AvaliableFields = FieldInfo.AllFieldInfos.Values.Where(s=>s.PacketType == PacketType.ISIS_PDUHDR || s.PacketType == PacketType.ISIS_LAN_HELLO).Select(s=>s.Field).ToList()
                }
            },

            {
                PacketType.ISIS_POINT_TO_POINT_HELLO,
                new PacketInfo()
                {
                    PacketType = PacketType.ISIS_POINT_TO_POINT_HELLO,
                    AvaliableFields = FieldInfo.AllFieldInfos.Values.Where(s=>s.PacketType == PacketType.ISIS_PDUHDR || s.PacketType == PacketType.ISIS_POINT_TO_POINT_HELLO).Select(s=>s.Field).ToList()
                }
            },

            {
                PacketType.ISIS_LSP,
                new PacketInfo()
                {
                    PacketType = PacketType.ISIS_LSP,
                    AvaliableFields = FieldInfo.AllFieldInfos.Values.Where(s=>s.PacketType == PacketType.ISIS_PDUHDR || s.PacketType == PacketType.ISIS_LSP).Select(s=>s.Field).ToList()
                }
            },

            {
                PacketType.ISIS_CSNP,
                new PacketInfo()
                {
                    PacketType = PacketType.ISIS_CSNP,
                    AvaliableFields = FieldInfo.AllFieldInfos.Values.Where(s=>s.PacketType == PacketType.ISIS_PDUHDR || s.PacketType == PacketType.ISIS_CSNP).Select(s=>s.Field).ToList()
                }
            },

            {
                PacketType.ISIS_PSNP,
                new PacketInfo()
                {
                    PacketType = PacketType.ISIS_PSNP,
                    AvaliableFields = FieldInfo.AllFieldInfos.Values.Where(s=>s.PacketType == PacketType.ISIS_PDUHDR || s.PacketType == PacketType.ISIS_PSNP).Select(s=>s.Field).ToList()
                }
            },

            {
                PacketType.ISIS_TLV,
                new PacketInfo()
                {
                    PacketType = PacketType.ISIS_TLV,
                    AvaliableFields = FieldInfo.AllFieldInfos.Values.Where(s=>s.PacketType == PacketType.ISIS_PDUHDR || s.PacketType == PacketType.ISIS_LAN_HELLO||s.PacketType == PacketType.ISIS_POINT_TO_POINT_HELLO||s.PacketType == PacketType.ISIS_LSP||s.PacketType == PacketType.ISIS_CSNP||s.PacketType == PacketType.ISIS_PSNP||s.PacketType == PacketType.ISIS_TLV).Select(s=>s.Field).ToList()
                }
            },
            //====================================================================================================================================

        };
    }

}
