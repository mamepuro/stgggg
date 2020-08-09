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
            NomalEnemy nomalEnemy= new NomalEnemy(new asd.Vector2DF(400.0f, 340.0f), new asd.Vector2DF(0.0f, 0.0f), playerInfo);
            //WavyAttackEnemy wavyAttackEnemy = new WavyAttackEnemy(new asd.Vector2DF(400.0f, 340.0f), new asd.Vector2DF(0.0f, 0.0f), playerInfo);
            //ReciprocateEnemy reciprocateEnemy = new ReciprocateEnemy(new asd.Vector2DF(400.0f, 340.0f), new asd.Vector2DF(0.0f, 0.0f), playerInfo);
            layer.AddObject(nomalEnemy);
            asd.Font font = asd.Engine.Graphics.CreateDynamicFont("", 24, new asd.Color(255, 255, 255), 1, new asd.Color(255, 255, 255));
            asd.TextObject2D textObject = new asd.TextObject2D();
            textObject.Font = font;
            textObject.Text = "おやすみなさい";
            textObject.Position = new asd.Vector2DF(255, 255);
            //layer.AddObject(textObject);
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
