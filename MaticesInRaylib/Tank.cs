using System;
using rl = Raylib.Raylib;
using static Raylib.Raylib;

namespace MaticesInRaylib
{
    /// <summary>
    /// Player Tank. Is controlled by keyboard.
    /// </summary>
    class Tank : Sprite
    {
        /// <summary>
        /// movement speed of the tank forward and backwards
        /// </summary>
        public float speed = 2;
        /// <summary>
        /// rotation speed of the tank and turret
        /// </summary>
        public float rotationSpeed = 0.05f;
        /// <summary>
        /// turret object on this tank
        /// </summary>
        Sprite turret = new Sprite();

        /// <summary>
        /// default constructor
        /// </summary>
        public Tank()
        {
            //Add self to the list of gameObject so we will be updated by Game
            Game.gameObjects.Add(this);
            //load our texture 
            Load("tankBlue.png");
            //start out facing left
            SetRotate(180 * (float)(Math.PI / 180.0f));
            //start in bottem right corner
            SetPosition(1180, 620);
            //aline image to fit tank properly
            image.SetRotate(-90 * (float)(Math.PI / 180));
            image.SetPosition(-Width / 2, Height / 2);

            //load turret's texture
            turret.Load("barrelBlue.png");
            //aline turret's image to fit properly
            turret.image.SetRotate(-90 * (float)(Math.PI / 180));
            turret.image.SetPosition(0, 11);
            //make turret a child of the tank
            AddChild(turret);
            //Update turret and image transforms
            UpdateTransform();

            //create collider for tank
            collider = new AABB();
            //set collider tag
            collider.tag = "Player";
            
            //set collider for turret
            turret.collider = new AABB();
            //set collider tag
            turret.collider.tag = "Player";
        }

        /// <summary>
        /// Gets user input and moves the tank and peforms actions
        /// </summary>
        /// <param name="deltaTime"></param>
        public override void OnUpdate(float dT)
        {
            if (IsKeyDown(Raylib.KeyboardKey.KEY_W))
            {
                //when user presses W go forward
                Vector3 facing = new Vector3(localTransform.m1, localTransform.m2, 1) * dT * 100;
                Translate(facing * speed);
            }
            if (IsKeyDown(Raylib.KeyboardKey.KEY_S))
            {
                //when user presses S go backward
                Vector3 facing = new Vector3(localTransform.m1, localTransform.m2, 1) * dT * -100;
                Translate(facing * speed);
            }
            if (IsKeyDown(Raylib.KeyboardKey.KEY_A))
            {
                //when user presses A turn the tank left
                Rotate(-rotationSpeed/2);
            }
            if (IsKeyDown(Raylib.KeyboardKey.KEY_D))
            {
                //when user presses D turn the tank right
                Rotate(rotationSpeed/2);
            }
            if (IsKeyDown(Raylib.KeyboardKey.KEY_Q))
            {
                //when user presses Q turn the turret left
                turret.Rotate(-rotationSpeed);
            }
            if (IsKeyDown(Raylib.KeyboardKey.KEY_E))
            {
                //when user presses E turn the turret right
                turret.Rotate(rotationSpeed);
            }
            if (IsKeyPressed(Raylib.KeyboardKey.KEY_SPACE))
            {
                //when user presses SPACE shoot a bullet
                Shoot();
            }

            //update tank collider to the tank new position
            collider.Fit(cornersGlobalPosition);
            //update turret collider as well
            turret.collider.Fit(turret.cornersGlobalPosition);
        }

        /// <summary>
        /// Creates a bullet sprite at the end of the tank barrel
        /// </summary>
        private void Shoot()
        {
            //Create new bullet object
            BlueBullet bullet = new BlueBullet();
            //set bullet to be a child of the turret
            turret.AddChild(bullet);
            //update the position of the bullet
            UpdateTransform();
            //set the bullet to have no parent
            turret.RemoveChild(bullet);
        }

        /// <summary>
        /// Called when the object should be killed
        /// </summary>
        public override void Die()
        {
            //set that we are no longer alive
            alive = false;
            //overlay a darkgray color to signify death
            color = Raylib.Color.DARKGRAY;
            //get all children
            foreach (var i in children)
            {
                //tell them they are dead as well
                i.Die();
            }
        }
    }
}
