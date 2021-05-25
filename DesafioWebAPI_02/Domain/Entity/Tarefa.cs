using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesafioWebAPI_02.Domain.Entity
{
    [Table("Tarefas")]
    public class Tarefa
    {
        [Key]
        public int IdTarefa { get; set; }
        [StringLength(255)]
        public string Titulo { get; set; }
        [StringLength(255)]
        public string Descricao { get; set; }
        public bool Concluido { get; set; }
        public int? Prioridade { get; set; }
    }
}
