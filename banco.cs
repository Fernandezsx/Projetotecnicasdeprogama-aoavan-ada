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
                foreach (string linha in linhas)
                {
                    if (!string.IsNullOrEmpty(linha))
                    {
                        string[] partes = linha.Split(';');
                        if (partes.Length > 0 && int.TryParse(partes[0], out int id))
                        {
                            ultimoId = Math.Max(ultimoId, id);
                        }
                    }
                }
            }
            return ultimoId;
        }

        public void LerTarefas()
        {
            Console.WriteLine("\nTarefas salvas no arquivo:");

            if (File.Exists(caminhoArquivo))
            {
                string[] linhas = File.ReadAllLines(caminhoArquivo);
                foreach (var linha in linhas)
                {
                    if (!string.IsNullOrEmpty(linha))
                    {
                        string[] partes = linha.Split(';');
                        Console.WriteLine($"Id:{partes[0]}");
                        Console.WriteLine($"Título:{partes[1]}");
                        Console.WriteLine($"Descrição:{partes[2]}");
                        Console.WriteLine($"Prioridade:{partes[3]}");
                        Console.WriteLine($"Status:{partes[4]}");
                        Console.WriteLine();
                    }
                }
            }
            else
            {
                Console.WriteLine("Arquivo não encontrado!");
            }
        }
    }
}