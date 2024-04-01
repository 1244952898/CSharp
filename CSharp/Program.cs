using CSharp.classes;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using Document = QuestPDF.Fluent.Document;

namespace CSharp
{
    class Program
    {
        static void Main(string[] args)
        {

            Class11 class11 = new Class11();
            var llll = class11.GetClass1s(0);
            if (llll==null)
            {

            }

            QuestPDF.Settings.License = LicenseType.Enterprise;
            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(2, Unit.Centimetre);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(20));

                    page.Header()
                        .Text("Hello PDFaaaaaaaasd!")
                        .SemiBold().FontSize(36).FontColor(Colors.Blue.Medium);

                    page.Content()
                        .PaddingVertical(1, Unit.Centimetre)
                        .Column(x =>
                        {
                            x.Spacing(20);

                            x.Item().Text(Placeholders.LoremIpsum());
                            x.Item().Image(Placeholders.Image(200, 100));
                        });

                    page.Footer()
                        .AlignCenter()
                        .Text(x =>
                        {
                            x.Span("Page ");
                            x.CurrentPageNumber();
                        });
                });
            }).GeneratePdf("hello.pdf");

            

            DatetimeNull datetimeNull = new DatetimeNull();
            datetimeNull.DTime = null;
            //bool siss = true;
            //Console.WriteLine(siss.ToString());
            //var fileLines = File.ReadAllText("D:\\项目\\英飞特\\IMDS\\Batch Client 14.0\\DataDownload_test.bat");
            //foreach (var line in fileLines)
            //{
            //    Console.WriteLine(line);
            //    //var strs = line.Split(new string[] { "\t" }, StringSplitOptions.None);
            //}

            var sList = new List<string> { "1", "2", "1", "2", "3", "1", "2", "1" };
            var sdsds = sList.ToString();
            var sdd = sList.Where(x => x.Equals("1111")).ToList();
            var itemIndexTuple = new List<(int, int)>();
            var startIndex = sList.FindIndex(x => x.Equals("1"));
            for (int i = startIndex + 1; i < sList.Count; i++)
            {
                if ("1" == sList[i])
                {
                    itemIndexTuple.Add((startIndex, i - startIndex));
                    startIndex = i;
                }
            }
            itemIndexTuple.Add((startIndex, sList.Count - startIndex));

            foreach (var item in itemIndexTuple)
            {
                var l = sList.GetRange(item.Item1, item.Item2);
            }

        }
    }
}
