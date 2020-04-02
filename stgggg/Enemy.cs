using System;
namespace stgggg
{
    public class Enemy:CollidableObject
    {
        asd.Vector2DF position;
        asd.Vector2DF moveVelocity;
        public Player playerInfo;
        public int fireBulletCounter;
        public Enemy(asd.Vector2DF position, Player player)
        {
            Texture = asd.Engine.Graphics.CreateTexture2D("Resources/Enemy.png");
            //position = new asd.Vector2DF(650.0f, 330.0f);
            Position = position;
            CenterPosition = new asd.Vector2DF(Texture.Size.X / 2.0f, Texture.Size.Y / 2.0f);
            moveVelocity = new asd.Vector2DF(0.0f, 3.0f);
            playerInfo = player;
            radius = Texture.Size.X / 2.0f;
            fireBulletCounter = 0;
        }
        public void Move()
        {
            position += moveVelocity;
            Position = position;
        }
        public void DisposeEnemy()
        {
            if(Position.X > asd.Engine.WindowSize.X || Position.Y > asd.Engine.WindowSize.Y)
            {
                Dispose();
            }
        }
        public void FireEnermyBullet()
        {
            asd.Vector2DF targetaVector = playerInfo.Position - Position;
            asd.Vector2DF aimVector = targetaVector.Normal * 1.5f;
            EnemyBullet enemyBullet = new EnemyBullet(Position, aimVector);
            asd.Engine.AddObject2D(enemyBullet);
        }
        public void JudgeFireEnemyBullet(int count)
        {
            if(count % 60 == 0 && playerInfo.IsAlive)
            {
                FireEnermyBullet();
            }
        }
        public override void OnCollided(CollidableObject collidableObject)
        {
            base.OnCollided(collidableObject);
            Dispose();
        }
        public override void CollideWithObject(CollidableObject collidableObject)
        {
            base.CollideWithObject(collidableObject);
            if(collidableObject == null)
            {
                return;
            }
            if(collidableObject is PlayerBullet)
            {
                CollidableObject playerbullet = collidableObject;
                if (IsCollide(playerbullet))
                {
                    OnCollided(playerbullet);
                    playerbullet.OnCollided(this);
                }
            }
        }
        protected override void OnUpdate()
        {
            base.OnUpdate();
            //Move();
            JudgeFireEnemyBullet(fireBulletCounter);
            DisposeEnemy();
            CheckCollision();
            fireBulletCounter += 1;
        }
    }
}
