using DIO.App.Classes;
using DIO.App.Interfaces;
using DIO.App.Enum;

namespace DIO.App
{
    class Program
    {
        static MusicRepository repository = new MusicRepository();

        static void Main(string[] args)
        {
            string UserOption = GetUserOption();

            while (UserOption.ToUpper() != "X")
            {
                switch (UserOption)
                {
                    case "1":
                        MusicList();
                        break;
                    case "2":
                        MusicAdd();
                        break;
                    case "3":
                        MusicUpdate();
                        break;
                    case "4":
                        MusicDelete();
                        break;
                    case "5":
                        MusicShow();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();

                }
                UserOption = GetUserOption();
            }

            Console.ReadLine();
        }
        private static void MusicDelete()
        {
            Console.Write("Music ID: ");
            int indexMusic = int.Parse(Console.ReadLine());

            repository.Delete(indexMusic);
        }

        private static void MusicShow()
        {
            Console.Write("Music ID: ");
            int indexMusic = int.Parse(Console.ReadLine());

            var music = repository.ReturnId(indexMusic);

            Console.WriteLine(music);
        }

        private static void MusicUpdate()
        {
            Console.Write("Music ID: ");
            int indexMusic = int.Parse(Console.ReadLine());

            // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
            // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
            foreach (int i in Enum.Genre.GetValues(typeof(Genre)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.Genre.GetName(typeof(Genre), i));
            }
            Console.Write("Enter the genre accord to the options above: ");
            int entryGenre = int.Parse(Console.ReadLine());

            Console.Write("Enter the music name: ");
            string entryName = Console.ReadLine();

            Console.Write("Enter the artist`s name: ");
            string entryArtist = Console.ReadLine();

            Console.Write("Enter the releasing year: ");
            int entryYear = int.Parse(Console.ReadLine());

            Musics MusicUpdater = new Musics(id: repository.NextId(),
                                        genre: (Genre)entryGenre,
                                        name: entryName,
                                        artist: entryArtist,
                                        year: entryYear);

            repository.Update(indexMusic, MusicUpdater);
        }
        private static void MusicList()
        {
            Console.WriteLine("Music List");

            var list = repository.Lists();

            if (list.Count == 0)
            {
                Console.WriteLine("No music found.");
                return;
            }

            foreach (var musics in list)
            {
                var Delete = musics.returnDeleted();

                Console.WriteLine("#ID {0}: - {1} {2}", musics.returnId(), musics.returnName(), (Delete ? "*Deleted*" : ""));
            }
        }
        private static void MusicAdd()
        {
            Console.WriteLine("Add new music");

            // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
            // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
            foreach (int i in Enum.Genre.GetValues(typeof(Genre)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.Genre.GetName(typeof(Genre), i));
            }
            Console.Write("Enter the genre accord to the options above: ");
            int entryGenre = int.Parse(Console.ReadLine());

            Console.Write("Enter the music name: ");
            string entryName = Console.ReadLine();

            Console.Write("Enter the artist`s name: ");
            string entryArtist = Console.ReadLine();

            Console.Write("Enter the releasing year: ");
            int entryYear = int.Parse(Console.ReadLine());

            Musics newMusic = new Musics(id: repository.NextId(),
                                        genre: (Genre)entryGenre,
                                        name: entryName,
                                        artist: entryArtist,
                                        year: entryYear);

            repository.Add(newMusic);
        }
        private static string GetUserOption()
        {
            Console.WriteLine();
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Type the desired option: ");
            Console.WriteLine("---------------------------------");

            Console.WriteLine("1 - Music list");
            Console.WriteLine("2 - Add a new song");
            Console.WriteLine("3 - Music update");
            Console.WriteLine("4 - Delete music");
            Console.WriteLine("5 - Show music");
            Console.WriteLine("C - Clean");
            Console.WriteLine("X - Exit");
            Console.WriteLine();

            string UserOption = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return UserOption;
        }
    }
}