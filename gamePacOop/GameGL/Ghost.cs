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
  internal abstract  class Ghost : GameObject
    {
        private ProgressBar enemyBar = new ProgressBar();
        protected int health;
        protected GamePlayer player;
        private string flipSide = "Right";
        protected bool flipBool = false;

        Form1 form;
        bool isActive;

        protected GameDirection direction;
        protected int timer = 1;

        public  int Health { get => health; set => health = value; }
        public bool IsActive { get => isActive; set => isActive = value; }
        public GameDirection Direction { get => direction; set => direction = value; }
        public  bool FlipBool { get => flipBool; set => flipBool = value; }
        protected string FlipSide { get => flipSide; set => flipSide = value; }
        public ProgressBar EnemyBar { get => enemyBar; set => enemyBar = value; }

        public Ghost(Form1 form, int health, GameObjectType gameObjectType, Image image) : base(GameObjectType.ENEMY, image)
        {
            this.Health = health;
            this.form = form;
            EnemyBar = new ProgressBar();
            EnemyBar.Size = new Size(30, 7);
            EnemyBar.ForeColor = Color.Red;
            EnemyBar.BackColor = Color.Black;
            EnemyBar.Style = ProgressBarStyle.Continuous;
            IsActive = true;
            form.Controls.Add(EnemyBar);
        }
        public abstract GameCell move();
       


       
        public int getHealth()
        {
            return Health;
        }

        public void increasHealth()
        {
            Health = Health + 5;
        }

        public void decreaseHealth()
        {
            Health = Health - 5;

        }

        public ProgressBar getBar()
        {
            return EnemyBar;
        }

        public void setBarValue()
        {
            EnemyBar.Value = Health;
        }

        public void setBarPosition()
        {
            EnemyBar.Top = this.CurrentCell.X * 55;
            EnemyBar.Left = this.CurrentCell.Y * 55;
        }


        public void generateBullet(GamePlayer gamePlayer)
        {
            GameCell currentCell = this.CurrentCell;
            GameCell nextCell = currentCell.nextWallCell(Direction);


            if (nextCell.CurrentGameObject.GameObjectType == GameObjectType.NONE)
            {
                if (gamePlayer.CurrentCell.X == this.CurrentCell.X)
                {
                    if (timer == 7)
                    {
                        this.FlipBool=(true);
                    }

                    if (timer % 12 == 0)
                    {
                        this.FlipBool = false;

                        GhostBullet b = new GhostBullet();
                        Image bullet = GameGL.Game.getGameObjectImage('B');
                        GameCell startBullet = new GameCell();
                       if (this.FlipSide == "Right")
                        {
                            startBullet = this.CurrentCell.nextCell(GameDirection.Right);
                            b = new GhostBullet(player, GameDirection.Right, bullet, startBullet);
                        }
                        else if (this.FlipSide == "Left")
                        {
                            startBullet = this.CurrentCell.nextCell(GameDirection.Left);
                            b = new GhostBullet(player, GameDirection.Left, bullet, startBullet);
                        }
                       else
                        {
                            startBullet = this.CurrentCell.nextCell(GameDirection.Left);
                            b = new GhostBullet(player, GameDirection.Left, bullet, startBullet);
                        }
                        b.IsActive = (true);
                        AllDL.GhostBulletsList.Add(b);
                    }
                    timer++;
                }
                else
                {
                    timer = 1;
                }
            }


        }

     
    }
}
