using System;
using System.Collections.Generic;
using Raylib;
using static Raylib.Raylib;

namespace MaticesInRaylib
{
    class BlueBullet : Sprite
    {
        public float speed = 2.5f;
        
        public BlueBullet()
        {
            Game.gameObjects.Add(this);
            Load("bulletBlue.png");
            image.SetRotate(90 * (float)(Math.PI / 180));
            image.SetPosition(70, -5);
            collider = new AABB();
        }

        public override void OnUpdate(float dT)
        {
            Vector3 facing = new Vector3(localTransform.m1, localTransform.m2, 1) * dT * 100;
            Translate(facing * speed);
            collider.Fit(cornersGlobalPosition);

            foreach (var i in Game.targets)
            {
                if (collider.Overlaps(i.collider))
                {
                    i.color = Color.RED;
                    Game.gameObjects.Remove(this);
                }
            }
        }
    }

    class RedBullet : Sprite
    {
        public float speed = 2f;

        public RedBullet()
        {
            Game.gameObjects.Add(this);
            Load("bulletRed.png");
            image.SetRotate(90 * (float)(Math.PI / 180));
            image.SetPosition(70, -5);
        }

        public override void OnUpdate(float dT)
        {
            Vector3 facing = new Vector3(localTransform.m1, localTransform.m2, 1) * dT * 100;
            Translate(facing * speed);
        }
    }
}
