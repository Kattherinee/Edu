using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace лб1
{
    public interface IDictionary<TKey, TValue>
    {
        void Add(TKey key, TValue? value);
        TValue? Get(TKey key);
        void Remove(TKey key);
        bool ContainsKey(TKey key);
    }

    public class KateDictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        private int _size;
        private readonly int _maxNodeSize;
        private Bucket[] _buckets;

        public KateDictionary(int size = 100, int maxNodeSize = 10)
        {
            _size = size;
            _maxNodeSize = maxNodeSize;
            _buckets = new Bucket[_size];
        }

        public void Add(TKey key, TValue? value)
        {
            int index = GetBucketIndex(key);
            if (_buckets[index] == null)
            {
                _buckets[index] = new Bucket(key, value);
                return;
            }

            _buckets[index].Add(key, value);

            if (_buckets[index].Items.Count > _maxNodeSize)
            {
                _size *= 2;
                Bucket[] newBuckets = new Bucket[_size];

                foreach (var bucket in _buckets)
                {
                    if (bucket != null)
                    {
                        foreach (var i in bucket.Items)
                        {
                            int newIndex = GetBucketIndex(i.Key);
                            if (newBuckets[newIndex] == null)
                            {
                                newBuckets[newIndex] = new Bucket(i.Key, i.Value);
                            }
                            else
                                newBuckets[newIndex].Add(i.Key, i.Value);
                        }
                    }
                }

                _buckets = newBuckets;
            }
        }

        public TValue? Get(TKey key)
        {
            int index = GetBucketIndex(key);
            if (_buckets[index] == null) return default(TValue);

            return _buckets[index].Get(key);
        }

        public void Remove(TKey key)
        {
            int index = GetBucketIndex(key);
            if (_buckets[index] == null) return;

            _buckets[index].Remove(key);
            if (_buckets[index].Items == null) _buckets[index] = null;
        }

        public bool ContainsKey(TKey key)
        {
            int index = GetBucketIndex(key);
            return _buckets[index] != null && _buckets[index].Contains(key);
        }

        private int GetBucketIndex(TKey key)
        {
            int hashCode = key.GetHashCode();
            int index = (hashCode & int.MaxValue) % _size;
            return index;
        }

        private class Bucket
        {
            private List<KeyValuePair<TKey, TValue>> _items;

            public Bucket(TKey key, TValue value)
            {
                _items = new List<KeyValuePair<TKey, TValue>>();
                _items.Add(new KeyValuePair<TKey, TValue>(key, value));
            }

            public void Add(TKey key, TValue value)
            {
                if (Contains(key)) return;
                _items.Add(new KeyValuePair<TKey, TValue>(key, value));
            }

            public void Remove(TKey key)
            {
                var itemToRemove = _items.FirstOrDefault(i => i.Key.Equals(key));
                if (itemToRemove.Key != null)
                    _items.Remove(itemToRemove);
            }

            public bool Contains(TKey key)
            {
                return _items.Any(i => i.Key.Equals(key));
            }

            public TValue? Get(TKey key)
            {
                var item = _items.FirstOrDefault(i => i.Key.Equals(key));
                return item.Value;
            }

            public List<KeyValuePair<TKey, TValue>> Items => _items;
        }
    }
}