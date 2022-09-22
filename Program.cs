using System.IO;

namespace TextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("O que você deseja faer?");
            Console.WriteLine("1 - Abrir um arquivo");
            Console.WriteLine("2 - Criar um novo arquivo");
            Console.WriteLine("0 - Sair");

            short options = short.Parse(Console.ReadLine());

            switch(options){
                case 0: System.Environment.Exit(0); break;
                case 1: Open(); break;
                case 2: Editing(); break;
                default: Menu(); break;
            }

        }
        static void Open() 
        {
            Console.Clear();
            Console.WriteLine("Qual o caminho do arquivo");
            Console.WriteLine("----------");
            string path = Console.ReadLine();

            using(var file = new StreamReader(path)) 
            {
                string text = file.ReadToEnd();
                Console.WriteLine(text);
                
            }

            Console.WriteLine();
            Console.ReadLine();
            Menu();
        }

        static void Editing() 
        {
            Console.Clear();
            Console.WriteLine("Digite seu texto abaixo (ESC para sair) ");
            Console.WriteLine("--------------");
            string  text = "";

            do
            {
                text += Console.ReadLine();
                text += Environment.NewLine;
            }
            while(Console.ReadKey().Key != ConsoleKey.Escape);

            Save(text);

        }
        static void Save(string text) 
        {
            Console.Clear();
            Console.WriteLine("Qual o caminho para salver o arquivo?");
            var path = Console.ReadLine();

            using(var file = new StreamWriter(path)) 
            {
                file.Write(text);
            }

            Console.WriteLine($"Arquivo {path} salvo com sucesso");
            Console.ReadLine();
            Menu();
        }
    }


}