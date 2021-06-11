using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB_11
{
    public partial class Task2 : Form
    {

        ECEPrivateKeys privateKeys;
        ECEPublicKeys publicKeys;

        List<ECMessageBlock> ecryptedPoints = new List<ECMessageBlock>();

        public Task2()
        {
            InitializeComponent();
        }

        private void GenerateKeysBtn_Click(object sender, EventArgs e)
        {
            (publicKeys, privateKeys) = ECEncryption.GenerateECE(751, -1, 1, 25);
            PrivateKeysContainer.Text = privateKeys.ToString();
            PublicKeysContainer.Text = publicKeys.ToString();
        }

        private void EncryptBtn_Click(object sender, EventArgs e)
        {
            string text = TextContainer.Text;
            ECPoint[] messPoints = ECRusAlphabet.ToPoints(text);
            ecryptedPoints = ECEncryption.Encryption(messPoints, publicKeys);
            EncryptedPointsContainer.Text = "";
            for (int i = 0; i < ecryptedPoints.Count; i++)
            {
                EncryptedPointsContainer.Text += ecryptedPoints[i].ToString() + "\r\n";
            }
        }

        private void DecryptBtn_Click(object sender, EventArgs e)
        {
            string text = ECRusAlphabet.ToText(ECEncryption.Decryption(ecryptedPoints, privateKeys));
            DecryptedTextContainer.Text = text;
        }
    }
}
