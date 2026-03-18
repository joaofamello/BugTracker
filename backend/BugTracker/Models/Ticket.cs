using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BugTracker.Enums;

namespace BugTracker.Models;

public class Ticket
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [StringLength(100)]
    public required string Titulo { get; set; }
    
    [StringLength(500)]
    public required string Descricao { get; set; }
    
    // perguntar do enum data type
    public required StatusTicket Status { get; set; }
    public DateTime DataCriacao { get; set; }
    
    [ForeignKey("Projeto")]
    public required int ProjetoId { get; set; }
    public Projeto? Projeto { get; set; }
}