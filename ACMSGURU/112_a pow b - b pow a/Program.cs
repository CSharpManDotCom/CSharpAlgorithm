var strs = Console.ReadLine()!.Split(' ');

int a = int.Parse(strs[0]);
int b = int.Parse(strs[1]);
Console.WriteLine(BigInteger.Power(a, b) - BigInteger.Power(b, a));

public readonly struct BigInteger
{

	private readonly int type = 0;
	private readonly string value = "0";

	public int Type { get { return type; } }
	public string Value { get { return value; } }

	public BigInteger(int type, string value)
	{
		this.type = type;
		this.value = value;
	}

	public BigInteger(string s)
	{
		if (Check(s))
		{
			if (s[0] == '-')
			{
				type = -1;
				value = s.Substring(1);
			}
			else
			{
				value = s;
			}
		}
	}

	public override string ToString()
	{
		if (type == -1)
		{
			return $"-{value}";
		}
		else
		{
			return value;
		}
	}

	static bool Check(string s)
	{
		if (s.Length > 0)
		{
			if (s[0] == '-')
			{
				if (s.Length == 1)
				{
					return false;
				}
				for (int i = 1; i < s.Length; i++)
				{
					if (s[i] < '0' || s[i] > '9')
					{
						return false;
					}
				}
			}
			else
			{
				foreach (var item in s)
				{
					if (item < '0' || item > '9')
					{
						return false;
					}
				}
			}

			return true;
		}
		return false;
	}

	public static BigInteger operator +(BigInteger a) => a;

	public static BigInteger operator -(BigInteger a)
	{
		return new BigInteger(-a.type, a.value);
	}

	public static BigInteger operator +(BigInteger a, BigInteger b)
	{
		if (a.type == -1 && b.type == -1)
		{
			return -(-a + -b);
		}
		else if (a.type == -1)
		{
			return b - (-a);
		}
		else if (b.type == -1)
		{
			return a - (-b);
		}
		List<int> x = new();
		List<int> y = new();
		for (int i = a.value.Length - 1; i >= 0; i--)
		{
			x.Add(int.Parse(a.value[i].ToString()));
		}
		for (int i = b.value.Length - 1; i >= 0; i--)
		{
			y.Add(int.Parse(b.value[i].ToString()));
		}

		if (x.Count() < y.Count())
		{
			List<int> tmp = x;
			x = y;
			y = tmp;
		}

		int w = x.Count() - y.Count();
		for (int i = 0; i < w; i++)
		{
			y.Add(0);
		}

		int c = 0;
		for (int i = 0; i < x.Count(); i++)
		{
			c += x[i] + y[i];
			x[i] = c % 10;
			c = c / 10;
		}
		if (c != 0)
		{
			x.Add(c);
		}
		x.Reverse();
		return new BigInteger(string.Join("", x));
	}

	public static BigInteger operator -(BigInteger a, BigInteger b)
	{
		if (a.type == -1 && b.type == -1)
		{
			return -(-a - (-b));
		}
		else if (a.type == -1)
		{
			return -((-a) + b);
		}
		else if (b.type == -1)
		{
			return a + (-b);
		}

		List<int> x = new();
		List<int> y = new();
		for (int i = a.value.Length - 1; i >= 0; i--)
		{
			x.Add(int.Parse(a.value[i].ToString()));
		}
		for (int i = b.value.Length - 1; i >= 0; i--)
		{
			y.Add(int.Parse(b.value[i].ToString()));
		}
		BigInteger res = new BigInteger();
		int t = 1;
		if (string.Compare(a.value, b.value) < 0)
		{
			t = -1;
			List<int> tmp = x;
			x = y;
			y = tmp;
		}
		int w = x.Count() - y.Count();
		for (int i = 0; i < w; i++)
		{
			y.Add(0);
		}

		int c = 0;
		for (int i = 0; i < x.Count(); i++)
		{
			c += x[i] - y[i];
			if (c < 0)
			{
				x[i] = c + 10;
				c = -1;
			}
			else
			{
				x[i] = c;
				c = 0;
			}
		}
		bool fi = true;
		for (int i = y.Count() - 1; i >= 0; i--)
		{
			if (fi && x[i] == 0 && i != 0)
			{
				x.RemoveAt(i);
			}
			else
			{
				break;
			}
		}

		x.Reverse();
		return new BigInteger(t, string.Join("", x));

	}

	public static BigInteger Power(int a, int b)
	{
		BigInteger res = new BigInteger("1");
		for (int i = 0; i < b; i++)
		{
			res = res * a;
		}
		return res;
	}

	public static BigInteger operator *(BigInteger a, int b)
	{
		List<int> x = new();
		for (int i = a.value.Length - 1; i >= 0; i--)
		{
			x.Add(int.Parse(a.value[i].ToString()));
		}
		int c = 0;
		for (int i = 0; i < x.Count(); i++)
		{
			c += b * x[i];
			x[i] = c % 10;
			c = c / 10;
		}
		if (c != 0)
		{
			while (c != 0)
			{
				x.Add(c % 10);
				c = c / 10;
			}
		}
		x.Reverse();
		return new BigInteger(string.Join("", x));
	}

	//public static BigInteger operator ^(BigInteger a, int b)
	//{
	//	BigInteger res = new BigInteger("1");
	//	while (b > 0)
	//	{
	//		if ((b & 1) == 1)
	//		{
	//			res = res * a;
	//		}
	//		a = a * a;
	//		b >>= 1;
	//	}
	//	return res;
	//}
}

