using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        [HttpGet]
        [Route("hi")]
        public string SayHi(string name)
        {
            return $"Hi,{name}!";
        }
        [HttpPost]
        [Route("hi2")]
        public string SayHi2(string name)
        {
            return $"Hi,{name}!";
        }
    }
}
