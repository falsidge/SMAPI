using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;
using Object = StardewValley.Object;
using StardewValley.Locations;
using StardewValley.Objects;
using StardewValley.Tools;
using xTile;
#pragma warning disable 1591

namespace StardewModdingAPI.Inheritance
{
    [Obsolete("Do not use at this time.")]
    public class SObject : Object
    {
        public SObject( )
        {
            name = "Modded Item Name";
            Description = "Modded Item Description";
            CategoryName = "Modded Item Category";
            Texture = Game1.mouseCursors;
            Category = 4163;
            CategoryColour = Color.White;
            IsPassable = false;
            IsPlaceable = true;
            PlacementPreview = false;
            defaultboundingBox = new Rectangle(0, -32, 140, 96);
            SourceRect = new Rectangle(173, 423, 16, 16);
          //  boundingBox = new Rectangle((int)tileLocation.X * Game1.tileSize, (int)tileLocation.Y * Game1.tileSize, 64,64);
            DestRect = new Rectangle(0,0,64, 64);
            MaxStackSize = 999;
            fragility = 0;
            type = "interactive";
            InvisTiles = new List<InvisibileTile>();
        }
        public SObject(String name, String Description, String CategoryName, int Category)
        {
            this.name = name;
            this.Description = Description;
            this.CategoryName = CategoryName;
            this.Category = Category;
            InvisTiles = new List<InvisibileTile>();
        }

        public override string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Description { get; set; }
        public Texture2D Texture { get; set; }
        public Rectangle DestRect { get; set; }
        public Rectangle SourceRect { get; set; }
        public Rectangle edgeBox { get; set; }
        public Rectangle sizeBox { get; set; }
        private Rectangle defaultBoundingBox;
        public Rectangle defaultboundingBox
        {
            get
            { return this.defaultBoundingBox; }
            set
            {
                this.defaultBoundingBox = value;
                int beginx = (int)Math.Floor((double)defaultBoundingBox.X / Game1.tileSize);
                int endx = (int)Math.Ceiling((double)defaultBoundingBox.Width / Game1.tileSize);
                int beginy = (int)Math.Floor((double)defaultBoundingBox.Y / Game1.tileSize);
                int endy = (int)Math.Ceiling((double)defaultBoundingBox.Height / Game1.tileSize);
                int leftx = (defaultBoundingBox.X % Game1.tileSize);
                if (leftx < 0)
                    leftx = Game1.tileSize + leftx;
                int rightx = (defaultBoundingBox.Width % Game1.tileSize);
                if (rightx <= 0)
                    rightx = Game1.tileSize + rightx;
                int topy = (defaultBoundingBox.Y % Game1.tileSize);
                if (topy < 0)
                    topy = Game1.tileSize + topy;
                int bottomy = (defaultBoundingBox.Height % Game1.tileSize);
                if (bottomy <= 0)
                    bottomy = Game1.tileSize + bottomy;
                this.edgeBox = new Rectangle(beginx,beginy,endx,endy);
                this.sizeBox = new Rectangle(leftx,topy,rightx,bottomy);

            }
        }
        public List<InvisibileTile> InvisTiles { get; set; }
        public string CategoryName { get; set; }
        public Color CategoryColour { get; set; }
        public bool IsPassable { get; set; }
        public bool IsPlaceable { get; set; }
        public bool PlacementPreview { get; set; }
        public bool HasBeenRegistered { get; set; }
        public int RegisteredId { get; set; }

        public int MaxStackSize { get; set; }



        public override int Stack
        {
            get { return stack; }
            set { stack = value; }
        }

        public override string getDescription()
        {
            return Description;
        }

        public override Rectangle getBoundingBox(Vector2 tileLocation)
        {
            this.boundingBox.X = (int)tileLocation.X * Game1.tileSize + defaultboundingBox.X;
            this.boundingBox.Y = (int)tileLocation.Y * Game1.tileSize + defaultboundingBox.Y;
            this.boundingBox.Width = defaultboundingBox.Width;
            this.boundingBox.Height = defaultboundingBox.Height;
            return this.boundingBox;
        }
        public override void draw(SpriteBatch spriteBatch, int x, int y, float alpha = 1)
        {
            if (Texture == null)
            {
                this.Texture = Game1.mouseCursors;
            }
            Vector2 vector2_1 = this.getScale() * (float)Game1.pixelZoom;
            Vector2 vector2_2 = Game1.GlobalToLocal(Game1.viewport, new Vector2((float)(x * Game1.tileSize - DestRect.X), (float)(y * Game1.tileSize - DestRect.Y)));

            Microsoft.Xna.Framework.Rectangle destinationRectangle = new Microsoft.Xna.Framework.Rectangle((int)((double)vector2_2.X - (double)vector2_1.X / 2.0) + (this.shakeTimer > 0 ? Game1.random.Next(-1, 2) : 0), (int)((double)vector2_2.Y - (double)vector2_1.Y / 2.0) + (this.shakeTimer > 0 ? Game1.random.Next(-1, 2) : 0), (int)((double)DestRect.Width + (double)vector2_1.X), (int)((double)(DestRect.Height) + (double)vector2_1.Y / 2.0));
            spriteBatch.Draw(Texture, destinationRectangle, SourceRect, Color.White * alpha, 0.0f, Vector2.Zero, SpriteEffects.None, (float)((double)Math.Max(0.0f, (float)((y + 1) * Game1.tileSize - Game1.pixelZoom * 6) / 10000f) + (this.parentSheetIndex == 105 ? 0.00350000010803342 : 0.0) + (double)x * 9.99999993922529E-09));
        }

