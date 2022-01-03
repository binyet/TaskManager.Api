using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TaskManager.Model
{
    public class PageInfo
    {
        [Required]
        [Description("每页数量")]
        [Range(1, 100)]
        public int Limit { get; set; }
        [Required]
        [Description("页数")]
        [Range(1, int.MaxValue)]
        public int Page { get; set; }
    }
}
