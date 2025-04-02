
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
        private int proximoId = 1;

        public TarefaService()
        {
            // Construtor sem parâmetros
        }

        public void CriarTarefa(string descricao, string prioridade, string status, string titulo)
        {
            var novaTarefa = new Tarefa 
            { 
                Id = proximoId++, 
                Descricao = descricao, 
                Prioridade = prioridade, 
                Status = status, 
                Titulo = titulo 
            };
            tarefas.Add(novaTarefa);
            Console.WriteLine("Tarefa adicionada com sucesso!");
        }

        public void ListarTarefas()
        {
            if (tarefas.Count == 0)
            {
                Console.WriteLine("Não há tarefas cadastradas.");
                return;
            }

            foreach (var tarefa in tarefas)
            {
                Console.WriteLine($"\nID: {tarefa.Id}");
                Console.WriteLine($"Título: {tarefa.Titulo}");
                Console.WriteLine($"Descrição: {tarefa.Descricao}");
                Console.WriteLine($"Prioridade: {tarefa.Prioridade}");
                Console.WriteLine($"Status: {tarefa.Status}");
            }
        }

        public void DeletarTarefa(int id)
        {
            var tarefa = tarefas.FirstOrDefault(t => t.Id == id);
            if (tarefa != null)
            {
                tarefas.Remove(tarefa);
                Console.WriteLine("Tarefa removida com sucesso!");
            }
            else
            {
                Console.WriteLine("Tarefa não encontrada.");
            }
        }

        public List<Tarefa> GetTarefas()
        {
            return tarefas;
        }
    }
}
