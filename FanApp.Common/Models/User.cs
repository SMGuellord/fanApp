using FanApp.Common.Models.Database;
using System.ComponentModel.DataAnnotations.Schema;

namespace FanApp.Common.Models
{
    public class User : DbEntity
    {
        public string Fistname { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public DateTime DOB { get; set; }

        [InverseProperty("CommentPoster")]
        public virtual List<Comment>? Comments { get; set; }
    }
}
