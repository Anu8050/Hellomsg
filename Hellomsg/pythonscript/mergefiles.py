import imp
PyPDF2 =imp.load_source('PyPDF2', 'C:\Users\User\AppData\Local\Programs\Python\Python310\Lib\site-packages\PyPDF2\__init__.py')
import os

def merge(pdfiles):
    print(pdfiles)
    return "hi"

import sys; 
print(sys.path)

pdfMerge = PyPDF2.PdfMerger()
pdfiles = []
#pdfiles ={
 #       'C:/Users/User/Documents/pdf_files/a.pdf',
     #   'C:/Users/User/Documents/Anusha.pdf',
      #'C:/Users/User/Documents/pdf_files/sample.pdf'
       # }
def merge1(pdfiles):
    for filename in pdfiles:
            pdfFile = open(filename, 'rb')
            pdf_reader = PyPDF2.PdfReader(pdfFile)
            pdfMerge.append(pdf_reader)
    pdfFile.close()
    pdfMerge.write('C://Users//User//Documents//pdf_files//merged2.pdf')
    return "Sucessfuly merge pdf files."
    



if __name__ == "__main__":
   merge1(pdfiles)
