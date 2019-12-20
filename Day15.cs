void Main()
{
	var data = "3,1033,1008,1033,1,1032,1005,1032,31,1008,1033,2,1032,1005,1032,58,1008,1033,3,1032,1005,1032,81,1008,1033,4,1032,1005,1032,104,99,1002,1034,1,1039,1002,1036,1,1041,1001,1035,-1,1040,1008,1038,0,1043,102,-1,1043,1032,1,1037,1032,1042,1105,1,124,1001,1034,0,1039,101,0,1036,1041,1001,1035,1,1040,1008,1038,0,1043,1,1037,1038,1042,1105,1,124,1001,1034,-1,1039,1008,1036,0,1041,101,0,1035,1040,1001,1038,0,1043,101,0,1037,1042,1105,1,124,1001,1034,1,1039,1008,1036,0,1041,1001,1035,0,1040,1002,1038,1,1043,1001,1037,0,1042,1006,1039,217,1006,1040,217,1008,1039,40,1032,1005,1032,217,1008,1040,40,1032,1005,1032,217,1008,1039,37,1032,1006,1032,165,1008,1040,39,1032,1006,1032,165,1102,2,1,1044,1105,1,224,2,1041,1043,1032,1006,1032,179,1101,0,1,1044,1106,0,224,1,1041,1043,1032,1006,1032,217,1,1042,1043,1032,1001,1032,-1,1032,1002,1032,39,1032,1,1032,1039,1032,101,-1,1032,1032,101,252,1032,211,1007,0,37,1044,1106,0,224,1102,0,1,1044,1105,1,224,1006,1044,247,1002,1039,1,1034,1001,1040,0,1035,1002,1041,1,1036,102,1,1043,1038,1002,1042,1,1037,4,1044,1105,1,0,2,32,78,22,32,29,53,14,61,46,21,16,34,19,73,25,76,17,97,20,4,63,23,46,15,13,75,30,58,28,29,82,23,32,11,22,16,82,2,57,24,31,48,51,4,52,25,92,15,78,78,55,32,46,5,31,88,21,74,29,47,89,34,80,58,14,33,4,69,74,33,70,60,7,39,29,68,12,1,11,64,17,75,4,52,11,47,24,71,23,99,83,28,17,56,94,33,8,90,9,83,7,62,15,77,45,49,5,53,36,67,18,82,93,22,53,9,20,20,60,90,22,25,48,15,27,68,12,27,13,50,25,92,73,35,81,15,1,48,22,12,35,38,1,36,44,12,82,30,92,22,71,31,39,20,43,34,46,36,24,67,72,13,85,45,18,68,64,20,40,2,67,25,15,33,40,53,48,32,59,13,57,28,61,26,15,88,21,42,15,95,34,74,32,7,82,63,22,95,22,83,22,20,25,11,81,88,94,31,9,50,26,76,78,34,88,19,68,72,7,85,14,54,80,5,5,45,24,24,91,22,34,39,32,22,11,15,87,57,35,83,86,51,23,71,29,13,23,59,51,36,46,33,27,99,4,13,59,14,55,88,89,29,22,97,46,40,2,17,48,93,9,40,35,94,6,71,34,14,2,39,29,36,5,55,72,31,22,87,4,50,27,92,36,88,20,82,79,21,35,67,57,23,48,6,15,65,10,69,12,29,3,8,51,56,90,29,88,59,28,40,89,18,93,83,2,66,46,22,50,30,86,3,49,55,22,33,97,27,51,15,7,26,57,36,98,3,64,35,84,90,16,88,3,7,98,94,13,1,13,71,88,36,17,84,29,5,57,50,84,14,47,25,85,64,31,95,8,43,10,81,36,58,3,40,24,40,20,13,5,14,50,42,23,9,74,40,92,4,10,3,60,1,91,39,27,77,9,20,42,47,35,15,90,43,21,46,30,63,85,28,93,6,82,8,86,86,88,30,33,26,8,92,58,32,20,1,40,72,79,49,68,14,73,6,2,99,9,5,12,47,43,14,29,66,8,31,12,97,8,69,32,63,31,96,23,32,24,60,69,74,15,24,6,76,39,14,33,89,36,6,63,21,10,95,95,32,45,41,8,76,82,14,78,15,79,72,71,34,39,27,56,27,48,28,94,21,30,25,27,53,1,81,26,24,80,55,27,51,2,93,15,80,12,28,36,56,3,7,77,34,90,49,44,24,35,99,63,11,88,93,28,75,21,62,57,8,44,10,57,9,61,4,43,3,21,20,41,95,13,6,98,16,93,70,98,64,27,35,49,12,18,23,17,68,5,11,13,61,79,30,87,53,11,11,26,80,23,55,92,46,31,70,13,76,87,29,6,91,19,90,88,36,39,25,99,12,87,90,1,93,12,98,28,27,44,51,18,32,80,86,1,26,1,19,99,83,18,2,58,29,68,3,77,82,6,55,63,56,2,61,4,90,21,22,71,30,36,51,64,32,44,52,9,51,80,93,9,71,20,41,98,21,12,61,80,10,80,33,92,80,78,8,29,9,70,4,76,24,13,92,5,26,80,88,72,3,3,49,73,27,98,15,46,30,73,17,94,30,78,5,75,16,2,57,3,96,15,47,36,31,53,39,34,44,26,96,41,68,9,81,20,40,25,76,55,9,67,3,28,18,63,1,31,31,87,22,20,67,10,2,77,20,74,28,79,34,52,91,51,24,47,13,58,9,61,10,77,25,72,17,45,8,51,16,72,3,69,80,79,6,53,48,83,34,63,86,42,19,42,0,0,21,21,1,10,1,0,0,0,0,0,0"
		.Split(',').Select(s => long.Parse(s)).ToArray();
	
	var cpu = new Intputer(data);
	var planner = new Planner();
	planner.Map[planner.Loc] = Tile.Open;
	Dir dir = default;
	var result = -1L;
	cpu.GetInput = () => {
		dir = planner.GetMove(result);
		
		switch (dir){
			case Dir.N: return 1;
			case Dir.E: return 4;
			case Dir.S: return 2;
			case Dir.W: return 3;
			default: throw new NotImplementedException();
		}
	};
	var steps = 0;
	while(cpu.Executing && steps++ < 10000){
		var status = cpu.Output().First();
		var attempt = planner.Loc.Plus(dir);
		result = status;
		switch(status){
			case 0:
				planner.Map[attempt] = Tile.Wall; 
				break;
			case 1:
				planner.Map[attempt] = Tile.Open;
				planner.Loc = attempt;
				break;
			case 2:
				planner.Map[attempt] = Tile.Goal;
				planner.Loc = attempt;
				break;
		}
		ExpandBounds(attempt);
		if (planner.Current == Tile.Goal)
			break;
	}
	planner.PrintMap();
}

