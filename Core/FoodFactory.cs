namespace Core.Snake {

	public class FoodFactory {
		private readonly Map.Map Map;
		private readonly Random Random;

		public FoodFactory(Map.Map map) {
			Map = map;
			Random = new();
		}

		public (int X, int Y) CreateFood() => Map.ЕmptyСells.ToArray()[Random.Next(Map.ЕmptyСells.Count - 1)];
	}
}
