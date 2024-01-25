using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Models;

[Table("Cart")]
public partial class Cart
{
    [Key]
    public int Id { get; set; }

    public int? CustomerId { get; set; }

    public int? Game1 { get; set; }

    public int? Game2 { get; set; }

    public int? Game3 { get; set; }

    public int? Game4 { get; set; }

    public int? Game5 { get; set; }

    public int? Game6 { get; set; }

    [ForeignKey("CustomerId")]
    [InverseProperty("Carts")]
    public virtual Customer? Customer { get; set; }

    [InverseProperty("Cart")]
    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

    [ForeignKey("Game1")]
    [InverseProperty("CartGame1Navigations")]
    public virtual Game? Game1Navigation { get; set; }

    [ForeignKey("Game2")]
    [InverseProperty("CartGame2Navigations")]
    public virtual Game? Game2Navigation { get; set; }
}
