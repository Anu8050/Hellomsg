import PyPDF2

def merge1(pdfiles,merge_file_name):
    #Merge Pdf function.
    pdfMerge = PyPDF2.PdfMerger()

    for filename in pdfiles:
        print(filename)
        pdfFile = open(filename,'rb')
        pdf_reader = PyPDF2.PdfReader(pdfFile)
        pdfMerge.append(pdf_reader)
        pdfFile.close()

    with open(merge_file_name, 'wb') as mergedFile:
        pdfMerge.write(mergedFile)

    print("Successfully merged pdf files.")

merge_file_name=''
pdfiles=[]
if __name__ == "__main__":
   merge1(pdfiles, merge_file_name)

