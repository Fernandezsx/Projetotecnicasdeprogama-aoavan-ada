using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using ProjetoTarefa;

class Program
{
    static void Main()
    {
        var banco = new Banco();
        var tarefaService = new TarefaService(banco.ObterUltimoId());

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
        var tarefas = tarefaService.GetTarefas();
        banco.SalvarTarefas(tarefas);
        banco.LerTarefas();

        // A classe Banco já lê e exibe as tarefas, não precisamos fazer isso novamente
    }
}