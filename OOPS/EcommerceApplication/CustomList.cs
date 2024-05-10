using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceApplication
{
    public partial class CustomList<Type>
    {
         private int _count;
        private int _capacity;
        public int Count { get { return _count; } }
        public int Capacity { get { return _capacity; } }
        public Type[] _array;
        public Type this[int index]
        {
            get { return _array[index]; }
            set { _array[index] = value; }
        }
        public CustomList()
        {
            _count = 0;
            _capacity = 4;
            _array = new Type[_capacity];
        }
        public CustomList(int size)
        {
            _count = 0;
            _capacity = size;
            _array = new Type[_capacity];
        }
        public void Add(Type element)
        {
            if (_count == _capacity)
            {
                GrowSize();
            }
            _array[_count] = element;
            _count++;
        }
        void GrowSize()
        {
            _capacity = _capacity * 2;
            Type[] temp = new Type[_capacity];
            for (int i = 0; i < _count; i++)
            {
                temp[i] = _array[i];
            }
            _array = temp;
        }
        public void AddRange(CustomList<Type> elements)
        {
            _capacity = _count + elements.Count + 4; // givimg extra element to prevent calling growSize()
            Type[] temp = new Type[_capacity];
            for (int i = 0; i < _count; i++)
            {
                temp[i] = _array[i];
            }
            //adding another list to temp array
            int k = 0;
            for (int i = _count; i < _count + elements.Count; i++)
            {
                temp[i] = elements[k];
                k++;
            }
            //assinging temp values to original array
            _array = temp;
            _count = _count + elements.Count;
        }
        public bool Contains(Type element)
        {
            bool temp = false;
            foreach (Type data in _array)
            {
                if (data.Equals(element))   // == Cant be used for custom type
                {
                    temp = true;
                    break;
                }
            }
            return temp;
        }
        public int IndexOf(Type element)
        {
            int index = -1;
            for (int i = 0; i < _count; i++)
            {
                if (element.Equals(_array[i]))
                {
                    index = i;
                    break;
                }
            }
            return index;
        }
        //10,20,20,30,40,50,60,70 - insert at index 2 after 2 element
        //1,2,6,3,4,5 - inserted 6
        public void Insert(int position, Type element)
        {
            _capacity = _capacity + 1 + 4; //4 given for extra space;
            Type[] temp = new Type[_capacity];
            for (int i = 0; i < _count+1; i++)
            {
                if (i < position)
                {
                    temp[i] = _array[i];
                }
                else if (i == position)
                {
                    temp[i] = element;
                }
                else
                {
                    temp[i] = _array[i - 1]; // storing previous element to temp array.
                }
                
            }
            _count++;
            _array = temp;
        }
        // 7,8,9 - add at index 2
        // 1,2,3,4,5
        // 1,2,
        //1,2,7,8,9
        // 1,2,3,7,8,9,3,4,5
        public void InsertRange(int position, CustomList<Type> elements)
        {
            _capacity = _count+elements.Count+4;
            Type[] temp = new Type[_capacity];
            // inserting before position
            for(int i = 0;i<position;i++)
            {
                temp[i] = _array[i];
            }
            int j = 0;
            // inserting after position
            for(int i=position;i<position+elements.Count;i++)
            {
                temp[i] = elements[j];
                j++;
            }
            //insering remaining elements after range of elements
            int k = position;
            for(int i = position+elements.Count;i<_count+elements.Count;i++)
            {
                temp[i] = _array[k];
                k++;
            }
            _array = temp;
            _count = _count+elements.Count;
        }
        //10,20,20,30,40,50,60,70
        //10,20,30,40,50,60,70
        public void RemoveAt(int position)
        {
            for(int i = 0;i<_count-1;i++)
            {
                if(i >= position)
                {
                    _array[i] = _array[i+1]; // we replace with next element values to replace
                }
            }
            _count--;
            
        }
        //10,20,30,40,50,60,70
        //10,20,40,50,60,70
        public bool Remove(Type element) 
        {
            int position = IndexOf(element);
            if(position>=0)
            {
                RemoveAt(position);
                return true;
            }
            return false;
        }  

        //1,2,3,4
        //4,3,2,1
        public void Reverse()
        {
            Type[] temp = new Type[_capacity];
            int j=0;
            for(int i = _count-1;i>=0;i--)
            {
                temp[j] = _array[i];
                j++;
            }
            _array = temp;
        }

        //1,4,3,2
        //1,2,3,4
        public void Sort()
        {
            for(int i=0;i<_count-1;i++)
            {
                for(int j=0;j<_count-1;j++)
                {
                    if(IsGreater(_array[j],_array[j+1]))
                    {
                        // swap
                        Type temp = _array[j+1];
                        _array[j+1] = _array[j];
                        _array[j] = temp;
                    }
                }
            }
        }

        public bool IsGreater(Type value, Type value1)
        {
            int result = Comparer<Type>.Default.Compare(value,value1);
            // value is greater =1 | value is less = -1 |value is equal = 0
            if(result>0)
            {
                return true;
            }
            return false;
        }

    }
}