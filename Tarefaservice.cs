
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
        private Banco banco = new Banco();

        public TarefaService()
        {
            CarregarTarefas();
        }

        private void CarregarTarefas()
        {
            string[] linhas = File.Exists("tarefas.txt") ? File.ReadAllLines("tarefas.txt") : new string[0];
            tarefas.Clear();
            foreach (string linha in linhas)
            {
                if (!string.IsNullOrEmpty(linha))
                {
                    string[] partes = linha.Split(';');
                    if (partes.Length >= 5)
                    {
                        var tarefa = new Tarefa
                        {
                            Id = int.Parse(partes[0]),
                            Titulo = partes[1],
                            Descricao = partes[2],
                            Prioridade = partes[3],
                            Status = partes[4]
                        };
                        tarefas.Add(tarefa);
                        proximoId = Math.Max(proximoId, tarefa.Id + 1);
                    }
                }
            }
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
            SalvarTarefas();
            Console.WriteLine("Tarefa adicionada com sucesso!");
        }

        private void SalvarTarefas()
        {
            File.WriteAllLines("tarefas.txt", tarefas.Select(t => 
                $"{t.Id};{t.Titulo};{t.Descricao};{t.Prioridade};{t.Status}"));
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
                SalvarTarefas();
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
