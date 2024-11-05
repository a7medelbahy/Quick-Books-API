using System.ComponentModel.DataAnnotations;

namespace Quick_Books.Models
{
    public class Book
    {
        public int Id { get; set; }

        [RegularExpression(@"^[a-zA-Z_ ]{3,50}$", ErrorMessage = "Title Must Be Between 3 to 50 charchters")]
        public string Title { get; set; }

        [RegularExpression(@"^[a-zA-Z_ ]{3,200}$", ErrorMessage = "Description Must Be Between 3 to 200 charchters")]
        public string Description { get; set; }

        [RegularExpression(@"^[a-zA-Z_ ]{3,50}$", ErrorMessage = "Author Name Must Be Between 3 to 50 charchters")]
        public string Author { get; set; }

        public Genre Genre { get; set; }

        public DateTime PublishedDate { get; set; }
    }
}
