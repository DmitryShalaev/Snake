namespace Core.Snake;

public enum Direction {
	LEFT,
	RIGHT,
	UP,
	DOWN
}

[Serializable]
public class Snake : ICloneable {
	public delegate int Random(int max);
	public Random? GetRandom;
	public delegate void EndGame(string str);
	public EndGame? End;

	private readonly Map.Map Map;

	public List<(int X, int Y)> Body { get; private set; }
	public (int X, int Y) FoodPoint { get; private set; }

	public Direction Direction;
	private bool rotate = true;

	public Snake(Map.Map map) {
		Map = map;
		Body = new();
	}

	public object Clone() {
		Snake snake = (Snake)MemberwiseClone();
		snake.Body = new(Body);

		return snake;
	}

	public (int X, int Y) GetHead() => Body.Last();

	public void Move() {
		rotate = true;

		(int X, int Y) nextHead = GetNextPoint();

		if(Body.Contains(nextHead) || Map.OccupiedCells.ContainsKey(nextHead)) {
			End?.Invoke("Game over");
			return;
		}
		if(!Eat(nextHead)) {
			Body.Add(nextHead);
			Map.ЕmptyСells.Remove(nextHead);

			(int X, int Y) tail = Body.First();
			Body.Remove(tail);
			Map.ЕmptyСells.Add(tail);
		}
	}

	public (int X, int Y) GetNextPoint() {
		(int X, int Y) point = GetHead();

		switch(Direction) {
			case Direction.LEFT:
				if(point.X - 1 < 0) point.X = Map.NumberOfCells - 1; else point.X -= 1;
				break;
			case Direction.RIGHT:
				if(point.X + 1 > Map.NumberOfCells - 1) point.X = 0; else point.X += 1;
				break;
			case Direction.UP:
				if(point.Y - 1 < 0) point.Y = Map.NumberOfCells - 1; else point.Y -= 1;
				break;
			case Direction.DOWN:
				if(point.Y + 1 > Map.NumberOfCells - 1) point.Y = 0; else point.Y += 1;
				break;
		}
		return point;
	}

	public void Rotation(Keys key) {
		if(rotate) {
			switch(Direction) {
				case Direction.LEFT:
				case Direction.RIGHT:
					if(key == Keys.Down) Direction = Direction.DOWN;
					else if(key == Keys.Up) Direction = Direction.UP;
					break;
				case Direction.UP:
				case Direction.DOWN:
					if(key == Keys.Left) Direction = Direction.LEFT;
					else if(key == Keys.Right) Direction = Direction.RIGHT;
					break;
			}
			rotate = false;
		}
	}

	public void SpawnEat() {
		if(Map.ЕmptyСells.Count == 0) {
			End?.Invoke("Tou Win");
			return;
		}

		if(GetRandom != null)
			FoodPoint = Map.ЕmptyСells.ToArray()[GetRandom.Invoke(Map.ЕmptyСells.Count - 1)];
	}

	public bool Eat((int X, int Y) Head) {
		if(Head == FoodPoint) {
			Body.Add(Head);
			Map.ЕmptyСells.Remove(Head);

			SpawnEat();

			return true;
		}
		return false;
	}
}

