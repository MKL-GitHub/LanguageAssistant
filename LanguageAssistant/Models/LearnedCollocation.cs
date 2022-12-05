using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LanguageAssistant.Models;

[Table("LearnedCollocation")]
public partial class LearnedCollocation
{
    [Key]
    public int Id { get; set; }

    public int? UserAchivementId { get; set; }

    [InverseProperty("LearnedCollocation")]
    public virtual ICollection<Collocation> Collocations { get; } = new List<Collocation>();

    [ForeignKey("UserAchivementId")]
    [InverseProperty("LearnedCollocations")]
    public virtual UserAchivement? UserAchivement { get; set; }
}
