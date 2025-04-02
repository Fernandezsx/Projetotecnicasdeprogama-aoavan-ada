
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace ProjetoTarefa
{
    public class TarefaService
    {
        private List<Tarefa> tarefas = new List<Tarefa>();
        private int proximoId; // Gerador de IDs

        public TarefaService(int ultimoId)
        {
            proximoId = ultimoId + 1;
        }

        public void CriarTarefa(string descricao, string prioridade, string status, string titulo)
        {

                var novaTarefa = new Tarefa { Id = proximoId++, Descricao = descricao, 
                Prioridade = prioridade, Status = status, Titulo = titulo };
                tarefas.Add(novaTarefa);
                Console.WriteLine("Tarefa adicionada com sucesso!");
                
        }

        // Método para retornar as tarefas
        public List<Tarefa> GetTarefas()
        {
            return tarefas;
        }
    }
}