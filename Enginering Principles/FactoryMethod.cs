using System;

interface IDocument { void Open(); }

class PdfDocument : IDocument
{
    public void Open() => Console.WriteLine("PDF Document Opened");
}

abstract class DocumentFactory
{
    public abstract IDocument CreateDocument();
}

class PdfFactory : DocumentFactory
{
    public override IDocument CreateDocument() => new PdfDocument();
}

class Program
{
    static void Main()
    {
        IDocument doc = new PdfFactory().CreateDocument();
        doc.Open();
    }
}