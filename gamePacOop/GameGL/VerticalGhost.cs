using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace gamePacOop.GameGL
{
    class VerticalGhost : Ghost
    {
        int timer = 0;
        GameDirection gameDirection;
        public VerticalGhost(Form1 mainForm,int lives, GamePlayer player, GameDirection gameDirection , Image image ,GameCell gameCell):base (mainForm,lives, GameObjectType.ENEMY , image)
        {
            this.gameDirection = gameDirection;
            this.CurrentCell = gameCell;
        }
        public override GameCell move()
        {
            GameCell next = null;
            if (this.IsActive)
            {
                GameCell current = this.CurrentCell;
                 next = current.nextCell(gameDirection);
                if (timer % 25 == 0)
                {
                    this.CurrentCell = next;
                    if (this.CurrentCell.X == 8 && this.CurrentCell.Y == 5)
                    {
                        changeDirection();
                    }
                    if (current == next)
                    {
                        changeDirection();
                    }
                    if (current != next)
                    {
                        current.setGameObject(Game.getBlankGameObject());

                    }
                    timer = 0;
                }
                timer++;
            }
            return next;

        }
        public void changeDirection()
        {
            if (gameDirection == GameDirection.Up)
            {
                gameDirection = GameDirection.Down;
            }
            else if (gameDirection == GameDirection.Down)
            {
                gameDirection = GameDirection.Up;
            }
        }

       
    }
}
