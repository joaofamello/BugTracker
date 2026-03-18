using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BugTracker.Enums;

namespace BugTracker.Models;

public class Projeto
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [StringLength(100)]
    public required string Nome { get; set; }
    
    [StringLength(200)]
    public required string Descricao { get; set; }
    
    [EnumDataType(typeof(StatusProjeto))]
    public required StatusProjeto Status { get; set; }
    
    public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
    
    public ICollection<Ticket>? Tickets { get; set; } = new List<Ticket>();
}
