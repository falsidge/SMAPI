using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using StardewModdingAPI;
using StardewModdingAPI.Inheritance;
using StardewValley;

namespace StardewModdingAPI.Inheritance
{
    public class InvisibileTile:SObject
    {
        public SObject Source;
        public InvisibileTile (SObject source) : base()
        {
           IsPassable = source.IsPassable;
            Source = source;
        }
        public override void draw(SpriteBatch spriteBatch, int x, int y, float alpha = 1)
        {
        }
        public override bool performToolAction(Tool t)
        {
          //  this.tileLocation = Source.tileLocation;
            return Source.performToolAction(t);
        }
    }
}
