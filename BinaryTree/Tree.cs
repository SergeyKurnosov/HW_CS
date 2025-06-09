using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BinaryTree
{
	internal class Tree
	{
		static readonly int BASE_INTERVAL = 3;

		public Element Root { get; protected set; }

		public Tree()
		{
			Root = null;
		}
		~Tree() { }

		public void Insert(int Data)
		{
			Insert(Data, this.Root);
		}

		public void Insert(int Data, Element Root)
		{

			if (this.Root == null) this.Root = new Element(Data);

			if (Root == null) return;
			if (Data < Root.Data)
			{
				if (Root.p_Left == null) Root.p_Left = new Element(Data);
				else Insert(Data, Root.p_Left);
			}
			else if (Data > Root.Data)
			{
				if (Root.p_Right == null) Root.p_Right = new Element(Data);
				else Insert(Data, Root.p_Right);
			}
		}

		public int MinValue(Element Root)
		{
			if (Root == null) return 0;
			else return Root.p_Left == null ? Root.Data : MinValue(Root.p_Left);
		}

		public int MaxValue(Element Root)
		{
			if (Root == null) return 0;
			else return Root.p_Right == null ? Root.Data : MaxValue(Root.p_Right);
		}

		public int Count(Element Root)
		{
			return Root == null ? 0 : Count(Root.p_Left) + Count(Root.p_Right) + 1;
		}

		public int Sum(Element Root)
		{
			return Root == null ? 0 : Sum(Root.p_Left) + Sum(Root.p_Right) + Root.Data;
		}


		public int MinValue() { return MinValue(this.Root); }
		public int MaxValue() { return MaxValue(this.Root); }
		public int Count()
		{
			return Count(this.Root);
		}
		public int Sum() { return Sum(this.Root); }

		public void Erase(int Data)
		{
			Element Root = this.Root;
			Erase(Data, Root, null);
		}
		public void Clear()
		{
			Clear(this.Root);
			this.Root = null;
		}

		private void Clear(Element Root)
		{
			if (Root == null) return;
			Clear(Root.p_Left);
			Clear(Root.p_Right);

			Root.p_Left = null;
			Root.p_Right = null;
		}

		void Erase(int Data, Element Root, Element Parent)
		{
			if (Root == null) return;
			Erase(Data, Root.p_Left, Root);
			Erase(Data, Root.p_Right, Root);
			if (Data == Root.Data)
			{
				if (Root.p_Left == Root.p_Right)
				{
					if (Root.Equals(Parent.p_Left)) Parent.p_Left = null;
					if (Root.Equals(Parent.p_Right)) Parent.p_Right = null;
				}
				else
				{
					if (Count(Root.p_Left) > Count(Root.p_Right))
					{
						Root.Data = MaxValue(Root.p_Left);
						Erase(MaxValue(Root.p_Left), Root.p_Left, Root);
					}
					else
					{
						Root.Data = MinValue(Root.p_Right);
						Erase(MinValue(Root.p_Right), Root.p_Right, Root);
					}
				}
			}
		}

			public int Depth()
		{
			return Depth(Root);
		}
		int Depth(Element Root)
		{
			if (Root == null) return 0;
			int lDepth = Depth(Root.p_Left);
			int rDepth = Depth(Root.p_Right);
			return (lDepth > rDepth ? lDepth : rDepth) + 1;
		}


		public void DepthPrint(int Depth)
		{
			DepthPrint(this.Root, Depth);
			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine();
		}
		void DepthPrint(Element Root, int Depth)
		{
			int interval = BASE_INTERVAL * (this.Depth(this.Root) - Depth);
			if (Root == null)
			{
				Console.Write("".PadLeft(interval));
				return;
			}
			if (Depth == 0)
			{
				Console.Write(Root.Data.ToString().PadLeft(interval));
			}
			else
			{
				DepthPrint(Root.p_Left, Depth - 1);
				DepthPrint(Root.p_Right, Depth - 1);
			}
		}
		public void TreePrint(int Depth = 0)
		{
			if (Root == null) return;
			if (this.Depth(this.Root) - Depth == 0) return;
			int interval = BASE_INTERVAL * (this.Depth() - Depth);
			Console.Write("".PadLeft(interval));
			PrintInterval(this.Depth(this.Root) - Depth);
			DepthPrint(Depth);
			TreePrint(Depth + 1);
		}
		void PrintInterval(int count)
		{
			for (int i = 0; i < count; i++) Console.Write("    ");
		}
		public void Print()
		{
			Print(this.Root);
			Console.WriteLine();
		}
		void Print(Element Root)
		{
			if (Root == null) return;
			Print(Root.p_Left);
			Console.Write(Root.Data + "\t");
			Print(Root.p_Right);
		}

		public void Balance()
		{
			Balance(this.Root);
		}

		void Balance(Element Root)
		{
			if (Root == null) return;
			if (Math.Abs(Count(Root.p_Left) - Count(Root.p_Right)) < 2) return;
			if (Count(Root.p_Left) > Count(Root.p_Right))
			{
				if (Root.p_Right == null) Root.p_Right = new Element(Root.Data);
				else Insert(Root.Data, Root.p_Right);
				Root.Data = MaxValue(Root.p_Left);
				Erase(MaxValue(Root.p_Left), Root.p_Left, Root);
			}
			else
			{
				if (Root.p_Left == null) Root.p_Left = new Element(Root.Data);
				else Insert(Root.Data, Root.p_Left);
				Root.Data = MinValue(Root.p_Right);
				Erase(MinValue(Root.p_Right), Root.p_Right, Root);
			}
			Balance(Root.p_Left);
			Balance(Root.p_Right);
			Balance(Root);
		}

	}

}
