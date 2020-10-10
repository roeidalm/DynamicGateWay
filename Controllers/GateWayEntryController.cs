using System.Collections.Generic;
using DynamicGateWay.imp;
using DynamicGateWay.Interfaces;
using DynamicGateWay.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DynamicGateWay.Controllers {
    [ApiController]
    [Route ("[controller]")]
    public class GateWayEntryController : ControllerBase, IServiceRun {
        private readonly ILogger<WeatherForecastController> _logger;
        public GateWayEntryController (ILogger<WeatherForecastController> logger) {
            _logger = logger;
        }

        [HttpPost]
        public Res Post (Req req) {
            ImpService imp = new ImpService ();
            return imp.MainRun (req);
        }

        [HttpGet ("/[controller]/GetEnumListType")]
        public IEnumerable<string> GetEnumListType () {
            var a = new List<string> () { "value1", "value2", "value3", "value4" };
            return a;
        }
    }
}