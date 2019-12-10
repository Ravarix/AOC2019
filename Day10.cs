void Main()
{
	var data = @"###..#.##.####.##..###.#.#..
#..#..###..#.......####.....
#.###.#.##..###.##..#.###.#.
..#.##..##...#.#.###.##.####
.#.##..####...####.###.##...
##...###.#.##.##..###..#..#.
.##..###...#....###.....##.#
#..##...#..#.##..####.....#.
.#..#.######.#..#..####....#
#.##.##......#..#..####.##..
##...#....#.#.##.#..#...##.#
##.####.###...#.##........##
......##.....#.###.##.#.#..#
.###..#####.#..#...#...#.###
..##.###..##.#.##.#.##......
......##.#.#....#..##.#.####
...##..#.#.#.....##.###...##
.#.#..#.#....##..##.#..#.#..
...#..###..##.####.#...#..##
#.#......#.#..##..#...#.#..#
..#.##.#......#.##...#..#.##
#.##..#....#...#.##..#..#..#
#..#.#.#.##..#..#.#.#...##..
.#...#.........#..#....#.#.#
..####.#..#..##.####.#.##.##
.#.######......##..#.#.##.#.
.#....####....###.#.#.#.####
....####...##.#.#...#..#.##."
	.Split('\n').Select(s => s.Trim()).ToArray();
	
	var dims = (x: data[0].Length, y: data.Length);
	var map = new HashSet<(int x, int y)>();
	for (var y = 0; y < dims.y; y++)
	for (var x = 0; x < dims.x; x++)
		if (data[y][x] == '#')
			map.Add((x, y));
			
	var (bestCenter, sightMap) = map
		.Select(c => (center: c, map: GetSightMap(map, c)))
		.OrderBy(tup => tup.map.Values.Count)
		.Last();
	
	Console.WriteLine(bestCenter);
	Console.WriteLine(sightMap.Values.Count);
	
	//time to blow em up
	int count = 0;
	while (sightMap.Count > 0){	
		foreach(var key in sightMap.Keys.OrderBy(k => k)){
			var group = sightMap[key];
			var destroyed = group[group.Count - 1];
			group.RemoveAt(group.Count - 1);
			Console.WriteLine($"{++count}: Destroyed {destroyed}");
			if (group.Count == 0)
				sightMap.Remove(key);
		}
	}
}

static Dictionary<double, List<(int x, int y)>> GetSightMap(HashSet<(int x, int y)> map, (int x, int y) center){
	var grouped = map
		.GroupBy(a => a.Sub(center).ToAngle())
		.ToDictionary(k => k.Key, k => k.ToList());
		
	foreach(var group in grouped){
		group.Value.Sort((a, b) => b.Sub(center).SqDist().CompareTo(a.Sub(center).SqDist()));
	}
	return grouped;
}

public static class TupleMethods {
	public static (int x, int y) Add(this (int x, int y) a, (int x, int y) b) => (a.x + b.x, a.y + b.y);
	public static (int x, int y) Sub(this (int x, int y) a, (int x, int y) b) => (a.x - b.x, a.y - b.y);
	public static (int x, int y) Div(this (int x, int y) a, int b) => (a.x / b, a.y / b);
	public static (int x, int y) Mul(this (int x, int y) a, int b) => (a.x * b, a.y * b);
	public static double ToAngle(this (int x, int y) a, int offset = 90){
		var angle = ((180/Math.PI)*Math.Atan2(a.y, a.x) + offset) % 360;
		return angle < 0 ? angle + 360 : angle;
	}
	public static double SqDist(this (int x, int y) a) => a.x * a.x + a.y * a.y;
}
