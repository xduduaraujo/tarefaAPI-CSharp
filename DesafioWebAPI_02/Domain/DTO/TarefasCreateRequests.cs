using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioWebAPI_02.Domain.DTO
{
    public class TarefasCreateRequests
    {
        [Required]
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        [Range(1, 5, ErrorMessage = "A prioridade da tarefa deve ser entre 1 e 5.")] 
        public int? Prioridade { get; set; }
    }
}
