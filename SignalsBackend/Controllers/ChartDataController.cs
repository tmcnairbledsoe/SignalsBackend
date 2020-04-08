using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignalsBackend.Data;
using SignalsBackend.Models;

namespace SignalsBackend.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ChartDataController : ControllerBase
    {

        // GET: api/ChartData
        [HttpGet]
        public async Task<IActionResult> GetChartData()
        {
            List<Trade> trades = BitcoinData.Instance.GetData;
            return Ok(trades);
        }
    }
}