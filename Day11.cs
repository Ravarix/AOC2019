void Main()
{
	var data = "3,8,1005,8,345,1106,0,11,0,0,0,104,1,104,0,3,8,102,-1,8,10,1001,10,1,10,4,10,108,1,8,10,4,10,102,1,8,28,1006,0,94,2,106,5,10,1,1109,12,10,3,8,1002,8,-1,10,1001,10,1,10,4,10,1008,8,1,10,4,10,101,0,8,62,1,103,6,10,1,108,12,10,3,8,102,-1,8,10,1001,10,1,10,4,10,1008,8,0,10,4,10,102,1,8,92,2,104,18,10,2,1109,2,10,2,1007,5,10,1,7,4,10,3,8,102,-1,8,10,1001,10,1,10,4,10,108,0,8,10,4,10,102,1,8,129,2,1004,15,10,2,1103,15,10,2,1009,6,10,3,8,102,-1,8,10,1001,10,1,10,4,10,1008,8,1,10,4,10,101,0,8,164,2,1109,14,10,1,1107,18,10,1,1109,13,10,1,1107,11,10,3,8,102,-1,8,10,101,1,10,10,4,10,108,0,8,10,4,10,1001,8,0,201,2,104,20,10,1,107,8,10,1,1007,5,10,3,8,102,-1,8,10,101,1,10,10,4,10,1008,8,1,10,4,10,101,0,8,236,3,8,1002,8,-1,10,1001,10,1,10,4,10,108,0,8,10,4,10,1001,8,0,257,3,8,102,-1,8,10,101,1,10,10,4,10,108,1,8,10,4,10,102,1,8,279,1,107,0,10,1,107,16,10,1006,0,24,1,101,3,10,3,8,102,-1,8,10,101,1,10,10,4,10,108,0,8,10,4,10,1002,8,1,316,2,1108,15,10,2,4,11,10,101,1,9,9,1007,9,934,10,1005,10,15,99,109,667,104,0,104,1,21101,0,936995730328,1,21102,362,1,0,1105,1,466,21102,1,838210728716,1,21101,373,0,0,1105,1,466,3,10,104,0,104,1,3,10,104,0,104,0,3,10,104,0,104,1,3,10,104,0,104,1,3,10,104,0,104,0,3,10,104,0,104,1,21102,1,235350789351,1,21101,0,420,0,1105,1,466,21102,29195603035,1,1,21102,1,431,0,1105,1,466,3,10,104,0,104,0,3,10,104,0,104,0,21101,0,825016079204,1,21101,0,454,0,1105,1,466,21101,837896786700,0,1,21102,1,465,0,1106,0,466,99,109,2,21201,-1,0,1,21101,0,40,2,21102,1,497,3,21101,0,487,0,1105,1,530,109,-2,2106,0,0,0,1,0,0,1,109,2,3,10,204,-1,1001,492,493,508,4,0,1001,492,1,492,108,4,492,10,1006,10,524,1101,0,0,492,109,-2,2105,1,0,0,109,4,2102,1,-1,529,1207,-3,0,10,1006,10,547,21102,1,0,-3,21201,-3,0,1,22102,1,-2,2,21101,1,0,3,21102,1,566,0,1105,1,571,109,-4,2106,0,0,109,5,1207,-3,1,10,1006,10,594,2207,-4,-2,10,1006,10,594,21201,-4,0,-4,1106,0,662,21201,-4,0,1,21201,-3,-1,2,21202,-2,2,3,21101,613,0,0,1105,1,571,22101,0,1,-4,21101,0,1,-1,2207,-4,-2,10,1006,10,632,21101,0,0,-1,22202,-2,-1,-2,2107,0,-3,10,1006,10,654,22101,0,-1,1,21102,654,1,0,105,1,529,21202,-2,-1,-2,22201,-4,-2,-4,109,-5,2105,1,0"
		.Split(',').Select(s => long.Parse(s)).ToArray();
	var cpu = new Intputer(data);
	var grid = new DefaultDict<(int x, int y), Color>();
	var current = (loc: (x: 0, y: 0), dir: Dir.N);
	grid[current.loc] = Color.White;
	cpu.GetInput = () => grid[current.loc] == Color.White ? 1 : 0;
	var painted = 0;
	
	while (cpu.Executing) {
		var output = cpu.Output().Take(2).ToArray();
		if (output.Length == 0 || !cpu.Executing)
			break;
		if (grid[current.loc] == Color.None)
			painted++;
		grid[current.loc] = output[0] == 1 ? Color.White : Color.Black;
		current.dir = output[1] == 1 ? current.dir.Right() : current.dir.Left();
		var step = current.dir.Step();
		current.loc.x += step.x;
		current.loc.y += step.y;
	}
	Console.WriteLine(painted);
	
	//print (slow but golfy)
	for (int y = grid.Keys.Min(k => k.y), yMax = grid.Keys.Max(k => k.y); y <= yMax; yMax--){
		for (int x = grid.Keys.Min(k => k.x), xMax = grid.Keys.Max(k => k.x); x <= xMax; x++){
			var color = grid[(x,yMax)];
			Console.Write(color == Color.White ? '#' : '.');
		}
		Console.WriteLine();
	}
}

public enum Color { None, Black, White }
public enum Dir { N = 0, E = 1, S = 2, W = 3 }

static class DirMethods {
	public static Dir Right(this Dir dir) => dir == Dir.W ? Dir.N : (Dir)((int)dir + 1);
	public static Dir Left(this Dir dir) => dir == Dir.N ? Dir.W : (Dir)((int)dir - 1);
	public static (int x, int y) Step(this Dir dir){
		switch (dir){
			case Dir.N: return (0, 1);
			case Dir.E: return (1, 0);
			case Dir.S: return (0, -1);
			case Dir.W: return (-1, 0);
			default: throw new NotImplementedException();
		}
	}
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
