//*******************************************************************
//       ByteScout PDF Extractor SDK		                                     
//                                                                   
//       Copyright © 2017 ByteScout - http://www.bytescout.com       
//       ALL RIGHTS RESERVED                                         
//                                                                   
//*******************************************************************

using System;
using Bytescout.PDFExtractor;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create Bytescout.PDFExtractor.XMLExtractor instance
            XMLExtractor extractor = new XMLExtractor();
            extractor.RegistrationName = "demo";
            extractor.RegistrationKey = "demo";

            // Load sample PDF document
            extractor.LoadDocumentFromFile("sample1.pdf");

            // Uncomment this line to get rid of empty nodes in XML
            //extractor.PreserveFormattingOnTextExtraction = false;

            // Set output image format
            extractor.ImageFormat = OutputImageFormat.PNG;
            
            // Save images to external files
            extractor.SaveImages = ImageHandling.OuterFile;
            extractor.ImageFolder = "images"; // Folder for external images
            extractor.SaveXMLToFile("result_with_external_images.xml");

            // Embed images into XML as Base64 encoded string
            extractor.SaveImages = ImageHandling.Embed;
            extractor.SaveXMLToFile("result_with_embedded_images.xml");
        }
    }
}
