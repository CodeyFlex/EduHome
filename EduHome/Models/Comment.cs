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
        public string Comment_String { get; set; }


    }
}
