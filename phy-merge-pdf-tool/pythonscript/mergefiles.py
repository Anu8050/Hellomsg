import PyPDF2

def merge1(pdfiles,merge):
    pdfMerge = PyPDF2.PdfMerger()

    for filename in pdfiles:
        print(filename)
        pdfFile = open(filename,'rb')
        pdf_reader = PyPDF2.PdfReader(pdfFile)
        pdfMerge.append(pdf_reader)
        pdfFile.close()

    with open(merge, 'wb') as mergedFile:
        pdfMerge.write(mergedFile)

    print("Successfully merged pdf files.")
    #return "Successfully merged pdf files."

merge=''
pdfiles=[]
if __name__ == "__main__":
   merge1(pdfiles, merge)

