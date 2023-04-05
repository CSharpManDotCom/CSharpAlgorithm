int tt = int.Parse(Console.ReadLine()!);
while (tt-- > 0)
{
	var data = Console.ReadLine()!.Split(' ');
	int n = int.Parse(data[0]);
	int x1 = int.Parse(data[1]);
	int y1 = int.Parse(data[2]);
	int x2 = int.Parse(data[3]);
	int y2 = int.Parse(data[4]);

	int w1 = Math.Min(Math.Min(x1, n - x1 + 1), Math.Min(y1, n - y1 + 1));
	int w2 = Math.Min(Math.Min(x2, n - x2 + 1), Math.Min(y2, n - y2 + 1));

	Console.WriteLine(Math.Abs(w1 - w2));

}