        public new void drawAsProp(SpriteBatch spriteBatch )
        {
            float x = this.tileLocation.X;
            float y = this.tileLocation.Y;
            Vector2 vector2_1 = this.getScale() * (float)Game1.pixelZoom;
            Vector2 vector2_2 = Game1.GlobalToLocal(Game1.viewport, new Vector2((float)(x * Game1.tileSize - DestRect.X), (float)(y * Game1.tileSize - DestRect.Y)));

            Microsoft.Xna.Framework.Rectangle destinationRectangle = new Microsoft.Xna.Framework.Rectangle((int)((double)vector2_2.X - (double)vector2_1.X / 2.0) + (this.shakeTimer > 0 ? Game1.random.Next(-1, 2) : 0), (int)((double)vector2_2.Y - (double)vector2_1.Y / 2.0) + (this.shakeTimer > 0 ? Game1.random.Next(-1, 2) : 0), (int)((double)DestRect.Width + (double)vector2_1.X), (int)((double)(DestRect.Height) + (double)vector2_1.Y / 2.0));
            spriteBatch.Draw(Texture, destinationRectangle, SourceRect, Color.White, 0.0f, Vector2.Zero, SpriteEffects.None, (float)((double)Math.Max(0.0f, (float)((y + 1) * Game1.tileSize - Game1.pixelZoom * 6) / 10000f) + (this.parentSheetIndex == 105 ? 0.00350000010803342 : 0.0) + (double)x * 9.99999993922529E-09));
        }

        public override void draw(SpriteBatch spriteBatch, int xNonTile, int yNonTile, float layerDepth, float alpha = 1)
        {
            spriteBatch.Draw(Texture, Game1.GlobalToLocal(Game1.viewport, new Vector2((float)(xNonTile + Game1.tileSize / 2 + (this.shakeTimer > 0 ? Game1.random.Next(-1, 2) : 0)), (float)(yNonTile + Game1.tileSize / 2 + (this.shakeTimer > 0 ? Game1.random.Next(-1, 2) : 0)))), null, Color.White * alpha, 0.0f, new Vector2(8f, 8f), (double)this.scale.Y > 1.0 ? this.getScale().Y : (float)Game1.pixelZoom, this.flipped ? SpriteEffects.FlipHorizontally : SpriteEffects.None, layerDepth);
        }


        public override void drawInMenu(SpriteBatch spriteBatch, Vector2 location, float scaleSize, float transparency, float layerDepth, bool drawStackNumber)
        {
            if (isRecipe)
            {
                transparency = 0.5f;
                scaleSize *= 0.75f;
            }

            if (Texture == null)
            {
                this.Texture = Game1.mouseCursors;
            }
                double Biggest;
                if (this.SourceRect.Width > this.SourceRect.Height)
                    Biggest = this.SourceRect.Width;
                else
                    Biggest = this.SourceRect.Height;
                Biggest /= (16);
                spriteBatch.Draw(Texture, location + new Vector2((float)(Game1.tileSize /(SourceRect.Width/16 +1 )), (float)(Game1.tileSize /(SourceRect.Height/16))), SourceRect  , Color.White * transparency, 0.0f, new Vector2(8f, 16f), (float)Game1.pixelZoom * ((double)scaleSize < 0.2 ? scaleSize : (float ) (scaleSize/Biggest) ), SpriteEffects.None, layerDepth);
            if (drawStackNumber && stack != 1   )
            {
                var _scale = 0.5f + scaleSize;
                Game1.drawWithBorder(stack.ToString(), Color.Black, Color.White, location + new Vector2(Game1.tileSize - Game1.tinyFont.MeasureString(string.Concat(stack.ToString())).X * _scale, Game1.tileSize - (float)((double)Game1.tinyFont.MeasureString(string.Concat(stack.ToString())).Y * 3.0f / 4.0f) * _scale), 0.0f, _scale, 1f, true);
            }
        }

