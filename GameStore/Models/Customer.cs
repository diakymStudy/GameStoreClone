using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Models;

[Table("Customer")]
public partial class Customer
{
    [Key]
    public int Id { get; set; }

    [StringLength(25)]
    public string Email { get; set; } = null!;

    [StringLength(25)]
    public string Name { get; set; } = null!;

    public int? Phone { get; set; }

    public int? CartId { get; set; }

    [ForeignKey("CartId")]
    [InverseProperty("Customers")]
    public virtual Cart? Cart { get; set; }

    [InverseProperty("Customer")]
    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();
}
