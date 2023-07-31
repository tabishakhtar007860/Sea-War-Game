using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using gamePacOop.GameDL;

namespace gamePacOop.GameGL
{
    class GamePlayer : GameObject
    {
        bool isActive = false;
        private int scores = 0;
        private int health = 0;
        private string flipSide = "Right";
        private bool  flipBool = false;
        ProgressBar HealthBar;
        Form1 mainForm;
        Label scoreLabel;
        public GamePlayer(Label label, Form1 mainForm, int scores, int health, Image image, GameCell startCell) : base(GameObjectType.PLAYER, image)
        {
            scoreLabel = label;
            this.Health = health;
            this.Scores = scores;
            this.CurrentCell = startCell;
            this.mainForm = mainForm;

            HealthBar = new ProgressBar();
            HealthBar.Size = new Size(30, 7);
            HealthBar.ForeColor = Color.Green;
            HealthBar.BackColor = Color.Black;
            HealthBar.Style = ProgressBarStyle.Continuous;
            mainForm.Controls.Add(HealthBar);
        }

        public bool IsActive { get => isActive; set => isActive = value; }
        public int Scores { get => scores; set => scores = value; }
        public int Health { get => health; set => health = value; }
        public string FlipSide { get => flipSide; set => flipSide = value; }
        public bool FlipBool { get => flipBool; set => flipBool = value; }

        public void increasHealth()
        {
            health = health + 5;
        }

        public void decreaseHealth()
        {
            health = health - 1;
        }
        public  void addScores(GameCell nextCell)
        {
            if(nextCell.CurrentGameObject.GameObjectType == GameObjectType.REWARD )  
            {
                 scores++;
            }

        }

        public GameCell move(GameDirection direction)
        {
            GameCell currentCell = this.CurrentCell;
            GameCell nextCell = currentCell.nextCellForEnemyBullet(direction);
            this.CurrentCell = nextCell;
            addScores(nextCell);
        
            if (nextCell.CurrentGameObject.GameObjectType == GameObjectType.REWARD  || (nextCell.X == 8 && nextCell.Y == 1) || (nextCell.X == 10 && nextCell.Y == 1) || (nextCell.X == 8 && nextCell.Y == 4) || (nextCell.X == 8 && nextCell.Y == 3) || (nextCell.X == 8 && nextCell.Y == 2) || (nextCell.X == 8 && nextCell.Y == 1) || (nextCell.X == 9 && nextCell.Y == 1) || (nextCell.X == 9 && nextCell.Y == 2) || (nextCell.X == 9 && nextCell.Y == 3) || (nextCell.X == 9 && nextCell.Y == 4) || (nextCell.X == 10 && nextCell.Y == 1))
            {
                scores++;
            }
            if (nextCell.X == 10 && nextCell.Y == 11)
            {
                scores = scores + 10;   
            }
                scoreLabel.Text = "Scores:" + Scores.ToString();
            if (currentCell != nextCell)
            {
                currentCell.setGameObject(Game.getBlankGameObject());
            }
            return nextCell;
        }
        public void flipPlayerNow()
        {
            if (flipSide == "Left")
            {
                this.CurrentCell.PictureBox.Image = gamePacOop.Properties.Resources.playerLeft;
            }
            else if (flipSide == "Right")
            {
                this.CurrentCell.PictureBox.Image = gamePacOop.Properties.Resources.playerRight;

            }
        }

        public void setBarValue()
        {
            if (health > 0)
            {
                HealthBar.Value
                    = health;
            }
        }

        public void setBarPosition()
        {
            HealthBar.Top = this.CurrentCell.X * 55;
            HealthBar.Left = this.CurrentCell.Y * 55;
        }


        public void generateBullet()
        {


            PlayerBullet b = new PlayerBullet();
            Image bullet = GameGL.Game.getGameObjectImage('b');
            GameCell startBullet = new GameCell();
            if (this.FlipSide == "Right")
            {
                GameCell next = this.CurrentCell.nextWallCell(GameDirection.Right);
                if (next.CurrentGameObject.GameObjectType == GameObjectType.NONE)
                {
                    startBullet = this.CurrentCell.nextWallCell(GameDirection.Right);
                    b = new PlayerBullet(AllDL.GhostsList, GameDirection.Right, bullet, startBullet);
                    b.setIsActive (true);
                    AllDL.BulletsList.Add(b);
                }

            }
            else if (this.FlipSide == "Left")
            {
                GameCell next = this.CurrentCell.nextWallCell(GameDirection.Left);
                if (next.CurrentGameObject.GameObjectType == GameObjectType.NONE)
                {
                    startBullet = this.CurrentCell.nextCell(GameDirection.Left);
                    b = new PlayerBullet(AllDL.GhostsList, GameDirection.Left, bullet, startBullet);
                    b.setIsActive(true);
                    AllDL.BulletsList.Add(b);
                }

            }

        }
    }
}
