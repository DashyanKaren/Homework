using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterator
{
    internal class MyCollection : IEnumerable, IEnumerator
    {

        private int defaultCapacity = 16;
        private int _index = -1;
        private int _coefficent = 4;
        private int _version = 0;
        private object _syncRoot;

        private object[] _list;

        public bool IsFixedSize => false;

        public bool IsReadOnly => false;

        public int Count => _index;

        public bool IsSynchronized => false;

        public object SyncRoot
        {
            get
            {
                lock (this)
                {
                    if (_syncRoot == null)
                    {
                        _syncRoot = new object();
                        return _syncRoot;
                    }
                    else
                    {
                        return _syncRoot;
                    }
                }

            }
        }

        object IEnumerator.Current => _list[iteratorIndex];

        public object? this[int index]
        {
            get { return _list[index]; }
            set
            {
                _version++;
                _list[index] = value;
            }
        }

        private MyCollection(object[] array, int index)
        {
            _list = array;
            _index = index;
        }
        public MyCollection()
        {
            _list = new object[defaultCapacity];
        }
        public MyCollection(int capacity)
        {
            this.defaultCapacity = capacity;
            _list = new object[capacity];
        }

        public int Add(object? value)
        {

            if (value == null) return -1;
            if (_index >= defaultCapacity - 1)
            {
                addDefaultCapacity();
                var tmpList = new object[defaultCapacity];
                _list.CopyTo(tmpList, 0);
                _list = tmpList;
            }
            _index++;
            _list[_index] = value;
            _version++;
            return _index;
        }

        public void Clear()
        {
            _list = new object[defaultCapacity];
            _index = -1;
            _version++;
        }

        public bool Contains(object? value)
        {
            var index = IndexOf(value);
            if (index == -1) return false;
            return true;
        }

        public int IndexOf(object? value)
        {
            for (int i = 0; i <= _index; i++)
            {
                if (_list[i] == value) return i;
            }
            return -1; ;
        }

        public void Insert(int index, object? value)
        {
            if (index > _index || index < 0)
            {
                return;
            }
            if (index == _index)
            {
                Add(value);
                _list[_index] = _list[index];
                _list[index] = value;

            }
            else
            {
                if (_index + 1 >= defaultCapacity - 1)
                {
                    addDefaultCapacity();
                    var tmpList = new object[defaultCapacity];
                    Array.Copy(_list, 0, tmpList, 0, index);
                    Array.Copy(_list, index, tmpList, index + 1, _index - index);
                    tmpList[index] = value;
                    _list = tmpList;
                    _index++;
                }
                else
                {
                    for (int i = _index; i >= index; i--)
                    {
                        _list[i] = _list[i - 1];
                    }
                    _list[index] = value;
                    _index = _index + 1;
                }
                _version++;
            }
        }

        public void Remove(object? value)
        {
            int index = IndexOf(value);
            if (index < 0)
            {
                return;
            }
            removeByIndex(index);
        }

        public void RemoveAt(int index)
        {
            removeByIndex(index);
        }

        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        public IEnumerator GetEnumerator()
        {
            var myThis = new MyCollection(_list, _index);

            return myThis;
        }
        private void removeByIndex(int index)
        {
            if (index >= _index || index < 0)
            {
                throw new InvalidOperationException("Wrong argument");
            }
            for (int i = index; i <= _index; i++)
            {
                _list[i] = _list[i + 1];
            }
            _index--;
            _version++;
        }

        private void addDefaultCapacity()
        {
            defaultCapacity = _coefficent * defaultCapacity;
        }

        private int iteratorIndex = -1;

        bool IEnumerator.MoveNext()
        {
            if (iteratorIndex++ >= _index)
                return false;
            else return true;
        }

        void IEnumerator.Reset()
        {
            throw new NotImplementedException();
        }
    }
}
