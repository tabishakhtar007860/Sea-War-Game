using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EZInput;
using gamePacOop.GameDL;
using gamePacOop.GameGL;

namespace gamePacOop
{
    public partial class Form1 : Form
    {
        GamePlayer player;
        HorizontalGhost ghostH1;
        HorizontalGhost ghostH2;
        HorizontalGhost ghostH3;
        HorizontalGhost ghostH4;
        VerticalGhost ghostV1;
        RandomGhost ghostR1;
        SmartGhost ghostS1;


        GameGrid grid;
        HBullet hBullet;
        
        List<Ghost> ghosts = new List<Ghost>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
             grid = new GameGrid("maze.txt", 13, 25);
            Image playerImage = GameGL.Game.getGameObjectImage('P');
            GameCell startCell = grid.getCell(3, 10);
            player = new GamePlayer(label1, this, 0, 100, playerImage, startCell) ;

            Image ghostH1Img = GameGL.Game.getGameObjectImage('H');
            GameCell startH1 = grid.getCell(1, 3);
            ghostH1 = new HorizontalGhost(this,100,player,GameDirection.Left, ghostH1Img, startH1);

            Image ghostH2Img = GameGL.Game.getGameObjectImage('2');
            GameCell startH2 = grid.getCell(1, 20);
            ghostH2 = new HorizontalGhost(this,100,player,GameDirection.Right, ghostH2Img, startH2);

            Image ghostH3Img = GameGL.Game.getGameObjectImage('4');
            GameCell startH3 = grid.getCell(6, 2);
            ghostH3 = new HorizontalGhost(this, 100, player, GameDirection.Right, ghostH3Img, startH3);

            Image ghostH4Img = GameGL.Game.getGameObjectImage('3');
            GameCell startH4 = grid.getCell(6, 18);
            ghostH4 = new HorizontalGhost(this, 100, player, GameDirection.Right, ghostH4Img, startH4);


             Image ghostV1Img = GameGL.Game.getGameObjectImage('V');
             GameCell startV1 = grid.getCell(11, 5);
             ghostV1 = new VerticalGhost(this,100,player, GameDirection.Up, ghostV1Img, startV1);

          
            ghosts.Add(ghostH1);
            ghosts.Add(ghostV1);
            ghosts.Add(ghostH2);
           /* ghosts.Add(ghostR1);
            ghosts.Add(ghostS1);*/
            ghosts.Add(ghostH3);
            ghosts.Add(ghostH4);

           // BulletDL.Bullets1.Add(hBullet);
            printMaze(grid);
        }

        void printMaze(GameGrid grid)
        {
            for (int x = 0; x < grid.Rows; x++)
            {

                for (int y = 0; y < grid.Cols; y++)
                {
                    GameCell cell = grid.getCell(x, y);
                    this.Controls.Add(cell.PictureBox);
                    //        printCell(cell);
                }

            }
        }
        static void printCell(GameCell cell)
        {
            Console.SetCursorPosition(cell.Y, cell.X);
            Console.Write(cell.CurrentGameObject.DisplayCharacter);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            if (Keyboard.IsKeyPressed(Key.LeftArrow))
            {

                player.move(GameDirection.Left);
                if (player.FlipSide == "Right")
                {
                    player.FlipSide = ("Left");
                }
                player.FlipBool = (true);
            }
            else if (Keyboard.IsKeyPressed(Key.RightArrow))
            {
                player.move(GameDirection.Right);
                if (player.FlipSide == "Left")
                {
                    player.FlipSide = ("Right");
                }
                player.FlipBool = (true);
            }
            else if (Keyboard.IsKeyPressed(Key.UpArrow))
            {
                player.move(GameDirection.Up);

            }
            else if (Keyboard.IsKeyPressed(Key.DownArrow))
            {
                player.move(GameDirection.Down);
            }
            else if(Keyboard.IsKeyPressed(Key.Space))
            {

                
                player.generateBullet();
            }

            


            foreach (Ghost g in ghosts)
            {
                if(isCollideWithPlayerBullet(g))
                {
                    g.IsActive = false;
                    GameObject gameObj = Game.getBlankGameObject();

                    g.CurrentCell.CurrentGameObject1 = gameObj;

                }
                


                g.move();
                if (g.IsActive)
                {
                    g.generateBullet(player);
                }
                if (g.FlipBool == true)
                {
                    g.FlipBool = (false);
                }
                if (g.getHealth() == 0)
                {
                    g.IsActive = (false);
                    GameObject gameObj = Game.getBlankGameObject();

                    g.CurrentCell.CurrentGameObject1 = gameObj;
                }
            }
            player.flipPlayerNow();
            player.setBarPosition();
            player.setBarValue();

            for (int x = 0; x < AllDL.GhostsList.Count; x++)
            {
                if (AllDL.GhostsList[x].IsActive == false)
                {
                    AllDL.GhostsList.Remove(AllDL.GhostsList[x]);
                }
            }



            foreach (Bullet b in AllDL.GhostBulletsList)
            {
                b.move();
            }
            for (int x = 0; x < AllDL.GhostBulletsList.Count; x++)
            {
                if (AllDL.GhostBulletsList[x].IsActive == false)
                {
                   AllDL.GhostBulletsList.RemoveAt(x);
                }
            }



            foreach (Bullet b in AllDL.BulletsList)
            {
                b.move();
            }

            for (int x = 0; x < AllDL.BulletsList.Count; x++)
            {
                if (AllDL.BulletsList[x].IsActive == false)
                {
                    AllDL.BulletsList.RemoveAt(x);
                }
            }
            int count = 0;
            foreach (Ghost g in ghosts)
            {

                if(! g.IsActive)
                {
                    count++;
                }
            }
            if(count == 5)
            {
                this.Close();
            }



        }
        private bool isCollideWithPlayerBullet(Ghost ghost)
        {
            if(ghost.CurrentCell.CurrentGameObject.GameObjectType != GameObjectType.ENEMY)
            {

            }
            GameCell next = ghost.CurrentCell.nextCellForEnemyBullet(ghost.Direction);
            if (ghost.CurrentCell.CurrentGameObject.GameObjectType == GameObjectType.PLAYER_BULLET || ghost.CurrentCell.CurrentGameObject.GameObjectType == GameObjectType.BULLET)
            {
                return true;
            }
            return false;
        }
        
        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void CongralutionBox_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
