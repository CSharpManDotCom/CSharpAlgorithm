int k = int.Parse(Console.ReadLine()!);

List<int> fib = new();
fib.Add(1);
fib.Add(1);
for (int i = 2; i < 40; i++)
{
	fib.Add(fib[i - 2] + fib[i - 1]);
}

int ans = 0;
for (int i = 0; i < k; i++)
{
	ans += fib[i];
}

Console.WriteLine(ans);