class Planner {
	public readonly DefaultDict<(int x, int y), Tile> Map = new DefaultDict<(int x, int y), Tile>();
	public (int x, int y) Loc = default;
	public Tile Current => Map[Loc];
	Dir _outDir;
	
	public Dir GetMove(long result){
		var neighborCheck = CheckNeighbors(); //touch any unknowns
		if (neighborCheck.HasValue){
			//return _outDir = neighborCheck.Value;
		}
		var openNeighbors = Dirs.Where(dir => Map[Loc.Plus(dir)] == Tile.Open).ToArray();
		if (openNeighbors.Length == 1){ //dead end
			return _outDir = openNeighbors.First();
		}
		
		if (openNeighbors.Length == 2){
			var exitDir = openNeighbors.Where(dir => dir != _outDir.Reverse()).First();
			return _outDir = exitDir;
		}
		
		if (openNeighbors.Length == 3){
			PrintMap();
			if (true){
				System.Threading.Thread.Sleep(500);
				return _outDir = _outDir.Left();
			} else {
				switch(Util.ReadLine()){
					case "w": return _outDir = Dir.N;
					case "d": return _outDir = Dir.E;
					case "s": return _outDir = Dir.S;
					case "a": return _outDir = Dir.W;
					default: return _outDir;
				}
			}
		}
		
		return _outDir;
	}
	
	Dir? CheckNeighbors() => Dirs
		.Where(dir => Map[Loc.Plus(dir)] == Tile.Unknown)
		.Cast<Dir?>().FirstOrDefault();
		
	public void PrintMap(){
		Util.ClearResults();
		Console.WriteLine($"Bounds={Bounds}  Loc={Loc}  OutDir={_outDir}");
		for (int y = Bounds.y.min, yMax = Bounds.y.max; y <= yMax; yMax--){
			for (int x = Bounds.x.min, xMax = Bounds.x.max; x <= xMax; x++){
				string s = " ";
				switch (Map[(x, yMax)]){
					case Tile.Wall: s = "#"; break;
					case Tile.Open: s = "."; break;
					case Tile.Goal: s = "$"; break;
				}
				if (x == 0 && y == 0){
					s = "@";
					Console.WriteLine("HERE");
				}
				if (x == Loc.x && yMax == Loc.y)
					s = "D";
				Console.Write(s);
			}
			Console.WriteLine();
		}
	}
}


