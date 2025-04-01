using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using ProjetoTarefa;

class Program
{
    static void Main()
    {
        var tarefaService = new TarefaService();

        // Create a new task
        Console.WriteLine("Digite o título da tarefa:");
        string titulo = Console.ReadLine();

        Console.WriteLine("Digite a descrição da tarefa:");
        string descricao = Console.ReadLine();

        Console.WriteLine("Digite a prioridade (Alta/Media/Baixa):");
        string prioridade = Console.ReadLine();

        Console.WriteLine("Digite o status (Pendente/Em Andamento/Concluída):");
        string status = Console.ReadLine();

        tarefaService.CriarTarefa(descricao, prioridade, status, titulo);

        var banco = new Banco();
        var tarefas = tarefaService.GetTarefas();
        banco.SalvarTarefas(tarefas);
        banco.LerTarefas();

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