using System;
using System.Collections.Generic;

namespace Zamastrov.DataObjects
{
    public partial class CommentImages
    {
        public CommentImages()
        {
            CommentsImagesConn = new HashSet<CommentsImagesConn>();
        }

        public int Id { get; set; }
        public string ImagesName { get; set; }

        public virtual ICollection<CommentsImagesConn> CommentsImagesConn { get; set; }
    }
}
