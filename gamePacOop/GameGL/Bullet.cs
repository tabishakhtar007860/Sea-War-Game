using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace gamePacOop.GameGL
{
   internal abstract class Bullet : GameObject
    {
        private bool isActive;

        public bool IsActive { get => isActive; set => isActive = value; }
        public void setIsActive(bool set)
        {
            this.isActive = set;
        }
        public Bullet(GameObjectType gameObjectType, Image image) : base(GameObjectType.BULLET, image)
        {

        }

        public Bullet()
        {

        }

        public abstract GameCell move();

    }
}
