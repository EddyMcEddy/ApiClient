using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using ConsoleTables;

namespace ApiClient
{
    class Program
    {

        static void Greetings()
        {
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("    WELCOME TO JOKE FINDER!!!");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Would you like: \n(1) One Joke (2) Ten Jokes or (3)Quit ");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("-----------------------------------");

        }
        static async Task Main(string[] args)
        {
            var client = new HttpClient();

            bool menuKeepGoing = true;
            if (menuKeepGoing == true)
            {

                Greetings();
                var userInput = Convert.ToDouble(Console.ReadLine());

                if (userInput == 3)
                {
                    menuKeepGoing = false;

                }


                else if (userInput == 1)
                {

                    var responseAsStream = await client.GetStreamAsync("https://official-joke-api.appspot.com/random_joke");

                    var oneJoke = await JsonSerializer.DeserializeAsync<JokeItem>(responseAsStream);

                    Console.WriteLine($"{oneJoke.Type}, {oneJoke.SetUp}, {oneJoke.PunchLine}, {oneJoke.Id}");
                    //Creating a table so it shows us in Terminal better 
                    var table = new ConsoleTable("Type", "Setup", "Punchline", "Id");

                    table.AddRow(oneJoke.Type, oneJoke.SetUp, oneJoke.PunchLine, oneJoke.Id);
                    table.Write();

                }

                else if (userInput == 2)
                {
                    var tenJokes = await client.GetStreamAsync("https://official-joke-api.appspot.com/random_ten");

                    var Jokes = await JsonSerializer.DeserializeAsync<List<JokeItem>>(tenJokes);

                    foreach (var joke in Jokes)
                    {
                        Console.WriteLine($"Type of Joke:\n{joke.Type}, \n{joke.SetUp}, \n{joke.PunchLine}, \nID:{joke.Id}");
                    }
                }

            }

        }
    }
}

