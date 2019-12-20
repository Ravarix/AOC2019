void Main()
{
	var data = @"157 ORE => 5 NZVS
165 ORE => 6 DCFZ
44 XJWVT, 5 KHKGT, 1 QDVJ, 29 NZVS, 9 GPVTF, 48 HKGWZ => 1 FUEL
12 HKGWZ, 1 GPVTF, 8 PSHF => 9 QDVJ
179 ORE => 7 PSHF
177 ORE => 5 HKGWZ
7 DCFZ, 7 PSHF => 2 XJWVT
165 ORE => 2 GPVTF
3 DCFZ, 7 NZVS, 5 HKGWZ, 10 PSHF => 8 KHKGT"
	.Split('\n');
	
	var recipes = new RecipeBook();
	foreach(var line in data){
		var split = line.Split("=>").Select(s => s.Trim()).ToArray();
		var output = split[1].Split(' ');
		var inputs = split[0].Split(',').Select(i => {
			var s = i.Trim().Split(' ');
			return (int.Parse(s[0]), s[1].Trim());
		}).ToArray();
		recipes[output[1]] = (int.Parse(output[0]), inputs);
	}
	//Console.WriteLine(recipes);
	var oreRequired = 0L;
	var leftovers = new Dictionary<string, long>();
	Calc(recipes, "FUEL", 82892753, ref oreRequired, leftovers);
	Console.WriteLine($"Requires {oreRequired} ore.");
	Console.WriteLine(leftovers);
}

class RecipeBook : Dictionary<string, (int resultQty, (int qty, string ele)[] inputs)> {}

void Calc(RecipeBook recipes, string chemical, long qty, ref long oreRequired, Dictionary<string, long> leftovers){
	if(chemical == "ORE"){
		oreRequired += qty;
		return;
	}
	if (leftovers.TryGetValue(chemical, out var leftoverQty)){
		if(leftoverQty >= qty){
			leftovers[chemical] = leftoverQty - qty;
			return;
		} else {
			leftovers[chemical] = 0;
			qty -= leftoverQty;
		}
	}
	var result = recipes[chemical];
	var required = (int)Math.Ceiling((double)qty / result.resultQty);
	if (!leftovers.ContainsKey(chemical))
		leftovers[chemical] = 0;
	leftovers[chemical] += (required * result.resultQty) - qty;
	
	for(long i = 0; i < required; i ++)
	foreach(var input in result.inputs)
		Calc(recipes, input.ele, input.qty, ref oreRequired, leftovers);
}