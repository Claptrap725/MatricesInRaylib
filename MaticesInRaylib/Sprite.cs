using System;
using System.Collections.Generic;
using Raylib;
using static Raylib.Raylib;

namespace MaticesInRaylib
{
    /// <summary>
    /// A GameObject that has a texture that gets drawn at the end of every frame
    /// </summary>
    class Sprite : GameObject
    {
        /// <summary>
        /// texture that gets drawn every frame
        /// </summary>
        Texture2D texture;
        /// <summary>
        /// Color tint (usually just white)
        /// </summary>
        public Color color = Color.WHITE;
        /// <summary>
        /// object the is used as the position of the texture. This is important for making the texture draw in the correct place
        /// </summary>
        public GameObject image = new GameObject();
        /// <summary>
        /// 4 objects that are the corners of the texture. Useful for automatically fitting colliders
        /// </summary>
        protected List<GameObject> corners;
        /// <summary>
        /// returns the global position of the corners. Format: BL, TL, TR, BR
        /// </summary>
        public List<Vector3> cornersGlobalPosition
        {
            get
            {
                List<Vector3> globals = new List<Vector3>();
                globals.Add(corners[0].Position);
                globals.Add(corners[1].Position);
                globals.Add(corners[2].Position);
                globals.Add(corners[3].Position);
                return globals;
            }
        }

        /// <summary>
        /// returns the width of the texture
        /// </summary>
        public float Width
        {
            get { return texture.width; }
        }
        /// <summary>
        /// returns the hieght of the texture
        /// </summary>
        public float Height
        {
            get { return texture.height; }
        }
        /// <summary>
        /// default constructor
        /// </summary>
        public Sprite()
        {
            
        }

        /// <summary>
        /// sets texture variable and corners variable. Will load new textures into memory if nessisary
        /// </summary>
        /// <param name="filename"></param>
        public void Load(string filename)
        {
            // check if this texture has already been loaded
            if (Game.textures.ContainsKey(filename))
            {
                // use the previously loaded texture
                texture = Game.textures[filename];
            }
            else
            {
                // load an image from filename
                Image img = LoadImage(filename);
                // set texture based on img
                texture = LoadTextureFromImage(img);
                // add texture to list of loaded textures
                Game.textures[filename] = texture;
            }
            // initilize corners
            corners = new List<GameObject>()
            {
                // bottem left corner
                new GameObject(0, Height),
                // top left corner
                new GameObject(0, 0),
                // top right corner
                new GameObject(Width, 0),
                // bottem right corner
                new GameObject(Width, Height)
            };
            // make sure texture position follow SpriteObject correctly
            AddChild(image);
            // make corners follow texture position correctly
            image.AddChild(corners[0]);
            image.AddChild(corners[1]);
            image.AddChild(corners[2]);
            image.AddChild(corners[3]);
        }

        /// <summary>
        /// updates collider position
        /// </summary>
        /// <param name="deltaTime"></param>
        public override void OnUpdate(float dT)
        {
            // update collider position
            collider.Fit(cornersGlobalPosition);
        }

        /// <summary>
        /// Draws the texture into the Game window. Also tells collider to draw.
        /// </summary>
        public override void OnDraw()
        {
            // get proper roataion of object
            double rotation = Math.Atan2(image.GlobalTransform.m2, image.GlobalTransform.m1);
            // draw texture in window
            DrawTextureEx(texture, new Vector2(image.GlobalTransform.m7, image.GlobalTransform.m8), (float)rotation * (float)(180.0f / Math.PI), 1, color);
            // check if we have a collider
            if (collider != null)
            {
                // tell collider to draw
                collider.OnDraw();
            }
        }

        /// <summary>
        /// Called when the object should be killed
        /// </summary>
        public override void Die()
        {
            //set that we are no longer alive
            alive = false;
            //overlay a darkgray color to signify death
            color = Color.DARKGRAY;
            //get all children
            foreach (var i in children)
            {
                //tell them they are dead as well
                i.Die();
            }
        }


    }
}
