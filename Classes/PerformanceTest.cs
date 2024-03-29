﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MathNet.Numerics;

namespace Blazor_WebAssembly_StatisticsAndML_DotNet7
{
    public class PerformanceTest
    {
        string fullName = string.Empty;

        public int ID { get; set; }

        public string? DistributionName { get; set; }

        public int TrialsNumber { get; set; }

        public int SamplesNumber { get; set; }

        public double TestDuration { get; set; }

        public double TakeSamples()
        {
            var dateTimeElapsed = 0.0;
            var dateTime = DateTime.Now;

            //IEnumerable<int> generatedSamplesEnumerable = Enumerable.Empty<int>();
            //IEnumerable<double> generatedSamplesDoubleEnumerable = Enumerable.Empty<double>();

            if (this.DistributionName == "Binomial")
            {
                fullName = $"{DistributionName}-Samples:{SamplesNumber}-Trials:{TrialsNumber}";

                var binomaial = new MathNet.Numerics.Distributions.Binomial(0.5, this.TrialsNumber);
                var generatedsamples = binomaial.Samples().Take(SamplesNumber).ToArray();

                //generatedSamplesEnumerable = binomaial.Samples().Take(SamplesNumber);
                //foreach (var item in generatedSamplesEnumerable)
                //{
                //    var test = item;
                //}
            }
            else if (this.DistributionName == "Geometric")
            {
                fullName = $"{DistributionName}-Samples:{SamplesNumber}";

                var geometric = new MathNet.Numerics.Distributions.Geometric(0.5);
                var generatedsamples = geometric.Samples().Take(SamplesNumber).ToArray();

                //generatedSamplesEnumerable = geometric.Samples().Take(SamplesNumber);
                //foreach (var item in generatedSamplesEnumerable)
                //{
                //    var test = item;
                //}
            }
            else if (this.DistributionName == "Poisson")
            {
                fullName = $"{DistributionName}-Samples:{SamplesNumber}";

                var poisson = new MathNet.Numerics.Distributions.Poisson(0.5);
                var generatedsamples = poisson.Samples().Take(SamplesNumber).ToArray();

                //generatedSamplesEnumerable = poisson.Samples().Take(SamplesNumber);
                //foreach (var item in generatedSamplesEnumerable)
                //{
                //    var test = item;
                //}
            }
            else if (this.DistributionName == "Normal")
            {
                fullName = $"{DistributionName}-Samples:{SamplesNumber}";

                var normal = new MathNet.Numerics.Distributions.Normal(0.5, 2);
                var generatedsamples = normal.Samples().Take(SamplesNumber).ToArray();

                //generatedSamplesDoubleEnumerable = normal.Samples().Take(SamplesNumber);
                //foreach(var item in generatedSamplesDoubleEnumerable)
                //{
                //    var test = item;
                //}
            }

            dateTimeElapsed = (DateTime.Now - dateTime).TotalMilliseconds;
            return dateTimeElapsed;
        }

        public string GetTestName()
        {
            return fullName;
        }
    }
}