        public override void drawWhenHeld(SpriteBatch spriteBatch, Vector2 objectPosition, Farmer f)
        {
            if (Texture == null)
            {
                this.Texture = Game1.mouseCursors;
            }
                Vector2 vector2_1 = this.getScale() * (float)Game1.pixelZoom;
                Rectangle destinationRectangle = new Rectangle((int)  (objectPosition.X - DestRect.X), (int)(objectPosition.Y - DestRect.Y - (vector2_1.X / 2.0)), DestRect.Width, DestRect.Height);

                spriteBatch.Draw(Texture, destinationRectangle, SourceRect, Color.White, 0.0f, Vector2.Zero, SpriteEffects.None, (float)(f.getStandingY() + 2) / 10000f);
        }

        public override Color getCategoryColor()
        {
            return CategoryColour;
        }

        public override string getCategoryName()
        {
            if (string.IsNullOrEmpty(CategoryName))
                return "Modded Item";
            return CategoryName;
        }

        public override bool isPassable()
        {
            return IsPassable;
        }

        public override bool isPlaceable()
        {
            return IsPlaceable;
        }

        public override int maximumStackSize()
        {
            return MaxStackSize;
        }

        public SObject Clone()
        {
            var toRet = new SObject
            {
                Name = Name,
                CategoryName = CategoryName,
                Description = Description,
                Texture = Texture,
                defaultboundingBox = defaultboundingBox,
                boundingBox = boundingBox,
                SourceRect = SourceRect,
                DestRect = DestRect,
                IsPassable = IsPassable,
                IsPlaceable = IsPlaceable,
                quality = quality,
                scale = scale,
                isSpawnedObject = isSpawnedObject,
                isRecipe = isRecipe,
                questItem = questItem,
                stack = 1,
                HasBeenRegistered = HasBeenRegistered,
                RegisteredId = RegisteredId
            };


            return toRet;
        }

        public override Item getOne()
        {
            return Clone();
        }

        public override void actionWhenBeingHeld(Farmer who)
        {

            base.actionWhenBeingHeld(who);
        }

        public override bool canBePlacedHere(GameLocation l, Vector2 tile)
        {
            if (!l.objects.ContainsKey(tile))
                return true;

            return false;
        }

