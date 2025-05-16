using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Calc
{
	internal class Program
	{
		static char[] operations = new char[] { '+', '-', '*', '/' };
		static char[] digits = "0123456789. ".ToCharArray();

		static void Main(string[] args)
		{

			string expression = "(1+(22+33)/5-44/(2+6)*8)*3";     // -96
		//	string expression = "22+33-44/2+6*8";                 // 81
		//  string expression = "(5/(2+1))+5/(2*((1+(1+0))+1))";  // 2.5

			double result = 0;
			Console.WriteLine(expression);
			if (check_stroke(expression))
			{
				result = evaluate(expression, 0);
			}
			else
			{
				Console.WriteLine("\nline not correctly");
			}
			
			Console.WriteLine(result);
			
		}



		static bool check_stroke(string expression)
		{
			char[] oper = new char[] { '+', '-', '*', '/', '(', ')' };

			if (expression.StartsWith("+") || expression.StartsWith("-") || expression.StartsWith("*") || expression.StartsWith("/"))
			{
				return false;
			}
			if (expression.EndsWith("+") || expression.EndsWith("-") || expression.EndsWith("*") || expression.EndsWith("/"))
			{
				return false;
			}
			int countLeftParenthesis = expression.Count(c => c == '(');
			int countRightParenthesis = expression.Count(c => c == ')');
			if (countLeftParenthesis != countRightParenthesis)
			{
				return false;
			}
			foreach (char element in expression)
			{
				bool exit = false;
				for (int i = 0; i < oper.Length; ++i)
				{
					if (element == oper[i])
					{
						exit = true;
					}
				}
				if (Char.IsDigit(element))
				{
					exit = true;
				}
				if (!exit)
				{
					return false;
				}
			}
			Console.WriteLine("\nthe line is entered correctly");
			return true;
		}

		static double get_result(string expression)
		{
			string[] s_values = expression.Split(Program.operations);
			double[] values = new double[s_values.Length];


			for (int i = 0; i < values.Length; i++)
			{
				
				if (s_values[i] != "")
					values[i] = Convert.ToDouble(s_values[i]);

			}
			Console.WriteLine();


			string[] operations = expression.Split(Program.digits);
			operations = operations.Where(o => o != "" && o != ",").ToArray();

			while (operations.Contains("*") || operations.Contains("/"))
			{
				for (int i = 0; i < operations.Length; i++)
				{
					if (operations[i] == "*") values[i] *= values[i + 1];
					if (operations[i] == "/") values[i] /= values[i + 1];

					if (operations[i] == "*" || operations[i] == "/")
					{
						for (int j = i + 1; j < operations.Length; j++)
						{
							operations[j - 1] = operations[j];
							values[j] = values[j + 1];
						}
						if (operations[operations.Length - 1] != " ")
						{
							operations[operations.Length - 1] = " ";
							values[values.Length - 1] = 0;
						}
					}


				}
			}

			while (operations.Contains("+") || operations.Contains("-"))
			{
				if (operations[0] == "+") values[0] += values[1];
				if (operations[0] == "-") values[0] -= values[1];
				if (operations[0] == "+" || operations[0] == "-")
				{
					for (int j = 1; j < operations.Length; j++)
					{
						operations[j - 1] = operations[j];
						values[j] = values[j + 1];
					}
					if (operations[operations.Length - 1] != " ")
					{
						operations[operations.Length - 1] = " ";
						values[values.Length - 1] = 0;
					}
				}
			}

			return values[0];
		}


		static double evaluate(string expression, int index)
		{
			string expression_copy = expression;

			for (int i = index; i < expression.Length; i++)
			{

				if (expression[i] == '(')
				{
					int exp_mini_index = i + 1;
					int count = 0;
					int count_parentheses_open = 1;
					int count_parentheses_close = 0;
					bool a = true;
					while (a)
					{
						++count;
						++i;
						if (expression[i] == '(')
							count_parentheses_open++;
						else if (expression[i] == ')')
							count_parentheses_close++;

						a = count_parentheses_open == count_parentheses_close ? false : true;
					}
					string exp_mini = expression.Substring(exp_mini_index, --count);
					const int valic = 0;
					double result = mathematical_expression_in_parentheses(exp_mini, expression_copy, valic);
					expression_copy = expression_copy.Replace("("+exp_mini+")", Convert.ToString(result));
					++i;
				}
			}

			Console.WriteLine("================================================");
			Console.WriteLine(expression_copy);
			Console.Write("\nthis result : ");
			return get_result(expression_copy);
		}

		static double mathematical_expression_in_parentheses(string expression, string expression_copy, int index)
		{

			for (int i = index; i < expression.Length; i++)
			{

				if (expression[i] == '(')
				{
					int exp_mini_index = i + 1;
					int count = 0;
					int count_parentheses_open = 1;
					int count_parentheses_close = 0;
					bool a = true;
					while (a)
					{
						++count;
						++i;
						if (expression[i] == '(')
							count_parentheses_open++;
						else if (expression[i] == ')')
							count_parentheses_close++;

						a = count_parentheses_open == count_parentheses_close ? false : true;
					}
					string exp_mini = expression.Substring(exp_mini_index, --count);
					const int valic = 0;

					double result = mathematical_expression_in_parentheses(exp_mini, expression_copy , valic);
					expression = expression.Replace("("+exp_mini+")", Convert.ToString(result));
					++i;
				}
			}
			Console.WriteLine("================================================");
			Console.WriteLine(expression);
			return get_result(expression);
		}

	}
}
