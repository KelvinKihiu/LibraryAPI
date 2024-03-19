using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Models
{
    /// <summary>
    /// Represents the base model for the project
    /// </summary>
    public record Book
    {
        /// <summary>
        /// The Id of the book as a GUID string
        /// </summary>
        public string Id { get; set; } = string.Empty;
        /// <summary>
        /// The title of the book
        /// </summary>
        [Required]
        public string Title { get; set; }
        /// <summary>
        /// A breif description of the book
        /// </summary>
        public string? Description { get; set; }
        /// <summary>
        /// The author of the book
        /// </summary>
        [Required]
        public string Author { get; set; }
        /// <summary>
        /// The publication date
        /// </summary>
        [Required]
        public DateTime PublicationDate { get; set; }
    }
}
