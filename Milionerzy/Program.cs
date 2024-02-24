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
                new Question("Stolica Francji?", "d", new List<string>{"a) Berlin", "b) Londyn", "c) Madryt", "d) Paryż"}),
                new Question("Ile wynosi pierwiastek z 16?", "d", new List<string>{"a) 2", "b) 6", "c) 8", "d) 4"}),
                new Question("Które zwierzę jest największe na świecie?", "a", new List<string>{"a) Błękitny wieloryb", "b) Słoń", "c) Krokodyl", "d) Słoń afrykański"}),
                new Question("Jaki jest najdłuższy rzeka na świecie?", "a", new List<string>{"a) Nil", "b) Amazonka", "c) Missisipi", "d) Jangcy"}),
                new Question("Kto napisał powieść 'Lśnienie'?", "a", new List<string>{"a) Stephen King", "b) J.K. Rowling", "c) Dan Brown", "d) Agatha Christie"}),
                new Question("Który pierwiastek chemiczny ma symbol 'Fe'?", "a", new List<string>{"a) Żelazo", "b) Srebro", "c) Złoto", "d) Rtęć"}),
                new Question("W którym roku miała miejsce bitwa pod Grunwaldem?", "a", new List<string>{"a) 1410", "b) 1385", "c) 1453", "d) 1525"}),
                new Question("Jak nazywa się książka napisana przez George'a Orwella, która opowiada o totalitarnej rzeczywistości?", "a", new List<string>{"a) Rok 1984", "b) Fahrenheit 451", "c) Władca much", "d) Nowy wspaniały świat"}),
                new Question("Ile kontynentów jest na Ziemi?", "a", new List<string>{"a) 7", "b) 5", "c) 6", "d) 8"}),
                new Question("Która planeta jest najbliżej Słońca?", "a", new List<string>{"a) Merkury", "b) Wenus", "c) Mars", "d) Jowisz"}),
                new Question("Kto napisał dramat 'Romeo i Julia'?", "a", new List<string>{"a) William Shakespeare", "b) Fiodor Dostojewski", "c) John Steinbeck", "d) Victor Hugo"}),
                new Question("Kto odkrył penicylinę?", "a", new List<string>{"a) Alexander Fleming", "b) Louis Pasteur", "c) Marie Curie", "d) Albert Einstein"}),
                new Question("Ile wynosi 2 do potęgi 10?", "a", new List<string>{"a) 1024", "b) 512", "c) 256", "d) 2048"}),
                new Question("Które państwo jest najmniejszym na świecie?", "a", new List<string>{"a) Watikan", "b) Monako", "c) San Marino", "d) Liechtenstein"}),
                new Question("Jak nazywa się najwyższy szczyt w Afryce?", "a", new List<string>{"a) Kilimandżaro", "b) Everest", "c) K2", "d) Aconcagua"}),
                new Question("Która z następujących planet jest największa?", "a", new List<string>{"a) Jowisz", "b) Saturn", "c) Uran", "d) Neptun"}),
                new Question("Kto jest autorem serii książek o Harrym Potterze?", "a", new List<string>{"a) J.K. Rowling", "b) Stephen King", "c) George R.R. Martin", "d) J.R.R. Tolkien"}),
                new Question("Która z następujących planet jest gazowym olbrzymem?", "a", new List<string>{"a) Neptun", "b) Mars", "c) Wenus", "d) Merkury"}),
                new Question("Kto jest autorem 'Opowieści z Narnii'?", "a", new List<string>{"a) C.S. Lewis", "b) J.R.R. Tolkien", "c) J.K. Rowling", "d) George Orwell"}),
                new Question("Która z rzek płynie przez Rzym?", "a", new List<string>{"a) Tyber", "b) Nil", "c) Ryga", "d) Dunaj"}),
                new Question("W którym roku miała miejsce Rewolucja Francuska?", "a", new List<string>{"a) 1789", "b) 1776", "c) 1812", "d) 1917"}),
                new Question("Jaki kolor mają liście na fladze Kanady?", "a", new List<string>{"a) Czerwony", "b) Zielony", "c) Niebieski", "d) Żółty"}),
                new Question("Które z państw graniczy z Polską od północy?", "a", new List<string>{"a) Rosja", "b) Niemcy", "c) Czechy", "d) Ukraina"}),
                new Question("W którym roku miała miejsce pierwsza wyprawa człowieka na Księżyc?", "a", new List<string>{"a) 1969", "b) 1957", "c) 1975", "d) 1983"}),
                new Question("Kto był pierwszym prezydentem Stanów Zjednoczonych?", "a", new List<string>{"a) George Washington", "b) Thomas Jefferson", "c) Abraham Lincoln", "d) John Adams"})
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