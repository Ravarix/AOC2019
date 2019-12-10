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
			
	var sightMap = map.ToDictionary(a => a, a => 0);
	foreach(var center in map){
		foreach(var asteroid in map){
			if (center == asteroid)
				continue;
			if (!IsOccluded(map, center, asteroid))
				sightMap[center]++;
		}
	}
	var best = sightMap.Aggregate((l, r) => l.Value > r.Value ? l : r);
	Console.WriteLine(best);
	
	//time to blow em up
	//
	var grouped = new Dictionary<double, List<(int x, int y)>>();
	foreach(var asteroid in map){
		if (asteroid == best.Key)
			continue;
		var delta = asteroid.Sub(best.Key);
		var angle = delta.ToAngle();
		if (angle < 0)
			angle += 360;
		if (!grouped.ContainsKey(angle)){
			grouped[angle] = new List<(int, int)>();
		}
		grouped[angle].Add(delta);
	}
	
	foreach(var group in grouped){
		group.Value.Sort((a, b) => b.SqDist().CompareTo(a.SqDist()));
	}
	int count = 0;
	while (grouped.Count > 0){	
		foreach(var key in grouped.Keys.OrderBy(k => k)){
			var group = grouped[key];
			var destroyed = group[group.Count - 1].Add(best.Key);
			group.RemoveAt(group.Count - 1);
			Console.WriteLine($"{++count}: Destroyed {destroyed}");
			if (group.Count == 0)
				grouped.Remove(key);
		}
	}
}

static bool IsOccluded(HashSet<(int x, int y)> map, (int x, int y) center, (int x, int y) asteroid){
	var delta = asteroid.Sub(center);
	int gcf;
	(int x, int y)? step = null;
	if (delta.x == 0 || delta.y == 0){
		step = (Math.Sign(delta.x), Math.Sign(delta.y));
	} else if ((gcf = delta.GCF()) > 1){
		step = delta.Div(gcf);
	}
	if (step.HasValue){
		while (true){
			delta = delta.Sub(step.Value);
			if (delta.x == 0 && delta.y == 0)
				break;
			if (map.Contains(center.Add(delta))){
				return true;			
			}
		}
	}
	return false;
}

public static IEnumerable<int> GetFactors(int x){
 	x = Math.Abs(x);
    for (int i = 1; i*i <= x; i++){
        if (x % i == 0){
            yield return i;
            if ((x / i) != i){
                yield return x / i;
            }
        }
    }
}

public static class TupleMethods {
	public static (int x, int y) Add(this (int x, int y) a, (int x, int y) b) => (a.x + b.x, a.y + b.y);
	public static (int x, int y) Sub(this (int x, int y) a, (int x, int y) b) => (a.x - b.x, a.y - b.y);
	public static (int x, int y) Div(this (int x, int y) a, int b) => (a.x / b, a.y / b);
	public static (int x, int y) Mul(this (int x, int y) a, int b) => (a.x * b, a.y * b);
	public static int GCF(this (int x, int y) a) => GetFactors(a.x).Intersect(GetFactors(a.y)).Max();
	public static double ToAngle(this (int x, int y) a, int offset = 90) => ((180/Math.PI)*Math.Atan2(a.y, a.x) + offset) % 360;
	public static double SqDist(this (int x, int y) a) => a.x * a.x + a.y * a.y;
}
