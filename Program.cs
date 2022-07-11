using PdfSharp.Charting;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Pdf;
using resume_PDF;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Reflection;
using static System.Net.Mime.MediaTypeNames;


namespace ResumePdf
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("JSON to PDF Resume Maker");
            //Calls the function to read jsonfile from the class JsonRead
            JsonRead.ReadJsonFile(FileName());
            //Calls the function to create pdf 
            MakePdf();
            Console.WriteLine("PDF Resume Successfully Created!");
        }

        public static string FileName()
        {
        BEGIN:
            Console.Write("\nWhat is the name of your JSON file? ");
            var projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            var response = Console.ReadLine();
            var directory = projectDirectory + @"\" + response;
            if (File.Exists(directory))
            {
                return directory;
            }
            else
            {
                Console.Write("File not Found.");
                goto BEGIN;
            }
        }
        public static void MakePdf()
        {
             System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
             // Create a new PDF document
             PdfDocument document = new PdfDocument();
             document.Info.Title = "PDF Resume";

             // Create an empty page
             PdfPage page = document.AddPage();

             // Get an XGraphics object for drawing
             XGraphics gfx = XGraphics.FromPdfPage(page);

             // Create a font
             XFont namef = new XFont("Quicksand", 36, XFontStyle.Bold);
             XFont proff = new XFont("Quicksand", 16);
             XFont headf = new XFont("Quicksand", 16, XFontStyle.Bold);
             XFont detf = new XFont("Quicksand", 14, XFontStyle.Bold);
             XFont basef = new XFont("Quicksand", 14);
             //-----------------------------PDF CONTENT------------------------------
             //--------------------HEADER--------------------
             //First Name
             gfx.DrawString(JsonRead.firstname, namef, XBrushes.Black,
                new XRect(25, 30, page.Width, page.Height),
                XStringFormats.TopLeft);
             //Last Name
             gfx.DrawString(JsonRead.lastname, namef, XBrushes.Black,
                new XRect(25, 70, page.Width, page.Height),
                XStringFormats.TopLeft);
             //Proffession
             gfx.DrawString(JsonRead.profession, proff, XBrushes.Black,
                new XRect(25, 120, page.Width, page.Height),
                XStringFormats.TopLeft);
            
             //--------------------Details--------------------
             gfx.DrawString("Details", headf, XBrushes.Black,
                new XRect(25, 160, page.Width, page.Height),
                XStringFormats.TopLeft);
             //-----Address-----
             gfx.DrawString("Address", detf, XBrushes.Black,
                  new XRect(25, 210, page.Width, page.Height),
                  XStringFormats.TopLeft);
                //Street Name
                gfx.DrawString(JsonRead.add1, basef, XBrushes.Black,
                  new XRect(25, 235, page.Width, page.Height),
                  XStringFormats.TopLeft);
                //City, State and ZIP code
                gfx.DrawString(JsonRead.add2, basef, XBrushes.Black,
                  new XRect(25, 255, page.Width, page.Height),
                  XStringFormats.TopLeft);
                //Country
                gfx.DrawString(JsonRead.add3, basef, XBrushes.Black,
                  new XRect(25, 275, page.Width, page.Height),
                  XStringFormats.TopLeft);
                //-----Phone-----
                gfx.DrawString("Phone", detf, XBrushes.Black,
                  new XRect(25, 300, page.Width, page.Height),
                  XStringFormats.TopLeft);
                //Phone NUmber
                gfx.DrawString(JsonRead.phone, basef, XBrushes.Black,
                  new XRect(25, 320, page.Width, page.Height),
                  XStringFormats.TopLeft);
                //-----Email-----
                gfx.DrawString("Email", detf, XBrushes.Black,
                  new XRect(25, 345, page.Width, page.Height),
                  XStringFormats.TopLeft);
                //Email Address
                gfx.DrawString(JsonRead.email, basef, XBrushes.Black,
                  new XRect(25, 365, page.Width, page.Height),
                  XStringFormats.TopLeft);

                //---------------------SKILLS----------------------
                gfx.DrawString("Skills", headf, XBrushes.Black,
                  new XRect(25, 415, page.Width, page.Height),
                  XStringFormats.TopLeft);
                //Skill 1
                gfx.DrawString("• " + JsonRead.s1, basef, XBrushes.Black,
                  new XRect(25, 450, page.Width, page.Height),
                  XStringFormats.TopLeft);
                //Skill 2
                gfx.DrawString("• " + JsonRead.s2, basef, XBrushes.Black,
                  new XRect(25, 470, page.Width, page.Height),
                  XStringFormats.TopLeft);
                //Skill 3
                gfx.DrawString("• " + JsonRead.s3, basef, XBrushes.Black,
                  new XRect(25, 490, page.Width, page.Height),
                  XStringFormats.TopLeft);
                //Skill 4
                gfx.DrawString("• " + JsonRead.s4, basef, XBrushes.Black,
                  new XRect(25, 510, page.Width, page.Height),
                  XStringFormats.TopLeft);
                //Skill 5
                gfx.DrawString("• " + JsonRead.s5, basef, XBrushes.Black,
                  new XRect(25, 530, page.Width, page.Height),
                  XStringFormats.TopLeft);

                //---------------------LANGUAGE----------------------
                gfx.DrawString("Languages", headf, XBrushes.Black,
                  new XRect(25, 580, page.Width, page.Height),
                  XStringFormats.TopLeft);
                //Language 1
                gfx.DrawString(JsonRead.l1, basef, XBrushes.Black,
                  new XRect(25, 615, page.Width, page.Height),
                  XStringFormats.TopLeft);
                //Language 2
                gfx.DrawString(JsonRead.l2, basef, XBrushes.Black,
                  new XRect(25, 635, page.Width, page.Height),
                  XStringFormats.TopLeft);
                //Language 3
                gfx.DrawString(JsonRead.l3, basef, XBrushes.Black,
                  new XRect(25, 655, page.Width, page.Height),
                  XStringFormats.TopLeft);

                //---------------------PROFILE----------------------
                gfx.DrawString("Profile", headf, XBrushes.Black,
                  new XRect(265, 160, page.Width, page.Height),
                  XStringFormats.TopLeft);

                XTextFormatter tf = new XTextFormatter(gfx);
                XRect rect = new XRect(265, 210, 325, 80);
                gfx.DrawRectangle(XBrushes.White, rect);
                tf.DrawString(JsonRead.profile, basef, XBrushes.Black, rect, XStringFormats.TopLeft);

                //---------------------WORK EXPERIENCE----------------------
                gfx.DrawString("Work Experience", headf, XBrushes.Black,
                  new XRect(265, 310, page.Width, page.Height),
                  XStringFormats.TopLeft);
                //WE 1
                XRect rect1 = new XRect(265, 360, 325, 80);
                gfx.DrawRectangle(XBrushes.White, rect1);
                tf.DrawString(JsonRead.we1, basef, XBrushes.Black, rect1, XStringFormats.TopLeft);
                //WE 2
                XRect rect2 = new XRect(265, 460, 325, 80);
                gfx.DrawRectangle(XBrushes.White, rect2);
                tf.DrawString(JsonRead.we2, basef, XBrushes.Black, rect2, XStringFormats.TopLeft);
                //WE 3
                XRect rect3 = new XRect(265, 560, 325, 80);
                gfx.DrawRectangle(XBrushes.White, rect3);
                tf.DrawString(JsonRead.we3, basef, XBrushes.Black, rect3, XStringFormats.TopLeft);

                //---------------------EDUCATION----------------------
                gfx.DrawString("Education", headf, XBrushes.Black,
                  new XRect(265, 665, page.Width, page.Height),
                  XStringFormats.TopLeft);
                //Education 1
                gfx.DrawString(JsonRead.ed1, basef, XBrushes.Black,
                  new XRect(265, 700, page.Width, page.Height),
                  XStringFormats.TopLeft);
                //Education 2
                gfx.DrawString(JsonRead.ed2, basef, XBrushes.Black,
                  new XRect(265, 720, page.Width, page.Height),
                  XStringFormats.TopLeft);
                //Education 3
                gfx.DrawString(JsonRead.ed3, basef, XBrushes.Black,
                  new XRect(265, 740, page.Width, page.Height),
                  XStringFormats.TopLeft);

                //--------------------LAY OUT----------------------
                //Lines
                gfx.DrawLine(XPens.LightGray, 20, 150, 590, 150);
                gfx.DrawLine(XPens.LightGray, 240, 150, 240, 775);
                gfx.DrawLine(XPens.LightGray, 270, 295, 580, 295);
                gfx.DrawLine(XPens.LightGray, 270, 645, 580, 645);
                XPen pen = new XPen(XColors.Black, 2);
                gfx.DrawLine(pen, 25, 185, 60, 185);
                XPen pen1 = new XPen(XColors.Black, 2);
                gfx.DrawLine(pen1, 25, 440, 60, 440);
                XPen pen2 = new XPen(XColors.Black, 2);
                gfx.DrawLine(pen2, 25, 605, 60, 605);
                XPen pen3 = new XPen(XColors.Black, 2);
                gfx.DrawLine(pen3, 265, 185, 300, 185);
                XPen pen4 = new XPen(XColors.Black, 2);
                gfx.DrawLine(pen4, 265, 335, 300, 335);
                XPen pen5 = new XPen(XColors.Black, 2);
                gfx.DrawLine(pen5, 265, 690, 300, 690);


                // Save the document...
                var dir = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                string filename = dir + "\\Desktop\\Resume.pdf";
                document.Save(filename);
            }
        }
    }   

