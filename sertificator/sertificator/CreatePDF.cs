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
            //size of document        
            using (FileStream fs = new FileStream(filePath+@"/rkkррррррррmd.pdf", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                Rectangle pagesize = new Rectangle(PageSize.A5.Rotate()); //size of document
                Document doc = new Document(pagesize, 0f, 0f, 0f, 0f);
                PdfWriter writer = PdfWriter.GetInstance(doc, fs);
                doc.Open();
                //doc.Add(new Paragraph("JPG"));
                Image jpg = Image.GetInstance(imagePath+@"/image.jpg");
                jpg.ScaleToFit(610f, 420f);
                //jpg.Alignment = Element.ALIGN_CENTER;
                doc.Add(jpg);
                doc.Add(new Paragraph("Привет!"));
                doc.Close();
            }

        }
    }
}
