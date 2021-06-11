using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;

namespace NeauralNetwork
{
	public class NeuralNetwork
	{
		public List<NeuronLayer> NeuronLayers { get; set; }
		public Topology Topology { get; set; }

        public NeuralNetwork() { }

		public NeuralNetwork(Topology topology)
		{
            Random rand = new Random();
			Topology = topology;
			NeuronLayers = new List<NeuronLayer>();

			NeuronLayer inputLayer = new NeuronLayer(NeuronLayerType.Input, topology.Inputs, 0, rand);
			NeuronLayers.Add(inputLayer);

			for (int i = 0; i < topology.HiddenLayers.Length; i++)
            {
				NeuronLayer hiddenLayer;
				if (i - 1 >= 0)
					hiddenLayer = new NeuronLayer(NeuronLayerType.Hidden, topology.HiddenLayers[i], topology.HiddenLayers[i - 1], rand);
				else
					hiddenLayer = new NeuronLayer(NeuronLayerType.Hidden, topology.HiddenLayers[i], topology.Inputs, rand);
				NeuronLayers.Add(hiddenLayer);
			}

			NeuronLayer outputLayer;
			if (topology.HiddenLayers.Length > 0)
				outputLayer = new NeuronLayer(NeuronLayerType.Output, topology.Outputs, topology.HiddenLayers.Last(), rand);
			else
				outputLayer = new NeuronLayer(NeuronLayerType.Output, topology.Outputs, topology.Inputs, rand);
			NeuronLayers.Add(outputLayer);
		}

		public double[] Predict(params double[] inputSignals)
		{
			double[] nextInputs = inputSignals.CopyArray();
            double[] result = null;

			for (int i = 0; i < NeuronLayers.Count; i++)
            {
				if (NeuronLayers[i].NeuronLayerType == NeuronLayerType.Output)
                {
					result = NeuronLayers[i].HandleInputs(nextInputs);
					break;
				}
                else
                {
					nextInputs = NeuronLayers[i].HandleInputs(nextInputs);
                }
            }

			return result;
		}

        public void SelfLearn(List<double[]> inputs, int epochs)
        {
            int epoch = 0;

            do
            {
                for (int inp = 0; inp < inputs.Count; inp++)
                {
                    Predict(inputs[inp]);
                    for (int i = NeuronLayers.Count - 1; i >= 1; i--)
                    {
                        NeuronLayers[i].SelfLearn(Topology.LearningRate);
                    }
                }

                epoch++;

            } while (epoch < epochs);
        }

        public void SelfLearn(double[] input, int epochs)
        {
            int epoch = 0;

            do
            {
                Predict(input);
                for (int i = NeuronLayers.Count - 1; i >= 1; i--)
                {
                    NeuronLayers[i].SelfLearn(Topology.LearningRate);
                }

                epoch++;

            } while (epoch < epochs);
        }

        public void ForceHebbLearn(double L)
        {
            for (int i = NeuronLayers.Count - 1; i >= 1; i--)
            {
                NeuronLayers[i].ForceHebbLearn(L);
            }
        }

        /*public double TeacherLearn(double[] expected, double[] inputs, int epoch = 1)
        {
            var error = 0.0;

            for (int i = 0; i < epoch; i++)
            {
                var outputs = expected;

                error += Backpropagation(outputs, inputs);
            }

            var result = error / epoch;
            return result;
        }

        public double TeacherLearn(List<double[]> expected, List<double[]> inputs, double eps = 1e-7, int epochs = 1)
        {
            int epoch = 1;

            double error;

            do
            {
                error = 0;
                for (int i = 0; i < expected.Count; i++)
                {
                    double[] output = expected[i];
                    double[] input = inputs[i];

                    error += Backpropagation(output, input);
                }

                Console.WriteLine("epoch: {0}, error: {1}", epoch, error);

                epoch++;
            } while (epoch <= epochs && error > eps);

            var result = error / epoch;
            return result;
        }

        private double Backpropagation(double[] expected, params double[] inputs)
        {
            List<double[]> errors = new List<double[]>();
            double[] actual = Predict(inputs);
            double[] difference = actual.ArrToArrDif(expected);
            double[] error = difference.ArrToArrMult(actual.SigmoidDx());
            errors.Add(error);

            NeuronLayers.Last().Learn(error, Topology.LearningRate);

            for (int j = NeuronLayers.Count - 2; j >= 0; j--)
            {
                NeuronLayer nextLayer = NeuronLayers[j + 1];

                errors.Add(nextLayer.GetError(error));
            }

            errors.Reverse();

            for (int j = NeuronLayers.Count - 1; j >= 0; j--)
            {
                NeuronLayer layer = NeuronLayers[j];

                layer.Learn(errors[j], Topology.LearningRate);
            }

            double result = difference.Pow(2).Sum();
            return result;
        }*/

        public void Save(string path)
        {
            string serialized = JsonSerializer.Serialize(this);
            File.WriteAllText(path, serialized);
        }

        public static NeuralNetwork Open(string path)
        {
            string serialized = File.ReadAllText(path);
            NeuralNetwork neuralNetwork = JsonSerializer.Deserialize<NeuralNetwork>(serialized);
            return neuralNetwork;
        }
    }
}
