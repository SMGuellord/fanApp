using FanApp.Common.Models.Database;
using System.ComponentModel.DataAnnotations.Schema;

namespace FanApp.Common.Models
{
    public class Comment : DbEntity
    {
        public  string Commentary { get; set; }

        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }
        public virtual User CommentPoster { get; set; }
    }
}
