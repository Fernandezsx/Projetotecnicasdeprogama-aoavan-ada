using System;
using System.Collections.Generic;
using System.IO;
namespace ProjetoTarefa
{
    public class Banco
    {
        private string caminhoArquivo = "tarefas.txt";

        // Método para salvar as tarefas no arquivo
        public void SalvarTarefas(List<Tarefa> tarefas)
        {
            using (StreamWriter sw = new StreamWriter(caminhoArquivo))
            {
                foreach (var tarefa in tarefas)
                {
                    sw.WriteLine($"{tarefa.Id};{tarefa.Titulo};");
                    sw.WriteLine(tarefa.Descricao);
                    sw.WriteLine($"{tarefa.Prioridade};");
                    sw.WriteLine(tarefa.Status);
                    sw.WriteLine(); 
                }
            }
            Console.WriteLine("Tarefas salvas em 'tarefas.txt' com sucesso!");
        }

        // Método para ler e exibir as tarefas do arquivo
        public void LerTarefas()
        {
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
}