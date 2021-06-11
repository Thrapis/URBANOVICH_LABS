using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LAB_14.Services
{
	public class SynchroServer
	{
		public int GetPort { get; private set; }
		public int RandomSeed { get; set; }
		public bool Messages { get; set; }
		private Main Main;
		private CancellationTokenSource TokenSource = new CancellationTokenSource();
		

		public SynchroServer(int getPort, Main main, int randomSeed = 1234, bool messages = true)
		{
			GetPort = getPort;
			Main = main;
			RandomSeed = randomSeed;
			Messages = messages;
		}

		private void MakeSynchro(CancellationToken token)
		{
			byte[] sending;
			byte[] recving = new byte[1024];
			double[] rcvedArr;
			int bytes;
			string rcved;
			double rcvedTauRes = 1;
			double tauRes = -1;

			IPAddress address = IPAddress.Any;
			TcpListener listener = new TcpListener(address, GetPort);

			int counter = 0;
			listener.Start();
			while (true)
			{
				try
				{
					while (!listener.Pending())
					{
						Thread.Sleep(10);
						if (token.IsCancellationRequested)
							return;
					}

					TcpClient client = listener.AcceptTcpClient();
					NetworkStream stream = client.GetStream();

					Random random = new Random(RandomSeed);

					while (true)
					{
						bytes = stream.Read(recving, 0, recving.Length);
						rcved = Encoding.UTF8.GetString(recving, 0, bytes);
						if (Messages)
							Console.WriteLine($"Received tauA: {rcved}");

						tauRes = Main.PushArray(StringToArray(GenerateStringArray(Main.K * Main.N, random)));

						sending = Encoding.UTF8.GetBytes(tauRes.ToString());
						stream.Write(sending, 0, sending.Length);
						if (Messages)
							Console.WriteLine($"Sending tauB: {tauRes}");

						bytes = stream.Read(recving, 0, recving.Length);
						rcved = Encoding.UTF8.GetString(recving, 0, bytes);
						if (Messages)
							Console.WriteLine($"Received hash: {rcved}");
						if (Messages)
							Console.WriteLine($"Self     hash: {MD5.GetHash(Main.GetWeights())}");

						string ok = "FALSE";
						if (rcved == MD5.GetHash(Main.GetWeights()))
							ok = "TRUE";

						sending = Encoding.UTF8.GetBytes(ok.ToString());
						stream.Write(sending, 0, sending.Length);
						if (Messages)
							Console.WriteLine($"Sending ststus: {ok}");

						if (ok == "TRUE")
							break;

						if (tauRes == rcvedTauRes)
                        {
							Main.ForceTeach(tauRes, rcvedTauRes);
						}
						counter++;
					}

					stream.Close();
					client.Close();

					Console.WriteLine($"Self weights: {Main.GetWeights()}");
					Console.WriteLine($"Steps: {counter}");
					listener.Stop();
					return;
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex);
				}

			}
		}

		private string GenerateStringArray(int count, Random random)
        {
			string arr = "";
			for (int i = 0; i < count; i++)
			{
				arr += random.Next(0, 2) == 0 ? -1 : 1;
				if (i + 1 < count)
					arr += ';';
			}
			return arr;
		}

		private double[] StringToArray(string strArr)
		{
			return strArr.Split(';').Select(t => Convert.ToDouble(t)).ToArray();
		}

		public void Start()
		{
			Task task = new Task(() => MakeSynchro(TokenSource.Token));
			task.Start();
		}

		public void Stop()
		{
			TokenSource.Cancel();
		}
	}
}
