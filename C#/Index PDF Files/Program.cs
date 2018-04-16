//*****************************************************************************************//
//                                                                                         //
// Download offline evaluation version (DLL): https://bytescout.com/download/web-installer //
//                                                                                         //
// Signup Web API free trial: https://secure.bytescout.com/users/sign_up                   //
//                                                                                         //
// Copyright © 2017-2018 ByteScout Inc. All rights reserved.                               //
// http://www.bytescout.com                                                                //
//                                                                                         //
//*****************************************************************************************//


using System;
using System.IO;
using Bytescout.PDFExtractor;

namespace IndexPDFFiles
{
	class Program
	{
		static void Main(string[] args)
		{
			// Create Bytescout.PDFExtractor.InfoExtractor instance
			InfoExtractor infoExtractor = new InfoExtractor();
			infoExtractor.RegistrationName = "demo";
			infoExtractor.RegistrationKey = "demo";

			TextExtractor textExtractor = new TextExtractor();
			textExtractor.RegistrationName = "demo";
			textExtractor.RegistrationKey = "demo";

			// List all PDF files in directory
			foreach (string file in Directory.GetFiles(@"..\..\..\..", "*.pdf"))
			{
				infoExtractor.LoadDocumentFromFile(file);

				Console.WriteLine("File Name:      " + Path.GetFileName(file));
				Console.WriteLine("Page Count:     " + infoExtractor.GetPageCount());
				Console.WriteLine("Author:         " + infoExtractor.Author);
				Console.WriteLine("Title:          " + infoExtractor.Title);
				Console.WriteLine("Producer:       " + infoExtractor.Producer);
				Console.WriteLine("Subject:        " + infoExtractor.Subject);
				Console.WriteLine("CreationDate:   " + infoExtractor.CreationDate);
				Console.WriteLine("Text (first 2 lines): ");

				textExtractor.LoadDocumentFromFile(file);
				using (StringReader stringReader = new StringReader(textExtractor.GetTextFromPage(0)))
				{
				    Console.WriteLine(stringReader.ReadLine());
				    Console.WriteLine(stringReader.ReadLine());
				}
				Console.WriteLine();
			    
                infoExtractor.Dispose();
                textExtractor.Dispose();
			}
			
			Console.WriteLine();
			Console.WriteLine("Press any key to continue...");
			Console.ReadLine();
		}
	}
}
