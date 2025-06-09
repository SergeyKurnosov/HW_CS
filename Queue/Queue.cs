using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue
{
	internal class Queue<T>
	{
		private Node<T> head; 
		private Node<T> tail;

		public Queue()
		{
			head = null;
			tail = null;
		}

		public void Enqueue(T item)
		{
			Node<T> newNode = new Node<T>(item);
			if (tail == null)
			{
				head = newNode;
				tail = newNode;
			}
			else
			{
				tail.Next = newNode;
				newNode.Prev = tail;
				tail = newNode;
			}
		}

		public T Dequeue()
		{
			if (head == null)
				throw new InvalidOperationException("Очередь пуста");

			T value = head.Data;
			head = head.Next;

			if (head != null)
				head.Prev = null;
			else
				tail = null;

			return value;
		}

		public T Peek()
		{
			if (head == null)
				throw new InvalidOperationException("Очередь пуста");
			return head.Data;
		}

		public bool IsEmpty()
		{
			return head == null;
		}
	}
}
