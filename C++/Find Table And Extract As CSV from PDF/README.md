## How to find table and extract as CSV from PDF in C++ using ByteScout PDF Extractor SDK

### The tutorial shows how to find table and extract as CSV from PDF in C++

This sample source code below will demonstrate you how to find table and extract as CSV from PDF in C++. ByteScout PDF Extractor SDK: the SDK that helps developers to extract data from unstructured documents, pdf, images, scanned and electronic forms. Includes AI functions like automatic table detection, automatic table extraction and restructuring, text recognition and text restoration from pdf and scanned documents. Includes PDF to CSV, PDF to XML, PDF to JSON, PDF to searchable PDF functions as well as methods for low level data extraction. It can find table and extract as CSV from PDF in C++.

This code snippet below for ByteScout PDF Extractor SDK works best when you need to quickly find table and extract as CSV from PDF in your C++ application. In your C++ project or application you may simply copy & paste the code and then run your app! Code testing will allow the function to be tested and work properly with your data.

Trial version of ByteScout PDF Extractor SDK is available for free. Source code samples are included to help you with your C++ app.

## REQUEST FREE TECH SUPPORT

[Click here to get in touch](https://bytescout.zendesk.com/hc/en-us/requests/new?subject=ByteScout%20PDF%20Extractor%20SDK%20Question)

or just send email to [support@bytescout.com](mailto:support@bytescout.com?subject=ByteScout%20PDF%20Extractor%20SDK%20Question) 

## ON-PREMISE OFFLINE SDK 

[Get Your 60 Day Free Trial](https://bytescout.com/download/web-installer?utm_source=github-readme)
[Explore SDK Docs](https://bytescout.com/documentation/index.html?utm_source=github-readme)
[Sign Up For Online Training](https://academy.bytescout.com/)


## ON-DEMAND REST WEB API

[Get your API key](https://pdf.co/documentation/api?utm_source=github-readme)
[Explore Web API Documentation](https://pdf.co/documentation/api?utm_source=github-readme)
[Explore Web API Samples](https://github.com/bytescout/ByteScout-SDK-SourceCode/tree/master/PDF.co%20Web%20API)

## VIDEO REVIEW

[https://www.youtube.com/watch?v=s28W3_KMraU](https://www.youtube.com/watch?v=s28W3_KMraU)




<!-- code block begin -->

##### ****FindTableAndExtractAsCsv.cpp:**
    
```
#include "stdafx.h"
#include "comip.h"

#import "c:\\Program Files\\Bytescout PDF Extractor SDK\\net4.00\\Bytescout.PDFExtractor.tlb" raw_interfaces_only

using namespace Bytescout_PDFExtractor;

int _tmain(int argc, _TCHAR* argv[])
{
	// Initialize COM.
	HRESULT hr = CoInitializeEx(NULL, COINIT_APARTMENTTHREADED);

	// Create CSVExtractor instance
	_CSVExtractorPtr pICSVExtractor(__uuidof(CSVExtractor));
	pICSVExtractor->put_RegistrationName(_bstr_t(L"DEMO"));
	pICSVExtractor->put_RegistrationKey(_bstr_t(L"DEMO"));

	// Create TableDetector instance
	_TableDetectorPtr pITableDetector(__uuidof(TableDetector));
	pITableDetector->put_RegistrationName(_bstr_t(L"DEMO"));
	pITableDetector->put_RegistrationKey(_bstr_t(L"DEMO"));

	// Set table detection mode to "bordered tables" - best for tables with closed solid borders.
	pITableDetector->put_ColumnDetectionMode(ColumnDetectionMode_BorderedTables);

	// We should define what kind of tables we should detect.
	// So we set min required number of columns to 2 ...
	pITableDetector->put_DetectionMinNumberOfColumns(2);
	// ... and we set min required number of rows to 2
	pITableDetector->put_DetectionMinNumberOfRows(2);

	// Load sample PDF document
	_bstr_t inputFile(L"..\\..\\sample3.pdf");
	pICSVExtractor->LoadDocumentFromFile(inputFile);
	pITableDetector->LoadDocumentFromFile(inputFile);

	// Get page count
	long pageCount;
	pITableDetector->GetPageCount(&pageCount);

	for (int pageIndex = 0; pageIndex < pageCount; pageIndex++)
	{
		int t = 1;
		VARIANT_BOOL vbResult;

		// Find first table and continue if found
		pITableDetector->FindTable(pageIndex, &vbResult);
		if (vbResult == VARIANT_TRUE)
		{
			do
			{
				float left, top, width, height;
				pITableDetector->GetFoundTableRectangle_Left(&left);
				pITableDetector->GetFoundTableRectangle_Top(&top);
				pITableDetector->GetFoundTableRectangle_Width(&width);
				pITableDetector->GetFoundTableRectangle_Height(&height);

				// Set extraction area for CSV extractor to rectangle received from the table detector
				pICSVExtractor->SetExtractionArea(left, top, width, height);
				// Export the table to CSV file
				CString fileName;
				fileName.Format(L"page-%d-table-%d.csv", pageIndex, t);
				pICSVExtractor->SavePageCSVToFile(pageIndex, _bstr_t(fileName));
				t++;

				pITableDetector->FindNextTable(&vbResult);
			} while (vbResult == VARIANT_TRUE);
		}
	}

	pICSVExtractor->Release();
	pITableDetector->Release();

	CoUninitialize();

	return 0;
}


```

<!-- code block end -->    

<!-- code block begin -->

##### ****FindTableAndExtractAsCsv.sln:**
    
```

Microsoft Visual Studio Solution File, Format Version 12.00
# Visual Studio 2013
VisualStudioVersion = 12.0.40629.0
MinimumVisualStudioVersion = 10.0.40219.1
Project("{8BC9CEB8-8B4A-11D0-8D11-00A0C91BC942}") = "FindTableAndExtractAsCsv", "FindTableAndExtractAsCsv.vcxproj", "{74A23FC0-E323-4980-9363-41326A457785}"
EndProject
Global
	GlobalSection(SolutionConfigurationPlatforms) = preSolution
		Debug|Win32 = Debug|Win32
		Release|Win32 = Release|Win32
	EndGlobalSection
	GlobalSection(ProjectConfigurationPlatforms) = postSolution
		{74A23FC0-E323-4980-9363-41326A457785}.Debug|Win32.ActiveCfg = Debug|Win32
		{74A23FC0-E323-4980-9363-41326A457785}.Debug|Win32.Build.0 = Debug|Win32
		{74A23FC0-E323-4980-9363-41326A457785}.Release|Win32.ActiveCfg = Release|Win32
		{74A23FC0-E323-4980-9363-41326A457785}.Release|Win32.Build.0 = Release|Win32
	EndGlobalSection
	GlobalSection(SolutionProperties) = preSolution
		HideSolutionNode = FALSE
	EndGlobalSection
EndGlobal

```

<!-- code block end -->    

<!-- code block begin -->

##### ****stdafx.cpp:**
    
```
// stdafx.cpp : source file that includes just the standard includes
// CPPExample.pch will be the pre-compiled header
// stdafx.obj will contain the pre-compiled type information

#include "stdafx.h"

// TODO: reference any additional headers you need in STDAFX.H
// and not in this file

```

<!-- code block end -->    

<!-- code block begin -->

##### ****stdafx.h:**
    
```
// stdafx.h : include file for standard system include files,
// or project specific include files that are used frequently, but
// are changed infrequently
//

#pragma once

#include "targetver.h"

#include <stdio.h>
#include <tchar.h>

// TODO: reference additional headers your program requires here

#include <atlstr.h>
```

<!-- code block end -->    

<!-- code block begin -->

##### ****targetver.h:**
    
```
#pragma once

// Including SDKDDKVer.h defines the highest available Windows platform.

// If you wish to build your application for a previous Windows platform, include WinSDKVer.h and
// set the _WIN32_WINNT macro to the platform you wish to support before including SDKDDKVer.h.

#include <SDKDDKVer.h>

```

<!-- code block end -->