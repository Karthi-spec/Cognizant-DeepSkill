using System;

interface IImage { void Display(); }

class RealImage : IImage
{
    private string fileName;

    public RealImage(string fileName)
    {
        this.fileName = fileName;
        Console.WriteLine("Loading Image...");
    }

    public void Display()
    {
        Console.WriteLine("Displaying " + fileName);
    }
}