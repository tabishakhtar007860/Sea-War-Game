using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace gamePacOop.GameGL
{
    class Game
    {
       
        public static GameObject getBlankGameObject()
        {
            GameObject blankGameObject =  new GameObject(GameObjectType.NONE, null);
            return blankGameObject;
        }
        public static Image getGameObjectImage(char displayCharacter)
        {
            Image img = null;
            if (displayCharacter == '|' || displayCharacter == '%')
            {
                img = gamePacOop.Properties.Resources.vertical;
            }

             if (displayCharacter == '#')
             {
                 img = gamePacOop.Properties.Resources.th__3___3_;
             }

             if (displayCharacter == 'B')
             {
                 img = gamePacOop.Properties.Resources.fire;

             }
             if(displayCharacter == 'b')
            {
                img = gamePacOop.Properties.Resources.FirePlayer;
            }
            if (displayCharacter == 'P' )
            {
                img = gamePacOop.Properties.Resources.pacman_open;
            }
            if (displayCharacter == 'H')
            {
                img = gamePacOop.Properties.Resources.giphy__1_;
            }
            if (displayCharacter == '2')
            {
                img = gamePacOop.Properties.Resources.VEnemy;
            }
            if (displayCharacter == '3')
            {
                img = gamePacOop.Properties.Resources.giphy__17_;
            }
            if (displayCharacter == '4')
            {
                img = gamePacOop.Properties.Resources.giphy__13_;
            }
            if (displayCharacter == 'V' || displayCharacter == 'v')
            {
                img = gamePacOop.Properties.Resources.giphy__10_;
            }
            if(displayCharacter == '$')
            {
               img = gamePacOop.Properties.Resources.w;
            }
            if(displayCharacter == '&')
            {
                img = gamePacOop.Properties.Resources.giphy__8_;
            }

            if (displayCharacter == 'S' || displayCharacter == 's')
            {
                img = gamePacOop.Properties.Resources.ghost_pink;
            }

            if (displayCharacter == 'R' || displayCharacter == 'r')
            {
                img = gamePacOop.Properties.Resources.ghost_orange;
            }
            if(displayCharacter == '.' )
            {
                img = gamePacOop.Properties.Resources.Yellow_Wall;
            }
            

            return img;
        }
    }
}
