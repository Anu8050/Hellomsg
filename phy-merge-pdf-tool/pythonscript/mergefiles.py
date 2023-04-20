import PyPDF2
import os


#def merge1(pdfiles):
#    print(pdfiles)

#pdfiles =[]
#if __name__ == "__main__":
#   merge1(pdfiles)




def merge1(pdfiles,mergefile):
    pdfMerge = PyPDF2.PdfMerger()

    for filename in pdfiles:
        print(filename)
        if os.path.exists(filename) and os.path.getsize(filename) > 0:
            with open(filename, 'rb') as input_file:
                pdf_reader = PyPDF2.PdfReader(input_file)
                pdfMerge.append(pdf_reader)
                input_file.close()

    #with open(dirc + mergefile + '.pdf', 'wb') as mergedFile:
    with open(mergefile, 'wb') as mergedFile:
        pdfMerge.write(mergedFile)
        print(mergedFile)
    #print("Successfully merged pdf files.")
    #return "Successfully merged pdf files."


#'C:/Users/User/Desktop/merged2.pdf'
#dirc = "C://Users//User//Documents//"
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

#from PyPDF2 import PdfFileMerger
#def merge1(pdfiles):
#    merger = PdfFileMerger()
#    mergefile = "C:\\Users\\User\\Documents\\A.pdf"
#    for pdf in pdfiles:
#        try:
#            print("Merging file %s" % pdf)
#            merger.append(pdf)
#        except FileNotFoundError:
#            print("Skipping file %s" % pdf)
#    print("Writing result file")
#    merger.write(mergefile)
#    print(mergefile)
#    merger.close()

#dirc = "C://Users//User//Documents//"
pdfiles = []
#mergefile = ''
#mergefile = "C://Users//User//Documents//A.pdf"
#pdfiles=['C:/Users/User/Documents/Anusha.pdf','C:/Users/User/Documents/Anusha.pdf',]
if __name__ == "__main__":
   merge1(pdfiles)