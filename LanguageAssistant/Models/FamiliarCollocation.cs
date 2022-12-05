using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LanguageAssistant.Models;

[Table("FamiliarCollocation")]
public partial class FamiliarCollocation
{
    [Key]
    public int Id { get; set; }

    public int? UserAchivementId { get; set; }

    [InverseProperty("FamiliarCollocation")]
    public virtual ICollection<Collocation> Collocations { get; } = new List<Collocation>();

    [ForeignKey("UserAchivementId")]
    [InverseProperty("FamiliarCollocations")]
    public virtual UserAchivement? UserAchivement { get; set; }
}
