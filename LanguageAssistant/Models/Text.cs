using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LanguageAssistant.Models;

[Table("Text")]
public partial class Text
{
    [Key]
    public int Id { get; set; }

    public int? UserLibraryId { get; set; }

    public int? ReadTextId { get; set; }

    [StringLength(255)]
    public string Name { get; set; } = null!;

    public string Content { get; set; } = null!;

    public int AllWordQuantity { get; set; }

    public int UniqueWordQuantity { get; set; }

    [ForeignKey("ReadTextId")]
    [InverseProperty("Texts")]
    public virtual ReadText? ReadText { get; set; }

    [ForeignKey("UserLibraryId")]
    [InverseProperty("Texts")]
    public virtual UserLibrary? UserLibrary { get; set; }

    [InverseProperty("Text")]
    public virtual ICollection<Word> Words { get; } = new List<Word>();
}
