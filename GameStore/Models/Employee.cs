using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Models;

[Table("Employee")]
public partial class Employee
{
    [Key]
    public int Id { get; set; }

    [StringLength(25)]
    public string Email { get; set; } = null!;

    [StringLength(25)]
    public string Password { get; set; } = null!;

    [StringLength(25)]
    public string Name { get; set; } = null!;

    public int? Phone { get; set; }
}
