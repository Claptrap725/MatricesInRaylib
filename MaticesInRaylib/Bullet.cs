using System;
using System.Collections.Generic;
using Raylib;
using static Raylib.Raylib;

namespace MaticesInRaylib
{
    /// <summary>
    /// The Player's bullet. Will kill enemies on collision
    /// </summary>
    class BlueBullet : Sprite
    {
        /// <summary>
        /// speed at which the bullet moves forwards
        /// </summary>
        public float speed = 2.5f;
        
        /// <summary>
        /// default constructor
        /// </summary>
        public BlueBullet()
        {
            //Add self to the list of gameObject so we will be updated by Game
            Game.gameObjects.Add(this);
            //load our texture 
            Load("bulletBlue.png");
            //aline image to fit tank properly
            image.SetRotate(90 * (float)(Math.PI / 180));
            image.SetPosition(70, -5);
            //create collider for bullet
            collider = new Circle();
            //set collider tag
            collider.tag = "BlueBullet";
        }

        /// <summary>
        /// makes bullet fly through the air and checks collision
        /// </summary>
        /// <param name="deltaTime"></param>
        public override void OnUpdate(float dT)
        {
            //move forward
            Vector3 facing = new Vector3(localTransform.m1, localTransform.m2, 1) * dT * 100;
            Translate(facing * speed);
            //update collider to new position
            collider.Fit(cornersGlobalPosition);

            //search through all gameObjects to check collision
            for (int i = 0;i < Game.gameObjects.Count; i++)
            {
                //skip gameObjects that don't have a collider
                if (Game.gameObjects[i].collider == null) continue;
                //skip the player tank objects
                if (Game.gameObjects[i].collider.tag == "Player") continue;
                //skip another bullet of the same type
                if (Game.gameObjects[i].collider.tag == "BlueBullet") continue;

                //check collision with the object
                if (collider.Overlaps(Game.gameObjects[i].collider))
                {
                    //kill us and the other object
                    Game.gameObjects[i].Die();
                    Die();
                }
            }
        }

        /// <summary>
        /// Called when the object should be killed
        /// </summary>
        public override void Die()
        {
            //spawn explosion object
            Game.gameObjects.Add(new Explosion(image.Position));
            //remove ourselves from the gameObjects list so GC will delete us
            Game.gameObjects.Remove(this);
        }
    }

    /// <summary>
    /// Enemies' bullet. It will kill the player on collision.
    /// </summary>
    class RedBullet : Sprite
    {
        /// <summary>
        /// speed at which the bullet moves forwards
        /// </summary>
        public float speed = 2.5f;

        /// <summary>
        /// default constructor
        /// </summary>
        public RedBullet()
        {
            //Add self to the list of gameObject so we will be updated by Game
            Game.gameObjects.Add(this);
            //load our texture 
            Load("bulletRed.png");
            //aline image to fit tank properly
            image.SetRotate(90 * (float)(Math.PI / 180));
            image.SetPosition(70, -5);
            //create collider for bullet
            collider = new Circle();
            //set collider tag
            collider.tag = "RedBullet";
        }

        /// <summary>
        /// makes bullet fly through the air and checks collision
        /// </summary>
        /// <param name="dT"></param>
        public override void OnUpdate(float dT)
        {
            //move forward
            Vector3 facing = new Vector3(localTransform.m1, localTransform.m2, 1) * dT * 100;
            Translate(facing * speed);
            //update collider to new position
            collider.Fit(cornersGlobalPosition);

            //search through all gameObjects to check collision
            for (int i = 0; i < Game.gameObjects.Count; i++)
            {
                //skip gameObjects that don't have a collider
                if (Game.gameObjects[i].collider == null) continue;
                //skip the enemy tank objects
                if (Game.gameObjects[i].collider.tag == "Enemy") continue;
                //skip another bullet of the same type
                if (Game.gameObjects[i].collider.tag == "RedBullet") continue;

                //check collision with the object
                if (collider.Overlaps(Game.gameObjects[i].collider))
                {
                    //kill us and the other object
                    Game.gameObjects[i].Die();
                    Die();
                }
            }
        }

        /// <summary>
        /// Called when the object should be killed
        /// </summary>
        public override void Die()
        {
            //spawn explosion object
            Game.gameObjects.Add(new Explosion(image.Position));
            //remove ourselves from the gameObjects list so GC will delete us
            Game.gameObjects.Remove(this);
        }
    }
}
