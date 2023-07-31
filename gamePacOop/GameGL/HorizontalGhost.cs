using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace gamePacOop.GameGL
{
    class HorizontalGhost : Ghost
    {
        int timer = 0;
        public HorizontalGhost(Form1 mainForm,int lives, GamePlayer player, GameDirection direction, Image image, GameCell startCell) : base(mainForm,lives, GameObjectType.ENEMY, image)
        {
            this.direction = direction;
            this.CurrentCell = startCell;
            this.player = player;
        }

        public override GameCell  move()
        {
            GameCell nextCell = null;
            if (timer%10 ==0 &&  this.IsActive)
            {
                    if (player.CurrentCell.X != this.CurrentCell.X)
                    {
                    GameCell currentCell = this.CurrentCell;
                     nextCell = currentCell.nextCell(direction);
                    GameCell nextCell2 = currentCell.nextWallCell(direction);
                   // GameObject previousObject = nextCell.CurrentGameObject;
                    this.CurrentCell = nextCell;
                   // GameCell downCell = nextCell.nextWallCell(GameDirection.Down);




                   
                        if (currentCell == nextCell)
                        {
                            manageDirections();
                        }
                    this.flipBool = true;
                    
                    if (nextCell2.CurrentGameObject.GameObjectType == GameObjectType.PLAYER_BULLET)
                    {

                        MessageBox.Show("Jitt gya ma");
                        this.decreaseHealth();
                    }
                    
                    
                    if (this.CurrentCell.X == 1 && (this.CurrentCell.Y == 7 || this.CurrentCell.Y == 17 || this.CurrentCell.Y == 1 || this.CurrentCell.Y == 21))
                        {
                            manageDirections();
                        }
                        if (this.CurrentCell.X == 6 && (this.CurrentCell.Y == 6 || this.CurrentCell.Y == 14 || this.CurrentCell.Y == 1 || this.CurrentCell.Y == 21))
                        {
                            manageDirections();
                        }




                        if (currentCell != nextCell)
                        {
                            currentCell.setGameObject(Game.getBlankGameObject());

                        }

                        timer = 0;
                    }
                    else if(player.CurrentCell.X == this.CurrentCell.X)
                    {
                        FlipDirection();
                    }
                
            }
                    timer++;
                return nextCell;
            
        }
        private void FlipDirection()
        {
            if (player.CurrentCell.Y < this.CurrentCell.Y)
            {
                this.FlipSide = "Left";
                direction = GameDirection.Left;
            }
            else if (player.CurrentCell.Y > this.CurrentCell.Y)
            {
                this.FlipSide = "Right";
                direction = GameDirection.Right;
            }

        }
        public void manageDirections()
        {
            if (direction == GameDirection.Left)
            {
                direction = GameDirection.Right;
            }
            else if (direction == GameDirection.Right)
            {
                direction = GameDirection.Left;
            }
        }
      
    }
}
