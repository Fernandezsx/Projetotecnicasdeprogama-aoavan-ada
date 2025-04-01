
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace ProjetoTarefa
{
  
  public class TarefaService 
  {
    private List<Tarefa> tarefa = new List<Tarefa>();
    private string caminhoArquivo = "tarefas.txt";
    private int proximoId = 1;

    public void CriarTarefa(string descricao, string prioridade, string status, string titulo)
    {
        var novaTarefa = new Tarefa 
        { 
            Id = proximoId++,
            Titulo = titulo,
            Descricao = descricao,
            Prioridade = prioridade,
            Status = status
        };

        tarefa.Add(novaTarefa);

        // Salvar a tarefa no arquivo
        using (StreamWriter sw = new StreamWriter(caminhoArquivo, true))
        {
            sw.WriteLine($"{novaTarefa.Id};{novaTarefa.Titulo};{novaTarefa.Descricao};{novaTarefa.Prioridade};{novaTarefa.Status}");
        }

        Console.WriteLine("Tarefa criada e salva com sucesso!");
    }

    public void ListarTarefas()
        {
          Console.WriteLine("Tarefas:");
          if (!tarefa.Any())
          {
            Console.WriteLine("Nenhuma tarefa encontrada.");
          }
          else 
          {
            foreach(var t in tarefa)
            {
              Console.WriteLine($"Título: {t.Titulo}");
            }
          }
        }

        public void DeletarTarefa(string titulo)
        {
          var tarefaToRemove = tarefa.FirstOrDefault(t => t.Titulo == titulo);
          if (tarefaToRemove != null)
          {
            tarefa.Remove(tarefaToRemove);
            Console.WriteLine("Tarefa deletada com sucesso!");
          }
          else 
          {
            Console.WriteLine("Tarefa não encontrada.");
          }
        }
      }
    }
