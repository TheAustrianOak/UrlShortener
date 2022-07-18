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
        [Display(Name = "Original Url")]
        public string OriginalUrl { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        [Display(Name = "Shorted Url")]
        public string ShortedUrl { get; set; }

        [Column(TypeName = "nvarchar(6)")]
        public string Code { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [Display(Name = "Created At")]
        public string CreatedAt { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }
    }
}
