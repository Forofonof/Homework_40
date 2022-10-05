using System;
using System.Collections.Generic;

internal class Program
{
    static void Main(string[] args)
    {
        const string TakeCard = "1";
        const string ShowAllCards = "2";
        const string DoExit = "3";

        Player player = new Player();
        Deck deck = new Deck();

        bool isWork = true;

        Console.WriteLine("Какое ваше следующее действие?\n");

        while (isWork)
        {
            Console.WriteLine($"{TakeCard} - Взять карту.\n{ShowAllCards} - Показать все карты.\n{DoExit} - Закрыть программу.\n");
            string userInput = Console.ReadLine();

            switch (userInput) 
            {
                case TakeCard:
                    player.TakeCard(deck);
                    break;
                case ShowAllCards:
                    player.ShowCard();
                    break;
                case DoExit:
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
        if (deck.TryGetCard(out Card card))
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

    public bool TryGetCard(out Card card)
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