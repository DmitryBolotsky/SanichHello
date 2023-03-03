using System;
using System.Collections.Generic;

namespace Zamastrov.DataObjects
{
    public partial class Comments
    {
        public Comments()
        {
            CommentsImagesConn = new HashSet<CommentsImagesConn>();
        }

        public int Id { get; set; }
        public int SourceId { get; set; }
        public int UserId { get; set; }
        public int? CommentAnswerId { get; set; }
        public string Text { get; set; }
        public int Score { get; set; }
        public DateTime Date { get; set; }
        public int SourceType { get; set; }

        public virtual Master Source { get; set; }
        public virtual Organization SourceNavigation { get; set; }
        public virtual ICollection<CommentsImagesConn> CommentsImagesConn { get; set; }
    }
}
