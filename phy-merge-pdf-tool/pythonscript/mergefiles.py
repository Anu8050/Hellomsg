import PyPDF2

#Creating method Merge pdf d in python.
def mergePdfMethod(pdfFiles,mergeFileName):
    #Merge Pdf function.
    pdfMerge = PyPDF2.PdfMerger()

    for filename in pdfFiles:
        print(filename)
        pdfFile = open(filename,'rb')
        pdf_reader = PyPDF2.PdfReader(pdfFile)
        pdfMerge.append(pdf_reader)
        pdfFile.close()

    with open(mergeFileName, 'wb') as mergedFile:
        pdfMerge.write(mergedFile)

    print("Successfully merged pdf files.")

mergeFileName=''
pdfFiles=[]
if __name__ == "__main__":
   mergePdfMethod(pdfFiles, mergeFileName)

