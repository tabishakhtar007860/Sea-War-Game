using gamePacOop.GameDL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gamePacOop.GameGL
{
    class PlayerBullet : Bullet
    {
        GameDirection direction;
        private List<Ghost> ghosts;
        public PlayerBullet(List<Ghost> ghosts, GameDirection direction, Image image, GameCell startCell) : base(GameObjectType.PLAYER_BULLET, image)
        {
            this.direction = direction;
            this.CurrentCell = startCell;
            this.ghosts = ghosts;

        }
        public PlayerBullet()
        {

        }

        public override GameCell move()
        {
            if (IsActive == true)
            {
                GameCell currentCell = this.CurrentCell;
                GameCell nextCell = currentCell.nextCell(direction);
                GameCell nextCell2 = currentCell.nextWallCell(direction);

                this.CurrentCell = nextCell;
                GameObject previousObject = nextCell.CurrentGameObject;
                GameObject nextObject = nextCell2.CurrentGameObject;
                GameObject nextCellObjForEnemy = nextCell.CurrentGameObject;
               // MessageBox.Show(nextObject.GameObjectType.ToString());

                if (currentCell != nextCell)
                {
                    currentCell.setGameObject(Game.getBlankGameObject());

                }
               // MessageBox.Show(this.GameObjectType.ToString());
             /*   if (nextObject.GameObjectType == GameObjectType.ENEMY_BULLET || nextObject.GameObjectType == GameObjectType.GHOST_BULLET)
                {
                  
                    foreach (Ghost ghost in AllDL.GhostsList)
                    {
                        MessageBox.Show(ghost.DisplayCharacter.ToString());
                        // GameCell next = ghost.CurrentCell.nextCellForEnemyBullet(ghost.Direction);
                        if (ghost.DisplayCharacter == nextCell.CurrentGameObject.DisplayCharacter)
                        {
                            MessageBox.Show("ha gi");
                            ghost.IsActive = false;
                        }
                    }
                }*/
                

                        /*GameObject obj = next.CurrentGameObject;

                        if (obj.GameObjectType == GameObjectType.PLAYER_BULLET)
                        {
                            ghost.decreaseHealth();
                        }*/


                    

                
                 if (currentCell == nextCell)
                {  
                      //  MessageBox.Show("Enemy ha ab tu");
                    
                    if (nextObject.GameObjectType == GameObjectType.ENEMY)
                    {

                        foreach (Ghost ghost in ghosts)
                        {
                            GameCell next = ghost.CurrentCell.nextWallCell(ghost.Direction);
                            GameObject obj = next.CurrentGameObject;

                            if (obj.GameObjectType == GameObjectType.PLAYER_BULLET)
                            {
                                ghost.decreaseHealth();
                            }


                        }

                    }

                    currentCell.setGameObject(Game.getBlankGameObject());

                    this.setIsActive(false);

                }
                return nextCell;
            }

            return null;
        }

    }
}
