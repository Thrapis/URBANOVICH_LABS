using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeauralNetwork
{
    public class NeuronLayer
    {
        public NeuronLayerType NeuronLayerType { get; set; }
        public List<Neuron> Neurons { get; set; }
        public double[] LastInputs { get; set; }

        public int NeuronsCount 
        { 
            get { return Neurons.Count; }
            private set { }
        }

        public NeuronLayer() { }

        public NeuronLayer(NeuronLayerType neuronLayerType, int neuronsCount, int lastLayerNeuronCount, Random rand)
        {
            NeuronLayerType = neuronLayerType;
            Neurons = new List<Neuron>();
            for (int i = 0; i < neuronsCount; i++)
                Neurons.Add(new Neuron(lastLayerNeuronCount, rand));
        }

        public double[] HandleInputs(double[] inputs)
        {
            List<double> output = new List<double>();

            if (inputs == null)
            {
                return null;
            }

            LastInputs = inputs.CopyArray();

            if (NeuronLayerType == NeuronLayerType.Input)
            {
                for (int i = 0; i < NeuronsCount; i++)
                    output.Add(Neurons[i].HandleInputs(new double[]{ inputs[i] }));
            }
            else
            {
                for (int i = 0; i < NeuronsCount; i++)
                    output.Add(Neurons[i].HandleInputs(inputs));
            }

            return output.ToArray();
        }

        public void SelfLearn(double learningRate)
        {
            if (NeuronLayerType == NeuronLayerType.Input)
                return;

            for (int i = 0; i < NeuronsCount; i++)
            {
                Neurons[i].SelfLearn(LastInputs, learningRate);
            }
        }

        public void ForceHebbLearn(double L)
        {
            if (NeuronLayerType == NeuronLayerType.Input)
                return;

            if (LastInputs == null)
            {
                Console.WriteLine("LastInputs == null");
                return;
            }

            for (int i = 0; i < NeuronsCount; i++)
            {
                Neurons[i].ForceHebbLearn(LastInputs, L);
            }
        }

        public double[] GetOutputs() { return Neurons.Select(t => t.LastOutput).ToArray(); }

        /*public void Learn(double[] error, double rate)
        {
            if (NeuronLayerType == NeuronLayerType.Input)
                return;

            for (int i = 0; i < NeuronsCount; i++)
            {
                Neurons[i].Learn(error[i], rate, LastInputs);
            }
        }*/

        /*public double[] GetError(double[] nextLayerError)
        {
            int lastLayerCount = Neurons[0].LastLayerWeights.Length;
            double[] preResult = new double[lastLayerCount];

            for (int i = 0; i < lastLayerCount; i++)
            {

                for (int j = 0; j < nextLayerError.Length; j++)
                {
                    Neuron nextNeuron = Neurons[j];
                    preResult[i] += nextNeuron.LastLayerWeights[i] * nextLayerError[j];
                }
                preResult[i] *= LastInputs[i].SigmoidDx();
            }

            return preResult;
        }*/
    }
}
