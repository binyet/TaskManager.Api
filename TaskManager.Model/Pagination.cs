using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TaskManager.Model
{
    public class Pagination<T>
    {
        [Description("总数")]
        public int Count { get; set; }
        [Description("当前页数据")]
        public IEnumerable<T> Items { get; set; }
    }
}
