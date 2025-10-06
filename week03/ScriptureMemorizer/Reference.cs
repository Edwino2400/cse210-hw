public class Reference
{
    private string book;
    private int startChapter;
    private int startVerse;
    private int? endVerse;

    public Reference(string book, int chapter, int verse)
    {
        this.book = book;
        this.startChapter = chapter;
        this.startVerse = verse;
        this.endVerse = null;
    }

    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        this.book = book;
        this.startChapter = chapter;
        this.startVerse = startVerse;
        this.endVerse = endVerse;
    }

    public string GetDisplayText()
    {
        if (endVerse.HasValue)
        {
            return $"{book} {startChapter}:{startVerse}-{endVerse}";
        }
        return $"{book} {startChapter}:{startVerse}";
    }
}
