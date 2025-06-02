using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleList
{
	internal class Element
	{
		public int Data { get; set; }
		public Element pNext { get; set; }
		public Element pPrev { get; set; }
		public Element(int Data , Element pNext = null , Element pRev = null)
		{
			this.Data = Data ;
			this.pNext = pNext ;
			this.pPrev = pRev ;
			Console.WriteLine($"EConstructor\t:{GetHashCode()}");
		}

		~Element()
		{
			Console.WriteLine($"EDestructor\t:{GetHashCode()}");
		}



	}
}
