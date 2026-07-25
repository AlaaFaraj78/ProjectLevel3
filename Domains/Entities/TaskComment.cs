using System;
using System.Collections.Generic;
using System.Text;

namespace Pioneersacademy.Domains.Entities
{
    public class TaskComment: BaseEntity
    {
        public string Comment { get; set; }


        public int UserId { get; set; }
        public User User { get; set; }
    }
}
