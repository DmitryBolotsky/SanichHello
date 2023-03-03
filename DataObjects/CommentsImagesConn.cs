using System;
using System.Collections.Generic;

namespace Zamastrov.DataObjects
{
    public partial class CommentsImagesConn
    {
        public int Id { get; set; }
        public int IdComments { get; set; }
        public int IdImg { get; set; }

        public virtual Comments IdCommentsNavigation { get; set; }
        public virtual CommentImages IdImgNavigation { get; set; }
    }
}
