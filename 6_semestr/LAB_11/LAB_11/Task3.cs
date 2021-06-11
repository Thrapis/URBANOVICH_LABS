using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB_11
{
    public partial class Task3 : Form
    {
        ECEPrivateKeys privateKeys;
        ECEPublicKeys publicKeys;
        Bitmap OK = new Bitmap(@"OK.png");
        Bitmap NOTOK = new Bitmap(@"NOTOK.png");

        List<ECMessageBlock> ecryptedPoints = new List<ECMessageBlock>();

        public Task3()
        {
            InitializeComponent();
        }

        private void GenerateKeysBtn_Click(object sender, EventArgs e)
        {
            (publicKeys, privateKeys) = ECEncryption.GenerateECE(751, -1, 1, new ECPoint(416, 55), 13, 7);
            PrivateKeysContainer.Text = privateKeys.ToString();
            PublicKeysContainer.Text = publicKeys.ToString();
        }

        private void GetEDS_Click(object sender, EventArgs e)
        {
            string text = OriginText.Text;
            string algText = ЕСDSA.GenerateEDS(text, privateKeys).ToString();
            string EDSed = text + '`' + algText;
            EDSText.Text = EDSed;
        }

        private void VerifyEDS_Click(object sender, EventArgs e)
        {
            string EDSed = EDSText.Text;
            string[] textEDS = EDSed.Split('`');
            ECDSABlock eds = ECDSABlock.FromString(textEDS[1]);
            bool ok = ЕСDSA.VerifyEDS(textEDS[0], eds, publicKeys);
            if (ok)
                StatusPic.Image = new Bitmap(OK);
            else
                StatusPic.Image = new Bitmap(NOTOK);
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

        private void button1_Click(object sender, EventArgs e)
        {
            StatusPic.Image = null;
        }
    }
}
