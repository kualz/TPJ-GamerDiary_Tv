using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace PAC_Man
{
    class Collisions
    {
        public static List<Rectangle> Rectangles { get; protected set; }
        public static List<Rectangle> Food { get; protected set; }
        public static List<Rectangle> Bigfood { get; protected set; }

        static Collisions()
        {
            Rectangles = new List<Rectangle>();
            Food = new List<Rectangle>();
            Bigfood = new List<Rectangle>();
        }

        // Sempre que crias uma parede no jogo, adicionas aqui a esta lista de Rectangles, basicamente.
    }
}
