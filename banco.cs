using System;
using System.Collections.Generic;
using System.IO;
namespace ProjetoTarefa
{
    public class Banco
    {
        private string caminhoArquivo = "tarefas.txt";

        public int ObterUltimoId()
        {
            int ultimoId = 0;
            if (File.Exists(caminhoArquivo))
            {
                string[] linhas = File.ReadAllLines(caminhoArquivo);
                for (int i = 0; i < linhas.Length; i++)
                {
                    if (linhas[i].Contains(";"))
                    {
                        string[] partes = linhas[i].Split(';');
                        if (int.TryParse(partes[0], out int id))
                        {
                            ultimoId = Math.Max(ultimoId, id);
                        }
                    }
                }
            }
            return ultimoId;
        }

        // Método para salvar as tarefas no arquivo
        public void SalvarTarefas(List<Tarefa> tarefas)
        {
            // Salva as tarefas adicionando ao arquivo existente
            using (StreamWriter sw = new StreamWriter(caminhoArquivo, true))
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