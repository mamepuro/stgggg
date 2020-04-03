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
            //StraightMoveEnemy straightMoveEnemy = new StraightMoveEnemy(new asd.Vector2DF(400.0f, 340.0f), new asd.Vector2DF(1.0f, 0.0f), playerInfo);
            BulletEnemy bulletEnemy = new BulletEnemy(new asd.Vector2DF(400.0f, 340.0f), new asd.Vector2DF(0.0f, 0.0f), playerInfo);
            layer.AddObject(bulletEnemy);
        }
        public void JudgeEnemySporn(int count)
        {
            if(count % 60 == 0)
            {
                Enemy enemy = new Enemy(new asd.Vector2DF(650.0f, 330.0f), playerInfo);
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
