using System.Runtime.Serialization;

namespace JF.Common.Libary.JEnum
{
    [DataContract]
    [KnownType(typeof(EnumInfo))]
    public class EnumInfo
    {
        [DataMember]
        public string EnumName { get; set; }

        [DataMember]
        public string AttriName { get; set; }

        [DataMember]
        public string Key { get; set; }

        [DataMember]
        public int Value { get; set; }

    }
}