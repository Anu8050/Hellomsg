#from PyPDF2 import PdfFileMerger
import PyPDF2
import os
pdfMerge = PyPDF2.PdfFileMerger()
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

if __name__ == "__main__":
   merge(pdfiles)
     