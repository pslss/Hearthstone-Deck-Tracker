using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using Hearthstone_Deck_Tracker.Hearthstone;
using Hearthstone_Deck_Tracker.Stats;
using Hearthstone_Deck_Tracker.Utility.MVVM;

namespace Hearthstone_Deck_Tracker.Windows.MainWindowControls
{
	/// <summary>
	/// Interaction logic for DeckRecentGamesView.xaml
	/// </summary>
	public partial class DeckRecentGamesView : UserControl
	{
		public DeckRecentGamesView()
		{
			InitializeComponent();
		}

		public void SetDeck(Deck deck) => ((DeckRecentGamesViewModel)DataContext).Deck = deck;
	}

	public class DeckRecentGamesViewModel : ViewModel
	{
		private Deck _deck;

		public Deck Deck
		{
			get => _deck;
			set
			{
				_deck = value;
				OnPropertyChanged();
				OnPropertyChanged(nameof(Games));
			}
		}
		public IEnumerable<GameStats> Games => Deck?.DeckStats.Games.OrderByDescending(x => x.StartTime).Take(20);
	}
}
