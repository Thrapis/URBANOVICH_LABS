using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB_12
{
    public partial class Form1 : Form, IProgressBar
    {
        Bitmap OriginImage;
        Bitmap EncodedImage;
        Bitmap LSBImage;

        public Form1()
        {
            InitializeComponent();
            OriginImageBox.SizeMode = PictureBoxSizeMode.Zoom;
            EncodedImageBox.SizeMode = PictureBoxSizeMode.Zoom;
            LSBImageBox.SizeMode = PictureBoxSizeMode.Zoom;


            SpectrumBox.DropDownStyle = ComboBoxStyle.DropDownList;
            SpectrumBox.Items.Add(Spectrum.Red);
            SpectrumBox.Items.Add(Spectrum.Green);
            SpectrumBox.Items.Add(Spectrum.Blue);
            SpectrumBox.Items.Add(Spectrum.All);
            SpectrumBox.SelectedIndex = 0;
        }

        private void BytesCanBeEncoded(object sender, EventArgs e)
        {
            if (OriginImage == null)
            {
                CanBeEncodedBox.Text = "";
                return;
            }

            Spectrum spectrum = (Spectrum)SpectrumBox.SelectedItem;
            int lesserbits = (int)LesserBitsBox.Value;
            int pixels = OriginImage.Width * OriginImage.Height;

            int bytesCanBeEncoded = pixels * lesserbits;
            if (spectrum == Spectrum.All)
                bytesCanBeEncoded *= 3;

            CanBeEncodedBox.Text = $"Can be encoded {bytesCanBeEncoded / 8} bytes";
        }

        private void OriginImageBox_DoubleClick(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files (*.bmp;*.png;*.jpg)|*.bmp;*.png;*.jpg|BMP Image (*.bmp)|*.bmp|PNG Image (*.png)|*.png|JPEG Image (*.jpg)|*.jpg";
            ofd.Title = "Open Image";
            ofd.AddExtension = true;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                OriginImage = (Bitmap)Image.FromFile(ofd.FileName);
                OriginImageBox.Image = new Bitmap(OriginImage);
            }

            BytesCanBeEncoded(sender, e);
        }

        private void EncodedImageBox_DoubleClick(object sender, EventArgs e)
        {
            if (EncodedImage == null)
                return;

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Save Encoded Image";
            sfd.AddExtension = true;
            sfd.DefaultExt = "*.bmp";
            sfd.Filter = "BMP Image (*.bmp)| *.bmp|PNG Image (*.png)| *.png|JPEG Image (*.jpg)| *.jpg";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                int filterIndex = sfd.FilterIndex;
                string fileName = sfd.FileName;

                switch (filterIndex)
                {
                    case 1: EncodedImage.Save(fileName, ImageFormat.Bmp); break;
                    case 2: EncodedImage.Save(fileName, ImageFormat.Png); break;
                    case 3: EncodedImage.Save(fileName, ImageFormat.Jpeg); break;
                }
            }
        }

        private void LSBImageBox_DoubleClick(object sender, EventArgs e)
        {
            if (LSBImage == null)
                return;

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Save LSB Image";
            sfd.AddExtension = true;
            sfd.DefaultExt = "*.bmp";
            sfd.Filter = "BMP Image (*.bmp)| *.bmp|PNG Image (*.png)| *.png|JPEG Image (*.jpg)| *.jpg";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                int filterIndex = sfd.FilterIndex;
                string fileName = sfd.FileName;

                switch (filterIndex)
                {
                    case 1: LSBImage.Save(fileName, ImageFormat.Bmp); break;
                    case 2: LSBImage.Save(fileName, ImageFormat.Png); break;
                    case 3: LSBImage.Save(fileName, ImageFormat.Jpeg); break;
                }
            }
        }

        private void LSBBtn_Click(object sender, EventArgs e)
        {
            if (OriginImage == null)
                return;

            LSBImage = LSB.GetLSBImage(new Bitmap(OriginImage), this);
            LSBImageBox.Image = LSBImage;
            ProgressChanged(0);
        }

        public void ProgressChanged(double progress, double from)
        {
            ProgressBar.Value = (int)(progress / from * 100);
        }

        public void ProgressChanged(int progressPercents)
        {
            ProgressBar.Value = progressPercents;
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            OriginImage = null;
            EncodedImage = null;
            LSBImage = null;
            OriginImageBox.Image = null;
            EncodedImageBox.Image = null;
            LSBImageBox.Image = null;
            TextToEncode.Text = "";
            DecodedText.Text = "";
            BytesCanBeEncoded(sender, e);
        }

        private void EncodeBtn_Click(object sender, EventArgs e)
        {
            if (OriginImage == null)
                return;

            string text = TextToEncode.Text;
            byte lesserBits = (byte)LesserBitsBox.Value;
            Spectrum spectrum = (Spectrum)SpectrumBox.SelectedItem;
            int key = 0; 
            (EncodedImage, key) = LSB.EncodeText(new Bitmap(OriginImage), text, lesserBits, spectrum, this);
            EncodedImageBox.Image = EncodedImage;
            KeyBox.Value = key;
            ProgressChanged(0);
        }

        private void DecodeBtn_Click(object sender, EventArgs e)
        {
            if (OriginImage == null)
                return;

            byte lesserBits = (byte)LesserBitsBox.Value;
            Spectrum spectrum = (Spectrum)SpectrumBox.SelectedItem;
            int key = (int)KeyBox.Value;
            string text = LSB.DecodeText(new Bitmap(OriginImage), key, lesserBits, spectrum, this);
            DecodedText.Text = text;
            ProgressChanged(0);
        }

        private void TextToEncode_DoubleClick(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Open text";
            ofd.Filter = "Text file (*.txt)|*.txt|All files (*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string fileName = ofd.FileName;
                using (StreamReader sr = new StreamReader(fileName))
                {
                    TextToEncode.Text = sr.ReadToEnd();
                }
            }
        }

        private void DecodedText_DoubleClick(object sender, EventArgs e)
        {
            if (DecodedText.Text.Length == 0)
                return;

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Save Decoded Text";
            sfd.AddExtension = true;
            sfd.DefaultExt = "*.txt";
            sfd.Filter = "Text file (*.txt)|*.txt|All files (*.*)|*.*";

            string text = DecodedText.Text;

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string fileName = sfd.FileName;

                using (StreamWriter sw = new StreamWriter(fileName, true, Encoding.ASCII))
                {
                    sw.Write(text);
                }
            }
        }
    }
}
