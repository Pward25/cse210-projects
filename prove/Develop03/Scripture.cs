class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = text.Split(' ').Select(w => new Word(w)).ToList();
    }

    public void Display()
    {
        Console.WriteLine(string.Join(" ", _words.Select(w => w.Display())));
    }

    public void DisplayReference()
    {
        _reference.Display();
    }

    public void HideWords(Random random)
    {
        int wordsToHide = Math.Max(1, _words.Count / 5);
        List<Word> visibleWords = _words.Where(w => !w.IsHidden).ToList();

        if (visibleWords.Count == 0) return;  // Prevent further hiding if all words are hidden

        for (int i = 0; i < wordsToHide && visibleWords.Count > 0; i++)
        {
            Word word = visibleWords[random.Next(visibleWords.Count)];
            word.Hide();
            visibleWords.Remove(word);
        }
    }

    public bool HasVisibleWords()
    {
        return _words.Any(w => !w.IsHidden);
    }
}