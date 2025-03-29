using System;
using Newtonsoft.Json;
using System.Collections.Generic;

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
        // Criando algumas tarefas
        List<Tarefa> tarefas = new List<Tarefa>
        {
            new Tarefa { Id = 1, Titulo = "Estudar C#", Descricao = "Ler sobre pacotes NuGet", Prioridade = "Alta", Status = "Em andamento" },
            new Tarefa { Id = 2, Titulo = "Ler livro", Descricao = "Ler o livro de C# para iniciantes", Prioridade = "Média", Status = "Não Iniciado" },
            new Tarefa { Id = 3, Titulo = "Comprar supermercado", Descricao = "Ir ao mercado e comprar itens essenciais", Prioridade = "Baixa", Status = "Concluído" },
            new Tarefa { Id = 4, Titulo = "Fazer compras", Descricao = "Ir ao mercado e comprar itens essenciais", Prioridade = "Baixa", Status = "Nao iniciado"}
        };

        // Perguntar ao usuário qual tarefa ele deseja visualizar
        Console.WriteLine("Digite o ID da tarefa que você deseja visualizar:");
        int idTarefa = Convert.ToInt32(Console.ReadLine());

        // Encontrar a tarefa com o ID fornecido
        Tarefa tarefaEncontrada = tarefas.Find(t => t.Id == idTarefa);

        // Exibir a tarefa encontrada ou uma mensagem de erro
        if (tarefaEncontrada != null)
        {
            Console.WriteLine("\nTarefa encontrada:");
            Console.WriteLine($"ID: {tarefaEncontrada.Id}");
            Console.WriteLine($"Título: {tarefaEncontrada.Titulo}");
            Console.WriteLine($"Descrição: {tarefaEncontrada.Descricao}");
            Console.WriteLine($"Prioridade: {tarefaEncontrada.Prioridade}");
            Console.WriteLine($"Status: {tarefaEncontrada.Status}");

            // Serializando a tarefa encontrada para JSON
            string json = JsonConvert.SerializeObject(tarefaEncontrada, Formatting.Indented);
            

            // Desserializando o JSON de volta para objeto
            Tarefa tarefaDesserializada = JsonConvert.DeserializeObject<Tarefa>(json);
        
            
        }
        else
        {
            Console.WriteLine("Tarefa não encontrada!");
        }
    }
}