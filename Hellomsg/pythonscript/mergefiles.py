#import datetime
#import os


#def merge1(pdfiles):
 #   for i in pdfiles:
 #       print(i)
 #       x = datetime.datetime.now()
 #       print(x)
 #   return "Anu"

#import aspose.words as aw

import sys
print(sys.version)
sys.path.append(r"C:\\Users\\User\\AppData\\Local\\Programs\\Python\\Python310\\Lib\\site-packages\\PyPDF2")

import PyPDF2
import os

pdfMerge = PyPDF2.PdfFileMerger()
pdfiles = []
#pdfiles ={
 #       'C:/Users/User/Documents/pdf_files/a.pdf',
     #   'C:/Users/User/Documents/Anusha.pdf',
      #'C:/Users/User/Documents/pdf_files/sample.pdf'
       # }
def merge(pdfiles):
    for filename in pdfiles:
            pdfFile = open(filename, 'rb')
            pdfReader = PyPDF2.PdfFileReader(pdfFile)
            pdfMerge.append(pdfReader)
    pdfFile.close()
    pdfMerge.write('C://Users//User//Documents//pdf_files//merged.pdf')
    return "Sucessfuly merge pdf files."


if __name__ == "__main__":
   merge(pdfiles)
