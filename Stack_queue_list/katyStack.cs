using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack_queue_list
{
    public interface IStack<T>
    {
        void Push(T item);
        T? Pop();
    }
    public class KatyStack<T>:IStack<T>
    {
        private T[] _items;
        private int _currentIndex;
        private const int DefaultCapacity = 4;

        public KatyStack()
        {
            _items = new T[DefaultCapacity];
            _currentIndex = -1;
        }

        public void Push(T item)
        {
            if (_currentIndex == _items.Length - 1)
            {
                Array.Resize(ref _items, _items.Length * 2);
            }
            _items[++_currentIndex] = item;
        }

        public T? Pop()
        {
            if (_currentIndex < 0)
                return default;
            T item = _items[_currentIndex--];
            return item;
        }
    }
}
