using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent.Responses
{
    public class AllCpuPercentileMetricsResponse
    {
        public List<CpuPercentileMetricDto> Metrics { get; set; }
    }
    public class CpuPercentileMetricDto
    {
        public TimeSpan Time { get; set; }
        public int Value { get; set; }
        public int Id { get; set; }
    }
}

