using Snake.Logica;
using Snake.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class QueueLast:Queue<Position>
    {
        public new void Enqueue(Position position)
        {
            base.Enqueue(position);
            if (this.Count > MaxCount)
            {
               var obj =  base.Dequeue();
               arrays[obj.Y][obj.X] = 0;
            }
        }
        public int MaxCount { set; get; }
        CustomArray[] arrays;
        public QueueLast(CustomArray[] arrays)
        {
            this.arrays = arrays;
        }
    }
}
