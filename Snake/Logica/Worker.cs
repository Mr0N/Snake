using Snake.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Snake.Logica
{
    class Worker
    {
        public async Task<bool> MoveShakeAsync(int sleep = 500)
        {
            if (!snake.CheckIsGood()) return false;
            CheckIsEating(snake.position);
            if (snake.position.Y > obj.Length - 2) return false;
            if (snake.position.Y == 1) return false;
            if (snake.position.X > obj[0].Length - 2) return false;
            if (snake.position.X == 1) return false;
            if (snake.Move == Moves.Down)
            {
                snake.position = new Position() { X = snake.position.X, Y = snake.position.Y + 1 };
            }
            if (snake.Move == Moves.Up)
            {
                snake.position = new Position() { X = snake.position.X, Y = snake.position.Y - 1 };
            }
            if (snake.Move == Moves.Left)
            {
                snake.position = new Position() { X = snake.position.X - 1, Y = snake.position.Y };
            }
            if (snake.Move == Moves.Right)
            {
                snake.position = new Position() { X = snake.position.X + 1, Y = snake.position.Y };
            }
            await Task.Delay(sleep);
            return true;
        }
        Position eating;
        private void CheckIsEating(Position position)
        {
            if(position.X == eating.X && position.Y == eating.Y)
            {
                this.Snake.Length++;
                CreateEating();
            }
        }
        private void CreateEating()
        {
            var obj = GenerateRandom(this.width-2, this.height-2);
            this.eating = new Position() { X = obj.x, Y = obj.y };
            this.obj[this.eating.Y][this.eating.X] = 1;
        }
        private (int x, int y) GenerateRandom(int width,int heidth)
        {
            return (random.Next(2, width), random.Next(2, heidth));
        }
        Random random = new Random();
        public CustomArray[] Current
        {
            get => obj;
        }
        private CustomArray[] Create()
        {
            CustomArray[] array = new CustomArray[this.height];
            for (int x = 0; x < array.Length; x++)
            {
                array[x] = new CustomArray(this.width, x);
            }
            return array;
        }
        int width;
        int height;
        CustomArray[] obj;
        SnakeObj snake;
        public SnakeObj Snake { get => snake; }
        private void Initialization()
        {
            this.obj = this.Create();
            this.snake = new SnakeObj(this.obj);
            this.WriteBorder();
            snake.position = new Position() { X = 4, Y = 6 };
            CreateEating();
        }
        private void WriteBorder()
        {
            int page = 0;
            foreach (var item in obj)
            {
                for (int i = 0; i < item.Length; i++)
                {
                    if (i == 0) item[i] = 1;
                    if (i == item.Length - 1) item[i] = 1;
                    if (page == 0) item[i] = 1;
                    if (page == obj.Length - 1) item[i] = 1;
                }
                page++;
            }
        }
        public Worker(int width, int height)
        {
            this.width = width;
            this.height = height;
            Initialization();
        }
    }
}
