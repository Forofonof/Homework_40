using System;
using System.Collections.Generic;

internal class Program
{
    static void Main(string[] args)
    {
        const string CommandTakeCard = "1";
        const string CommandShowAllCards = "2";
        const string CommandExit = "3";

        Player player = new Player();
        Deck deck = new Deck();

        bool isWork = true;

        Console.WriteLine("Какое ваше следующее действие?\n");

        while (isWork)
        {
            Console.WriteLine($"{CommandTakeCard} - Взять карту.\n{CommandShowAllCards} - Показать все карты.\n{CommandExit} - Закрыть программу.\n");
            string userInput = Console.ReadLine();

            switch (userInput) 
            {
                case CommandTakeCard:
                    player.TakeCard(deck);
                    break;
                case CommandShowAllCards:
                    player.ShowCard();
                    break;
                case CommandExit:
                    isWork = false;
                    break;
                default:
                    Console.WriteLine("Ошибка! Нет такой команды.");
                    break;
            }
        }
    }
}

class Player
{
    private List<Card> _hand = new List<Card>();

    public void ShowCard()
    {
        for (int i = 0; i < _hand.Count; i++)
        {
            Console.WriteLine($"Карта: {_hand[i].Name}. Уровень карты: {_hand[i].Level}");
        }
    }

    public void TakeCard(Deck deck)
    {
        if (deck.TryTakeCard(out Card card))
        {
            _hand.Add(card);
            Console.WriteLine("Ваши карты");
            ShowCard();
        }
        else
        {
            Console.WriteLine("\nВ колоде закончились карты!\n");
        }
    }
}

class Card
{
    public string Name { get; private set; }

    public int Level { get; private set; }

    public Card(string name, int level)
    {
        Name = name;
        Level = level;
    }
}

class Deck
{
    private List<Card> _cards = new List<Card>();
    private Random _random = new Random();

    public Deck()
    {
        int maximumCards = 4;

        for (int i = 0; i < maximumCards; i++)
        {
            _cards.Add(new Card("Обычная", GetPowerCard()));
        }
    }

    public bool TryTakeCard(out Card card)
    {
        if (_cards.Count > 0)
        {
            int numberCard = 0;
            card = _cards[numberCard];
            _cards.Remove(card);
            return true;
        }
        else
        {
            card = null;
            return false;
        }
    }

    private int GetPowerCard()
    {
        int maximumPowerCard = 15;
        int minimumPowerCard = 5;
        int powerCard = _random.Next(minimumPowerCard, maximumPowerCard);

        return powerCard;
    }
}