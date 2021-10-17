using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Model
{
    class CustomArray : IEnumerable<short>
    {
        public int Length => this.obj.Length;
        public event Action<(int indexInCollumn, int @value, int row)> Edit;
        public short this[int id]
        {
            get
            {
                return obj[id];
            }
            set
            {
                obj[id] = value;
                Edit?.Invoke((id, value, this.row));
            }
        }
        short[] obj;
        public int row { get; }
        public CustomArray(int count, int row)
        {
            this.obj = new short[count];
            this.row = row;
        }

        public IEnumerator<short> GetEnumerator()
        {
            for (int i = 0; i < this.obj.Length; i++)
            {
                yield return this.obj[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
