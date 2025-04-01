
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
        private int proximoId = 1; // Gerador de IDs

        public void CriarTarefa(string descricao, string prioridade, string status, string titulo)
        {
            var novaTarefa = new Tarefa
            {
                Id = proximoId++,  // Garante que cada tarefa tem um ID único
                Titulo = titulo,
                Descricao = descricao,
                Prioridade = prioridade,
                Status = status
            };

            tarefas.Add(novaTarefa);
            Console.WriteLine("Tarefa criada com sucesso!");
        }

        // Método para retornar as tarefas
        public List<Tarefa> GetTarefas()
        {
            return tarefas;
        }
    }
}