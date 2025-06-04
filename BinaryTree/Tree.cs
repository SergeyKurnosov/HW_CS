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
		public Element Root { get; protected set; }
		public int Depth_ALL { get; set; }
		public int With_L { get; set; }
		public int With_R { get; set; }
		public int With_ALL { get; set; }
		public int H_Index { get; set; }
		public int W_Index { get; set; }

		public Tree()
		{
			Root = null;
			Depth_ALL = 0;
			With_L = 0;
			With_R = 0;
			H_Index = 0;
			W_Index = 0;
			With_ALL = 0;
			Console.WriteLine($"TConstructor: {GetHashCode()}");
		}
		~Tree()
		{
			Console.WriteLine($"TDestructor: {GetHashCode()}");
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

		public void Print(Element Root)
		{
			if (Root == null) return;

			Print(Root.p_Left);
			Console.Write(Root.Data + "\t");
			if (Root.p_Left != null || Root.p_Right != null) Print(Root.p_Right);
		}



		public void Insert(int Data)
		{
			Insert(Data, this.Root);
			this.Depth_ALL = With_L = With_R = With_ALL = 0; 
			this.Depth_ALL = Depth(this.Root) + 1;
			CountWith(this.Root);
		}

		public int MinValue() { return MinValue(this.Root); }
		public int MaxValue() { return MaxValue(this.Root); }
		public int Count() {
			With_L = With_R = With_ALL = 0;
			return Count(this.Root); 
		}
		public int Sum() { return Sum(this.Root); }
		public void Print() => Print(this.Root);

		public void Erase(int value)
		{
			Erase(this.Root, value);
			this.Depth_ALL = With_L = With_R = With_ALL = 0;
			this.Depth_ALL = Depth(this.Root) + 1;
			CountWith(this.Root);
		}
		public void Clear()
		{
			Clear(this.Root);
			this.Depth_ALL = With_L = With_R = With_ALL = 0;
			this.Depth_ALL = Depth(this.Root) + 1;
			CountWith(this.Root);

			this.Root = null;
		}
		public void Insert_For_Print_Dinamic()
		{
			H_Index = W_Index = 0;
			this.Depth_ALL = With_L = With_R = With_ALL = 0;
			this.Depth_ALL = Depth(this.Root) + 1;
			CountWith(this.Root);
			//		int[,] arr1 = new int[this.Depth_ALL, this.With_ALL+1];
			//		int[,] arr2 = new int[this.Depth_ALL, this.With_ALL + 1];
			int[,] arr1 = new int[this.Depth_ALL, (this.With_ALL*2)+1];
			int[,] arr2 = new int[this.Depth_ALL, (this.With_ALL*2)+1];
			Insert_For_Print_Dinamic(this.Root.p_Left, arr1);
			Insert_For_Print_Dinamic(this.Root.p_Right, arr2);

			Console.WriteLine("Левая часть :");
			for (int i = 0; i < this.Depth_ALL; i++)
			{
				for (int j = 0; j < (this.With_ALL * 2) + 1; j++)
				{
					if (arr1[i, j] > 0) Console.Write(arr1[i, j]);
					else Console.Write("   ");
					}
				Console.WriteLine();
			}
			Console.WriteLine($"Корневой элемент : {this.Root.Data}") ;

			Console.WriteLine("Правая часть :");
			for (int i = 0; i < this.Depth_ALL; i++)
			{
				for (int j = 0; j < (this.With_ALL * 2)+1; j++)
				{
					if (arr2[i, j] > 0) Console.Write(arr2[i, j]);
					else Console.Write("   ");
				}
				Console.WriteLine();
			}
		}

		private void Clear(Element Root)
		{
			if (Root == null) return;
			Clear(Root.p_Left);
			Clear(Root.p_Right);

			Root.p_Left = null;
			Root.p_Right = null;
		}

		private Element Erase(Element Root, int value)
		{
			if (Root == null) return null;

			if (value < Root.Data) { Root.p_Left = Erase(Root.p_Left, value); }
			else if (value > Root.Data) { Root.p_Right = Erase(Root.p_Right, value); }

			else if (value == Root.Data)
			{
				if (Root.p_Right == null && Root.p_Left == null)
				{
					return Root.p_Right;
				}
				int min_value = MinValue(Root.p_Right);
				Root.Data = min_value;
				Root.p_Right = Erase(Root.p_Right, min_value);
			}
			return Root;
		}

		public int Depth(Element Root)
		{
			int L = 0, R = 0;
			if (Root == null) return 0;
			if (Root.p_Left != null) L += Depth(Root.p_Left) + 1;
			if (Root.p_Right != null) R += Depth(Root.p_Right) + 1;
			this.Depth_ALL = L > R ? L + 1 : R + 1;
			return L > R ? L : R;
		}

		public int CountWith(Element Root)
		{

			if (Root == null) return 0;
			Element Temp = this.Root;
			while (Temp.p_Left != null)
			{
				With_L++;
				Temp = Temp.p_Left;
			}
			Temp = this.Root;
			while (Temp.p_Right != null)
			{
				With_R++;
				Temp = Temp.p_Right;
			}

			this.With_ALL = this.With_L + 1 + this.With_R;
			return 0;
		}


		public void Insert_For_Print_Dinamic(Element Root, int[,] arr)
		{

			if (Root == null) return;
			int med = (this.With_ALL / 2);//  this.With_ALL % 2 == 0 ?  (this.With_ALL / 2) - 1 : (this.With_ALL / 2);
			arr[H_Index, W_Index + med] = Root.Data;


			//if (Root.p_Left != null)
			//{
			//	H_Index++;
			//	W_Index--;
			//	Insert_For_Print_Dinamic(Root.p_Left, arr);
			//	H_Index--;
			//	W_Index++;
			//}

			//if (Root.p_Right != null)
			//{
			//	H_Index++;
			//	W_Index++;
			//	Insert_For_Print_Dinamic(Root.p_Right, arr);
			//	W_Index--;
			//	H_Index--;
			//}

			if (Root.p_Left != null)
			{
				H_Index++;
				W_Index-=2;
				Insert_For_Print_Dinamic(Root.p_Left, arr);
				H_Index--;
				W_Index+=2;
			}

			if (Root.p_Right != null)
			{
				H_Index ++;
				W_Index += 2;
				Insert_For_Print_Dinamic(Root.p_Right, arr);
				W_Index -= 2;
				H_Index --;
			}

		}

	}
}
