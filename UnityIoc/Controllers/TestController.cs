using System.Collections.Generic;
using System.Web.Http;
using Services;

namespace UnityIoc.Controllers
{
    [System.Web.Http.RoutePrefix("api/test")]
    public class TestController : ApiController
    {
        private readonly ITestService _testService;

        public TestController(ITestService testService)
        {
            _testService = testService;
        }

        public IEnumerable<string> Get()
        {
            return _testService.GetTestValues();
        }

        [Route("value/{key}")]
        [HttpGet]
        public string Value(string key)
        {
            return _testService.GetValue(key);
        }

        [Route("testme")]
        [HttpGet]
        public TestMeModel TestMe()
        {
            return new TestMeModel
            {
                A = "aaaa",
                B = "xklslskd"
            };
        }
    }

    public class TestMeModel
    {
        public string A { get; set; }
        public string B { get; set; }
    }
}
