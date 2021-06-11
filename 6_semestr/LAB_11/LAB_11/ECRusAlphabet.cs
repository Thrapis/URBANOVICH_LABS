using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_11
{
    public static class ECRusAlphabet
    {
        static Dictionary<char, ECPoint> dictionary;
        
        static ECRusAlphabet()
        {
            dictionary = new Dictionary<char, ECPoint>();
            dictionary.Add('А', new ECPoint(189, 297));
            dictionary.Add('Б', new ECPoint(189, 454));
            dictionary.Add('В', new ECPoint(192, 32));
            dictionary.Add('Г', new ECPoint(192, 719));
            dictionary.Add('Д', new ECPoint(194, 205));
            dictionary.Add('Е', new ECPoint(194, 546));
            dictionary.Add('Ж', new ECPoint(197, 145));
            dictionary.Add('З', new ECPoint(197, 606));
            dictionary.Add('И', new ECPoint(198, 224));
            dictionary.Add('Й', new ECPoint(198, 527));
            dictionary.Add('К', new ECPoint(200, 30));
            dictionary.Add('Л', new ECPoint(200, 721));
            dictionary.Add('М', new ECPoint(203, 324));
            dictionary.Add('Н', new ECPoint(203, 427));
            dictionary.Add('О', new ECPoint(205, 372));
            dictionary.Add('П', new ECPoint(205, 379));
            dictionary.Add('Р', new ECPoint(206, 106));
            dictionary.Add('С', new ECPoint(206, 645));
            dictionary.Add('Т', new ECPoint(209, 82));
            dictionary.Add('У', new ECPoint(209, 669));
            dictionary.Add('Ф', new ECPoint(210, 31));
            dictionary.Add('Х', new ECPoint(210, 720));
            dictionary.Add('Ц', new ECPoint(215, 247));
            dictionary.Add('Ч', new ECPoint(215, 504));
            dictionary.Add('Ш', new ECPoint(218, 150));
            dictionary.Add('Щ', new ECPoint(218, 601));
            dictionary.Add('Ъ', new ECPoint(221, 138));
            dictionary.Add('Ы', new ECPoint(221, 613));
            dictionary.Add('Ь', new ECPoint(226, 9));
            dictionary.Add('Э', new ECPoint(226, 742));
            dictionary.Add('Ю', new ECPoint(227, 299));
            dictionary.Add('Я', new ECPoint(227, 452));
            dictionary.Add(' ', new ECPoint(72, 497));
        }

        public static ECPoint[] ToPoints(string text)
        {
            ECPoint[] result = new ECPoint[text.Length];
            text = text.ToUpper();
            for (int i = 0; i < text.Length; i++)
            {
                ECPoint point;
                if (dictionary.TryGetValue(text[i], out point))
                {
                    result[i] = point;
                }
            }
            return result;
        }

        public static string ToText(ECPoint[] points)
        {
            string text = "";
            for (int i = 0; i < points.Length; i++)
            {
                foreach (var po in dictionary)
                {
                    if (po.Value == points[i])
                    {
                        text += po.Key;
                        break;
                    }
                }
            }
            return text;
        }
    }
}
