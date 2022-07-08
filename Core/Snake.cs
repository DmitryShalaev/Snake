namespace Core.Snake;

internal enum Direction {
	LEFT,
	RIGHT,
	UP,
	DOWN
}

[Serializable]
public class Snake : ICloneable {
	public delegate (int X, int Y) Food();
	public Food? CreateFood;

	private readonly Map.Map Map;

	public List<(int X, int Y)> Body { get; set; }
	public (int X, int Y) FoodPoint;

	private Direction direction;

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
			//TODO: Game over
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

		switch(direction) {
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
			switch(direction) {
				case Direction.LEFT:
				case Direction.RIGHT:
					if(key == Keys.Down) direction = Direction.DOWN;
					else if(key == Keys.Up) direction = Direction.UP;
					break;
				case Direction.UP:
				case Direction.DOWN:
					if(key == Keys.Left) direction = Direction.LEFT;
					else if(key == Keys.Right) direction = Direction.RIGHT;
					break;
			}
			rotate = false;
		}
	}

	public bool Eat((int X, int Y) nextHead) {
		if(nextHead == FoodPoint) {
			Body.Add(nextHead);
			Map.ЕmptyСells.Remove(nextHead);

			if(CreateFood != null)
				FoodPoint = CreateFood();

			return true;
		}
		return false;
	}

	public void FoodCreated((int X, int Y) point) => FoodPoint = point;
}

