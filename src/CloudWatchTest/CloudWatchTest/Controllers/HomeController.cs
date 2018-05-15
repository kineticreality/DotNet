using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Amazon.CloudWatch;
using Amazon.CloudWatch.Model;
using Amazon.Runtime;
using Microsoft.AspNetCore.Mvc;
using CloudWatchTest.Models;

namespace CloudWatchTest.Controllers
{
    public class HomeController : Controller
    {
        IAmazonCloudWatch CloudwatchClient { get; set; }
        IAmazonService AmazonService { get; set; }

        public HomeController(IAmazonCloudWatch cloudwatchClient)
        {
            this.CloudwatchClient = cloudwatchClient;

            var dimension = new Dimension
            {
                Name = "Desktop Machine Metrics",
                Value = "Virtual Desktop Machine Usage"
            };

            var metric1 = new MetricDatum
            {
                Dimensions = new List<Dimension>(),
                MetricName = "Desktop Machines Online",
                StatisticValues = new StatisticSet(),
                Timestamp = DateTime.Today,
                Unit = StandardUnit.Count,
                Value = 14
            };

            var metric2 = new MetricDatum
            {
                Dimensions = new List<Dimension>(),
                MetricName = "Desktop Machines Offline",
                StatisticValues = new StatisticSet(),
                Timestamp = DateTime.Today,
                Unit = StandardUnit.Count,
                Value = 7
            };

            var metric3 = new MetricDatum
            {
                Dimensions = new List<Dimension>(),
                MetricName = "Desktop Machines Online",
                StatisticValues = new StatisticSet(),
                Timestamp = DateTime.Today,
                Unit = StandardUnit.Count,
                Value = 12
            };

            var metric4 = new MetricDatum
            {
                Dimensions = new List<Dimension>(),
                MetricName = "Desktop Machines Offline",
                StatisticValues = new StatisticSet(),
                Timestamp = DateTime.Today,
                Unit = StandardUnit.Count,
                Value = 9
            };

            var request = new PutMetricDataRequest
            {
                MetricData = new List<MetricDatum>()
                {
                    metric1,
                    metric2,
                    metric3,
                    metric4
                },
                Namespace = "Example.com Custom Metrics"
            };

            cloudwatchClient.PutMetricDataAsync(request).GetAwaiter().GetResult();
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
