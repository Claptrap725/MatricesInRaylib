using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using Raylib;
using static Raylib.Raylib;


namespace MaticesInRaylib
{
    class Game
    {
        /// <summary>
        /// Stores all parent GameObjects so they can be updated
        /// </summary>
        public static List<GameObject> gameObjects = new List<GameObject>();
        /// <summary>
        /// When a players bullet collides with these it will harm the enemy
        /// </summary>
        public static List<Sprite> targets = new List<Sprite>();
        /// <summary>
        /// All Textures that are currently loaded in the Game. Used to optimize memory usage when reusing textures.
        /// </summary>
        public static Dictionary<string, Texture2D> textures = new Dictionary<string, Texture2D>();
        Stopwatch stopwatch = new Stopwatch();

        private long currentTime = 0;
        private long lastTime = 0;

        private float timer = 0;
        private int fps = 1;
        private int frames;

        private float deltaTime = 0.005f;
        
        Tank tank = new Tank();
        Sprite enemy = new Sprite();

        public void Init()
        {
            stopwatch.Start();
            lastTime = stopwatch.ElapsedMilliseconds;
            gameObjects.Add(enemy);
            enemy.Load("tankBlue.png");
            //enemy.image.SetRotate(90 * (float)(Math.PI / 180));
            enemy.image.SetPosition(570, 100);
            enemy.collider = new AABB();
            targets.Add(enemy);
        }

        public void Shutdown()
        {

        }

        public void Update()
        {
            currentTime = stopwatch.ElapsedMilliseconds;
            deltaTime = (currentTime - lastTime) / 1000.0f;
            timer += deltaTime;

            if (timer >= 1)
            {
                fps = frames;
                frames = 0;
                timer -= 1;
            }

            frames++;

            for (int i = 0; i < gameObjects.Count; i++)
            {
                gameObjects[i].Update(deltaTime);
            }

            lastTime = currentTime;
        }


        public void Draw()
        {
            BeginDrawing();

            ClearBackground(Color.WHITE);
            DrawText(fps.ToString(), 10, 10, 12, Color.RED);

            for (int i = 0; i < gameObjects.Count; i++)
            {
                gameObjects[i].Draw();
            }

            //DrawRectangleLines(GetScreenWidth()/2, GetScreenHeight()/2, 100, 100, Color.DARKBROWN);
            //DrawCircle(GetScreenWidth()/2, GetScreenHeight()/2, 10, Color.GOLD);

            EndDrawing();
        }

    }
}
