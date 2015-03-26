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
            string str = "SPA-салон SPAкой";
            string str1 = @"Сертификат";
            string str2 = @"#0001";
            string str3 = @"МАССАЖ ТАЙСКИМИ БУЛЫЖНИКАМИ";
            string str4 = @"Краткое описание массажа. Во время процедуры используются настоящие масла из ореганы, василька и апельсина. Время процедуры - 1 час.";
            string str5 = @"Пупкиной Александрине Романовне";
            //size of document        
            using (FileStream fs = new FileStream(filePath+@"/53.pdf", FileMode.Create, FileAccess.Write, FileShare.None))
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

                PdfPTable table = new PdfPTable(1);
                //table.GetDefaultCell().setBorder(Rectangle.NO_BORDER);
                //table.DefaultCell.Border = Rectangle.NO_BORDER;
                
                //table.DefaultCell.Border = Rectangle.NO_BORDER;
                  //first cell
                    FontSelector selector = new FontSelector();
                    Font f = FontFactory.GetFont(font + @"/constantine.ttf", BaseFont.IDENTITY_H, true);
                    f.SetColor(255, 250, 250);
                    selector.AddFont(f);
                    var ph = selector.Process(str);
                    Paragraph company = new Paragraph(ph);
                    PdfPCell cell = new PdfPCell(new Phrase(company));
                    cell.FixedHeight = 30.0f;  // Give rows some height
                    cell.BorderWidthBottom = 0f;
                    cell.BorderWidthLeft = 0f;
                    cell.BorderWidthTop = 0f;
                    cell.BorderWidthRight = 0f;
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.VerticalAlignment = Element.ALIGN_MIDDLE;        
                    table.AddCell(cell);
                    //cell.GetBorder = Rectangle.NO_BORDER;
                    //cell.SetBorder(Rectangle.NO_BORDER);
                  //second cell
                    FontSelector selector1 = new FontSelector();
                    Font f1 = FontFactory.GetFont(font + @"/constantine.ttf", BaseFont.IDENTITY_H, true, 39);
                    f1.SetColor(255, 250, 250);
                    selector1.AddFont(f1);
                    var ph1 = selector1.Process(str1);
                    Paragraph title = new Paragraph(ph1);
                    PdfPCell cell1 = new PdfPCell(new Phrase(title));        
                    cell1.FixedHeight = 45.0f;
                    cell1.BorderWidthBottom = 0f;
                    cell1.BorderWidthLeft = 0f;
                    cell1.BorderWidthTop = 0f;
                    cell1.BorderWidthRight = 0f;
                    cell1.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell1.VerticalAlignment = Element.ALIGN_MIDDLE;
                    table.AddCell(cell1);
                  //third cell
                    FontSelector selector2 = new FontSelector();
                    Font f2 = FontFactory.GetFont(font + @"/constantine.ttf", BaseFont.IDENTITY_H, true, 12);
                    f2.SetColor(255, 228, 196);
                    selector2.AddFont(f2);
                    Phrase ph2 = selector2.Process(str2);
                    Paragraph desc = new Paragraph(ph2);
                    PdfPCell cell2 = new PdfPCell(new Phrase(desc));
                    cell2.FixedHeight = 20.0f;
                    cell2.BorderWidthBottom = 0f;
                    cell2.BorderWidthLeft = 0f;
                    cell2.BorderWidthTop = 0f;
                    cell2.BorderWidthRight = 0f;
                    cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                    table.AddCell(cell2);
                  //4 cell
                    FontSelector selector3 = new FontSelector();
                    Font f3 = FontFactory.GetFont(font + @"/constantine.ttf", BaseFont.IDENTITY_H, true, 20);
                    f3.SetColor(255, 228, 196);
                    selector3.AddFont(f3);
                    Phrase ph3 = selector3.Process(str3);
                    Paragraph usluga = new Paragraph(ph3);
                    PdfPCell cell3 = new PdfPCell(new Phrase(usluga));
                    cell3.FixedHeight = 45.0f;
                    cell3.BorderWidthBottom = 0f;
                    cell3.BorderWidthLeft = 0f;
                    cell3.BorderWidthTop = 0f;
                    cell3.BorderWidthRight = 0f;
                    cell3.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell3.VerticalAlignment = Element.ALIGN_BASELINE;
                    table.AddCell(cell3);
                  //5 cell
                    FontSelector selector4 = new FontSelector();
                    Font f4 = FontFactory.GetFont(font + @"/constantine.ttf", BaseFont.IDENTITY_H, true, 9);
                    //f4.SetColor(255, 228, 196);
                    selector4.AddFont(f4);
                    Phrase ph4 = selector4.Process(str4);
                    Paragraph about = new Paragraph(ph4);
                    PdfPCell cell4 = new PdfPCell(new Phrase(about));
                    cell4.FixedHeight = 40.0f;
                    cell4.BorderWidthBottom = 0f;
                    cell4.BorderWidthLeft = 0f;
                    cell4.BorderWidthTop = 0f;
                    cell4.BorderWidthRight = 0f;
                    cell4.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell4.VerticalAlignment = Element.ALIGN_TOP;
                    table.AddCell(cell4);
                //6 cell - name 
                    FontSelector selector5 = new FontSelector();
                    Font f5 = FontFactory.GetFont(font + @"/constantine.ttf", BaseFont.IDENTITY_H, true, 30);
                    //f5.SetColor(255, 228, 100);
                    
                    selector5.AddFont(f5);
                    Phrase ph5 = selector5.Process(str5);
                    Paragraph name = new Paragraph(ph5);
                    PdfPCell cell5 = new PdfPCell(new Phrase(name));
                    cell5.FixedHeight = 100.0f;
                    cell5.BorderWidthBottom = 0f;
                    cell5.BorderWidthLeft = 0f;
                    cell5.BorderWidthTop = 0f;
                    cell5.BorderWidthRight = 0f;
                    cell5.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell5.VerticalAlignment = Element.ALIGN_MIDDLE;
                    table.AddCell(cell5);
                    
                    
                doc.Add(table);
                doc.Close();
            }

        }
    }
}
