using System;
using TennisGame.Match;
using TennisGame.Players;
using TennisGame.Resources;

namespace TennisGame
{
    public class Program
    {
        private static TennisMatch _tennisMatch;

        public static void Main()
        {
            SetupConsole();

            _tennisMatch = new TennisMatch(new Server(), new Receiver());
            _tennisMatch.OnFinish += OnEventHandler;
            _tennisMatch.Start();

            do
            {
                PrintMessage();

                ConsoleKeyInfo selectedUser = Console.ReadKey();
                _tennisMatch.ProcessPoint(selectedUser.KeyChar);
            }
            while (_tennisMatch.IsStarted);

            Console.ReadKey();
        }

        private static void OnEventHandler(object sender, MatchFinishedArgs args)
        {
            Console.Clear();
            Console.WriteLine($"{args.Player} {Translations.WonTheMatch}");
        }

        private static void SetupConsole()
        {
            Console.Title = Translations.AppTitle;
        }

        private static void PrintMessage()
        {
            Console.Clear();
            if (_tennisMatch.IsStarted)
            {
                Console.WriteLine($"{_tennisMatch.FirstPlayer.LastPoint}:{_tennisMatch.SecondPlayer.LastPoint}");
            }

            Console.WriteLine($"{Translations.Server}= 1");
            Console.WriteLine($"{Translations.Receiver}= 2");
            Console.Write(Translations.SelectUser);
        }
    }
}
