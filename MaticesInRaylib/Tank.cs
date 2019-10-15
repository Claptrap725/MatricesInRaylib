using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using rl = Raylib.Raylib;

namespace MaticesInRaylib
{
    class Tank : Sprite
    {
        public float speed = 1;
        public float rotationSpeed = 0.05f;
        Sprite turret = new Sprite();

        public override void OnUpdate(float dT)
        {
            if (rl.IsKeyDown(Raylib.KeyboardKey.KEY_W))
            {
                Vector3 facing = new Vector3(localTransform.m1, localTransform.m2, 1) * dT * 100;
                Translate(facing * speed);
            }
            if (rl.IsKeyDown(Raylib.KeyboardKey.KEY_S))
            {
                Vector3 facing = new Vector3(localTransform.m1, localTransform.m2, 1) * dT * -100;
                Translate(facing * speed);
            }
            if (rl.IsKeyDown(Raylib.KeyboardKey.KEY_A))
            {
                Rotate(-rotationSpeed);
            }
            if (rl.IsKeyDown(Raylib.KeyboardKey.KEY_D))
            {
                Rotate(rotationSpeed);
            }
            if (rl.IsKeyDown(Raylib.KeyboardKey.KEY_Q))
            {
                turret.Rotate(-rotationSpeed);
            }
            if (rl.IsKeyDown(Raylib.KeyboardKey.KEY_E))
            {
                turret.Rotate(rotationSpeed);
            }
            if (rl.IsKeyDown(Raylib.KeyboardKey.KEY_SPACE))
            {

            }
        }

        public Tank()
        {
            Game.gameObjects.Add(this);
            Load("tankBlue_outline.png");
            // tank is facing the wrong way... fix that here 
            SetRotate(-90 * (float)(Math.PI / 180.0f));
            SetPosition(rl.GetScreenWidth() / 2.0f, rl.GetScreenHeight() / 2.0f);
            image.SetRotate(-90 * (float)(Math.PI / 180));
            image.SetPosition(-Width / 2, Height / 2);

            turret.Load("barrelBlue_outline.png");
            turret.image.SetRotate(-90 * (float)(Math.PI / 180));
            turret.image.SetPosition(0, 11);
            AddChild(turret);
            UpdateTransform();
        }
    }
}
