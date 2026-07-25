using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Pioneersacademy.Domains.Entities;

public class BaseEntity
{

    [Key]
    public int Id { get; set; }
    
    public bool IsDeleted { get; set; }
    
    public DateTime CreatedDate { get; set; }
    
    public DateTime UpdatedDate { get; set; }
}
