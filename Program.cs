/* 
 * program to find subsequence of two lists and random cards picker based on user input.
 *
 */

using System;
using System.Collections.Generic;
using System.Linq;
using static Assignment_1.CardPicker;

namespace Assignment_1
{
	public class Program
	{
		static void Main(string[] args)
		{
			// Two lists for subsequence find.
			var list1 = new List<int>() { 1, 2, 3, 4, 5, 6, };
			var list2 = new List<int>() { 5, 6 };
			Console.WriteLine(SubsequenceFinder.ContainsSubsequence(list1, list2));


			// for card picker
			{
				// Take input from user for how many cards they want to pick
				Console.WriteLine("Enter the number of the cards to pick: ");
				var res = Console.ReadLine();
				int number = Convert.ToInt32(res);
				CardPicker cardPicker = new CardPicker();

				if (number < 0 || number > 52)
				{
					Console.WriteLine("invalid number! please enter between 1 to 52.");
				}
                else
                {
					ShowCards(cardPicker.selection(number));
				}

			}

			static void ShowCards(Card[] cards)
			{
				// store the cards value and suit
				foreach (var card in cards)
					if (card != null)
						Console.WriteLine("{0} of {1}", card.Value, card.Suit);
			}
		}

	}

	public class SubsequenceFinder
	{
		/// <summary>
		/// Determines whether a list of integers is a subsequence of another list of integers
		/// </summary>
		/// <param name="seq">The main sequence of integers.</param>
		/// <param name="subseq">The potential subsequence.</param>
		/// <returns>True if subseq is a subsequence of seq and false otherise.</returns>
		///

		public static bool ContainsSubsequence(List<int> seq, List<int> subseq)
		{
			var startIndex = seq.IndexOf(subseq.First());
			if (seq == null || subseq == null || startIndex < 0)
				return false;

			while (startIndex >= 0)
			{
				if (seq.Count - startIndex < subseq.Count)
					return false;
				var nonMatch = false;
				for (int i = 0; i < subseq.Count; i++)
				{
					if (seq[i + startIndex] != subseq[i])
					{
						seq = seq.Skip(startIndex + 1).ToList();
						startIndex = seq.IndexOf(subseq.First());
						nonMatch = true;
						break;
					}
				}
				if (!nonMatch)
					return true;
			}
			return false;
		}




	}


		
public class CardPicker
		{
		public class Card
		{
			public Suit Suit;
			public Value Value;
			private string v;

			public Card()
			{
			}

			public Card(Suit suit, string v)
			{
				Suit = suit;
				this.v = v;
			}

			public override String ToString()
			{
				return String.Format("{0:F} of {1:F}", this.Value, this.Suit);
			}
		}
		// Random variable
		Random rnd;
			// deck for all 52 cards
			Card[] deck = new Card[52];
			// array for selected cards.
			Double[] select = new Double[52];
			// pointer to get next card.
			int ptr = 0;
			bool move = false;




			// to get card suit and value
			public CardPicker()
			{
				rnd = new Random();
				int cardCtr = 0;

				foreach (var suit in Enum.GetValues(typeof(Suit)))
				{
					foreach (var value in Enum.GetValues(typeof(Value)))
					{
						Card card = new Card();
						card.Suit = (Suit)suit;
						card.Value = (Value)value;
						deck[cardCtr] = card;
						cardCtr++;
					}
				}
				for (int ctr = 0; ctr < select.Length; ctr++)
					select[ctr] = rnd.NextDouble();

				Array.Sort(select, deck);
			}
			// for card selection
			public Card[] selection(int number)
			{
				Card[] sel_cards = new Card[number];
				for (int count = 0; count < number; count++)
				{
					sel_cards[count] = deck[ptr];
					ptr++;
					if (ptr == deck.Length)
						move = true;
				}
				return sel_cards;
			}

		

			/// <summary>
			/// Chooses a random value for a card (Ace, two, three, ... , Queen, King)
			/// </summary>
			public enum Value
				{
					Ace, Two, Three, Four, Five, Six,
					Seven, Eight, Nine, Ten, Jack, Queen,
					King
				};



			/// <summary>
			/// Chooses a random suit for a card (Clubs, Diamonds, Hearts, Spades)
			/// </summary>
			public enum Suit { Hearts, Diamonds, Spades, Clubs };

		}
	
}

