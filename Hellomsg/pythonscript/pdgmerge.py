import PyPDF2

# Open the files that have to be merged one by one
pdf1File = open(
    'C://Users//User//Documents//a.pdf', 'rb')
pdf2File = open('C://Users//User//Documents//Anusha.pdf', 'rb')
# pdf3File = open('file3.pdf', 'rb')


# Read the files that you have opened
pdf1Reader = PyPDF2.PdfFileReader(pdf1File)
pdf2Reader = PyPDF2.PdfFileReader(pdf2File)
# pdf3Reader = PyPDF2.PdfFileReader(pdf3File)

pdfWriter = PyPDF2.PdfFileWriter()


for pageNum in range(pdf1Reader.numPages):
    pageObj = pdf1Reader.getPage(pageNum)
    pdfWriter.addPage(pageObj)

for pageNum in range(pdf2Reader.numPages):
    pageObj = pdf2Reader.getPage(pageNum)
    pdfWriter.addPage(pageObj)


# # Loop through all the pagenumbers for the second document
# for pageNum in range(pdf3Reader.numPages):
#     pageObj = pdf3Reader.getPage(pageNum)
#     pdfWriter.addPage(pageObj)

pdfOutputFile = open('C://Users//User//Documents//MergedFiles.pdf', 'wb')
pdfWriter.write(pdfOutputFile)

pdfOutputFile.close()
pdf1File.close()
pdf2File.close()
# pdf3File.close()