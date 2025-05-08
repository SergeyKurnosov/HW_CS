using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
	internal class Program
	{
		static void Main(string[] args)
		{
			double left_operand = 0, right_operand = 0, result;
			char operation = ' ';
			string input_left, input_right, input_operation;

			bool is_valid_operands = false, is_valid_operation;

			do
			{
				Console.Write("Please input left operand : "); input_left = Console.ReadLine();
				Console.Write("Please input operation ( + - * / ) : "); input_operation = Console.ReadLine();
				Console.Write("Please input right operand : "); input_right = Console.ReadLine();

				is_valid_operands = double.TryParse(input_left, out left_operand) && double.TryParse(input_right, out right_operand);
				is_valid_operation = char.TryParse(input_operation, out operation);

				if (!is_valid_operands || !is_valid_operation || !valid_operation(operation))
				{
					Console.WriteLine("You entered incorrectly, try again");
				}


			} while (!is_valid_operands || !is_valid_operation || !valid_operation(operation));

			result = calculation_result(operation, left_operand, right_operand);
			if (double.IsNaN(result))
				Console.WriteLine("Error division by 0");
			else
				Console.WriteLine($"The result is : {result}");
		}

		static bool valid_operation(char operation)
		{
			HashSet<char> validOperations = new HashSet<char> { '+', '-', '*', '/' };
			return validOperations.Contains(operation);
		}

		static double calculation_result(char operation, double left_operand, double right_operand)
		{
			if (valid_operation(operation))
			{
				switch (operation)
				{
					case '+':
						return left_operand + right_operand;
					case '-':
						return left_operand - right_operand;
					case '*':
						return left_operand * right_operand;
					case '/':
						return right_operand != 0 ? left_operand / right_operand : double.NaN;
				}
			}
			return 0.0;
		}
	}
}


