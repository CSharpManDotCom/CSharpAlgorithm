using System.Text;

int tt = int.Parse(Console.ReadLine()!);
while (tt-- > 0)
{
	var data = Console.ReadLine()!.Split(' ');
	int n = int.Parse(data[0]);
	int d = int.Parse(data[1]);
	string str = Console.ReadLine()!;
	StringBuilder sb = new();
	bool f = true;
	foreach (var item in str)
	{
		if (f && d > item - '0')
		{
			f = false;
			sb.Append(d.ToString());
		}
		sb.Append(item);
	}
	if (f)
	{
		sb.Append(d.ToString());
	}
	Console.WriteLine(sb.ToString());
}
