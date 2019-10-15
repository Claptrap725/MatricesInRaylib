using Raylib;
using rl = Raylib.Raylib;

namespace MaticesInRaylib
{
    static class Program
    {
        public static int Main()
        {
            // Initialization
            //--------------------------------------------------------------------------------------
            int screenWidth = 1280;
            int screenHeight = 720;

            rl.InitWindow(screenWidth, screenHeight, "I'm sure glad Unity does all this for me!");

            rl.SetTargetFPS(60);
            //--------------------------------------------------------------------------------------

            Game gameSession = new Game();
            gameSession.Init();

            // Main game loop
            while (!rl.WindowShouldClose())    // Detect window close button or ESC key
            {
                // Update
                //----------------------------------------------------------------------------------
                gameSession.Update();
                // TODO: Update your variables here
                //----------------------------------------------------------------------------------

                // Draw
                //----------------------------------------------------------------------------------
                
                gameSession.Draw();
                //----------------------------------------------------------------------------------
            }

            // De-Initialization
            //--------------------------------------------------------------------------------------
            rl.CloseWindow();        // Close window and OpenGL context
                                     //--------------------------------------------------------------------------------------

            return 0;
        }
    }
}
