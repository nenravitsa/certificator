using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Mime;
using iTextSharp.text;
using iTextSharp.text.pdf;


namespace sertificator
{
    class CreatePDF
    {
        public static void Create()
        {
            //Console.WriteLine("Введите путь, по которому будет размещен сгенерированный PDF-файл:");
            //string filePath = Console.ReadLine();
            string filePath = @"c://users/lenovo/documents";
            string imagePath = @"c://users/lenovo/documents";
            string font = @"c://users/lenovo/documents/new";
            string str1 = "Сертификат";
            string str2 = "это информация об услуге";
            string str3 = "и еще чуть-чуть";
            //size of document        
            using (FileStream fs = new FileStream(filePath+@"/9.pdf", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                Rectangle pagesize = new Rectangle(PageSize.A5.Rotate()); //size of document
                Document doc = new Document(pagesize, 0f, 0f, 0f, 0f);
                PdfWriter writer = PdfWriter.GetInstance(doc, fs);
                doc.Open();
                Image jpg = Image.GetInstance(imagePath + @"/image.jpg");
                jpg.ScaleToFit(610f, 420f); // size of image
                jpg.Alignment = Image.UNDERLYING; //image like background
                //jpg.SetAbsolutePosition(7, 69);
                doc.Add(jpg);
                //first string
                FontSelector selector1 = new FontSelector();
                Font f1 = FontFactory.GetFont(font + @"/constantine.ttf", BaseFont.IDENTITY_H, true);
                f1.SetColor(255, 250, 250);
                Phrase ph = selector1.Process(str1);
                Paragraph title = new Paragraph(ph);
                title.Alignment = Element.ALIGN_CENTER;
                doc.Add(title);
                //second string
                FontSelector selector2 = new FontSelector();
                Font f2 = FontFactory.GetFont(font + @"/constantine.ttf", BaseFont.IDENTITY_H, true);
                f2.SetColor(255, 228, 196);
                selector2.AddFont(f2);
                Phrase ph2 = selector2.Process(str2);
                Paragraph desc = new Paragraph(ph2);
                desc.Alignment = Element.ALIGN_CENTER;
                doc.Add(desc);
                //third string
                FontSelector selector3 = new FontSelector();
                //Font f3 = FontFactory.GetFont(FontFactory.TIMES_ROMAN, 12, new BaseColor(255, 250, 250));
                Font f3 = FontFactory.GetFont(font + @"/constantine.ttf", BaseFont.IDENTITY_H, true); //russian
                f3.SetColor(255, 250, 250);
                selector3.AddFont(f3);
                Phrase ph3 = selector3.Process(str3);            
                Paragraph rus = new Paragraph(ph3);
                rus.Alignment = Element.ALIGN_CENTER;
                doc.Add(rus);
                doc.Close();
            }

        }
    }
}
