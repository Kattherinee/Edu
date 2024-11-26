using System; 
using System.Collections;
using System.Collections.Generic;

public interface ILinkedList<T> : IEnumerable<T>
{
    void Add(T item);
    void Remove(T item); 
    T GetFirst(); 
    int Count { get; } 
}
public class MyLinkedList<T> : ILinkedList<T>, IEnumerable<T>
{
    private class Node
    {
        public T Value { get; }
        public Node? Next { get; set; } 

        public Node(T value) 
        {
            Value = value;
            Next = null;
        }
    }

    private Node? _head; 
    private Node? _tail; 
    private int _size; 
    private int _version; 

    public MyLinkedList()
    {
        _head = null;
        _tail = null;
        _size = 0;
        _version = 0;
    }

    public void Add(T item)
    {
        var newNode = new Node(item);
        if (_tail != null) _tail.Next = newNode;
        _tail = newNode;
        if (_head == null) _head = newNode; 
        _size++;
        _version++;
    }

   
    public void Remove(T item)
    {
        Node? current = _head;
        Node? previous = null;

        while (current != null)
        {
            if (Equals(current.Value, item))
            {
                if (previous == null) _head = current.Next; 
                else previous.Next = current.Next; 
                if (current.Next == null) _tail = previous; 
                _size--;
                _version++;
                return;
            }

            previous = current;
            current = current.Next;
        }

        throw new InvalidOperationException("Элемент не найден в списке.");
    }

    public T GetFirst()
    {
        if (_head == null) throw new InvalidOperationException("Список пуст.");
        return _head.Value;
    }

    public int Count => _size;

    public IEnumerator<T> GetEnumerator() => new LinkedListEnumerator(this);

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    private class LinkedListEnumerator : IEnumerator<T>
    {
        private readonly MyLinkedList<T> _list;
        private Node? _current;
        private readonly int _version;

        public LinkedListEnumerator(MyLinkedList<T> list)
        {
            _list = list;
            _current = null;
            _version = list._version;
        }

        public bool MoveNext()
        {
            if (_version != _list._version) throw new InvalidOperationException("Список был изменен.");
            _current = _current == null ? _list._head : _current.Next;
            return _current != null;
        }

        public void Reset() => _current = null;

        public T Current
        {
            get
            {
                if (_current == null) throw new InvalidOperationException("Итерация не началась или завершена.");
                return _current.Value;
            }
        }

        object? IEnumerator.Current => Current;

        public void Dispose() { }
    }
}
