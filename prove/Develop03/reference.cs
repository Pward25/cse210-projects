class Reference
{
    public string Book { get; }
    public int Chapter { get; }
    public int VerseStart { get; }
    public int? VerseEnd { get; }

    public Reference(string book, int chapter, int verseStart, int? verseEnd = null)
    {
        Book = book;
        Chapter = chapter;
        VerseStart = verseStart;
        VerseEnd = verseEnd;
    }

    public void Display()
    {
        if (VerseEnd.HasValue)
            Console.WriteLine($"{Book} {Chapter}:{VerseStart}-{VerseEnd}");
        else
            Console.WriteLine($"{Book} {Chapter}:{VerseStart}");
    }
}