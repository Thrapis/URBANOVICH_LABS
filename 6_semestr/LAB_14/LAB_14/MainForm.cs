using LAB_14.Services;
using NeauralNetwork;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB_14
{
	public partial class Main : Form
	{
		NeuralNetwork[] NeuralNetworks;
		SynchroServer SynchroServer;
		SynchroClient SynchroClient;
		public int K = 4;
		public int N = 3;
		public double L = 4;

		public Main()
		{
			InitializeComponent();

			Topology topology = new Topology(K, 1);
			topology.LearningRate = 1;

			NeuralNetworks = new NeuralNetwork[N];
			for (int i = 0; i < N; i++)
				NeuralNetworks[i] = new NeuralNetwork(topology);

			/*SynchroClient = new SynchroServer(2000, this, 1111, false);
			SynchroServer = new SynchroClient("localhost", 2000, this, 1111, false);*/

			//string ch = Console.ReadLine();
			/*if (ch == "1")
				SynchroClient.Start();
			else
				SynchroServer.Start();*/

		}

		private string GetArray(double[] array)
		{
			string result = "[ ";

			for (int i = 0; i < array.Length; i++)
			{
				result += Math.Round(array[i], 2) + "  ";
			}

			result += "]";

			return result;
		}

		private double[] Cut(double[] arr, int fromIndex, int count)
        {
			double[] newArr = new double[count];
			for (int i = 0; i < count; i++)
            {
				newArr[i] = arr[fromIndex + i];
            }
			return newArr;
        }

		public double PushArray(double[] arrays)
        {
			double glob_res = 1;

			for (int i = 0; i < N; i++) 
			{
				glob_res *= NeuralNetworks[i].Predict(Cut(arrays, i * K, K))[0];
			}

			return glob_res;
		}

		public void SetValues(object sender, EventArgs e)
        {
			try
			{
				WeightsBox.Text = GetWeights();

				string array = "";
				for (int i = 0; i < N; i++)
				{
					double[] inputs = NeuralNetworks[i].NeuronLayers[0].LastInputs;
					for (int j = 0; j < inputs.Length; j++)
                    {
						array += inputs[j] + " ";
                    }
					
				}
				ArrayBox.Text = array;
			}
			catch (Exception) { }
		}

		public void ForceTeach(double tauA, double tauB)
        {
			for (int i = 0; i < N; i++)
			{
				if (NeuralNetworks[i].NeuronLayers.Last().Neurons[0].LastOutput == tauA)
					NeuralNetworks[i].ForceHebbLearn(L);
			}

		}

		public string GetWeights()
        {
			List<double> weights = new List<double>();

			for (int i = 0; i < N; i++)
			{
				weights.AddRange(NeuralNetworks[i].NeuronLayers.Last().Neurons[0].LastLayerWeights);
			}

			string preparedWeightsString = "";
			for (int i = 0; i < weights.Count; i++)
			{
				preparedWeightsString += Math.Round(weights[i], 2) + "  ";
			}

			return preparedWeightsString;
		}

		public string GetArray(Random rand)
        {
			string arr = "";
			for (int i = 0; i < 4; i++)
            {
				arr += rand.Next(0, 2) == 0 ? -1 : 1;
				if (i + 1 < 4)
					arr += ';';
            }
			return arr;
        }

        private void ServerBtn_Click(object sender, EventArgs e)
        {
			SynchroServer = new SynchroServer((int)PortBox.Value, this, (int)SeedBox.Value, MessagesChekBox.Checked);
			SynchroServer.Start();
		}

        private void ClientBtn_Click(object sender, EventArgs e)
        {
			SynchroClient = new SynchroClient(AddressBox.Text, (int)PortBox.Value, this, (int)SeedBox.Value, MessagesChekBox.Checked);
			SynchroClient.Start();
		}
    }
}
