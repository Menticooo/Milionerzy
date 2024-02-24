using System;
using System.Collections.Generic;

namespace Milionerzy
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Witaj w grze Milionerzy!");
            Console.WriteLine("Wybierz opcję:");
            Console.WriteLine("1. Rozpocznij grę");
            Console.WriteLine("2. Wyjdź");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Game game = new Game();
                    game.Start();
                    break;
                case 2:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Niepoprawny wybór.");
                    break;
            }
        }
    }

    class Question
    {
        public string Content { get; set; }
        public string CorrectAnswer { get; set; }
        public List<string> Answers { get; set; }

        public Question(string content, string correctAnswer, List<string> answers)
        {
            Content = content;
            CorrectAnswer = correctAnswer;
            Answers = answers;
        }
    }

    class Game
    {
        private List<Question> questions;
        private int moneyWon;

        public Game()
        {
            InitializeQuestions();
            moneyWon = 0;
        }

        private void InitializeQuestions()
        {
            questions = new List<Question>
            {
                new Question("Jak nazywa się główny bohater serii gier Gothic?", "b", new List<string>{"a) Xardas", "b) Nie posiadał imienia", "c) Javier", "d) Diego"}),
                new Question("Kto jest ojcem Luke'a Skywalkera w serii 'Star Wars'?", "c", new List<string>{"a) Han Solo", "b) Obi-wan Kenobi", "c) Vader", "d) Boba Fett"}),
                new Question("Która z podanych gier wyszła tylko i wyłącznie na konsole firmy Sony?", "a", new List<string>{"a) Bloodborne", "b) Elden Ring", "c) Dark Souls", "d) Sekiro: Shadows die Twice"}),
                new Question("W którym roku zmarł papież Jan Paweł 2?", "a", new List<string>{"a) 2005", "b) 2004", "c) 2003", "d) Nie wiem, choć się domyślam"}),
                new Question("Która z gier została grą roku 2022?", "d", new List<string>{"a) The Callisto Protocol", "b) Lego Star Wars: Skywalker Saga", "c) God of War: Ragnarok", "d) Elden Ring"}),
                new Question("W którym roku zmarł wokalista zespołu Linkin Park - Chester Bennington?", "c", new List<string>{"a) 2019", "b) 2018", "c) 2017", "d) 2020"}),
                new Question("Z jakiego kraju pochodzi zespół Rammstein", "b", new List<string>{"a) Rosja", "b) Niemcy", "c) Stany Zjednoczojne", "d) Ukraina"}),
                new Question("Jak nazywa się wokalista zespołu Nocny Kochanek", "b", new List<string>{"a) Michał Wiśniewski", "b) Krzysztof Sokołowski", "c) Piotr Kupicha", "d) Krzysztof Krawczyk"}),
                new Question("Która z podanych osób miała konflikt z liderem zespołu 'Nirvana' - Kurtem Cobainem?", "a", new List<string>{"a) Axel Rose", "b) Brian Johnson", "c) David Coverdale", "d) Paul Stanley"}),
                new Question("Który z podanych albumów wyszedł najwcześniej?", "a", new List<string>{"a) Linkin Park - Hybrid Theory", "b) Three Days Grace - One-X", "c) Rammstein - Mutter", "d) Breaking Benjamin - Phobia"}),
                new Question("Jak nazywa się postać kierowana przez gracza w grze 'Cyberpunk 2077'?", "d", new List<string>{"a) Jackie Welles", "b) Johnny Silverhand", "c) Dexter DeShawn", "d) V"}),
                new Question("W którym roku wyszła gra League of Legends?", "d", new List<string>{"a) 2006", "b) 2007", "c) 2008", "d) 2009"}),
                new Question("Który z podanych bossów pochodzi z gry Dark Souls 3?", "a", new List<string>{"a) Nameless King", "b) Asylum Demon", "c) Lady Maria", "d) Olgierd Von Everec"}),
                new Question("W którym roku wyszła gra 'Baldurs Gate 2'?", "d", new List<string>{"a) 2001", "b) 2003", "c) 2002", "d) 2000"}),
                new Question("Która z postaci była 'ojcem' protagonisty gry 'Sekiro: Shadows die twice'?", "d", new List<string>{"a) Genichiro Ashina", "b) Isshin Ashina", "c) Kuro", "d) Shinobi Sowa"}),
                new Question("Z jakiego kraju pochodzi zespół Nickelback?", "b", new List<string>{"a) Niemcy", "b) Kanada", "c) Polska", "d) Francja"}),
                new Question("Jak nazywała się pierwsza płyta zespołu Three Days Grace?", "b", new List<string>{"a) One-X", "b) Three Days Grace", "c) Human", "d) Outsider"}),
                new Question("Do kogo był zaadresowany list, dostaje protagonista gry 'Gothic' przed strąceniem za barierę?", "a", new List<string>{"a) Xardasa", "b) Pyrokara", "c) Saturasa", "d) Y'Beriona"}),
                new Question("Kto zniszczył eldeński krąg w grze 'Elden Ring'?", "b", new List<string>{"a) Radagon", "b) Marika", "c) Rennala", "d) Miquella"}),
                new Question("Która z podanych serii gier pochodzi z Polski?", "c", new List<string>{"a) Dark Souls", "b) Diablo", "c) The Witcher", "d) God of War"}),
                new Question("W którym roku miała miejsce premiera konsoli Playstation 2?", "a", new List<string>{"a) 2000", "b) 2001", "c) 1999", "d) 2002"}),
                new Question("Jaka gra została grą roku 2023?", "b", new List<string>{"a) Diablo 4", "b) Baldurs Gate 3", "c) Starfield", "d) Alan Wake 2"}),
                new Question("Która z gier wyszła spod skrzydeł Valve?", "a", new List<string>{"a) Half Life", "b) League of Legends", "c) Baldurs Gate", "d) Armored Core"}),
                new Question("Jak nazywała 3 część serii 'The Elder Scrolls'?", "d", new List<string>{"a) Oblivion", "b) Skyrim", "c) Daggerfall", "d) Morrowind"}),
                new Question("Jak nazywał się wielki mag pojawiający się w filmie 'Magnaci i czarodzieje'?", "a", new List<string>{"a) Stachu Jones", "b) Szeryf", "c) Bestia z Północy", "d) Bogusław"})
            };
        }

        private Question GetRandomQuestion(Random rand)
        {
            int index = rand.Next(questions.Count);
            Question randomQuestion = questions[index];
            questions.RemoveAt(index);
            return randomQuestion;
        }

        private void DisplayQuestion(Question question)
        {
            Console.WriteLine(question.Content);
            foreach (var answer in question.Answers)
            {
                Console.WriteLine(answer);
            }
            Console.WriteLine("Wybierz odpowiedź (np. a, b, c, d):");
        }

        private void DisplayEndGame()
        {
            Console.WriteLine("Koniec gry!");
            Console.WriteLine($"Twoja końcowa wygrana to: {moneyWon} zł");
            Console.WriteLine("Czy chcesz zagrać ponownie? (T/N)");

            string choice = Console.ReadLine();
            if (choice.ToUpper() == "T")
            {
                Console.Clear(); // Czyszczenie ekranu konsoli
                moneyWon = 0; // Resetowanie wygranej kwoty
                Start();
            }
            else
            {
                Environment.Exit(0);
            }
        }

        private void CheckAnswer(Question question, string answer)
        {
            if (answer.ToLower() == question.CorrectAnswer.ToLower())
            {
                Console.WriteLine("Poprawna odpowiedź! Wygrywasz kolejne 1000 zł.");
                moneyWon += 1000;
            }
            else
            {
                Console.WriteLine("Niestety, błędna odpowiedź. Koniec gry.");
                DisplayEndGame();
            }
        }

        public void Start()
        {
            Console.WriteLine("Nowa gra!");
            Random rand = new Random();
            int questionsToAsk = 10;

            while (questionsToAsk > 0 && questions.Count > 0)
            {
                Question randomQuestion = GetRandomQuestion(rand);
                DisplayQuestion(randomQuestion);
                string answer = Console.ReadLine();
                CheckAnswer(randomQuestion, answer);

                Console.WriteLine($"Aktualna wygrana: {moneyWon} zł");
                questionsToAsk--;
            }

            DisplayEndGame();
        }
    }
}