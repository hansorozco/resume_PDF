﻿using PdfSharp.Charting;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Pdf;
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
        public static void ReadJsonFile(string jsonFileIn)
        {
            //Reads the Json Text
            dynamic jsonFile = JsonConvert.DeserializeObject(File.ReadAllText(jsonFileIn));

            //Assigning Json Values to Variables
            firstname = $"{jsonFile["firstname"]}";
            lastname = $"{jsonFile["lastname"]}";
            profession = $"{jsonFile["profession"]}";
            add1 = $"{jsonFile["address"]["housenumber and streetname"]}";
            add2 = $"{jsonFile["address"]["city,state,zipcode"]}";
            add3 = $"{jsonFile["address"]["country"]}";
            phone = $"{jsonFile["phone"]}";
            email = $"{jsonFile["email"]}";
            s1 = $"{jsonFile["skills"]["skill1"]}";
            s2 = $"{jsonFile["skills"]["skill2"]}";
            s3 = $"{jsonFile["skills"]["skill3"]}";
            s4 = $"{jsonFile["skills"]["skill4"]}";
            s5 = $"{jsonFile["skills"]["skill5"]}";
            l1 = $"{jsonFile["languages"]["language1"]}";
            l2 = $"{jsonFile["languages"]["language2"]}";
            l3 = $"{jsonFile["languages"]["language3"]}";
            profile = $"{jsonFile["profile"]}";
            we1 = $"{jsonFile["work experience"]["we1"]}";
            we2 = $"{jsonFile["work experience"]["we2"]}";
            we3 = $"{jsonFile["work experience"]["we3"]}";
            ed1 = $"{jsonFile["education"]["education1"]}";
            ed2 = $"{jsonFile["education"]["education2"]}";
            ed3 = $"{jsonFile["education"]["education3"]}";
        }

    }
}
