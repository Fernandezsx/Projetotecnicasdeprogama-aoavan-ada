using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace ProjetoTarefa{
  public class tarefaservice 
  {
    private lis<tarefas> tarefas = new List<tarefas>();
    private string caminhoArquivo = "tarefas.txt";
    private int proximoid = 1;

    public void CriarTarefa(string descriçao, string prioridade, string status , string titulo, int id)
    {
      var novatarefa = new tarefas(Id = proximoId++, Titulo = titulo, Descricao = descricao, Prioridade = prioridade, Status = status);
      tarefas.Add(novatarefa);
      SalvarTarefas();
      Console.WriteLine("Tarefa criada com sucesso!");
    }
    public void ListarTarefas(string status)
    {
      Console.WriteLine("Tarefas:");
      if (!tarefas.Any())
      console.WriteLine("Nenhuma tarefa encontrada.");
      else 
      tarefas.ForEach(t => Console.WriteLine($"ID: {t.Id} - Título: {t.Titulo} - Descrição: {t.Descricao} - Prioridade: {t.Prioridade} - Status:" {t.Status});
    }
      public void deletarTarefa(int id)
    {
      var tarefa = tarefas.FirstOrDefault(t => t.Id == id);
      if (tarefa != null)
      {
        tarefas.Remove(tarefa);
        Console.WriteLine("Tarefa deletada com sucesso!");
      }
      else 
      {
        Console.WriteLine("Tarefa não encontrada.");
      }
    }   
  }
}