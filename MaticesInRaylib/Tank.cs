using System;
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
            if (rl.IsKeyPressed(Raylib.KeyboardKey.KEY_SPACE))
            {
                Shoot();
            }


            collider.Fit(cornersGlobalPosition);
            turret.collider.Fit(turret.cornersGlobalPosition);
        }

        public Tank()
        {
            Game.gameObjects.Add(this);
            Load("tankBlue.png");
            // tank is facing the wrong way... fix that here 
            SetRotate(-90 * (float)(Math.PI / 180.0f));
            SetPosition(rl.GetScreenWidth() / 2.0f, rl.GetScreenHeight() / 2.0f);
            image.SetRotate(-90 * (float)(Math.PI / 180));
            image.SetPosition(-Width / 2, Height / 2);

            turret.Load("barrelBlue.png");
            turret.image.SetRotate(-90 * (float)(Math.PI / 180));
            turret.image.SetPosition(0, 11);
            AddChild(turret);
            UpdateTransform();

            
            collider = new AABB();
            turret.collider = new AABB();
        }

        private void Shoot()
        {
            BlueBullet bullet = new BlueBullet();
            turret.AddChild(bullet);
            UpdateTransform();
            turret.RemoveChild(bullet);
        }
    }
}
