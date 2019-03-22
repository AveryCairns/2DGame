using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

namespace _2DGame
{
    public partial class GameScreen : UserControl
    {
        List<Obstacle> Background = new List<Obstacle>(); //background colors

        List<Obstacle> Obs1 = new List<Obstacle>(); // first layer of obstacles in grass1 from top down, yes it is goon
        List<Obstacle> Obs2 = new List<Obstacle>();

        List<Obstacle> Logs1 = new List<Obstacle>(); //first log obstacles from bottom up
        List<Obstacle> Logs2 = new List<Obstacle>();
        List<Obstacle> Logs3 = new List<Obstacle>();

        List<Obstacle> Cars1 = new List<Obstacle>(); // first car obstacles from bottom up
        List<Obstacle> Cars2 = new List<Obstacle>();
        List<Obstacle> Cars3 = new List<Obstacle>();

        //player start values
        Obstacle hero;
        int heroStartX = 310;
        int heroStartY = 455;
        int lives = 5;

        Boolean leftArrowDown, rightArrowDown, upArrowDown, downArrowDown;

        //timer before you can move again
        Stopwatch moveTimer = new Stopwatch();


        int moveSpeed1 = 1;
        int moveSpeed2 = 3;
        int moveSpeed3 = 5;

        SolidBrush drawBrush = new SolidBrush(Color.White);

        public GameScreen()
        {
            InitializeComponent();
            StartUp();
        }

        public void StartUp()
        {
            Obstacle grass21 = new Obstacle(0, 0, 700, 50, Color.DarkGreen); //background boxes
            Obstacle grass22 = new Obstacle(0, 50, 700, 50, Color.DarkGreen);
            Obstacle grass23 = new Obstacle(0, 100, 700, 50, Color.DarkGreen);
            Obstacle grass24 = new Obstacle(0, 150, 700, 50, Color.DarkGreen);
            Obstacle water11 = new Obstacle(0, 200, 700, 50, Color.DodgerBlue);
            Obstacle water12 = new Obstacle(0, 250, 700, 50, Color.DodgerBlue);
            Obstacle water13 = new Obstacle(0, 300, 700, 50, Color.DodgerBlue);
            Obstacle grass11 = new Obstacle(0, 350, 700, 50, Color.DarkGreen);
            Obstacle grass12 = new Obstacle(0, 400, 700, 50, Color.DarkGreen);
            Obstacle grass13 = new Obstacle(0, 450, 700, 50, Color.DarkGreen);
            Background.Add(grass21);
            Background.Add(grass22);
            Background.Add(grass23);
            Background.Add(grass24);
            Background.Add(water11);
            Background.Add(water12);
            Background.Add(water13);
            Background.Add(grass11);
            Background.Add(grass12);
            Background.Add(grass13);

            Obstacle o1 = new Obstacle(0, 355, 60, 40, Color.Black); //first obstacle in first layer
            Obstacle o2 = new Obstacle(200, 355, 60, 40, Color.Black);
            Obstacle o3 = new Obstacle(400, 355, 60, 40, Color.Black);
            Obstacle o4 = new Obstacle(680, 355, 60, 40, Color.Black);
            Obs1.Add(o1);
            Obs1.Add(o2);
            Obs1.Add(o3);
            Obs1.Add(o4);

            Obstacle o21 = new Obstacle(640, 405, 60, 40, Color.SlateGray); //obs layer 2
            Obstacle o22 = new Obstacle(380, 405, 60, 40, Color.SlateGray);
            Obstacle o23 = new Obstacle(310, 405, 60, 40, Color.SlateGray);
            Obstacle o24 = new Obstacle(140, 405, 60, 40, Color.SlateGray);
            Obs2.Add(o21);
            Obs2.Add(o22);
            Obs2.Add(o23);
            Obs2.Add(o24);

            Obstacle log1 = new Obstacle(680, 310, 80, 30, Color.SaddleBrown); //log 1 layer
            Obstacle log2 = new Obstacle(590, 310, 80, 30, Color.SaddleBrown);
            Obstacle log3 = new Obstacle(410, 310, 80, 30, Color.SaddleBrown);
            Obstacle log4 = new Obstacle(250, 310, 80, 30, Color.SaddleBrown);
            Obstacle log5 = new Obstacle(0, 310, 80, 30, Color.SaddleBrown);
            Logs1.Add(log1);
            Logs1.Add(log2);
            Logs1.Add(log3);
            Logs1.Add(log4);
            Logs1.Add(log5);

            Obstacle log21 = new Obstacle(120, 260, 80, 30, Color.SaddleBrown);
            Obstacle log22 = new Obstacle(200, 260, 80, 30, Color.SaddleBrown);
            Obstacle log23 = new Obstacle(340, 260, 80, 30, Color.SaddleBrown);
            Obstacle log24 = new Obstacle(460, 260, 80, 30, Color.SaddleBrown);
            Obstacle log25 = new Obstacle(540, 260, 80, 30, Color.SaddleBrown);
            Obstacle log26 = new Obstacle(640, 260, 80, 30, Color.SaddleBrown);
            Logs2.Add(log21);
            Logs2.Add(log22);
            Logs2.Add(log23);
            Logs2.Add(log24);
            Logs2.Add(log25);
            Logs2.Add(log26);

            Obstacle log31 = new Obstacle(220, 210, 80, 30, Color.SaddleBrown);
            Obstacle log32 = new Obstacle(280, 210, 80, 30, Color.SaddleBrown);
            Obstacle log33 = new Obstacle(390, 210, 80, 30, Color.SaddleBrown);
            Obstacle log34 = new Obstacle(500, 210, 80, 30, Color.SaddleBrown);
            Obstacle log35 = new Obstacle(630, 210, 80, 30, Color.SaddleBrown);
            Logs3.Add(log31);
            Logs3.Add(log32);
            Logs3.Add(log33);
            Logs3.Add(log34);
            Logs3.Add(log35);

            Obstacle car11 = new Obstacle(680, 155, 60, 40, Color.SlateGray);
            Obstacle car12 = new Obstacle(330, 155, 60, 40, Color.SlateGray);
            Obstacle car13 = new Obstacle(100, 155, 60, 40, Color.SlateGray);
            Cars1.Add(car11);
            Cars1.Add(car12);
            Cars1.Add(car13);

            Obstacle car21 = new Obstacle(50, 105, 60, 40, Color.SlateGray);
            Obstacle car22 = new Obstacle(420, 105, 60, 40, Color.SlateGray);
            Obstacle car23 = new Obstacle(490, 105, 60, 40, Color.SlateGray);
            Cars2.Add(car21);
            Cars2.Add(car22);
            Cars2.Add(car23);

            Obstacle car31 = new Obstacle(530, 55, 60, 40, Color.SlateGray);
            Obstacle car32 = new Obstacle(160, 55, 60, 40, Color.SlateGray);
            Cars3.Add(car31);
            Cars3.Add(car32);

            //create player
            hero = new Obstacle(heroStartX, heroStartY, 40, 40, Color.MediumPurple);

            moveTimer.Start();

        }

