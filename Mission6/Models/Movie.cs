using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission06_Goddard.Models
{
    public class Movie /* MovieId as PK. Title, Year, Edited and CopiedToPlex are all required fields.
                        * Year must be between 1888 and 2026. 
                        * CategoryId is a FK that links to Category model/table.
                          CategoryId, Director, Rating, LentTo, and Notes are all optional fields */
    {
        [Key]
        [Required]
        public int MovieId { get; set; }
        [ForeignKey("CategoryId")]
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
        [Required(ErrorMessage = "Title Required")]
        public string? Title { get; set; }
        [Required(ErrorMessage = "Year Required")]
        [Range(1888,2026, ErrorMessage = "Year must be between 1888 and 2026")]
        public int? Year { get; set; }
        public string? Director { get; set; }
        public string? Rating { get; set; }
        [Required(ErrorMessage = "Edited? Required")]
        public int? Edited { get; set; }
        public string? LentTo { get; set; }
        [Required(ErrorMessage = "Copied To Plex? Requried")]
        public int? CopiedToPlex { get; set; }
        public string? Notes { get; set; }

    }
}
