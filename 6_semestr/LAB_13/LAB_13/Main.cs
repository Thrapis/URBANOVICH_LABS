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
using Xceed.Words.NET;

namespace LAB_13
{
    public partial class Main : Form
    {
        DocX OriginDocument;
        DocX EncodedDocument;

        public Main()
        {
            InitializeComponent();
        }

        private void EncodeBtn_Click(object sender, EventArgs e)
        {
            if (OriginDocument == null)
                return;

            string text = TextToEncodeBox.Text;
            int key = 0;
            (EncodedDocument, key) = MSWordStego.EncodeText(OriginDocument, text);

            KeyBox.Value = key;
            EncodedDocumentBox.Text = MSWordStego.GetText(EncodedDocument);
        }

        private void DecodeBtn_Click(object sender, EventArgs e)
        {
            if (OriginDocument == null)
                return;

            int key = (int)KeyBox.Value;
            string text = MSWordStego.DecodeText(OriginDocument, key);
            DecodedTextBox.Text = text;
        }

        private void OriginDocumentBox_DoubleClick(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Open Origin Document";
            ofd.Filter = "MS Word (*.docx)|*.docx";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string fileName = ofd.FileName;
                OriginDocument = DocX.Load(fileName);

                int canBeEncoded = MSWordStego.ClearFromNoise((DocX)OriginDocument.Copy());
                StatusLabel.Text = $"Can be encoded: {canBeEncoded / 8} bytes";

                OriginDocumentBox.Text = MSWordStego.GetText(OriginDocument);
            }
        }

        private void TextToEncodeBox_DoubleClick(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Open Text To Encode";
            ofd.Filter = "Text file (*.txt)|*.txt|All files (*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string fileName = ofd.FileName;
                using (StreamReader sr = new StreamReader(fileName))
                {
                    TextToEncodeBox.Text = sr.ReadToEnd();
                }
            }
        }

        private void DecodedTextBox_DoubleClick(object sender, EventArgs e)
        {
            if (DecodedTextBox.Text.Length == 0)
                return;

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Save Decoded Text";
            sfd.AddExtension = true;
            sfd.DefaultExt = "*.txt";
            sfd.Filter = "Text file (*.txt)|*.txt|All files (*.*)|*.*";

            string text = DecodedTextBox.Text;

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string fileName = sfd.FileName;

                using (StreamWriter sw = new StreamWriter(fileName, true, Encoding.ASCII))
                {
                    sw.Write(text);
                }
            }
        }

        private void EncodedDocumentBox_DoubleClick(object sender, EventArgs e)
        {
            if (EncodedDocument == null)
                return;

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Save Encoded Document";
            sfd.AddExtension = true;
            sfd.DefaultExt = "*.txt";
            sfd.Filter = "MS Word (*.docx)|*.docx";

            string text = DecodedTextBox.Text;

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string fileName = sfd.FileName;

                EncodedDocument.SaveAs(fileName);
            }
        }

        private void TextToEncodeBox_TextChanged(object sender, EventArgs e)
        {
            int encodingBits = TextToEncodeBox.Text.Length * 8;
            TextStatus.Text = $"Text size: {encodingBits / 8} bytes";
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            OriginDocument = null;
            EncodedDocument = null;
            OriginDocumentBox.Text = "";
            EncodedDocumentBox.Text = "";
            TextToEncodeBox.Text = "";
            DecodedTextBox.Text = "";
            StatusLabel.Text = "";
            TextStatus.Text = "";
        }
    }
}
