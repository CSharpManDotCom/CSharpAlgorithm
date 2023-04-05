int tt = int.Parse(Console.ReadLine()!);
while (tt-- > 0)
{
	int n = int.Parse(Console.ReadLine()!);
	var data = Console.ReadLine()!.Split(' ');
	List<int> ans = new();
	for (int i = 0; i < n; i++)
	{
		ans.Add(0);
	}
	for (int i = 0; i < n - 2; i++)
	{
		int a = int.Parse(data[i]);
		int b = int.Parse(data[i + 1]);
		if (a < b)
		{
			ans[i + 2] = b;
		}
		else if (a > b)
		{
			ans[i] = a;
		}
	}
	for (int i = 0; i < n - 1; i++)
	{
		int a = int.Parse(data[i]);
		if (a != Math.Max(ans[i], ans[i + 1]))
		{
			if (ans[i] < ans[i + 1])
			{
				ans[i] = a;
			}
			else
			{
				ans[i + 1] = a;
			}
		}
	}
	for (int i = 0; i < n; i++)
	{
		Console.Write($"{ans[i]} ");
	}
	Console.WriteLine();
	//for (int i = 0; i < n - 1; i++)
	//{
	//	Console.Write($"{Math.Max(ans[i], ans[i + 1])}-");
	//}
	//Console.WriteLine();

}
