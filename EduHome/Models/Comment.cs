using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        
        public string Commenter { get; set; }

        [DisplayName("Date")]
        public string Comment_Date { get; set; }

        [DisplayName("Comment")]
        [Required]
        public string Comment_String { get; set; }

        [DisplayName("Likes")]
        public int Comment_Likes { get; set; }

        [DisplayName("Replies")]
        public int Comment_Replies { get; set; }

        public int Comment_Reply_To_Id { get; set; }

        [DisplayName("Highlighted")]
        public bool Comment_Highlighted { get; set; }
    }
}
