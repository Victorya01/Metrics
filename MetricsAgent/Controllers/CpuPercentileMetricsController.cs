using AutoMapper;
using MetricsAgent.DAL.Models;
using MetricsAgent.Repository;
using MetricsAgent.Requests;
using MetricsAgent.Responses;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent.Controllers
{
    
    
        [Route("api/metrics/cpu/from/{fromTime}/to/{toTime}/percentiles/{percentile}")]
        [ApiController]
        public class CpuPercentileMetricsController : ControllerBase
        {
            private ICpuPercentileMetricsRepository repository;
            private readonly IMapper mapper;

        public CpuPercentileMetricsController(ICpuPercentileMetricsRepository repository)
            {
                this.repository = repository;
                this.mapper = mapper;
        }

            [HttpPost("create")]
            public IActionResult Create([FromBody] CpuPercentileMetricCreateRequest request)
            {
                repository.Create(new CpuPercentileMetrics
                {
                    Time = request.Time,
                    Value = request.Value
                });

                return Ok();
            }
        [HttpGet("all")]
        public IActionResult GetAll()
        {
            IList<CpuPercentileMetrics> metrics = repository.GetAll();

            var response = new AllCpuPercentileMetricsResponse()
            {
                Metrics = new List<CpuPercentileMetricDto>()
            };

            foreach (var metric in metrics)
            {
                response.Metrics.Add(mapper.Map<CpuPercentileMetricDto>(metric));
            }

            return Ok(response);
        }

        [HttpGet("agent/{agentId}/from/{fromTime}/to/{toTime}")]
            public IActionResult GetMetricsFromAgent([FromRoute] int agentId, [FromRoute] TimeSpan fromTime, [FromRoute] TimeSpan toTime)
            {
                return Ok();
            }

            [HttpGet("agent/{agentId}/from/{fromTime}/to/{toTime}/percentiles/{percentile}")]
            public IActionResult GetMetricsByPercentileFromAgent([FromRoute] int agentId, [FromRoute] TimeSpan fromTime, [FromRoute] TimeSpan toTime)
            {
                return Ok();
            }

            [HttpGet("cluster/from/{fromTime}/to/{toTime}")]
            public IActionResult GetMetricsFromAllCluster([FromRoute] TimeSpan fromTime, [FromRoute] TimeSpan toTime)
            {
                return Ok();
            }

            [HttpGet("cluster/from/{fromTime}/to/{toTime}/percentiles/{percentile}")]
            public IActionResult GetMetricsByPercentileFromAllCluster([FromRoute] TimeSpan fromTime, [FromRoute] TimeSpan toTime,
                [FromRoute] Percentile percentile)
            {
                return Ok();
            }
        [HttpGet("sql-test")]
        public IActionResult TryToSqlLite()
        {
            string cs = "Data Source=:memory:";
            string stm = "SELECT SQLITE_VERSION()";

            using (var con = new SQLiteConnection(cs))
            {
                con.Open();

                using var cmd = new SQLiteCommand(stm, con);
                string version = cmd.ExecuteScalar().ToString();

                return Ok(version);
            }
        }

    }

}
