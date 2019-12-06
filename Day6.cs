void Main()
{
	var data = @"COM)B
B)C
C)D
D)E
E)F
B)G
G)H
D)I
E)J
J)K
K)L
K)YOU
I)SAN"
	.Split('\n');
	var planets = new Dictionary<string, Planet>();
	foreach (var line in data){
		var split = line.Split(')');
		var (left, right) = (split[0].Trim(), split[1].Trim());
		if (!planets.TryGetValue(left, out var centerPlanet)) {
			planets[left] = (centerPlanet = new Planet(left));
		}
		if (!planets.TryGetValue(right, out var orbitPlanet)) {
			planets[right] = (orbitPlanet = new Planet(right));
		}
		orbitPlanet.Orbits = centerPlanet;
	}
	
	//checksum
	var count = 0;
	foreach (var planet in planets.Values){
		var current = planet;
		while (current.Orbits != null){
			current = current.Orbits;
			count++;
		}
	}
	Console.WriteLine($"checksum: {count}");
	Console.WriteLine(MinTraversal(planets, planets["YOU"], planets["SAN"]));
}

int MinTraversal(Dictionary<string, Planet> planets, Planet start, Planet end){
	//find common root
	var steps = new Dictionary<Planet, int>();
	var curr = (planet: start, dist: 0);
	while (curr.planet.Orbits != null){
		curr.planet = curr.planet.Orbits;
		curr.dist++;
		steps.Add(curr.planet, curr.dist);
	}

	curr = (planet: end, dist: 0);
	while (!steps.ContainsKey(curr.planet)){
		curr.planet = curr.planet.Orbits;
		curr.dist++;
	}
	
	var jumps = steps[curr.planet] + curr.dist - 2;
	return jumps;
}

class Planet {
	public readonly string Name;
	public Planet Orbits;
	public Planet(string name) => Name = name;
}