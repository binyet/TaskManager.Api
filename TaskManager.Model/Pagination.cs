using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TaskManager.Model
{
    public class Pagination<T>
    {
        [Description("总数")]
        [Required]
        public int Count { get; set; }
        [Description("当前页数据")]
        [Required]
        public IEnumerable<T> Items { get; set; }
    }
}