        private void GameScreen_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode) //button releases
            {


                case Keys.Left:
                case Keys.A:
                    leftArrowDown = false;
                    break;
                case Keys.Right:
                case Keys.D:
                    rightArrowDown = false;
                    break;
                case Keys.Up:
                case Keys.W:
                    upArrowDown = false;
                    break;
                case Keys.Down:
                case Keys.S:
                    downArrowDown = false;
                    break;
            }
        }

        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            foreach (Obstacle b in Background)
            {
                drawBrush.Color = b.obsColor;

                e.Graphics.FillRectangle(drawBrush, b.x, b.y, b.width, b.height);
            }

            foreach (Obstacle b in Obs1)
            {
                drawBrush.Color = b.obsColor;

                e.Graphics.FillRectangle(drawBrush, b.x, b.y, b.width, b.height);
                
            }
            foreach (Obstacle b in Obs2)
            {
                drawBrush.Color = b.obsColor;

                e.Graphics.FillRectangle(drawBrush, b.x, b.y, b.width, b.height);

            }


            foreach (Obstacle b in Logs1)
            {
                drawBrush.Color = b.obsColor;

                e.Graphics.FillRectangle(drawBrush, b.x, b.y, b.width, b.height);

            }
            foreach (Obstacle b in Logs2)
            {
                drawBrush.Color = b.obsColor;

                e.Graphics.FillRectangle(drawBrush, b.x, b.y, b.width, b.height);
            }
            foreach (Obstacle b in Logs3)
            {
                drawBrush.Color = b.obsColor;

                e.Graphics.FillRectangle(drawBrush, b.x, b.y, b.width, b.height);
            }

            foreach (Obstacle b in Cars1)
            {
                drawBrush.Color = b.obsColor;

                e.Graphics.FillRectangle(drawBrush, b.x, b.y, b.width, b.height);
            }
            foreach (Obstacle b in Cars2)
            {
                drawBrush.Color = b.obsColor;

                e.Graphics.FillRectangle(drawBrush, b.x, b.y, b.width, b.height);
            }
            foreach (Obstacle b in Cars3)
            {
                drawBrush.Color = b.obsColor;

                e.Graphics.FillRectangle(drawBrush, b.x, b.y, b.width, b.height);
            }

            drawBrush.Color = Color.Firebrick;
            e.Graphics.FillEllipse(drawBrush, hero.x, hero.y, hero.width, hero.height);

            for (int i = 0; i < lives; i++)
            {
                e.Graphics.FillEllipse(drawBrush, (i * 20)+ 10, 10, 20, 20);
            }
            Font drawFont = new Font("Trajan", 36);
            if (lives == 0)
            {
                e.Graphics.DrawString("You lose!", drawFont, drawBrush, 100, 350);
            }
        }

        private void gameLoop_Tick(object sender, EventArgs e)
        {
            int tempX = hero.x, tempY = hero.y;

            if (lives == 0)
            {
                Refresh();
                Thread.Sleep(500);
                lives = 5;
            }

            #region move obstacles
            foreach (Obstacle b in Obs1)
            {
                b.MoveLeft(moveSpeed2);
                if (hero.Collision(b))
                {
                    hero.x = heroStartX;
                    hero.y = heroStartY;
                    lives--;
                }
            }
            foreach (Obstacle b in Obs2)
            {
                b.MoveRight(moveSpeed1);
                if (hero.Collision(b))
                {
                    hero.x = heroStartX;
                    hero.y = heroStartY;
                    lives--;
                }
            }


            bool onlog = false;
            foreach (Obstacle b in Logs1)
            {
                b.MoveRight(moveSpeed1);
                if (hero.y <= 350 && hero.y >= 300 && hero.Collision(b))
                {
                    hero.x += moveSpeed1;
                    onlog = true;
                }
                
            }
            foreach (Obstacle b in Logs2)
            {
                b.MoveLeft(moveSpeed3);
                if (hero.y <= 300 && hero.y >= 250 && hero.Collision(b))
                {
                    hero.x -= moveSpeed3;
                    onlog = true;
                }
                
            }
            foreach (Obstacle b in Logs3)
            {
                b.MoveLeft(moveSpeed2);
                if (hero.y <= 250 && hero.y >= 200 && hero.Collision(b))
                {
                    hero.x -= moveSpeed2;
                    onlog = true;
                }
                
            }

            if (hero.y <= 350 && hero.y >= 300 && onlog == false)
            {
                hero.x = heroStartX;
                hero.y = heroStartY;
                lives--;
            }
            if (hero.y <= 250 && hero.y >= 200 && onlog == false)
            {
                hero.x = heroStartX;
                hero.y = heroStartY;
                lives--;
            }
            if (hero.y <= 300 && hero.y >= 250 && onlog == false)
            {
                hero.x = heroStartX;
                hero.y = heroStartY;
                lives--;
            }

            foreach (Obstacle b in Cars1)
            {
                b.MoveRight(moveSpeed2);
                if (hero.Collision(b))
                {
                    hero.x = heroStartX;
                    hero.y = heroStartY;
                    lives--;
                }
            }
            foreach (Obstacle b in Cars2)
            {
                b.MoveLeft(moveSpeed3);
                if (hero.Collision(b))
                {
                    hero.x = heroStartX;
                    hero.y = heroStartY;
                    lives--;
                }
            }
            foreach (Obstacle b in Cars3)
            {
                b.MoveRight(moveSpeed1);
                if (hero.Collision(b))
                {
                    hero.x = heroStartX;
                    hero.y = heroStartY;
                    lives--;
                }
            }

            if (hero.Collision(Background[0])) //win zone
            {
                hero.x = heroStartX;
                hero.y = heroStartY;
                moveTimer.Restart();
            }
            #endregion

            #region remove and redraw
            bool obs1R = false; //checking if a obs has been removed
            bool obs2R = false;
            bool logs1R = false;
            bool logs2R = false;
            bool logs3R = false;
            bool cars1R = false;
            bool cars2R = false;
            bool cars3R = false;

            if (Obs1[0].x <= 0 - Obs1[0].width) //when obstacles get to end of screen, redraw them from opposite side
            {
                Obs1.RemoveAt(0);
                obs1R = true;
            }
            if (obs1R == true)
            {
                Obstacle o = new Obstacle(700, 355, 60, 40, Color.Black);
                Obs1.Add(o);
                obs1R = false;
            }
            if (Obs2[0].x >= this.Width)
            {
                Obs2.RemoveAt(0);
                obs2R = true;
            }
            if (obs2R == true)
            {
                Obstacle o = new Obstacle(-60, 405, 60, 40, Color.SlateGray);
                Obs2.Add(o);
                obs2R = false;
            }

            if (Logs1[0].x >= this.Width) //logs 1
            {
                Logs1.RemoveAt(0);
                logs1R = true;
            }
            if (logs1R == true)
            {
                Obstacle l = new Obstacle(-80, 310, 80, 30, Color.SaddleBrown);
                Logs1.Add(l);
                logs1R = false;
            }
            if (Logs2[0].x <= 0 - Logs2[0].width) // logs 2
            {
                Logs2.RemoveAt(0);
                logs2R = true;
            }
            if (logs2R == true)
            {
                Obstacle l = new Obstacle(700, 260, 80, 30, Color.SaddleBrown);
                Logs2.Add(l);
                logs2R = false;
            }
            if (Logs3[0].x <= 0 - Logs3[0].width) // logs3
            {
                Logs3.RemoveAt(0);
                logs3R = true;
            }
            if (logs3R == true)
            {
                Obstacle l = new Obstacle(700, 210, 80, 30, Color.SaddleBrown);
                Logs3.Add(l);
                logs3R = false;
            }

            if (Cars1[0].x >= this.Width) //cars 1
            {
                Cars1.RemoveAt(0);
                cars1R = true;
            }
            if (cars1R == true)
            {
                Obstacle c = new Obstacle(-60, 155, 60, 40, Color.SlateGray);
                Cars1.Add(c);
                cars1R = false;
            }
            if (Cars2[0].x <= 0 - Cars2[0].width) //cars 2
            {
                Cars2.RemoveAt(0);
                cars2R = true;
            }
            if (cars2R == true)
            {
                Obstacle c = new Obstacle(700, 105, 60, 40, Color.SlateGray);
                Cars2.Add(c);
                cars2R = false;
            }
            if (Cars3[0].x >= this.Width) //cars 3
            {
                Cars3.RemoveAt(0);
                cars3R = true;
            }
            if (cars3R == true)
            {
                Obstacle c = new Obstacle(-60, 55, 60, 40, Color.SlateGray);
                Cars3.Add(c);
                cars3R = false;
            }


            #endregion

            #region player movement
            if (leftArrowDown == true && moveTimer.ElapsedMilliseconds >= 250)
            {
                hero.MoveLeft(50);
                moveTimer.Restart();
            }
            if (rightArrowDown == true && moveTimer.ElapsedMilliseconds >= 250)
            {
                hero.MoveRight(50);
                moveTimer.Restart();
            }
            if (upArrowDown == true && moveTimer.ElapsedMilliseconds >= 250)
            {
                hero.MoveUp(50);
                moveTimer.Restart();
            }
            if (downArrowDown == true && moveTimer.ElapsedMilliseconds >= 250)
            {
                hero.MoveDown(50);
                moveTimer.Restart();
            }

            if (hero.x >= this.Width || hero.x <= 0 || hero.y >= this.Height || hero.y <= 0)
            {
                hero.x = tempX;
                hero.y = tempY;
            }
            #endregion

            Refresh();
        }

        private void GameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode) //button presses
            {


                case Keys.Left:
                case Keys.A:
                    leftArrowDown = true;
                    break;
                case Keys.Right:
                case Keys.D:
                    rightArrowDown = true;
                    break;
                case Keys.Up:
                case Keys.W:
                    upArrowDown = true;
                    break;
                case Keys.Down:
                case Keys.S:
                    downArrowDown = true;
                    break;
            }
        }
    }
}
