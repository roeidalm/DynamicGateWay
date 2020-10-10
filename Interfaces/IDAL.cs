using System.Threading.Tasks;
using DynamicGateWay.models;

namespace DynamicGateWay.Interfaces {
    public interface IDAL {
        public bool RequestValidatetion (Req req);
        public Task<string> CallToResource (Req req);
        public bool ResponseValidatetion (string req);
        public Res BuildRespose (string req);
    }
}