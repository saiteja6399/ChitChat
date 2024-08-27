using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    [Table("Photos")]
    public class Photo
    {
        public int Id { get; set; }
        public required string Url { get; set; }
        public required bool IsMain { get; set; }
        public string? PublicId { get; set; }

        //Navigation Properties
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; } = null!;
    }
}