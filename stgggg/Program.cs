using System;

namespace stgggg
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            asd.Engine.Initialize("test", 800, 500, new asd.EngineOption());
            GameScene gameScene = new GameScene();
            asd.Engine.ChangeSceneWithTransition(gameScene, new asd.TransitionFade(0, 1.0f));
            while (asd.Engine.DoEvents())
            {
                asd.Engine.Update();
            }
            asd.Engine.Terminate();
        }
    }
}
