using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gamePacOop.GameGL
{
    class GhostBullet : Bullet
    {
        GameDirection direction;
        GamePlayer player;
        public GhostBullet(GamePlayer player, GameDirection direction, Image image, GameCell startCell) : base(GameObjectType.GHOST_BULLET, image)
        {
            this.direction = direction;
            this.CurrentCell = startCell;
            this.player = player;

        }
        public GhostBullet()
        {

        }

        public override GameCell move()
        {
            if (this.IsActive == true  )
            {
                GameCell currentCell = this.CurrentCell;
                GameCell nextCell = currentCell.nextCell(direction);
                GameCell nextCell2 = currentCell.nextWallCell(direction);

                this.CurrentCell = nextCell;
                GameObject previousObject = nextCell.CurrentGameObject;
                GameObject nextObject = nextCell2.CurrentGameObject;
                    if (nextObject.GameObjectType == GameObjectType.BULLET)
                    {
                        player.decreaseHealth();
                    }

                if (currentCell != nextCell)
                {
                    currentCell.setGameObject(Game.getBlankGameObject());

                }
                else if (currentCell == nextCell)
                {
                    currentCell.setGameObject(Game.getBlankGameObject());

                    this.setIsActive(false);
                   
                }
                return nextCell;
            }

            return null;
        }

    }
}
