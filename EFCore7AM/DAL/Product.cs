using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL
{
    [Table("Products",Schema ="dbo")]
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        [Column(TypeName ="varchar(200)")]
        public string Name { get; set; }
        [Required]
        [Column(TypeName = "varchar(200)")]
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        //[ForeignKey("Category")]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
    }
}