static ((int min, int max) x, (int min, int max) y) Bounds = default;
static void ExpandBounds((int x, int y) loc){
	Bounds.x.min = Math.Min(Bounds.x.min, loc.x);
	Bounds.x.max = Math.Max(Bounds.x.max, loc.x);
	Bounds.y.min = Math.Min(Bounds.y.min, loc.y);
	Bounds.y.max = Math.Max(Bounds.y.max, loc.y);
}

public enum Dir { N, E, S, W }
public enum Tile { Unknown, Open, Wall, Goal }
public static Dir[] Dirs = Enum.GetValues(typeof(Dir)).Cast<Dir>()
	//.Reverse() //uncomment for right hand
	.ToArray();

static class DirMethods {
	public static (int x, int y) Plus(this (int x, int y) loc, Dir dir) {
		var step = dir.Step();
		return (loc.x + step.x, loc.y + step.y);
	}
	public static (int x, int y) Step(this Dir dir){
		switch (dir){
			case Dir.N: return (0, 1);
			case Dir.E: return (1, 0);
			case Dir.S: return (0, -1);
			case Dir.W: return (-1, 0);
			default: throw new NotImplementedException();
		}
	}
	public static Dir Reverse(this Dir dir) => (Dir)(((int)dir + 2) % 4);
	public static Dir Right(this Dir dir) => dir == Dir.W ? Dir.N : (Dir)((int)dir + 1);
	public static Dir Left(this Dir dir) => dir == Dir.N ? Dir.W : (Dir)((int)dir - 1);
}

class Intputer {
	public DefaultDict<long, long> Memory = new DefaultDict<long, long>();
	public Func<long> GetInput;
	long _ptr = 0;
	long _relativeBase = 0;
	public bool Executing { get; private set; } = true;
	
	public Intputer(long[] data){
		for(var i = 0; i < data.Length; i++)
			Memory[i] = data[i];
	}
	
	enum Mode { Position, Immediate, Relative }
	
	public IEnumerable<long> Output(){
		while (Executing){
			var inst = Memory[_ptr].ToString().PadLeft(2, '0');
			var op = int.Parse(inst.Substring(inst.Length-2));
			bool advance = true;
			var modes = inst.Substring(0, inst.Length-2).PadLeft(3, '0').Select(c => (int)Char.GetNumericValue(c)).Cast<Mode>().Reverse().ToArray();
			
			long getArgAddr(int argNum) {
				switch(modes[argNum]){
					case Mode.Position: return Memory[++_ptr];
					case Mode.Immediate: return ++_ptr;
					case Mode.Relative: return _relativeBase + Memory[++_ptr];
					default: throw new NotImplementedException();
				}
			}
			long? output = null;
			switch(op) {
				case 1: {
					var a = Memory[getArgAddr(0)];
					var b = Memory[getArgAddr(1)];
					Memory[getArgAddr(2)] = a + b;
				} break;
				case 2: {
					var a = Memory[getArgAddr(0)];
					var b = Memory[getArgAddr(1)];
					Memory[getArgAddr(2)] = a * b;
				} break;
				case 3: {
					Memory[getArgAddr(0)] = GetInput();
				} break;
				case 4: {
					output = Memory[getArgAddr(0)];
				} break;
				case 5: {
					var a = Memory[getArgAddr(0)];
					var b = Memory[getArgAddr(1)];
					if (a != 0){
						_ptr = b;
						advance = false;
					}
				} break;
				case 6: {
					var a = Memory[getArgAddr(0)];
					var b = Memory[getArgAddr(1)];
					if (a == 0){
						_ptr = b;
						advance = false;
					}
				} break;
				case 7: {
					var a = Memory[getArgAddr(0)];
					var b = Memory[getArgAddr(1)];
					Memory[getArgAddr(2)] = a < b ? 1 : 0;
				} break;
				case 8: {
					var a = Memory[getArgAddr(0)];
					var b = Memory[getArgAddr(1)];
					Memory[getArgAddr(2)] = a == b ? 1 : 0;
				} break;
				case 9: {
					var a = Memory[getArgAddr(0)];
					_relativeBase += a;
				} break;
				case 99: {
					Console.WriteLine("end");
					Executing = false;
					yield break;
				}
				default: Console.WriteLine($"Unkown Code {op}"); break;
			}
			if (advance)
				_ptr++;
			
			if (output.HasValue){
				yield return output.Value;
			}
		}
	}
}

class DefaultDict<TKey,  TVal> : Dictionary<TKey, TVal> where TVal : new() {
	Func<TVal> _generator;
	public DefaultDict(Func<TVal> generator = null) => _generator = generator;
	
	new public TVal this[TKey key] {
		get {
			if (!ContainsKey(key))
				base[key] = _generator == null ? new TVal() : _generator();
			return base[key];
		}
		set { base[key] = value; }
	}
}