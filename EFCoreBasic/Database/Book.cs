namespace EFCoreBasic.Database;

public class Book
{
    // Mapped to table's columns
    public int BookId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime PublishedOn { get; set; }
    public int AuthorId { get; set; }

    // Navigational property
    public Author Author { get; set; }
}
