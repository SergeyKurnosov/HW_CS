using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
	internal class Element
	{
		public int Data { get; set; }
		public Element p_Left { get; set; }
		public Element p_Right { get; set; }

		public Element(int Data, Element p_Left = null, Element p_Right = null)
		{
			this.Data = Data;
			this.p_Left = p_Left;
			this.p_Right = p_Right;
			Console.WriteLine($"EConstructor: {GetHashCode()}");
		}

		~Element()
		{
			Console.WriteLine($"EDestructor: {GetHashCode()}");
		}




	}
}