        public override bool placementAction(GameLocation location, int x, int y, Farmer who = null)
        {
            if (Game1.didPlayerJustRightClick())
                return false;

            var key = new Vector2( x / Game1.tileSize, y / Game1.tileSize);

            if (!canBePlacedHere(location, key))
                return false;

            x /= Game1.tileSize;
            y /= Game1.tileSize;

            for (int tx = 0; tx < edgeBox.Width; tx++)
            {
                for (int ty = 0; ty < edgeBox.Height; ty++)
                {
                    Vector2 pos = new Vector2(tx + x + edgeBox.X, ty + y + edgeBox.Y);
                    if (!canBePlacedHere (location,pos))//Utility.playerCanPlaceItemHere(location, (Item)this, (int)pos.X, (int)pos.Y, Game1.player))
                    {
                        return false;
                    }

                }
            }

            if (defaultboundingBox.Width > 64 || defaultboundingBox.Height > 64  )
            {
                int beginx = edgeBox.X;
                int endx = edgeBox.Width;
                int beginy = edgeBox.Y;
                int endy = edgeBox.Height;

                int leftx = sizeBox.X;
                int rightx = sizeBox.Width;
                int topy = sizeBox.Y;
                int bottomy = sizeBox.Height;

                this.tileLocation = key;
                var mainTile = Clone();
                for (int tx = 0; tx < endx; tx++)
                {
                    int bx = 0;
                    int wx = 64;

                    if (tx == 0)
                    {
                        bx = leftx;
                        wx -= bx;

                    }
                    else if (tx == endx-1)
                    {
                        wx = rightx;
                    }
                    for (int ty = 0; ty < endy; ty++)
                    {

                        int by = 0;
                        int wy = 64;
                        if (ty == 0)
                        {
                            by = topy;
                            wy -= by;
                        }
                        else if (ty == endy-1)
                        {
                            wy = bottomy;
                        }
                        Vector2 pos = new Vector2(tx + x + beginx, ty + y + beginy);
                        if (pos.X != key.X || pos.Y != key.Y)
                        {
                            var s = new InvisibileTile(mainTile);
                            s.tileLocation = pos;
                            s.defaultboundingBox = new Rectangle(bx, by , wx, wy);
                            s.getBoundingBox(pos);
                            location.objects.Add(pos, s);
                            mainTile.InvisTiles.Add(s);
                        }
                        else
                        {
                            
                            mainTile.tileLocation = key;
                            mainTile.defaultboundingBox = new Rectangle(bx,by,wx,wy);
                            mainTile.getBoundingBox(key);
                            location.objects.Add(key, mainTile);
                        }
                    }
                }
            }
            else
            {
                var mainTile = Clone();
                mainTile.tileLocation = key;
                mainTile.getBoundingBox(mainTile.tileLocation);
                location.objects.Add(key, mainTile);
            }
            return true;
        }
        public override bool performToolAction(Tool t)
        {
            GameLocation location = t.getLastFarmerToUse().currentLocation;
            //Game1.createRadialDebris(location, 12, (int)this.tileLocation.X, (int)this.tileLocation.Y, Game1.random.Next(4, 10), false, -1, false, -1);
           // location.temporarySprites.Add(new TemporaryAnimatedSprite(12, new Vector2(this.tileLocation.X * (float)Game1.tileSize, this.tileLocation.Y * (float)Game1.tileSize), Color.White, 8, Game1.random.NextDouble() < 0.5, 50f, 0, -1, -1f, -1, 0));
            t.getLastFarmerToUse().currentLocation.debris.Add(new Debris((Item)Clone(), this.tileLocation * (float)Game1.tileSize + new Vector2((float)(Game1.tileSize / 2), (float)(Game1.tileSize / 2))));
            foreach (InvisibileTile a in this.InvisTiles)
            {
                if (location.objects.ContainsKey(a.tileLocation))
                    location.objects.Remove(a.tileLocation);
            }
            if (location.objects.ContainsKey(tileLocation))
                location.objects.Remove(tileLocation);
            return false;
        }
        public override void performRemoveAction(Vector2 tileLocation, GameLocation enviroment)
        {
            foreach (InvisibileTile a in InvisTiles)
            {
                if (enviroment.objects.ContainsKey(a.tileLocation))
                    enviroment.objects.Remove(a.tileLocation);
            }
            if (enviroment.objects.ContainsKey(tileLocation))
                enviroment.objects.Remove(tileLocation);
        }
        public override void actionOnPlayerEntry()
        {
            //base.actionOnPlayerEntry();
        }

        public override void drawPlacementBounds(SpriteBatch spriteBatch, GameLocation location)
        {

            var targSize = Game1.tileSize;
            int x = Game1.getOldMouseX() + Game1.viewport.X;
            int y = Game1.getOldMouseY() + Game1.viewport.Y;
            if ((double)Game1.mouseCursorTransparency == 0.0)
            {
                x = (int)Game1.player.GetGrabTile().X * Game1.tileSize;
                y = (int)Game1.player.GetGrabTile().Y * Game1.tileSize;
            }
            if (Game1.player.GetGrabTile().Equals(Game1.player.getTileLocation()) && (double)Game1.mouseCursorTransparency == 0.0)
            {
                Vector2 translatedVector2 = Utility.getTranslatedVector2(Game1.player.GetGrabTile(), Game1.player.facingDirection, 1f);
                x = (int)translatedVector2.X * Game1.tileSize;
                y = (int)translatedVector2.Y * Game1.tileSize;
            }

            Boolean canplacehere = Utility.playerCanPlaceItemHere(location, (Item)this, (int)x, (int)y, Game1.player);
            for (int tx = 0; tx < edgeBox.Width && canplacehere; tx++)
            {
                for (int ty = 0; ty < edgeBox.Height && canplacehere; ty++)
                {
                    Vector2 pos = new Vector2(tx + x / Game1.tileSize + edgeBox.X, ty + y / Game1.tileSize + edgeBox.Y);
                    if (!canBePlacedHere(location,pos))//Utility.playerCanPlaceItemHere(location, (Item)this, (int) pos.X, (int) pos.Y, Game1.player))
                    {
                        canplacehere = false;   
                        break;
                    }

                }
            }
                    spriteBatch.Draw(Game1.mouseCursors, new Vector2((float)(x / Game1.tileSize * Game1.tileSize - Game1.viewport.X), (float)(y / Game1.tileSize * Game1.tileSize - Game1.viewport.Y)), new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(canplacehere ? 194 : 210, 388, 16, 16)), Color.White, 0.0f, Vector2.Zero, (float)Game1.pixelZoom, SpriteEffects.None, 0.01f);
            if (PlacementPreview)
                this.draw(spriteBatch, x / Game1.tileSize, y / Game1.tileSize, 0.5f);
        }
    }
}