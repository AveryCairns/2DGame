using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace _2DGame
{
    class Obstacle
    {
        public int x, y, width, height;
        public Color obsColor;

        public Obstacle(int _x, int _y, int _w, int _h, Color _obsColor)
        {
            x = _x;
            y = _y;
            width = _w;
            height = _h;
            obsColor = _obsColor;
        }

        public void MoveLeft(int speed)
        {
            x -= speed;
        }
        public void MoveRight(int speed)
        {
            x += speed;
        }
        public void MoveUp(int speed)
        {
            y -= speed;
        }
        public void MoveDown(int speed)
        {
            y += speed;
        }

        public bool Collision(Obstacle b)
        {
            Rectangle rec1 = new Rectangle(b.x, b.y, b.width, b.height);
            Rectangle rec2 = new Rectangle(x, y, width, height);

            if (rec1.IntersectsWith(rec2))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
