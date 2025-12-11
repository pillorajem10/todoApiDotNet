using System.ComponentModel.DataAnnotations.Schema;

namespace todoApiDotNet.Models;

[Table("tbl_todos")]
public class Todo
{
    [Column("id")]
    public int Id { get; set; }

    [Column("tbl_todos_title")]
    public string title { get; set; } = string.Empty;

    [Column("tbl_todos_is_complete")]
    public bool isComplete { get; set; }
}
