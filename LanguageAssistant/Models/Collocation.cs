using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LanguageAssistant.Models;

[Table("Collocation")]
public partial class Collocation
{
    [Key]
    public int Id { get; set; }

    public int? LearnedCollocationId { get; set; }

    public int? FamiliarCollocationId { get; set; }

    [ForeignKey("FamiliarCollocationId")]
    [InverseProperty("Collocations")]
    public virtual FamiliarCollocation? FamiliarCollocation { get; set; }

    [ForeignKey("LearnedCollocationId")]
    [InverseProperty("Collocations")]
    public virtual LearnedCollocation? LearnedCollocation { get; set; }

    [InverseProperty("Collocation")]
    public virtual ICollection<Word> Words { get; } = new List<Word>();
}
