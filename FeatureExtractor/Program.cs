﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeatureExtractor
{
    class Program
    {
        static void Main(string[] args)
        {
            FeatureReader reader = new FeatureReader();
            Extractor extractor = new Extractor();
            FeatureTransformer transformer = new FeatureTransformer();
            FeatureWriter writer = new FeatureWriter();
            writer.write(transformer.transform(extractor.extract(reader.readRequirements(args[0]))));
        }
    }
}
