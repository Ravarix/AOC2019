void Main()
{
	var input = @"<x=-7, y=-8, z=9>
<x=-12, y=-3, z=-4>
<x=6, y=-17, z=-9>
<x=4, y=-10, z=-6>"
		.Split('\n');

	var planets = new HashSet<Planet>();
	foreach(var line in input) {
		var values = line.Split(',').Select(s => int.Parse(s.Split('=')[1].Replace(">",""))).ToArray();
		planets.Add(new Planet(values[0], values[1], values[2]));
	}
	
	for(var i = 0; i < 0; i++){
		Step(planets);
	}
	
	var energy = planets.Sum(p => 
		(Math.Abs(p.Pos.x) + Math.Abs(p.Pos.y) + Math.Abs(p.Pos.z)) * 
		(Math.Abs(p.Vel.x) + Math.Abs(p.Vel.y) + Math.Abs(p.Vel.z)));
		
	Console.WriteLine(energy);
	
	var count = (x: 1, y: 1, z: 1);
	Step(planets);
	
	while(!planets.All(p => p.Vel.x == 0)){
		foreach(var p1 in planets)
		foreach(var p2 in planets)
			if (p1 != p2)
				p1.Vel.x -= p1.Pos.x.CompareTo(p2.Pos.x);
				
		foreach(var planet in planets)
			planet.Pos.x += planet.Vel.x;
		count.x++;
	}
	
	while(!planets.All(p => p.Vel.y == 0)){
		foreach(var p1 in planets)
		foreach(var p2 in planets)
			if (p1 != p2)
				p1.Vel.y -= p1.Pos.y.CompareTo(p2.Pos.y);
				
		foreach(var planet in planets)
			planet.Pos.y += planet.Vel.y;
		count.y++;
	}
	
	while(!planets.All(p => p.Vel.z == 0)){
		foreach(var p1 in planets)
		foreach(var p2 in planets)
			if (p1 != p2)
				p1.Vel.z -= p1.Pos.z.CompareTo(p2.Pos.z);
				
		foreach(var planet in planets)
			planet.Pos.z += planet.Vel.z;
		count.z++;
	}
	
	count = (count.x * 2, count.y * 2, count.z * 2);
	Console.WriteLine(count);
}

void Step(HashSet<Planet> planets){
	//apply gravity
	foreach(var p1 in planets)
	foreach(var p2 in planets)
		if (p1 != p2)
			p1.ApplyGravity(p2);
	
	//Move
	foreach(var planet in planets){
		planet.Pos.x += planet.Vel.x;
		planet.Pos.y += planet.Vel.y;
		planet.Pos.z += planet.Vel.z;
	}
}

class Planet {
	public (int x, int y, int z) Pos;
	public (int x, int y, int z) Vel = (0, 0, 0);
	
	public Planet(int x, int y, int z) => Pos = (x, y, z);
	
	public void ApplyGravity(Planet other){
		Vel.x -= Pos.x.CompareTo(other.Pos.x);
		Vel.y -= Pos.y.CompareTo(other.Pos.y);
		Vel.z -= Pos.z.CompareTo(other.Pos.z);
	}
}