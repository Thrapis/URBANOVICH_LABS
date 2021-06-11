using LAB_8;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB_10
{
    public partial class Form1 : Form
    {
        RSA rsa;
        ElGamal elGamal;
        Schnorr schnorr;
        Bitmap OK = new Bitmap(@"OK.png");
        Bitmap NOTOK = new Bitmap(@"NOTOK.png");

        public Form1()
        {
            InitializeComponent();

            EDSTypes.Items.Add("RSA");
            EDSTypes.Items.Add("El Gamal");
            EDSTypes.Items.Add("Schnorr");

            EDSTypes.SelectedIndex = 0;
        }

        private void OriginText_DoubleClick(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                using (StreamReader sr = new StreamReader(ofd.FileName))
                {
                    string text = sr.ReadToEnd();
                    OriginText.Text = text;
                }
            }
        }

        private void EDSText_DoubleClick(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                using (StreamReader sr = new StreamReader(ofd.FileName))
                {
                    string text = sr.ReadToEnd();
                    EDSText.Text = text;
                }
            }
        }

        private void EDSTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (EDSTypes.SelectedIndex)
            {
                case 0:
                    FormatP.Text = "p;q;d";
                    FormatO.Text = "n;e";
                    break;
                case 1:
                    FormatP.Text = "p;x";
                    FormatO.Text = "p;g;y";
                    break;
                case 2:
                    FormatP.Text = "";
                    FormatO.Text = "p;g;y";
                    break;
            }
        }

        private void GetEDS_Click(object sender, EventArgs e)
        {
            try
            {
                string text;
                string PKs;
                string[] nums;
                string algText;
                string EDSed;
                switch (EDSTypes.SelectedIndex)
                {
                    case 0:
                        text = OriginText.Text;
                        PKs = PrivateKeys.Text;
                        nums = PKs.Split(';');
                        rsa = new RSA(BigInteger.Parse(nums[0]), BigInteger.Parse(nums[1]), BigInteger.Parse(nums[2]));
                        algText = new BigInteger[] { RSA.GetEDS(text, rsa.N, rsa.D) }.ToStringArray();
                        EDSed = text + '`' + algText;
                        EDSText.Text = EDSed;
                        break;
                    case 1:
                        text = OriginText.Text;
                        PKs = PrivateKeys.Text;
                        nums = PKs.Split(';');
                        BigInteger hash = BigInteger.Abs(BigInteger.Parse(MD5.GetHash(text), System.Globalization.NumberStyles.AllowHexSpecifier));
                        elGamal = new ElGamal(BigInteger.Parse(nums[0]), BigInteger.Parse(nums[1]));
                        ElGamalBlock algBlock = ElGamal.HashEcryption(hash, elGamal.P, elGamal.G, elGamal.X);
                        EDSed = text + '`' + (new ElGamalBlock[] { algBlock }).ToStringArray();
                        EDSText.Text = EDSed;
                        break;
                    case 2:
                        text = OriginText.Text;
                        schnorr = new Schnorr();
                        algText = new ElGamalBlock[] { Schnorr.GetEDS(text, schnorr.P, schnorr.Q, schnorr.G, schnorr.X) }.ToStringArray();
                        EDSed = text + '`' + algText;
                        EDSText.Text = EDSed;
                        break;
                }
                
            }
            catch { MessageBox.Show("Something wrong"); }
        }

        private void VerifyEDS_Click(object sender, EventArgs e)
        {
            try
            {
                string text;
                string OKs;
                bool isEqv;
                string[] nums;
                string[] twoParts = new string[2];
                
                switch (EDSTypes.SelectedIndex)
                {
                    case 0:
                        text = EDSText.Text;
                        OKs = OpenKeys.Text;
                        nums = OKs.Split(';');
                        twoParts = text.Split('`');
                        //string dealgText = RSA.Decryption(twoParts[1].GetRSABlocks(), BigInteger.Parse(nums[0]), BigInteger.Parse(nums[1]));
                        isEqv = RSA.VerifyEDS(twoParts[0], twoParts[1].GetRSABlocks()[0], BigInteger.Parse(nums[0]), BigInteger.Parse(nums[1]));
                        if (isEqv)
                            StatusPic.Image = new Bitmap(OK);
                        else
                            StatusPic.Image = new Bitmap(NOTOK);
                        break;
                    case 1:
                        text = EDSText.Text;
                        OKs = OpenKeys.Text;
                        nums = OKs.Split(';');
                        twoParts = text.Split('`');
                        BigInteger hash = BigInteger.Abs(BigInteger.Parse(MD5.GetHash(twoParts[0]), System.Globalization.NumberStyles.AllowHexSpecifier));
                        isEqv = ElGamal.HashDecryptionVerify(twoParts[1].GetElGamalBlocks()[0], hash, BigInteger.Parse(nums[0]), BigInteger.Parse(nums[1]), BigInteger.Parse(nums[2]));
                        if (isEqv)
                            StatusPic.Image = new Bitmap(OK);
                        else
                            StatusPic.Image = new Bitmap(NOTOK);
                        break;
                    case 2:
                        text = EDSText.Text;
                        OKs = OpenKeys.Text;
                        nums = OKs.Split(';');
                        twoParts = text.Split('`');
                        isEqv = Schnorr.VerifyEDS(twoParts[0], twoParts[1].GetElGamalBlocks()[0], BigInteger.Parse(nums[0]), BigInteger.Parse(nums[1]), BigInteger.Parse(nums[2]));
                        if (isEqv)
                            StatusPic.Image = new Bitmap(OK);
                        else
                            StatusPic.Image = new Bitmap(NOTOK);
                        break;
                }
                

            }
            catch { MessageBox.Show("Something wrong"); }
        }

        private void CopyPK_Click(object sender, EventArgs e)
        {
            switch (EDSTypes.SelectedIndex)
            {
                case 0:
                    Clipboard.SetText(rsa.N + ";" + rsa.E);
                    break;
                case 1:
                    Clipboard.SetText(elGamal.P + ";" + elGamal.G + ";" + elGamal.Y);
                    break;
                case 2:
                    Clipboard.SetText(schnorr.P + ";" + schnorr.G + ";" + schnorr.Y);
                    break;
            }
            
        }

        private void PastePK_Click(object sender, EventArgs e)
        {
            OpenKeys.Text = Clipboard.GetText();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StatusPic.Image = null;
        }
    }
}
