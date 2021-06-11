using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeauralNetwork
{
    public class Topology
    {
        public int Inputs { get; set; }
        public int[] HiddenLayers { get; set; }
        public int Outputs { get; set; }
        public double LearningRate { get; set; }

        public Topology() { }
        public Topology(int inputs, int outputs, params int[] hiddenLayers)
        {
            Inputs = inputs;
            Outputs = outputs;
            HiddenLayers = hiddenLayers;
            LearningRate = 1;
        }
    }
}
