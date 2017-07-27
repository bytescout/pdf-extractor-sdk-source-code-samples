//*******************************************************************
//       ByteScout PDF Extractor SDK		                                     
//                                                                   
//       Copyright © 2016 ByteScout - http://www.bytescout.com       
//       ALL RIGHTS RESERVED                                         
//                                                                   
//*******************************************************************

	#include "stdafx.h"
	#include "comip.h"

	#import "c:\\Program Files\\Bytescout PDF Extractor SDK\\net4.00\\Bytescout.PDFExtractor.tlb" raw_interfaces_only

	using namespace Bytescout_PDFExtractor;

	int _tmain(int argc, _TCHAR* argv[])
	{
		// Initialize COM.
		HRESULT hr = CoInitializeEx(NULL, COINIT_APARTMENTTHREADED);

		// Create the interface pointer.
		_TextExtractorPtr pITextExtractor(__uuidof(TextExtractor));

		// Set the registration name and key
		// Note: You should use _bstr_t or BSTR to pass string to the library because of COM requirements
		_bstr_t bstrRegName(L"DEMO"); 
		pITextExtractor->put_RegistrationName(bstrRegName);
		
		_bstr_t bstrRegKey(L"DEMO");
		pITextExtractor->put_RegistrationKey(bstrRegKey);

		// Load sample PDF document
		_bstr_t bstrPath(L"..\\..\\sample_ocr.pdf");
		pITextExtractor->LoadDocumentFromFile(bstrPath);

		// Enable Optical Character Recognition (OCR)
		// in .Auto mode (SDK automatically checks if needs to use OCR or not)
		pITextExtractor->put_OCRMode(OCRMode_Auto);
		
		// Set the location of "tessdata" folder containing language data files
		_bstr_t bstrOCRLangDataPath(L"c:\\Program Files\\Bytescout PDF Extractor SDK\\net4.00\\tessdata");
		pITextExtractor->put_OCRLanguageDataFolder(bstrOCRLangDataPath);

		// Set OCR language
		_bstr_t bstrOCRLanguage(L"eng");
		pITextExtractor->put_OCRLanguage(bstrOCRLanguage);

		// Set PDF document rendering resolution
		pITextExtractor->put_OCRResolution(300);

		// Save extracted text to file
		_bstr_t bstrOutputFile(L"output.txt");
		pITextExtractor->SaveTextToFile(bstrOutputFile);

		pITextExtractor->Release();

		CoUninitialize();

		return 0;
	}

