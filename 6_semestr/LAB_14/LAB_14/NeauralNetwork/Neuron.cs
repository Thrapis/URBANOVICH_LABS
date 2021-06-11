using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeauralNetwork
{
    public class Neuron
    {
        public double[] LastLayerWeights { get; set; }
        public double LastOutput { get; set; }

        public Neuron() { }
        public Neuron(int lastLayerNeuronsCount, Random rand)
        {
            LastLayerWeights = new double[lastLayerNeuronsCount];

            for (int i = 0; i < lastLayerNeuronsCount; i++)
            {
                LastLayerWeights[i] = rand.NextDouble() - 0.5;
            }
        }

        public double HandleInputs(double[] inputs)
        {
            double sum = 0;

            if (LastLayerWeights.Length > 0)
                sum = inputs.ArrToArrMult(LastLayerWeights).Sum();
            else
                sum = inputs.Sum();

            LastOutput = Sign(sum);

            return Sign(sum);
        }

        public void SelfLearn(double[] lastInputs, double learningRate)
        {
            double[] delta = lastInputs.ArrToScalMult(LastOutput).ArrToScalMult(learningRate);
            LastLayerWeights = LastLayerWeights.ArrToArrSum(delta).Select(t => Math.Round(t)).ToArray();
        }

        public void ForceHebbLearn(double[] lastInputs, double L)
        {
            for (int i = 0; i < LastLayerWeights.Length; i++)
            {
                //LastLayerWeights[i] += lastInputs[i] * LastOutput; // правило Хэбба
                //LastLayerWeights[i] -= lastInputs[i] * LastOutput; // анти-правило Хэбба
                LastLayerWeights[i] += lastInputs[i]; // случайного блуждания
                LastLayerWeights[i] = CorrectWeight(LastLayerWeights[i], L);
            }
        }

        private double CorrectWeight(double weight, double L)
        {
            return Math.Abs(weight) > L ? Sign(weight) * L : weight;
        }

        private double Sign(double x)
        {
            return x <= 0 ? -1 : 1;

            /*if (x < 0)
                return -1;
            else if (x >= 0)
                return 1;
            else
                return 0;*/
        }

        private double G(double x, double y)
        {
            return Math.Abs(x) > y ? Sign(x) * y : x;
        }

        private double F(double x, double y)
        {
            return x == y ? 1 : 0;
        }

        private double Teta(double x)
        {
            return x >= 0 ? 1 : 0;
        }

        /*public void Learn(double error, double rate, double[] lastInputs)
        {
            double[] delta = lastInputs.ArrToScalMult(error).ArrToScalMult(rate);
            LastLayerWeights = LastLayerWeights.ArrToArrDif(delta);
        }*/
    }
}
