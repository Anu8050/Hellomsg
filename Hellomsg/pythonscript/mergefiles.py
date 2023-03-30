# print("hi")
# print("hello")
# person = input('Enter your name: ')
# print(person)

# import sys
    
# class student:
#     def name(self, y):
#         print("My name is", y)
#         return y

# studentObj = student()
# x=input('vcbcvnc: ')
# z = studentObj.name(x)
# print(z)


def sum(a):
    # print("hi",a)
    return a

def arry1(n):
    print(n)
    print("Anusha")
    # x = []
    # x.append(n);
    # print(x)
    # # x.append(m);
    return "Successfully executed the script!"

def arry(n):
    for idx, x in enumerate(n):
        print(idx, x)
    
    return n

def add(n):
    print(n)


def myfunc1(resultFile):
    print("aaa")
    return resultFile



#from pypdf import PdfMerger
#merger = PdfMerger()
def myfunc():

    def myfunc(pdfs):
        for pdf in pdfs:
            print(pdf)
            #merger.append(pdf)
        #merger.write("C://Users//User//Documents//result.pdf")
        #merger.close()
        return pdfs

        




#if __name__ == "__main__":
   #  myfunc1()
     
     
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
     