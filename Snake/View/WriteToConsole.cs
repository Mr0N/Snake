using Snake.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.View
{
    class WriteToConsole
    {
        CustomArray[] arrays;
        private void WriteToEvents()
        {
            foreach (var item in this.arrays)
            {
                item.Edit += Write;
            }
        }
        private void Driwe()
        {
            int top = 0;
            foreach (var obj in this.arrays)
            {
                int left = 0;
                foreach (var itemElement in obj)
                {
                    if(itemElement == 1)
                    {
                        Console.SetCursorPosition(left, top);
                        Console.Write("#");
                    }
                    left++;
                }
                top++;
            }
        }

        private void Write((int indexInCollumn, int value, int row) obj)
        {
            Console.SetCursorPosition(obj.indexInCollumn, obj.row);
            if(obj.value == 0)
                Console.Write(' ');
            else Console.Write("#");
        }
        void Initialization()
        {
            Driwe();
            WriteToEvents();
        }

        public WriteToConsole(CustomArray[] customArray)
        {
            this.arrays = customArray;
            Initialization();//Має стояти в кінці конструктора
        }
    }
}
