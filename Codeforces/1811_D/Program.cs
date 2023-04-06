
bool Check(long X, long Y, long x, long y)
{
	//Console.WriteLine($"{X} {Y}  {x} {y}");
	if (X == 1)
	{
		return true;
	}
	else
	{
		if (y > X)
		{
			return Check(Y - X, X, y - X, x);
		}
		else if (y <= Y - X)
		{
			return Check(Y - X, X, y, x);
		}
		else
		{
			return false;
		}
	}
}

List<long> fib = new();
fib.Add(1);
fib.Add(1);
for (int i = 2; i <= 45; i++)
{
	fib.Add(fib[i - 2] + fib[i - 1]);
}

int tt = int.Parse(Console.ReadLine()!);

while (tt-- > 0)
{
	var data = Console.ReadLine()!.Split(' ');
	int n = int.Parse(data[0]);
	long x = long.Parse(data[1]);
	long y = long.Parse(data[2]);
	if (Check(fib[n], fib[n + 1], x, y))
	{
		Console.WriteLine("YES");
	}
	else
	{
		Console.WriteLine("NO");
	}
}
