using System;
using System.Collections.Generic;
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

        public string Comment_Date { get; set; }

        public string Comment_String { get; set; }


    }
}
