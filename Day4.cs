void Main()
{
	var (lower, upper) = (240298, 784956);
	var cnt = 0;
	for (var num = lower; num <= upper; num++){
		if (IsValid(num))
			cnt++;
	}
	Console.WriteLine(cnt);
}

bool IsValid(int num){
	var chrs = num.ToString();
	int? doubleInt = null;
	HashSet<int> overGrouped = new HashSet<int>();
	int? prev = null;
	foreach (var chr in chrs){
		int intVal = (int)Char.GetNumericValue(chr);
		if (prev.HasValue && intVal < prev.Value){
			return false;
		}
		if (prev.HasValue 
			&& prev.Value == intVal 
			&& !overGrouped.Contains(intVal)
			&& !(doubleInt.HasValue && doubleInt.Value != intVal))
		{
			if (doubleInt.HasValue && doubleInt.Value == intVal){
				doubleInt = null;
				overGrouped.Add(intVal);
			} else {
				doubleInt = intVal;
			}
		}
		prev = intVal;
	}
	return doubleInt.HasValue;
}