using System.ComponentModel.DataAnnotations;

namespace RZAWebApp.Models
{
    public class Articles
    {
        [Key]
        public int ArticleID { get; set; }

        public string ArticleTitle { get; set; }

        public string ArticleContent { get; set; }

        public string WrittenBy { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreationDate { get; set; }

        public int ImageID { get; set; }

        public string? Tags { get; set; }
    }
}
