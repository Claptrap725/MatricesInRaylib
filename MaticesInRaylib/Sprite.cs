using System;
using System.Collections.Generic;
using Raylib;
using static Raylib.Raylib;

namespace MaticesInRaylib
{
    class Sprite : GameObject
    {
        Texture2D texture;
        public Color color = Color.WHITE;
        public GameObject image = new GameObject();
        protected List<GameObject> corners;
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

        public float Width
        {
            get { return texture.width; }
        }

        public float Height
        {
            get { return texture.height; }
        }

        public Sprite()
        {
            
        }

        public void Load(string filename)
        {
            if (Game.textures.ContainsKey(filename))
            {
                texture = Game.textures[filename];
            }
            else
            {
                Image img = LoadImage(filename);
                texture = LoadTextureFromImage(img);
                Game.textures[filename] = texture;
            }
            corners = new List<GameObject>()
            {
                new GameObject(0, Height),
                new GameObject(0, 0),
                new GameObject(Width, 0),
                new GameObject(Width, Height)
            };
            AddChild(image);
            image.AddChild(corners[0]);
            image.AddChild(corners[1]);
            image.AddChild(corners[2]);
            image.AddChild(corners[3]);
        }

        public override void OnUpdate(float dT)
        {
            collider.Fit(cornersGlobalPosition);
        }

        public override void OnDraw()
        {
            double rotation = Math.Atan2(image.GlobalTransform.m2, image.GlobalTransform.m1);
            DrawTextureEx(texture, new Vector2(image.GlobalTransform.m7, image.GlobalTransform.m8), (float)rotation * (float)(180.0f / Math.PI), 1, color);
            if (collider != null)
            {
                collider.OnDraw();
            }

            foreach (var i in corners)
            {
                DrawCircle((int)i.Position.x, (int)i.Position.y, 2f, Color.GREEN);
            }
        }


    }
}
