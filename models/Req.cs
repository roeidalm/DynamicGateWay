using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DynamicGateWay.models {
    [DataContract]
    public class Req {
        [DataMember]
        public string HeaderData { get; set; }

        [DataMember]
        public int ServiceID { get; set; }

        [DataMember]
        public string permissionPrevilage { get; set; }

        [DataMember]
        public List<Params> DataParams { get; set; }
    }

    [DataContract]
    public class Params {
        [DataMember]
        public string KeyName { get; set; }

        [DataMember]
        public string KeyValue { get; set; }

        [DataMember]
        public string KeyType { get; set; }
    }
}