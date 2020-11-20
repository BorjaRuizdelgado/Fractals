using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using MandelbrotSet;
using MandelbrotSet.ProgramLogic;
using Microsoft.AspNetCore.Mvc;

namespace JuliaSet.Controllers
{
    [ApiController]
    [Route("/mandelbort")]
    public class MandelbrotController : ControllerBase
    {
        public MandelbrotController()
        {
        }

        [HttpGet]
        public IEnumerable<Mandelbort> Get()
        {
            MandelbrotCalculator calc = new MandelbrotCalculator();
            Mandelbort mandelbrot = new Mandelbort();
            mandelbrot.Result = "hola";
            return Enumerable.Range(1, 1).Select(index => mandelbrot).ToArray();
        }
    }
}
