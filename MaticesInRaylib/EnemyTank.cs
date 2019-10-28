using System;
using System.Collections.Generic;
using rl = Raylib.Raylib;

namespace MaticesInRaylib
{
    /// <summary>
    /// AI Tank. Will automatically drive around and attack the player.
    /// </summary>
    class EnemyTank : Sprite
    {
        /// <summary>
        /// movement speed of the tank forwards
        /// </summary>
        public float speed = 1;
        /// <summary>
        /// rotation speed of the tank
        /// </summary>
        public float rotationSpeed = 0.005f;
        /// <summary>
        /// keeps track of time remaining before the tank will shoot again
        /// </summary>
        int shootTimer = 10;
        /// <summary>
        /// keeps track of how much time before the tank will choose a new direction to move
        /// </summary>
        int moveTimer = 150;
        /// <summary>
        /// varible gets randomized to help determine movement
        /// </summary>
        int move = 0;
        /// <summary>
        /// varible gets randomized to help determine movement
        /// </summary>
        int turn = 1;
        /// <summary>
        /// turret object on this tank
        /// </summary>
        Sprite turret = new Sprite();

        /// <summary>
        /// default constructor
        /// </summary>
        public EnemyTank()
        {
            //Add self to the list of gameObject so we will be updated by Game
            Game.gameObjects.Add(this);
            //load our texture 
            Load("tankRed.png");
            //start in top left corner
            SetPosition(10, 10);
            //aline image to fit tank properly
            image.SetRotate(-90 * (float)(Math.PI / 180));
            image.SetPosition(-Width / 2, Height / 2);

            //load turret's texture
            turret.Load("barrelRed.png");
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
            collider.tag = "Enemy";

            //set collider for turret
            turret.collider = new AABB();
            //set collider tag
            turret.collider.tag = "Enemy";
        }
        /// <summary>
        /// EnemyTank contructor that set the tank's position to a starting value
        /// </summary>
        /// <param name="startPosition"></param>
        public EnemyTank(Vector3 pos)
        {
            //Add self to the list of gameObject so we will be updated by Game
            Game.gameObjects.Add(this);
            //load our texture 
            Load("tankRed.png");
            //start at pos location
            SetPosition(pos.x, pos.y);
            //aline image to fit tank properly
            image.SetRotate(-90 * (float)(Math.PI / 180));
            image.SetPosition(-Width / 2, Height / 2);

            //load turret's texture
            turret.Load("barrelRed.png");
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
            collider.tag = "Enemy";

            //set collider for turret
            turret.collider = new AABB();
            //set collider tag
            turret.collider.tag = "Enemy";
        }

        /// <summary>
        /// moves the tank and performs actions based on player location and randomised numbers
        /// </summary>
        /// <param name="deltaTime"></param>
        public override void OnUpdate(float dT)
        {
            //find angle from the turret to the player
            float turretAngle = (float)Math.Atan2(turret.Position.y - Game.player.Position.y, turret.Position.x - Game.player.Position.x);
            //getParent angle in radians relative to world space
            float parentAngle = GetRotate();
            //set the turret's rotation to the turretAngle - parentAngle to compensate for hierachy. Also flip it cuz it ends up backwards otherwise
            turret.SetRotate(turretAngle + (float)Math.PI - parentAngle);

            //if we are near the middle of the screen
            if (collider.Overlaps(Game.arenaBox))
            {
                if (shootTimer > 0)
                {
                    //keep waiting to shoot
                    shootTimer--;
                }
                else
                {
                    //ready to shoot
                    Shoot();
                }
                

                if (moveTimer > 0)
                {
                    //keep waiting to change direction
                    moveTimer--;
                    //keep moving to in the same direction
                    Move(dT);
                }
                else
                {
                    //randomise movement directions
                    move = Game.Random.Next(0, 2);
                    turn = Game.Random.Next(0, 2);
                    //reset waiting period
                    moveTimer = Game.Random.Next(30, 100);
                }
            }
            //if we are leaving the screen
            else
            {
                //create new temperary matrix3
                Matrix3 angleToCenter = new Matrix3();
                //rotate in 180 degrees
                angleToCenter.SetRotateZ((float)Math.PI);
                //get angle we need to go to
                angleToCenter.RotateZ((float)Math.Atan2(Position.y - Game.arenaBox.Center.y, Position.x - Game.arenaBox.Center.x));

                //determine if we need to turn left or right
                if (angleToCenter.GetRotateZ() < GetRotate())
                {
                    //turn left quickly
                    Rotate(-rotationSpeed*3);
                }
                else
                {
                    //turn right quickly
                    Rotate(rotationSpeed*3);
                }

                //move forward
                Vector3 facing = new Vector3(localTransform.m1, localTransform.m2, 1) * dT * 100;
                Translate(facing * speed);
            }

            //if we are completely outside of the map
            if (!collider.Overlaps(Game.totalMapBox))
            {
                //flip 180 to point at home
                Rotate(3.14f);
                //move forwards quickly
                Vector3 facing = new Vector3(localTransform.m1, localTransform.m2, 1) * dT * 100;
                Translate(facing * speed*4);
            }

            //update tank collider
            collider.Fit(cornersGlobalPosition);
            //update turret collider
            turret.collider.Fit(turret.cornersGlobalPosition);
        }

        /// <summary>
        /// move the tank based on current variables
        /// </summary>
        /// <param name="deltaTime"></param>
        private void Move(float dT)
        {
            if (move == 0)
            {
                //move forward
                Vector3 facing = new Vector3(localTransform.m1, localTransform.m2, 1) * dT * 100;
                Translate(facing * speed);
            }

            if (turn == 1)
            {
                //turn right
                Rotate(rotationSpeed);
            }
            else if (turn == 0)
            {
                //turn left
                Rotate(-rotationSpeed);
            }

        }

        /// <summary>
        /// Creates a bullet sprite at the end of the tank barrel
        /// </summary>
        private void Shoot()
        {
            //Create new bullet object
            RedBullet bullet = new RedBullet();
            //set bullet to be a child of the turret
            turret.AddChild(bullet);
            //update the position of the bullet
            UpdateTransform();
            //set the bullet to have no parent
            turret.RemoveChild(bullet);
            //reset shootTimer to randomised number
            shootTimer = Game.Random.Next(30, 100);

        }

        /// <summary>
        /// Called when the object should be killed
        /// </summary>
        public override void Die()
        {
            //if we are already dead and grey
            if (!alive)
            {
                //delete this object completely
                Game.gameObjects.Remove(this);
            }
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
