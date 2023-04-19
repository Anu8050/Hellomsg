import PyPDF2
import os

def merge1(pdfiles,mergefile):
    pdfMerge = PyPDF2.PdfMerger()

    for filename in pdfiles:
        #print(filename)
        #if os.path.exists(filename) and os.path.getsize(filename) > 0:
        with open(filename, 'rb') as input_file:
            pdf_reader = PyPDF2.PdfReader(input_file)
            pdfMerge.append(pdf_reader)
            input_file.close()

    #with open(dirc + mergefile + '.pdf', 'wb') as mergedFile:
    with open(mergefile, 'wb') as mergedFile:
        pdfMerge.write(mergedFile)

    #print("Successfully merged pdf files.")
    #return "Successfully merged pdf files."

#dirc = "C:/Users/User/Documents/"
pdfiles = []
mergefile = ''
#pdfiles=['C:/Users/User/Documents/Anusha.pdf','C:/Users/User/Documents/Anusha.pdf',]
if __name__ == "__main__":
   merge1(pdfiles, mergefile)



#import PyPDF2

#def merge1(pdfiles):
#    pdfMerge = PyPDF2.PdfMerger()

#    for filename in pdfiles:
#        print(filename)
#        pdfFile = open(filename,'rb')
#        pdf_reader = PyPDF2.PdfReader(pdfFile)
#        pdfMerge.append(pdf_reader)
#        pdfFile.close()

#    with open('C://Users//User//Documents//merged2.pdf', 'wb') as mergedFile:
#        pdfMerge.write(mergedFile)

#    print("Successfully merged pdf files.")
#    return "Successfully merged pdf files."


#pdfiles=[]
##pdfiles=['C:/Users/User/Documents/Anusha.pdf','C:/Users/User/Documents/Anusha.pdf',]
#if __name__ == "__main__":
#   merge1(pdfiles)
