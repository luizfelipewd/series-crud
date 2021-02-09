using System;

namespace seriescrud
{
    class Program
    {
        static SeriesRepository repository = new SeriesRepository();
        static void Main(string[] args)
        {
            string userOption = GetUserChoice();

            while (userOption.ToUpper() != "X")
            {
                switch (userOption)
                {
                    case "1":
                        ListSeries();
                        break;
                    case "2":
                        InsertSerie();
                        break;
                    case "3":
                        UpdateSerie();
                        break;
                    case "4":
                        DeleteSerie();
                        break;
                    case "5":
                        ViewSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                userOption = GetUserChoice();
            }
            Console.WriteLine("Obrigado por utilizar a aplicação.");
            Console.ReadLine();
        }

        private static void ListSeries()
        {
            Console.WriteLine();
            Console.WriteLine("Lista de Séries");
            Console.WriteLine("==================================");
            Console.WriteLine();

            var list = repository.List();

            if (list.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }

            foreach (var serie in list)
            {
                var deleted = serie.returnDeleted();
                Console.WriteLine("ID: {0} - {1} {2}", serie.returnId(), serie.returnTitle(), (deleted ? "* Excluído *" : ""));
            }
        }

        private static void InsertSerie()
        {
            Console.WriteLine();
            Console.WriteLine("Inserir nova Série");
            Console.WriteLine("==================================");
            Console.WriteLine();

            foreach (int i in Enum.GetValues(typeof(Gender)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Gender), i));
            }

            Console.Write("Digite o gênero entre as listadas acima:");
            int genderEntry = int.Parse(Console.ReadLine());

            Console.Write("Digite o título da série:");
            string titleEntry = Console.ReadLine();

            Console.Write("Digite o ano de início da série:");
            int yearEntry = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição da série:");
            string descriptionEntry = Console.ReadLine();

            Serie newSerie = new Serie(
                id: repository.nextId(),
                gender: (Gender)genderEntry,
                title: titleEntry,
                year: yearEntry,
                description: descriptionEntry
            );

            repository.Insert(newSerie);

        }

        private static void UpdateSerie()
        {
            Console.WriteLine();
            Console.WriteLine("Atualizar Série");
            Console.WriteLine("==================================");
            Console.WriteLine();

            Console.Write("Digite o ID da série: ");
            int serieIndex = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Gender)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Gender), i));
            }

            Console.Write("Digite o gênero entre as listadas acima:");
            int genderEntry = int.Parse(Console.ReadLine());

            Console.Write("Digite o título da série:");
            string titleEntry = Console.ReadLine();

            Console.Write("Digite o ano de início da série:");
            int yearEntry = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição da série:");
            string descriptionEntry = Console.ReadLine();

            Serie updateSerie = new Serie(
                id: serieIndex,
                gender: (Gender)genderEntry,
                title: titleEntry,
                year: yearEntry,
                description: descriptionEntry
            );

            repository.Update(serieIndex, updateSerie);


        }

        private static void DeleteSerie()
        {
            Console.WriteLine();
            Console.WriteLine("Deletar Série");
            Console.WriteLine("==================================");
            Console.WriteLine();

            Console.Write("Digite o ID da série: ");
            int serieIndex = int.Parse(Console.ReadLine());
            repository.Delete(serieIndex);

            Console.WriteLine("Série deletada com sucesso!");
        }

        private static void ViewSerie()
        {
            Console.WriteLine();
            Console.WriteLine("Visualizar Série");
            Console.WriteLine("==================================");
            Console.WriteLine();

            Console.Write("Digite o ID da série: ");
            int serieIndex = int.Parse(Console.ReadLine());
            var serie = repository.returnById(serieIndex);

            Console.WriteLine(serie);
        }

        private static string GetUserChoice()
        {
            Console.WriteLine();
            Console.WriteLine("Series.NET - Programa em Console");
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1 - Listar séries");
            Console.WriteLine("2 - Inserir nova série");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Excluir série");
            Console.WriteLine("5 - Visualizar série");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine("==============================================");
            Console.WriteLine();

            string userOption = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return userOption;
        }
    }
}
