﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingWiki_Models.Models
{
    public class Fluent_Publisher
    {
        public int Publisher_Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        //public List<Book> Books { get; set; }
    }
}
