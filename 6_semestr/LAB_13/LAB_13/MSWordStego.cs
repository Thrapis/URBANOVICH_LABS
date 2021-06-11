using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using NPOI.XWPF.UserModel;
using NPOI.XWPF.Extractor;
using Xceed.Words.NET;

namespace LAB_13
{
	public static class MSWordStego
	{
		private static string ToEditableByte(byte theByte)
		{
			return new string(Convert.ToString(theByte, 2).PadLeft(8, '0').Reverse().ToArray());
		}

		private static byte FromEditableByte(string editableByte)
		{
			return Convert.ToByte(new string(editableByte.Reverse().ToArray()), 2);
		}

		private static int NthIndexOf(this string str, char c, int nth)
		{
			int match = 0;
			int index = str.IndexOf(c, 0);

			while (nth != match && index != -1)
			{
				index = str.IndexOf(c, index + 1);
				match++;
			}

			return index;
		}

		public static int ClearFromNoise(DocX document)
		{
			int lastSpaces = -1;
			int spaces = 0;

			while (lastSpaces != spaces)
			{
				lastSpaces = spaces;
				spaces = 0;
				foreach (var paragraph in document.Paragraphs)
				{
					foreach (var element in paragraph.Xml.Elements())
					{
						if (element.Name.LocalName == "r")
						{
							foreach (var subelement in element.Elements())
							{
								if (subelement.Name.LocalName == "t")
								{
									subelement.Value = subelement.Value.Replace("  ", " ");
									spaces += subelement.Value.Where(t => t == ' ').Count();
								}
							}
						}
					}
				}
			}

			return lastSpaces;
		}

		public static string GetText(DocX document)
        {
			string text = "";

			foreach (var paragraph in document.Paragraphs)
			{
				foreach (var element in paragraph.Xml.Elements())
				{
					if (element.Name.LocalName == "r")
					{
						foreach (var subelement in element.Elements())
						{
							if (subelement.Name.LocalName == "t")
							{
								text += subelement.Value + "\r\n";
							}
						}
					}
				}
			}

			return text;
		}

		public static (DocX, int) EncodeText(DocX document, string text)
		{
			DocX doc = (DocX)document.Copy();

			string bitsArray = "";

			for (int i = 0; i < text.Length; i++)
			{
				bitsArray += ToEditableByte(Encoding.GetEncoding(1251).GetBytes(text[i].ToString())[0]);
			}

			int bitsCounter = 0;

			int canBeEncoded = ClearFromNoise(doc);

			foreach (var paragraph in doc.Paragraphs)
			{
				foreach (var element in paragraph.Xml.Elements())
				{
					if (element.Name.LocalName == "r")
					{
						foreach (var subelement in element.Elements())
						{
							if (subelement.Name.LocalName == "t")
							{
								int offset = 0;
								int spaces = subelement.Value.Where(t => t == ' ').Count();

								string builder = subelement.Value;
								for (int i = 0; i < spaces; i++)
                                {
									if (bitsCounter >= bitsArray.Length)
										return (doc, bitsCounter / 8);

									int index = builder.NthIndexOf(' ', i + offset);

									if (bitsArray[bitsCounter] == '1')
                                    {
										string start = builder.Substring(0, index);
										string end = builder.Substring(index, builder.Length - index);

										builder = start + " " + end;
										offset++;
									}	
									bitsCounter++;
                                }
								subelement.Value = builder;
							}
						}
					}
				}
			}
			return (doc, bitsCounter / 8);
		}

		public static string DecodeText(DocX document, int key)
        {
			DocX doc = (DocX)document.Copy();

			string result = "";
			string bitsArray = "";

			foreach (var paragraph in doc.Paragraphs)
			{
				foreach (var element in paragraph.Xml.Elements())
				{
					if (element.Name.LocalName == "r")
					{
						foreach (var subelement in element.Elements())
						{
							if (subelement.Name.LocalName == "t")
							{
								if (bitsArray.Length >= key * 8)
                                {
									for (int octo = 0; octo < key; octo++)
									{
										if (bitsArray.Length - octo * 8 < 8)
											break;

										byte[] symb = new byte[] { FromEditableByte(bitsArray.Substring(octo * 8, 8)) };
										result += Encoding.GetEncoding(1251).GetString(symb);
									}

									return result;
								}

								string builder = subelement.Value;

								int index = builder.IndexOf(' ');
								while (index != -1)
                                {
									int len = builder.Length;
									if (index + 1 < len && builder[index + 1] == ' ')
                                    {
										bitsArray += '1';
										builder = builder.Remove(0, index + 2);
                                    }
                                    else
                                    {
										bitsArray += '0';
										builder = builder.Remove(0, index + 1);
									}
									index = builder.IndexOf(' ');
								}
							}
						}
					}
				}
			}

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
