using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LanguageAssistant.Models;

[Table("FamiliarWord")]
public partial class FamiliarWord
{
    [Key]
    public int Id { get; set; }

    public int? UserAchivementId { get; set; }

    [ForeignKey("UserAchivementId")]
    [InverseProperty("FamiliarWords")]
    public virtual UserAchivement? UserAchivement { get; set; }

    [InverseProperty("FamiliarWord")]
    public virtual ICollection<Word> Words { get; } = new List<Word>();
}
