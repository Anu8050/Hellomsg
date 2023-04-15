
import PyPDF2 
import os

def merge1(pdfiles, mergepdf_filename):
    pdfMerge = PyPDF2.PdfMerger()
    
    for filename in pdfiles:
        print(filename)
        pdfFile = open(filename,'rb')
        pdf_reader = PyPDF2.PdfReader(pdfFile)
        pdfMerge.append(pdf_reader)
        pdfFile.close()
    

    if (directory + mergepdf_filename +'.pdf') == os.path.isfile(directory + mergepdf_filename +'.pdf'):
        print("true")

        with open(directory + mergepdf_filename +'.pdf', 'wb') as mergedFile:
            pdfMerge.write(mergedFile)
    
    else: 
        print("false")

    #C://Users//User//Documents// +{mergepdf_filename} +.pdf
    print("Successfully merged pdf files.")
    #return "Merged file is created in " + directory + mergepdf_filename +'.pdf';

directory = "C://Users//User//Documents//"
pdfiles=[]
mergepdf_filename = ''
#mergepdf_filename='anu1'
#pdfiles=['C:/Users/User/Documents/Anusha.pdf','C:/Users/User/Documents/Anusha.pdf']
if __name__ == "__main__":
   merge1(pdfiles, mergepdf_filename)

