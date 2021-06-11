using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_12
{
	public static class LSB
	{
		private static string ToEditableByte(byte theByte)
		{
			return new string(Convert.ToString(theByte, 2).PadLeft(8, '0').Reverse().ToArray());
		}

		private static byte FromEditableByte(string editableByte)
		{
			return Convert.ToByte(new string(editableByte.Reverse().ToArray()), 2);
		}

		public static Bitmap GetLSBImage(Bitmap bitmap, IProgressBar progressBar)
		{
			int height = bitmap.Height;
			int width = bitmap.Width;

			double maxProgress = height * width;

			Bitmap newBitmap = new Bitmap(bitmap, new Size(width, height));

			byte[,] red = new byte[height, width];
			byte[,] green = new byte[height, width];
			byte[,] blue = new byte[height, width];

			for (int i = 0; i < height; i++)
			{
				for (int j = 0; j < width; j++)
				{
					if (ToEditableByte(bitmap.GetPixel(j, i).R)[0] == '1')
						red[i, j] = 255;
					else
						red[i, j] = 0;

					if (ToEditableByte(bitmap.GetPixel(j, i).G)[0] == '1')
						green[i, j] = 255;
					else
						green[i, j] = 0;

					if (ToEditableByte(bitmap.GetPixel(j, i).B)[0] == '1')
						blue[i, j] = 255;
					else
						blue[i, j] = 0;

					newBitmap.SetPixel(j, i, Color.FromArgb(red[i, j], green[i, j], blue[i, j]));

					progressBar.ProgressChanged(i * width + j, maxProgress);
				}
			}

			progressBar.ProgressChanged(100);

			return newBitmap;
		}

		public static (Bitmap, int) EncodeText(Bitmap bitmap, string text, byte lesserBits, Spectrum spectrum, IProgressBar progressBar)
		{
			if (lesserBits < 1 || lesserBits > 8)
				throw new Exception("Lesser Bits");

			int height = bitmap.Height;
			int width = bitmap.Width;

			double maxProgress = height * width;

			Bitmap newBitmap = new Bitmap(bitmap, new Size(width, height));

			byte[,] red = new byte[height, width];
			byte[,] green = new byte[height, width];
			byte[,] blue = new byte[height, width];

			string bitsArray = "";

			for (int i = 0; i < text.Length; i++)
			{
				bitsArray += ToEditableByte(Encoding.GetEncoding(1251).GetBytes(text[i].ToString())[0]);
			}

			int bitsCounter = 0;

			Random rand = new Random();

			for (int i = 0; i < height; i++)
			{
				for (int j = 0; j < width; j++)
				{
					Color pixel = bitmap.GetPixel(j, i);
					switch (spectrum)
					{
						case Spectrum.Red:
							StringBuilder redstr = new StringBuilder(ToEditableByte(pixel.R));
							for (int b = 0; b < lesserBits; b++)
							{
								if (bitsCounter < bitsArray.Length)
									redstr[b] = bitsArray[bitsCounter];
								else
									redstr[b] = rand.Next(0, 2) == 1 ? '1' : '0';
								bitsCounter++;
							}
							red[i, j] = FromEditableByte(redstr.ToString());
							green[i, j] = pixel.G;
							blue[i, j] = pixel.B;
							break;
						case Spectrum.Green:
							StringBuilder greenstr = new StringBuilder(ToEditableByte(pixel.G));
							for (int b = 0; b < lesserBits; b++)
							{
								if (bitsCounter < bitsArray.Length)
									greenstr[b] = bitsArray[bitsCounter];
								else
									greenstr[b] = rand.Next(0, 2) == 1 ? '1' : '0';
								bitsCounter++;
							}
							green[i, j] = FromEditableByte(greenstr.ToString());
							red[i, j] = pixel.R;
							blue[i, j] = pixel.B;
							break;
						case Spectrum.Blue:
							StringBuilder bluestr = new StringBuilder(ToEditableByte(pixel.B));
							for (int b = 0; b < lesserBits; b++)
							{
								if (bitsCounter < bitsArray.Length)
									bluestr[b] = bitsArray[bitsCounter];
								else
									bluestr[b] = rand.Next(0, 2) == 1 ? '1' : '0';
								bitsCounter++;
							}
							blue[i, j] = FromEditableByte(bluestr.ToString());
							red[i, j] = pixel.R;
							green[i, j] = pixel.G;
							break;
						case Spectrum.All:
							StringBuilder redstr_a = new StringBuilder(ToEditableByte(pixel.R));
							for (int b = 0; b < lesserBits; b++)
							{
								if (bitsCounter < bitsArray.Length)
									redstr_a[b] = bitsArray[bitsCounter];
								else
									redstr_a[b] = rand.Next(0, 2) == 1 ? '1' : '0';
								bitsCounter++;
							}
							red[i, j] = FromEditableByte(redstr_a.ToString());
							StringBuilder greenstr_a = new StringBuilder(ToEditableByte(pixel.G));
							for (int b = 0; b < lesserBits; b++)
							{
								if (bitsCounter < bitsArray.Length)
									greenstr_a[b] = bitsArray[bitsCounter];
								else
									greenstr_a[b] = rand.Next(0, 2) == 1 ? '1' : '0';
								bitsCounter++;
							}
							green[i, j] = FromEditableByte(greenstr_a.ToString());
							StringBuilder bluestr_a = new StringBuilder(ToEditableByte(pixel.B));
							for (int b = 0; b < lesserBits; b++)
							{
								if (bitsCounter < bitsArray.Length)
									bluestr_a[b] = bitsArray[bitsCounter];
								else
									bluestr_a[b] = rand.Next(0, 2) == 1 ? '1' : '0';
								bitsCounter++;
							}
							blue[i, j] = FromEditableByte(bluestr_a.ToString());
							break;
					}

					newBitmap.SetPixel(j, i, Color.FromArgb(red[i, j], green[i, j], blue[i, j]));

					progressBar.ProgressChanged(i * width + j, maxProgress);
				}
			}

			progressBar.ProgressChanged(100);

			return (newBitmap, bitsArray.Length / 8);
		}

		public static string DecodeText(Bitmap bitmap, int key, byte lesserBits, Spectrum spectrum, IProgressBar progressBar)
		{
			if (lesserBits < 1 || lesserBits > 8)
				throw new Exception("Lesser Bits");

			int height = bitmap.Height;
			int width = bitmap.Width;

			int bitsCounter = 0;
			string bitsArray = "";

			string result = "";

			for (int i = 0; i < height; i++)
			{
				for (int j = 0; j < width; j++)
				{
					Color pixel = bitmap.GetPixel(j, i);
					switch (spectrum)
					{
						case Spectrum.Red:
							string redstr = ToEditableByte(pixel.R);
							for (int b = 0; b < lesserBits; b++)
							{
								if (bitsCounter < key * 8)
									bitsArray += redstr[b];
								else
									break;
								bitsCounter++;
							}
							break;
						case Spectrum.Green:
							string greenstr = ToEditableByte(pixel.G);
							for (int b = 0; b < lesserBits; b++)
							{
								if (bitsCounter < key * 8)
									bitsArray += greenstr[b];
								else
									break;
								bitsCounter++;
							}
							break;
						case Spectrum.Blue:
							string bluestr = ToEditableByte(pixel.B);
							for (int b = 0; b < lesserBits; b++)
							{
								if (bitsCounter < key * 8)
									bitsArray += bluestr[b];
								else
									break;
								bitsCounter++;
							}
							break;
						case Spectrum.All:
							string redstr_a = ToEditableByte(pixel.R);
							for (int b = 0; b < lesserBits; b++)
							{
								if (bitsCounter < key * 8)
									bitsArray += redstr_a[b];
								else
									break;
								bitsCounter++;
							}
							string greenstr_a = ToEditableByte(pixel.G);
							for (int b = 0; b < lesserBits; b++)
							{
								if (bitsCounter < key * 8)
									bitsArray += greenstr_a[b];
								else
									break;
								bitsCounter++;
							}
							string bluestr_a = ToEditableByte(pixel.B);
							for (int b = 0; b < lesserBits; b++)
							{
								if (bitsCounter < key * 8)
									bitsArray += bluestr_a[b];
								else
									break;
								bitsCounter++;
							}
							break;
					}

					progressBar.ProgressChanged(bitsCounter, key * 8);

					if (bitsCounter >= key * 8)
                    {
						progressBar.ProgressChanged(100);

						for (int octo = 0; octo < key; octo++)
                        {
							if (bitsArray.Length - octo * 8 < 8)
								break;

							byte[] symb = new byte[] { FromEditableByte(bitsArray.Substring(octo * 8, 8)) };
							result += Encoding.GetEncoding(1251).GetString(symb);
                        }

						return result;
					}
				}
			}

			progressBar.ProgressChanged(100);

			for (int octo = 0; octo < key; octo++)
			{
				if (bitsArray.Length - octo * 8 < 8)
					break;

				byte[] symb = new byte[] { FromEditableByte(bitsArray.Substring(octo * 8, 8)) };
				result += Encoding.GetEncoding(1251).GetString(symb);
			}

			return result;
		}
	}
}
