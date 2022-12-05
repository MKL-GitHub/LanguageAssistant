using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LanguageAssistant.Models;

[Table("UserLibrary")]
public partial class UserLibrary
{
    [Key]
    public int Id { get; set; }

    public int UserId { get; set; }

    public int? LearnedWordQuantity { get; set; }

    public int? FamiliarWordQuantity { get; set; }

    public int? LearnedCollocationQuantity { get; set; }

    public int? FamiliarCollocationQuantity { get; set; }

    [InverseProperty("UserLibrary")]
    public virtual ICollection<Text> Texts { get; } = new List<Text>();

    [ForeignKey("UserId")]
    [InverseProperty("UserLibraries")]
    public virtual User User { get; set; } = null!;

    [InverseProperty("UserLibrary")]
    public virtual ICollection<Word> Words { get; } = new List<Word>();
}
