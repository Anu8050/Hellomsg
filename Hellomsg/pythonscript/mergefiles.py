#import datetime
#import os


#def merge1(pdfiles):
 #   for i in pdfiles:
 #       print(i)
 #       x = datetime.datetime.now()
 #       print(x)
 #   return "Anu"

import aspose.words as aw
# -*- coding: utf-8 -*-
#import sys
#sys.path.append(r"C:\Users\User\AppData\Local\Programs\Python\Python310\Lib\site-packages\PyPDF2")

#import PyPDF2
#import os


#pdfMerge = PyPDF2.PdfFileMerger()
#pdfiles = []
pdfiles ={
        'C:/Users/User/Documents/pdf_files/a.pdf',
        'C:/Users/User/Documents/Anusha.pdf',
      'C:/Users/User/Documents/pdf_files/sample.pdf'
        }
def merge(pdfiles):
    #for filename in pdfiles:
     #       pdfFile = open(filename, 'rb')
      #      pdfReader = PyPDF2.PdfFileReader(pdfFile)
       #     pdfMerge.append(pdfReader)
    #pdfFile.close()
    #pdfMerge.write('C://Users//User//Documents//pdf_files//merged.pdf')

    output = aw.Document()
    # Remove all content from the destination document before appending.
    output.remove_all_children()

    for fileName in pdfiles:
        input = aw.Document(fileName)
        # Append the source document to the end of the destination document.
        output.append_document(input, aw.ImportFormatMode.KEEP_SOURCE_FORMATTING)

    output.save("C://Users//User//Documents//pdf_files//Output.pdf");
    return "Sucessfuly merge pdf files."


if __name__ == "__main__":
   merge(pdfiles)
