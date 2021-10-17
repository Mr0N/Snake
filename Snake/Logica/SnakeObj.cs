using Snake.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Logica
{
    enum Moves
    {
        Up, Down, Left, Right
    }
    struct Position
    {
        public int X { set; get; }
        public int Y { set; get; }
        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(X);
            hash.Add(Y);
            return hash.ToHashCode();
        }
        public override bool Equals(object obj)
        {
            var result = ((Position)obj);
            if (result.Y == this.Y && result.X == this.X)
                return true;
            return false;
        }
    }
    class SnakeObj
    {
        public int Length
        {
            set
            {
                this.queue.MaxCount = value;
                this.length = value;
            }
            get => length;
        }
        int length;
        public Position position
        {
            set
            {
                customs[value.Y][value.X] = 1;
                pos = value;
                this.queue.Enqueue(pos);
            }
            get
            {
                return pos;
            }
        }
        Position pos;
        public Moves Move { set; get; } = Moves.Down;
        public void Up()
        {
            this.Move = Moves.Up;
        }
        public void Down()
        {
            this.Move = Moves.Down;
        }
        public void Left()
        {
            this.Move = Moves.Left;
        }
        public void Right()
        {
            this.Move = Moves.Right;
        }

        public bool CheckIsGood()
        {
            return queue.Distinct().Count() == this.queue.Count;
        }
        CustomArray[] customs;
        QueueLast queue;
        public SnakeObj(CustomArray[] arrays)
        {
            this.customs = arrays;
            this.queue = new QueueLast(arrays);
            this.Length = 3;
        }
    }
}
