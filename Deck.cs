using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace War_Card_Game
{
    class Deck
    {
        private List<Card> _cards = new List<Card>();
        private int _numCards;
        public Deck(bool fill)
        {
            _numCards = 0;
            if (fill)
            {
                for (int rank = 1; rank <= 13; rank++)
                    for (int suitIdx = 0; suitIdx < Card._Suits.Length; suitIdx++)
                        this.AddCard(new Card(rank, Card._Suits[suitIdx]));
            }
        }
        /*public void ShiftRight()
        {
            for (int i = _numCards; i > 0; i--)
                _cards[i] = _cards[i - 1];
        }*/
        public void AddCard(Card card)
        {
            //this.ShiftRight();
            _cards.Insert(0, card);
            _numCards++;
        }
        public Card DealCard()
        {
            _numCards--;
            Card _tempy = _cards[_numCards];
            _cards.RemoveAt(_numCards);
            return _tempy;
        }
        public int GetSize()
        {
            return _numCards;
        }
        public void Shuffle()
        {
            Random r = new Random();
            for (int i = 0; i < _numCards - 1; i++)
            {
                int rndIdx = r.Next(i + 1, _numCards);
                Card temp = _cards[i];
                _cards[i] = _cards[rndIdx];
                _cards[rndIdx] = temp;
            }

        }
        public void Show()
        {
            for (int i = 0; i < _numCards; i++) {
                _cards[i].Show();
             }
        }
        public int GetValue()
        {
            int value = 0;
            for (int i = 0; i < _numCards; i++)
                value +=_cards[i].Rank;
            return value;
        }
    }
}
