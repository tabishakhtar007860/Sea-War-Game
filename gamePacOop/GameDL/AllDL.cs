using gamePacOop.GameGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gamePacOop.GameDL
{
    class AllDL
    {
        private static List<Ghost> ghostsList = new List<Ghost>();
        private static List<Bullet> bulletsList = new List<Bullet>();
        private static List<Bullet> ghostBulletsList = new List<Bullet>();

        internal static List<Ghost> GhostsList { get => ghostsList; set => ghostsList = value; }
        internal static List<Bullet> GhostBulletsList { get => ghostBulletsList; set => ghostBulletsList = value; }
        internal static List<Bullet> BulletsList { get => bulletsList; set => bulletsList = value; }
       


    }
}
