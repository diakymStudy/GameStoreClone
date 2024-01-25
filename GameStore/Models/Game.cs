using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Models;

[Table("Game")]
public partial class Game
{
    [Key]
    public int Id { get; set; }

    [StringLength(25)]
    public string Name { get; set; } = null!;

    public int Year { get; set; }

    [StringLength(20)]
    public string? Publisher { get; set; }

    [Column(TypeName = "money")]
    public decimal Price { get; set; }

    public double? Rating { get; set; }

    [StringLength(20)]
    public string Category { get; set; } = null!;

    [InverseProperty("Game1Navigation")]
    public virtual ICollection<Cart> CartGame1Navigations { get; set; } = new List<Cart>();

    [InverseProperty("Game2Navigation")]
    public virtual ICollection<Cart> CartGame2Navigations { get; set; } = new List<Cart>();
}
