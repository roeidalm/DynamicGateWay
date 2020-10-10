using System.Collections;
using System.Collections.Generic;
using System.ServiceModel;
using DynamicGateWay.models;

namespace DynamicGateWay.Interfaces {

    [ServiceContract]
    public interface IServiceRun {
        [OperationContract]
        Res Post (Req req);
        [OperationContract]
        IEnumerable<string> GetEnumListType ();
    }
}