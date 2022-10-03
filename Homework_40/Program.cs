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
                    player.GetCard(deck);
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
            Console.WriteLine($"Карта: {_hand[i].NameCard}. Уровень карты: {_hand[i].LevelCard}");
        }
    }

    public void GetCard(Deck deck)
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
    public string NameCard { get; private set; }

    public int LevelCard { get; private set; }

    public Card(string nameCard, int levelCard)
    {
        NameCard = nameCard;
        LevelCard = levelCard;
    }
}

class Deck
{
    private List<Card> _cards = new List<Card>();

    public Deck()
    {
        _cards.Add(new Card("Обычная карта", 5));
        _cards.Add(new Card("Редкая карта", 10));
        _cards.Add(new Card("Эпическая карта", 15));
        _cards.Add(new Card("Легендарная карта", 25));
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
}