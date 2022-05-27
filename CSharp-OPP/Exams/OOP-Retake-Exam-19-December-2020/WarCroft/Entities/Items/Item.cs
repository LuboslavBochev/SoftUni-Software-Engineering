using WarCroft.Entities.Characters.Contracts;

namespace WarCroft.Entities.Items
{
	public abstract class Item
	{
		protected Item(int weight)
		{
			this.Weight = weight;
		}

		public int Weight { get; }

		public abstract void AffectCharacter(Character character);
	}
}
