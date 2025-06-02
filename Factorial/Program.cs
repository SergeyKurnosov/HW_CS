using System;
using System.Collections.Generic;
using System.Text;

class BigNumber
{
	private List<byte> digits = new List<byte> { };

	public BigNumber()
	{
		digits.Add(1);
	}
	public void Multiply(int n)
	{
		int carry = 0;
		for (int i = 0; i < digits.Count; i++)
		{
			int temp = digits[i] * n + carry;
			digits[i] = Convert.ToByte(temp % 10);
			carry = temp / 10;
		}
		while (carry > 0)
		{
			digits.Add(Convert.ToByte(carry % 10));
			carry /= 10;
		}

		Console.WriteLine($"{n}! = {this}");
	}

	public override string ToString()
	{
		StringBuilder sb = new StringBuilder();
		for (int i = digits.Count - 1; i >= 0; i--)
		{
			sb.Append(digits[i]);
		}
		return sb.ToString();
	}
}

class Program
{
	static void Main()
	{

		Console.Write("Введите число : ");
		int n = Convert.ToInt32(Console.ReadLine());


		BigNumber factorial = new BigNumber();

		try
		{
			for (int i = 1; i <= n; i++)
			{
				factorial.Multiply(i);
			}
		}
		catch (Exception e)
		{

			Console.WriteLine(e.Message);
		}
	}
}
