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

        




if __name__ == "__main__":
     myfunc1(resultFile)
    
     
from PyPDF2 import PdfFileMerger
import os

#Create an instance of PdfFileMerger() class
merger = PdfFileMerger()

#Define the path to the folder with the PDF files

path_to_files = r'C://Users//User//Documents//'    
def merge(path_to_files)
    
    
    #Get the file names in the directory
    for root, dirs, file_names in os.walk(path_to_files):
        #Iterate over the list of the file names
        for file_name in file_names:
            #Append PDF files
            merger.append(path_to_files + file_name)

    #Write out the merged PDF file
    merger.write("merged_all_pages.pdf")
    merger.close()


if __name__ == "__main__":
     merge(path_to_files)