using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LanguageAssistant.Models;

[Table("ReadText")]
public partial class ReadText
{
    [Key]
    public int Id { get; set; }

    public int? UserAchivementId { get; set; }

    [InverseProperty("ReadText")]
    public virtual ICollection<Text> Texts { get; } = new List<Text>();

    [ForeignKey("UserAchivementId")]
    [InverseProperty("ReadTexts")]
    public virtual UserAchivement? UserAchivement { get; set; }
}
