using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models.ViewModels
{
    public class CommentVM
    {
        public Comment Comment { get; set; }

        public IEnumerable<Comment> IEComment { get; set; } //Multiple comment models in one model
    }
}
