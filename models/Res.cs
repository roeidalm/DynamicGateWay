using System.Runtime.Serialization;

namespace DynamicGateWay.models {
    [DataContract]
    public class Res {
        [DataMember]
        public string HeaderData { get; set; }

        [DataMember]
        public string Results { get; set; }

    }
}