using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingWiki_Models.Models
{
    public class BookDetail
    {
        #region Other Properties
        [Key]
        public int BookDetail_Id { get; set; }
        public int NumberOfPages { get; set; }
        public int NumberOfChapters { get; set; }
        public string Weight { get; set; } 
        #endregion
        [ForeignKey("Book")]
        public int Book_Id { get; set; }
        public Book Book { get; set; }
    }
}
