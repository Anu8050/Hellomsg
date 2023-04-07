import sys
print(sys.version)
import PyPDF2
sys.path.append("C:\Program Files\IronPython 3.4\Lib")
print(sys.path)


def merge(pdfiles):
    print(pdfiles)
    return "hi"



pdfMerge = PyPDF2.PdfMerger()
pdfiles = ['C:/Users/User/Documents/pdf_files/sample.pdf','C:/Users/User/Documents/pdf_files/sample.pdf']
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
    print("Sucessfuly merge pdf files.")
    return "Sucessfuly merge pdf files."
    

if __name__ == "__main__":
   merge1(pdfiles)
