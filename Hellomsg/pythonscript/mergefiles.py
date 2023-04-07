#import clr
#clr.AddReference('System')
#from System import *
import sys
#print(sys.version)
#sys.path.append(r'C:\Users\User\AppData\Local\Programs\Python\Python310\Lib')
sys.path.append(r"C:\\Program Files\\IronPython 3.4\\Lib");

import PyPDF2
import os


pdfMerge = PyPDF2.PdfMerger()
pdfiles = ['C:/Users/User/Documents/pdf_files/a.pdf',
        'C:/Users/User/Documents/Anusha.pdf',]
#pdfiles ={
 #       'C:/Users/User/Documents/pdf_files/a.pdf',
     #   'C:/Users/User/Documents/Anusha.pdf',
      #'C:/Users/User/Documents/pdf_files/sample.pdf'
       # }
def merge(pdfiles):
    for filename in pdfiles:
            pdfFile = open(filename, 'rb')
            pdf_reader = PyPDF2.PdfReader(pdfFile)
            pdfMerge.append(pdf_reader)
    pdfFile.close()
    pdfMerge.write('C:\\Users\\User\\Documents\\pdf_files\\merged3.pdf')
    return "Sucessfuly merge pdf files."


if __name__ == "__main__":
   merge(pdfiles)
