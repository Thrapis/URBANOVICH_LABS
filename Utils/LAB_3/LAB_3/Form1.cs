using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB_3
{
    public partial class Form1 : Form
    {
        List<char> B64 = new List<char>();
        public Form1()
        {
            InitializeComponent();
            LoadB64();
        }

        private void LoadB64()
        {
            B64 = new List<char>();
            using (FileStream fs = new FileStream(@"base64.txt", FileMode.Open))
            {
                while (fs.Position != fs.Length)
                {
                    int num = fs.ReadByte();
                    char symb = (char)num;
                    B64.Add(symb);
                }
                Console.WriteLine($"{B64.Count}\n\n");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string text = textBox1.Text;

            byte[] bytes = GetArrayOfBytesWithReverse(text);
            BitArray bits = new BitArray(bytes);

            int twoBits = 0;
            byte[] newBytes = DivideBySixAndReverse(Additions.ToCanBeDividedBySix(bits, out twoBits));


            EnterWithB64(newBytes, twoBits);

        }

        private static byte[] GetArrayOfBytesWithReverse(string text)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(text);
            for (int i = 0; i < bytes.Length; i++)
            {
                bytes[i] = Additions.Reverse(bytes[i]);
            }

            return bytes;
        }
        private static byte[] GetArrayOfBytes(string text)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(text);
            return bytes;
        }
        private BitArray GetBitArrayFromB64(string text)
        {
            BitArray result = new BitArray(text.Length * 6);
            for (int i = 0; i < text.Length; i++)
            {
                byte ind = (byte)B64.IndexOf(text[i]);
                byte[] n = new byte[1];
                n[0] = ind;
                BitArray array = new BitArray(n);
                BitArray arr6 = Additions.FromEightToSix(array);
                for (int j = 0; j < 3; j++)
                {
                    bool f1;
                    bool f2;
                    f1 = arr6[j];
                    f2 = arr6[5 - j];
                    arr6[j] = f2;
                    arr6[5 - j] = f1;
                }
                for (int j = 0; j < 6; j++)
                {
                    result[j + i * 6] = arr6[j];
                }
            }
            return result;
        }

        private void EnterWithB64(byte[] bytes, int addChars)
        {
            string output = "";
            foreach (var b in bytes)
            {
                output += B64[b];
            }
            for (int i = 0; i < addChars; i++)
            {
                output += "=";
            }
            textBox2.Text = output;
        }

        private static byte[] DivideBySixAndReverse(BitArray bits)
        {
            byte[] newBytes = new byte[bits.Length / 6];

            int sixpletsCount = 0;
            int sixCounter = 0;
            int counter = 0;
            BitArray bufBits = new BitArray(6);

            while (sixpletsCount < bits.Length / 6)
            {
                bufBits[sixCounter] = bits[counter];

                sixCounter++;
                counter++;
                if (sixCounter == 6)
                {
                    byte[] n = new byte[1];
                    BitArray eightPlet = Additions.FromSixToEight(bufBits);
                    eightPlet.CopyTo(n, 0);
                    newBytes[sixpletsCount] = Additions.Reverse(n[0]);
                    //Console.Write(newBytes[sixpletsCount] + " ");
                    sixpletsCount++;
                    sixCounter = 0;
                }

            }
            //Console.WriteLine();
            return newBytes;
        }
        private static byte[] DivideBySix(BitArray bits)
        {
            byte[] newBytes = new byte[bits.Length / 6];

            int sixpletsCount = 0;
            int sixCounter = 0;
            int counter = 0;
            BitArray bufBits = new BitArray(6);

            while (sixpletsCount < bits.Length / 6)
            {
                bufBits[sixCounter] = bits[counter];

                sixCounter++;
                counter++;
                if (sixCounter == 6)
                {
                    byte[] n = new byte[1];
                    BitArray eightPlet = Additions.FromSixToEight(bufBits);
                    eightPlet.CopyTo(n, 0);
                    newBytes[sixpletsCount] = n[0];
                    //Console.Write(newBytes[sixpletsCount] + " ");
                    sixpletsCount++;
                    sixCounter = 0;
                }

            }
            //Console.WriteLine();
            return newBytes;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string originFile = "";
            string newFile = "";


            var openForm = new OpenFileDialog();
            openForm.Filter = "Text file (*.txt)|*.txt";
            if (openForm.ShowDialog() == DialogResult.OK)
            {
                originFile = File.ReadAllText(openForm.FileName);

                byte[] bytes = GetArrayOfBytes(originFile);
                BitArray bits = new BitArray(bytes);

                int twoBits = 0;
                byte[] newBytes = DivideBySixAndReverse(Additions.ToCanBeDividedBySix(bits, out twoBits));

                foreach (var b in newBytes)
                {
                    newFile += B64[b];
                }
                for (int i = 0; i < twoBits; i++)
                {
                    newFile += "=";
                }
                //Console.WriteLine(originFile.Length);
                //Console.WriteLine(newFile.Length);

                var saveForm = new SaveFileDialog();
                saveForm.Filter = "Text file (*.txt)|*.txt";
                if (saveForm.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(saveForm.FileName, newFile);
                }
            }


        }

        private void XOR(object sender, EventArgs e)
        {
            string ResultASCII = "";
            string ResultBase64 = "";

            string A = textBox3.Text;
            string B = textBox4.Text;

            //-------------
            byte[] Abytes = GetArrayOfBytesWithReverse(A);
            BitArray Abits = new BitArray(Abytes);
            byte[] Bbytes = GetArrayOfBytesWithReverse(B);
            BitArray Bbits = new BitArray(Bbytes);
            //-----------------

            if (A.Length > B.Length)
            {
                int AB = A.Length - B.Length;
                for (int i = 0; i < AB; i++)
                {
                    B += (char)0;
                }
            }
            else if (A.Length < B.Length)
            {
                int BA = B.Length - A.Length;
                for (int i = 0; i < BA; i++)
                {
                    A += (char)0;
                }
            }

            byte[] bytesA = GetArrayOfBytes(A);
            BitArray bitsA = new BitArray(bytesA);
            byte[] bytesB = GetArrayOfBytes(B);
            BitArray bitsB = new BitArray(bytesB);
            BitArray XOR = Additions.XOR(bitsA, bitsB);
            byte[] bytes_ascii = new byte[(XOR.Length - 1) / 8 + 1];
            XOR.CopyTo(bytes_ascii, 0);

            string binascii = "";
            foreach (var b in Additions.XOR(new BitArray(GetArrayOfBytesWithReverse(A)), new BitArray(GetArrayOfBytesWithReverse(B))))
            {
                binascii += (bool)b == true ? 1 : 0;
            }
            textBox9.Text = binascii;

            foreach (var b in bytes_ascii)
            {
                ResultASCII += (char)b;
            }
            //ResultASCII = Encoding.GetEncoding(866).GetString(bytes_ascii);
            Console.WriteLine(ResultASCII);

            textBox5.Text = ResultASCII;

            //--------------------------------------


            int AtwoBits = 0;
            byte[] AnewBytes = DivideBySixAndReverse(Additions.ToCanBeDividedBySix(Abits, out AtwoBits));
            int BtwoBits = 0;
            byte[] BnewBytes = DivideBySixAndReverse(Additions.ToCanBeDividedBySix(Bbits, out BtwoBits));


            string Ab64 = "";
            string Bb64 = "";
            foreach (var b in AnewBytes)
            {
                Ab64 += B64[b];
            }

            foreach (var b in BnewBytes)
            {
                Bb64 += B64[b];
            }


            textBox7.Text = Ab64;
            textBox8.Text = Bb64;
            for (int i = 0; i < AtwoBits; i++)
            {
                textBox7.Text += "=";
            }
            for (int i = 0; i < BtwoBits; i++)
            {
                textBox8.Text += "=";
            }


            if (Ab64.Length > Bb64.Length)
            {
                int AB = Ab64.Length - Bb64.Length;
                for (int i = 0; i < AB; i++)
                {
                    Bb64 += (char)0;
                }
            }
            else if (Ab64.Length < Bb64.Length)
            {
                int BA = Bb64.Length - Ab64.Length;
                for (int i = 0; i < BA; i++)
                {
                    Ab64 += (char)0;
                }
            }

            //byte[] bytesAb64 = GetArrayOfBytes(Ab64);
            BitArray bitsAb64 = GetBitArrayFromB64(Ab64);
            //byte[] bytesBb64 = GetArrayOfBytes(Bb64);
            BitArray bitsBb64 = GetBitArrayFromB64(Bb64);
            BitArray XORb64 = Additions.XOR(bitsAb64, bitsBb64);
            //byte[] bytes_b64 = new byte[(XORb64.Length - 1) / 8 + 1];
            int ds = 0;
            byte[] bytes_b64 = DivideBySixAndReverse(Additions.ToCanBeDividedBySix(XORb64, out ds));
            //XORb64.CopyTo(bytes_b64, 0);


            foreach (var b in bytes_b64)
            {
                ResultBase64 += B64[b];
            }
            for (int i = 0; i < ds; i++)
            {
                ResultBase64 += "=";
            }

            string binb64 = "";
            foreach (var b in XORb64)
            {
                binb64 += (bool)b == true ? 1 : 0;
            }
            textBox10.Text = binb64;

            //int twoBits = 0;
            //byte[] newBytes = DivideBySixAndReverse(Additions.ToCanBeDividedBySix(XOR, out twoBits));

            //foreach (var b in newBytes)
            //{
            //    ResultBase64 += B64[b];
            //}

            textBox6.Text = ResultBase64;
        }
    }
}
