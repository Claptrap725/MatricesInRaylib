using System;
using System.Collections.Generic;
using System.Text;

namespace MaticesInRaylib
{
    /// <summary>
    /// Just displays an explosion image for 1 second then deletes itself
    /// </summary>
    class Explosion : Sprite
    {
        /// <summary>
        /// timer used to keep track of how much longer until the explosion stops
        /// </summary>
        int Timer = 60;

        /// <summary>
        /// Contructor that takes in a position of where the explosion is taking place
        /// </summary>
        /// <param name="position"></param>
        public Explosion(Vector3 position)
        {
            //Add self to the list of gameObject so we will be updated by Game
            Game.gameObjects.Add(this);
            //load our texture 
            Load("explosion.png");

            // orient ourselves correctly
            SetRotate(-90 * (float)(Math.PI / 180.0f));
            // go to position where explosion takes place
            SetPosition(position);
            //aline image to fit tank properly
            image.SetRotate(-90 * (float)(Math.PI / 180));
            image.SetPosition(-Width / 2, Height / 2);
            //Rotate randomly to add some variation to explosions
            Rotate(Game.Random.Next(-180, 180));
        }

        /// <summary>
        /// updates timer and kills object when time is up
        /// </summary>
        /// <param name="deltaTime"></param>
        public override void OnUpdate(float dT)
        {
            // see if time is up
            if(Timer <= 0)
            {
                // kill this object
                Die();
            }
            // reduce time by 1 frame
            Timer--;
            
        }

        /// <summary>
        /// Called when the object should be killed
        /// </summary>
        public override void Die()
        {
            Game.gameObjects.Remove(this);
        }

    }
}
