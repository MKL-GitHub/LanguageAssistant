using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LanguageAssistant.Models;

[Table("UserAchivement")]
public partial class UserAchivement
{
    [Key]
    public int Id { get; set; }

    public int UserId { get; set; }

    [InverseProperty("UserAchivement")]
    public virtual ICollection<FamiliarCollocation> FamiliarCollocations { get; } = new List<FamiliarCollocation>();

    [InverseProperty("UserAchivement")]
    public virtual ICollection<FamiliarWord> FamiliarWords { get; } = new List<FamiliarWord>();

    [InverseProperty("UserAchivement")]
    public virtual ICollection<LearnedCollocation> LearnedCollocations { get; } = new List<LearnedCollocation>();

    [InverseProperty("UserAchivement")]
    public virtual ICollection<LearnedWord> LearnedWords { get; } = new List<LearnedWord>();

    [InverseProperty("UserAchivement")]
    public virtual ICollection<ReadText> ReadTexts { get; } = new List<ReadText>();

    [ForeignKey("UserId")]
    [InverseProperty("UserAchivements")]
    public virtual User User { get; set; } = null!;
}
