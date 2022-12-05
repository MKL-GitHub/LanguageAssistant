using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LanguageAssistant.Models;

[Table("Word")]
public partial class Word
{
    [Key]
    public int Id { get; set; }

    public int? TextId { get; set; }

    public int? UserLibraryId { get; set; }

    public int? LearnedWordId { get; set; }

    public int? FamiliarWordId { get; set; }

    public int? CollocationId { get; set; }

    [StringLength(50)]
    public string Name { get; set; } = null!;

    [StringLength(50)]
    public string? Transcription { get; set; }

    [ForeignKey("CollocationId")]
    [InverseProperty("Words")]
    public virtual Collocation? Collocation { get; set; }

    [ForeignKey("FamiliarWordId")]
    [InverseProperty("Words")]
    public virtual FamiliarWord? FamiliarWord { get; set; }

    [ForeignKey("LearnedWordId")]
    [InverseProperty("Words")]
    public virtual LearnedWord? LearnedWord { get; set; }

    [ForeignKey("TextId")]
    [InverseProperty("Words")]
    public virtual Text? Text { get; set; }

    [ForeignKey("UserLibraryId")]
    [InverseProperty("Words")]
    public virtual UserLibrary? UserLibrary { get; set; }
}
