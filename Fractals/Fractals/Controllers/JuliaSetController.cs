using System;
using System.Collections.Generic;
using System.Linq;
using JuliaSet;
using JuliaSet.ProgramLogic;
using Microsoft.AspNetCore.Mvc;

namespace JuliaSetController.Controllers
{
    [ApiController]
    [Route("/juliaset")]
    public class JuliaSetController : ControllerBase
    {
        public JuliaSetController()
        {
        }

        [HttpGet]
        public IEnumerable<Julia> Get()
        {
            JuliaSetCalculator calc = new JuliaSetCalculator();
            Julia julia = new Julia();
            julia.Result = "hola";
            return Enumerable.Range(1, 1).Select(index => julia).ToArray(); ;
        }
    }
}
