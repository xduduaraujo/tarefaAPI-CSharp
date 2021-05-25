using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioWebAPI_02.Domain.DTO
{
    public class PrioridadeUpdateRequest
    {
        [Range(1, 5, ErrorMessage = "A prioridade da tarefa deve ser entre 1 e 5.")]
        public int? Prioridade { get; set; }
    }
}
