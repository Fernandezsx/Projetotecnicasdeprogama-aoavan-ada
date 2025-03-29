using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

public class Tarefa
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public string Prioridade { get; set; }
    public string Status { get; set; }
}

class Program
{
    static void Main()
    {
        // Para instaciar uma nova tarefa é aqui pois precisa usar lista
        List<Tarefa> tarefas = new List<Tarefa>
        {
            new Tarefa { Id = 1, Titulo = "Estudar C#", Descricao = "Ler sobre pacotes NuGet", Prioridade = "Alta", Status = "Em andamento" },
    
        };


        string caminhoArquivo = "tarefas.txt";
        using (StreamWriter sw = new StreamWriter(caminhoArquivo))
        {
            foreach (var tarefa in tarefas)
            {
               
                string primeiraLinha = $"{tarefa.Id};{tarefa.Titulo};";
                string segundaLinha = $"{tarefa.Descricao}";
                string terceiraLinha = $"{tarefa.Prioridade};";
                string quartaLinha = $"{tarefa.Status}";
                sw.WriteLine(primeiraLinha);
                sw.WriteLine(segundaLinha);
                sw.WriteLine(terceiraLinha);
                sw.WriteLine(quartaLinha);
                sw.WriteLine(string.Empty); // Aqui é so pra pular uma linha
            }
        }

        Console.WriteLine("Tarefas salvas em 'tarefas.txt' com sucesso!");

        // Lendo as tarefas do arquivo e mostrando no console
        Console.WriteLine("\nTarefas salvas no arquivo:");

        if (File.Exists(caminhoArquivo))
        {
            string[] linhas = File.ReadAllLines(caminhoArquivo);
            foreach (var linha in linhas)
            {
                Console.WriteLine(linha);  
            }
        }
        else
        {
            Console.WriteLine("Arquivo não encontrado!");
        }

     
    }
}