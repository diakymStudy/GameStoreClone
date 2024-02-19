using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Models;

[Table("Album")]
public partial class Album
{
    [Key]
    public int Id { get; set; }
}
