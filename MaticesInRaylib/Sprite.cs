using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using Raylib;
using static Raylib.Raylib;

namespace MaticesInRaylib
{
    class Sprite : GameObject
    {
        Texture2D texture = new Texture2D();
        public GameObject image = new GameObject();

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
            Image img = LoadImage(filename);
            texture = LoadTextureFromImage(img);
            AddChild(image);
        }

        public override void OnUpdate(float dT)
        {
            
        }

        public override void OnDraw()
        {
            double rotation = Math.Atan2(image.GlobalTransform.m2, image.GlobalTransform.m1);
            DrawTextureEx(texture, new Vector2(image.GlobalTransform.m7, image.GlobalTransform.m8), (float)rotation * (float)(180.0f / Math.PI), 1, Color.WHITE);

        }


    }
}
