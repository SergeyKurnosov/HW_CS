using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace ForwardList
{
	internal class ForwardList : IEnumerable<int>
	{
		Element Head { get; set; }
		public int Lenth { get; private set; }


		public void Add(int y)
		{
			PushBack(y);
		}

	public IEnumerator<int> GetEnumerator()
		{
			for (Element Temp = Head; Temp != null; Temp = Temp.pNext)
			{
				yield return Temp.Data;
			}
		}

		public ForwardList()
		{
			Head = null;
			Lenth = 0;
			Console.WriteLine($"LConstructor\t:{GetHashCode()}");
		}

		~ForwardList()
		{
			Head = null;
			Console.WriteLine($"LDestructor\t:{GetHashCode()}");
		}

		public void Clear()
		{
			Head = null;
			Lenth = 0;
		}

		/// ////////////////////////////////Adding
		public void PushFront(int Data)
		{
			Head = new Element(Data, Head);
			Lenth++;
		}


		public void PushBack(int Data)
		{
			if (Head == null)
			{
				PushFront(Data);
				return;
			}

			Element Temp = Head;
			while (Temp.pNext != null) Temp = Temp.pNext;

			Temp.pNext = new Element(Data);
			Lenth++;
		}

		public void Insert(int Data, int index)
		{
			if(index > Lenth || index < 0)
			{
			throw new IndexOutOfRangeException("Error: Выход за пределы списка");
			}

			if(index == 0)
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
			Temp.pNext = new Element(Data , Temp.pNext);
			Lenth++;

		}

		/////////////////////////Removing
		public void PopFront()
		{
			if (Head != null)
				Head = Head.pNext;
			Lenth--;
		}

		public void PopBack()
		{
			if(Head == null || Head.pNext == null)
			{
				PopFront(); 
				return;
			}

			Element Temp = Head;
			while (Temp.pNext.pNext != null) Temp = Temp.pNext;
			Temp.pNext = null;
			Lenth--;
		}

		public void Print()
		{
			for (Element Temp = Head; Temp != null; Temp = Temp.pNext)
			{
				Console.Write($"{Temp.Data}\t");
			}
			Console.WriteLine();	
			Console.WriteLine($"Количество {Lenth}");
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

	}
}
