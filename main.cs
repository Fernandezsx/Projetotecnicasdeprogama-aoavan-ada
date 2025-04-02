
using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using ProjetoTarefa;

namespace ProjetoTarefas
{
    public class Program
    {
        static void Main(string[] args)
        {
            var menu = new Menu();
            menu.Mostrar();
        }
    }
}
