using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LanguageAssistant.Models;

[Table("LearnedWord")]
public partial class LearnedWord
{
    [Key]
    public int Id { get; set; }

    public int? UserAchivementId { get; set; }

    [ForeignKey("UserAchivementId")]
    [InverseProperty("LearnedWords")]
    public virtual UserAchivement? UserAchivement { get; set; }

    [InverseProperty("LearnedWord")]
    public virtual ICollection<Word> Words { get; } = new List<Word>();
}
