using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LanguageAssistant.Models;

[Table("User")]
public partial class User
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; } = null!;

    [Required]
    [StringLength(10)]
    public string Password { get; set; } = null!;

    [InverseProperty("User")]
    public virtual ICollection<UserAchivement> UserAchivements { get; } = new List<UserAchivement>();

    [InverseProperty("User")]
    public virtual ICollection<UserLibrary> UserLibraries { get; } = new List<UserLibrary>();
}
