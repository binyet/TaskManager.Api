using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TaskManager.Entities
{
    [Table("TMUser")]
    public class TMUser: IEntity
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [StringLength(64)]
        public string UserName { get; set; }
        [Required]
        [StringLength(64)]
        public string UserAccount { get; set; }
        [Required]
        [StringLength(128)]
        public string Password { get; set; }


    }
}
