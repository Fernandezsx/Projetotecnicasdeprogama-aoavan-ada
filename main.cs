using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;



class Program
{
    static void Main()
    {

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