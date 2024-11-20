using System;

public interface IQueue<T>
{
    void Enqueue(T item);
    T? Dequeue();
}
public class KatyQueue<T> : IQueue<T>
{
	private class Node
	{
		public T Value; 
		public Node? Next;

		public Node(T value)
		{
			Value = value;
			Next = null;
		}
	}

	private Node? _head; 
	private Node? _tail; 
	private int _size; 


	public KatyQueue()
	{
		_head = null;
		_tail = null; 
		_size = 0; 
	}


	public void Enqueue(T item)
	{
		Node newNode = new Node(item); 
		if (_tail != null)
		{
			_tail.Next = newNode; 
		}
		_tail = newNode; 
		if (_head == null)
		{
			_head = newNode; 
		}
		_size++; 
	}

	
	public T? Dequeue()
	{
		if (_head == null) 
			return default; 
		T item = _head.Value; 
		_head = _head.Next; 
		if (_head == null)
		{
			_tail = null; 
		}
		_size--; 
		return item; 
	}
}


