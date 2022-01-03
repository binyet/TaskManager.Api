using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TaskManager.Entities
{
    public interface IObjectEntity: IEntity<int>
    {
        public int ID { get; set; }
    }

    public interface IEntity<TKey>: IEntity
    {

    }

    public interface IEntity
    {

    }
}
