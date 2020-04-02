using System;
namespace stgggg
{
    public class GameScene:asd.Scene
    {
        int enemySpornCount;
        Player playerInfo;
        Enemy enemyInfo;
        public GameScene()
        {
        }
        protected override void OnRegistered()
        {
            base.OnRegistered();
            asd.Layer2D layer = new asd.Layer2D();
            AddLayer(layer);
            //asd.TextureObject2D background = new asd.TextureObject2D();
            //background.Texture = asd.Engine.Graphics.CreateTexture2D("Resources/Title.png");
            //layer.AddObject(background);
            Player player = new Player();
            playerInfo = player;
            layer.AddObject(player);
            enemySpornCount = 0;
            Enemy enemy = new Enemy(playerInfo);
            layer.AddObject(enemy);
        }
        public void JudgeEnemySporn(int count)
        {
            if(count % 60 == 0)
            {
                Enemy enemy = new Enemy(playerInfo);
                enemyInfo = enemy;
                asd.Engine.AddObject2D(enemy);
            }
        }
        protected override void OnUpdated()
        {
            base.OnUpdated();
            //JudgeEnemySporn(enemySpornCount);
            Console.WriteLine(enemySpornCount);
            enemySpornCount += 1;
        }
    }
}
