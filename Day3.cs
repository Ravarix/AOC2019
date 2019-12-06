void Main()
{
    var input = @"R75,D30,R83,U83,L12,D49,R71,U7,L72
U62,R66,U55,R34,D71,R55,D58,R83"
		.Split("\n");
    var wireA = ParseWire(input[0]);
    var wireB = ParseWire(input[1]);

    var intersections = wireA.Keys.Intersect(wireB.Keys);
    Console.WriteLine(intersections.Min(i => Math.Abs(i.x) + Math.Abs(i.y))); //part 1
    Console.WriteLine(intersections.Min(i => wireA[i] + wireB[i]) + 2); //part 2
}

Dictionary<(int x, int y), int> ParseWire(string input)
{
    var matrix = new Dictionary<(int x, int y), int>();
	var curr = (x: 0, y: 0);
	var dist = 0;
    foreach (var dir in input.Split(',')) {
		var len = int.Parse(dir.Substring(1));
		for (int i = 0; i < len; i++) {
			switch(dir[0]){
				case 'U': curr.y++; break;
				case 'D': curr.y--; break;
				case 'R': curr.x++; break;
				case 'L': curr.x--; break;
			}
			matrix.TryAdd(curr, dist++);
		}
    }
    return matrix;
}