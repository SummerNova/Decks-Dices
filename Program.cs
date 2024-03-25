using Decks_Dices;


Random rnd = new Random();
Deck<int> deck = new Deck<int>(40);

for (int i = 0; i < 40; i++)
{
    deck.Cards[i] = rnd.Next(1,21);
}

Dice die = new Dice(1, 20, 0);

RandomFighter<int>.Algorithm(deck, die);


