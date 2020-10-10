using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Reflection;
using System.Runtime.Loader;
using System.Threading.Tasks;
using DynamicGateWay.DAL;
using DynamicGateWay.Interfaces;
using DynamicGateWay.models;
using Microsoft.Extensions.Logging;
namespace DynamicGateWay.imp {
    public class ImpService {
        private readonly ILogger<ImpService> _logger;
        private IDAL _dal;
        public ImpService (ILogger<ImpService> logger) {
            _logger = logger;
        }
        public ImpService () {

        }

        public Res MainRun (Req req) {

            if (!RequestValidatetion (req)) {
                throw new System.Exception ("Bed Request");
            }
            var a = GetResourceData (GetParams (req));
            _dal = loadDll (a.DllName);

            if (!_dal.RequestValidatetion (req)) { throw new System.Exception ("Bed Request"); }

            string res = _dal.CallToResource (req).Result;

            if (_dal.ResponseValidatetion (res)) { throw new System.Exception ("Bed Request"); }

            return _dal.BuildRespose (res);;
        }
        private bool RequestValidatetion (Req req) {
            return true;
        }
        private IDAL loadDll (string DllName) {

            Assembly asm = Assembly.LoadFrom (DllName);
            foreach (Type t in asm.GetExportedTypes ()) {
                Type tInterface = t.GetInterface ("Server.Interfaces.IDAL");
                if (tInterface != null && (t.Attributes & TypeAttributes.Abstract) !=
                    TypeAttributes.Abstract) {
                    return (IDAL) Activator.CreateInstance (t);
                }
            }
            throw new Exception ("dll does not exist");
        }
        private SqlParameter[] GetParams (Req req) {
            return new SqlParameter[] {
                new SqlParameter () {
                    ParameterName = "@Quantity",
                        Value = "value",
                        SqlDbType = SqlDbType.Int
                }
            };
        }
        private DistanationData GetResourceData (SqlParameter[] paramsData) {
            //make the connection to db, and return the content results
            //return the sp object
            DBDal dal = new DBDal ("connectionstring");
            var a = dal.ExecuteSPAsync (paramsData, "getData");
            if (a.Rows.Count > 0) {
                return new DistanationData () {
                    Url = a.Rows[0].ItemArray[0].ToString (),
                        Method = a.Rows[0].ItemArray[1].ToString (),
                        DllName = a.Rows[0].ItemArray[2].ToString (),
                        UseIntegrationCredentials = Convert.ToBoolean (a.Rows[0].ItemArray[3].ToString ()),
                };
            }
            throw new System.NotImplementedException ();
        }
        private Task<string> CallResource (Req req) {
            //here we after the the distanation and we call the acutely resource
            throw new System.NotImplementedException ();
        }
        private Res BuildRespose (string resFromDB) {
            //we build the response for the return type like soap or json 
            throw new System.NotImplementedException ();
        }

    }
}