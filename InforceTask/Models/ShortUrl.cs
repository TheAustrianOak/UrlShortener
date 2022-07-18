using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InforceTask.Models
{
    public class ShortUrl
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(3999)")]
        public string OriginalUrl { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        public string ShortedUrl { get; set; }

        [Column(TypeName = "nvarchar(6)")]
        public string Code { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string CreatedAt { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string CreatedBy { get; set; }
    }
}
