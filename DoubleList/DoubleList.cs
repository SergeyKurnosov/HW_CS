using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace DoubleList
{
	internal class DoubleList : IEnumerable<int>
	{
		Element Head { get; set; }
		Element Tail { get; set; }
		public int Lenth { get; private set; }


		/////////////////////////Creating
		public void Add(int y) => PushBack(y);

		public DoubleList()
		{
			Head = null;
			Tail = null;
			Lenth = 0;
			Console.WriteLine($"LConstructor\t:{GetHashCode()}");
		}

		~DoubleList()
		{
			Head = null;
			Tail = null;
			Console.WriteLine($"LDestructor\t:{GetHashCode()}");
		}

		public void Clear()
		{
			Head = null;
			Tail = null;
			Lenth = 0;
		}

		/////////////////////////Adding
		public void PushFront(int Data)
		{
			Element new_element = new Element(Data, Head);
			if (Head == null)
			{
				Tail = Head = new_element;
				Lenth++;
				return;
			}

			Head.pPrev = new_element;
			Head = new_element;
			Lenth++;
		}


		public void PushBack(int Data)
		{
			if (Head == null)
			{
				PushFront(Data);
				Lenth++;
				return;
			}

			Element new_element = new Element(Data, null, Tail);
			Tail.pNext = new_element;
			Tail = new_element;
			Lenth++;
		}

		public void Insert(int Data, int index)
		{
			if (index > Lenth || index < 0)
			{
				throw new IndexOutOfRangeException("Error: Выход за пределы списка");
			}

			if (index == 0)
			{
				PushFront(Data);
				return;
			}

			Element Temp = Head;
			for (int i = 0; i < index - 1; i++)
			{
				if (Temp.pNext == null) break;
				Temp = Temp.pNext;
			}
			Element new_element = new Element(Data, Temp.pNext, Temp);
			Temp.pNext = new_element;
			new_element.pNext.pPrev = new_element;
			Lenth++;

		}

		/////////////////////////Removing
		public void PopFront()
		{
			if (Head != null && Lenth > 1)
			{
				Head = Head.pNext;
				Head.pNext.pPrev = Head;
				Lenth--;
			}

		}

		public void PopBack()
		{
			if (Tail != null && Lenth > 1)
			{
				Tail = Tail.pPrev;
				Tail.pPrev.pNext = Tail;
				Lenth--;
			}

		}

		/////////////////////////Print
		public void Print_go()
		{
			for (Element Temp = Head; Temp != null; Temp = Temp.pNext)
			{
				Console.Write($"{Temp.Data}\t");
			}
			Console.WriteLine();
			Console.WriteLine($"Количество {Lenth}");
		}

		public void Print_back()
		{
			for (Element Temp = Tail; Temp != null; Temp = Temp.pPrev)
			{
				Console.Write($"{Temp.Data}\t");
			}
			Console.WriteLine();
			Console.WriteLine($"Количество {Lenth}");
		}

		public IEnumerator<int> GetEnumerator()
		{
			for (Element Temp = Head; Temp != null; Temp = Temp.pNext)
			{
				yield return Temp.Data;
			}
		}
		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

	}
}
