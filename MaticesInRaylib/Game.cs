using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using Raylib;
using static Raylib.Raylib;


namespace MaticesInRaylib
{
    /// <summary>
    /// Game Class handles all GameObjects and Time
    /// </summary>
    class Game
    {
        /// <summary>
        /// SET TO TRUE IF YOU WANT TO SEE THE COLLIDERS IN GAME
        /// </summary>
        public static bool DrawColliders = false;

        /// <summary>
        /// Stores all parent GameObjects so they can be updated
        /// </summary>
        public static List<GameObject> gameObjects = new List<GameObject>();
        /// <summary>
        /// All Textures that are currently loaded in the Game. Used to optimize memory usage when reusing textures.
        /// </summary>
        public static Dictionary<string, Texture2D> textures = new Dictionary<string, Texture2D>();

        /// <summary>
        /// Used for all random generation in the game
        /// </summary>
        public static Random Random = new Random();
        /// <summary>
        /// used to keep track of time
        /// </summary>
        Stopwatch stopwatch = new Stopwatch();

        /// <summary>
        /// The curret time
        /// </summary>
        private long currentTime = 0;
        /// <summary>
        /// Time last frame
        /// </summary>
        private long lastTime = 0;

        /// <summary>
        /// used to calculate fps
        /// </summary>
        private float timer = 0;
        /// <summary>
        /// current fps on the game
        /// </summary>
        private int fps = 1;
        /// <summary>
        /// used to calculate fps
        /// </summary>
        private int frames;

        /// <summary>
        /// time since last frame
        /// </summary>
        private float deltaTime = 0.005f;

        /// <summary>
        /// area where NPC tanks will try to remain and will attack the player
        /// </summary>
        public static AABB arenaBox = new AABB();
        /// <summary>
        /// area that if NPC tanks leave then they will snap back towards the center of the map 
        /// </summary>
        public static AABB totalMapBox = new AABB();
        
        /// <summary>
        /// The Player's Tank Object
        /// </summary>
        public static Tank player = new Tank();

        /// <summary>
        /// Ran when the game starts
        /// </summary>
        public void Init()
        {
            // start keeping track of time
            stopwatch.Start();
            // note time at start of game
            lastTime = stopwatch.ElapsedMilliseconds;
            // set arenaBox
            arenaBox.Fit(new List<Vector3>() { new Vector3(150, 150, 1), new Vector3(1130, 570, 1)});
            // set totalMapBox
            totalMapBox.Fit(new List<Vector3>() { new Vector3(-100, -100, 1), new Vector3(1380, 820, 1) });
            // spawn 4 enemy NPC tanks
            new EnemyTank(new Vector3(10, 10, 0));
            new EnemyTank(new Vector3(-10, 300, 0));
            new EnemyTank(new Vector3(450, -10, 0));
            new EnemyTank(new Vector3(300, 200, 0));
        }

        /// <summary>
        /// Never used
        /// </summary>
        public void Shutdown()
        {

        }

        /// <summary>
        /// Called every frame
        /// </summary>
        public void Update()
        {
            // get current time
            currentTime = stopwatch.ElapsedMilliseconds;
            // calculate deltaTime
            deltaTime = (currentTime - lastTime) / 1000.0f;
            // add to timer
            timer += deltaTime;

            // caculate fps every second
            if (timer >= 1)
            {
                fps = frames;
                frames = 0;
                timer -= 1;
            }
            // add 1 to frames
            frames++;

            // update all GameObjects in the scene
            for (int i = 0; i < gameObjects.Count; i++)
            {
                gameObjects[i].Update(deltaTime);
            }

            // set lastTime
            lastTime = currentTime;
        }

        /// <summary>
        /// called every frame after Update
        /// </summary>
        public void Draw()
        {
            BeginDrawing();
            // set background
            ClearBackground(Color.WHITE);
            // draw fps
            DrawText(fps.ToString(), 10, 10, 12, Color.RED);

            // draw all GameObjects in the scene
            for (int i = 0; i < gameObjects.Count; i++)
            {
                gameObjects[i].Draw();
            }

            // tell arenaBox to draw collider
            arenaBox.OnDraw();

            // if player is dead
            if (!player.alive)
            {
                // Gameover
                DrawText("GAMEOVER", 500, 300, 60, Color.RED);
            }
            else
            {
                // check if all enemyTanks have been destroyed
                for (int i = 0; i < gameObjects.Count; i++)
                {
                    if (gameObjects[i].GetType() == typeof(EnemyTank))
                    {
                        // if we find an enemy tank still existing then continue playing the game
                        goto DoneDrawing;
                    }
                }
                // no enemyTanks left so the player wins
                DrawText("YOU WIN!", 500, 300, 60, Color.GREEN);
            }

            DoneDrawing:
            EndDrawing();
        }

    }
}
