using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioWebAPI_02.DAL;
using DesafioWebAPI_02.Domain.DTO;
using DesafioWebAPI_02.Domain.Entity;
using DesafioWebAPI_02.Services.Base;
using Microsoft.EntityFrameworkCore;

namespace DesafioWebAPI_02.Services
{
    public class TarefasServices
    {
        private readonly AppDbContext _dbContext;
        public TarefasServices(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        
        public ServiceResponse<Tarefa> CadastrarNovo(TarefasCreateRequests model)
        {

            var novaTarefa = new Tarefa()
            {
                Titulo = model.Titulo,
                Descricao = model.Descricao,
                Prioridade = model.Prioridade ?? 5
            };

            _dbContext.Add(novaTarefa);
            _dbContext.SaveChanges();

            return new ServiceResponse<Tarefa>(novaTarefa);
        }
        public List<Tarefa> ListarTodos()
        {
            return _dbContext.Tarefas.ToList();
        }

        public ServiceResponse<Tarefa> PesquisaPorId(int id)
        {
            var resultado = _dbContext.Tarefas.FirstOrDefault(x => x.IdTarefa == id);
            if(resultado == null)
            {
                return new ServiceResponse<Tarefa>("Tarefa não encontrada");
            } else
            {
                return new ServiceResponse<Tarefa>(resultado);
            }
        }

        public ServiceResponse<Tarefa> EditarConcluido(int id, StatusUpdateRequest model)
        {
            var resultado = _dbContext.Tarefas.FirstOrDefault(x => x.IdTarefa == id);

            if (resultado == null)
            {
                return new ServiceResponse<Tarefa>("Tarefa não encontrada");
            }

            resultado.Concluido = model.Concluido;
            _dbContext.Tarefas.Add(resultado).State = EntityState.Modified;
            _dbContext.SaveChanges();

            return new ServiceResponse<Tarefa>(resultado);
        }
          public ServiceResponse<Tarefa> EditarPrioridade(int id, PrioridadeUpdateRequest model)
        {

            var resultado = _dbContext.Tarefas.FirstOrDefault(x => x.IdTarefa == id);

            if (resultado == null)
            {
                return new ServiceResponse<Tarefa>("Tarefa não encontrada");
            }

            resultado.Prioridade = model.Prioridade;
            _dbContext.Tarefas.Add(resultado).State = EntityState.Modified;
            _dbContext.SaveChanges();

            return new ServiceResponse<Tarefa>(resultado);
        } 

        public ServiceResponse<bool> Deletar(int id)
        {
            var resultado = _dbContext.Tarefas.FirstOrDefault(x => x.IdTarefa == id);

            if (resultado == null) 
            {
                return new ServiceResponse<bool>("Tarefa não encontrada");
            }
            _dbContext.Tarefas.Remove(resultado);
            _dbContext.SaveChanges();

            return new ServiceResponse<bool>(true);
        }
     
    }
}
