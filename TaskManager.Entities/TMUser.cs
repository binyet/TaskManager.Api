using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TaskManager.Entities
{
    [Table("TMUser")]
    public class TMUser
    {
        [Key]
        public int ID { get; set; }
        public string UserName { get; set; }

    }
}
