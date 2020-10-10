using System.Collections.Generic;
using DynamicGateWay.imp;
using DynamicGateWay.Interfaces;
using DynamicGateWay.models;

namespace DynamicGateWay {
    public class SampleService : IServiceRun {
        public IEnumerable<string> GetEnumListType () {
            var a = new List<string> () { "value1", "value2", "value3", "value4" };
            return a;
        }
        public Res Post (Req req) {
            ImpService imp = new ImpService ();
            return imp.MainRun (req);
        }
    }
}