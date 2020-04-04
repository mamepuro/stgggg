using System;
namespace stgggg
{
    public class NomalEnemy:Enemy
    {
        asd.Vector2DF position;
        asd.Vector2DF moveVelocity;
        public int fireBulletCounter;
        public NomalEnemy(asd.Vector2DF position, asd.Vector2DF moveVelocity, Player player)
            :base(position,player)
        {
            this.position = position;
            this.moveVelocity = moveVelocity;
            fireBulletCounter = 0;
        }
        public override void Move()
        {
            base.Move();
            //moveVelocity = new asd.Vector2DF((float)Math.Sin(fireBulletCounter * 8 * Math.PI / 180.0f), 0);
            position += moveVelocity;
            Position = position;
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
            if (count % 60 == 0 && playerInfo.IsAlive)
            {
                FireEnermyBullet();
            }
        }
        protected override void OnUpdate()
        {
            base.OnUpdate();
            Move();
            JudgeFireEnemyBullet(fireBulletCounter);
            fireBulletCounter += 1;
        }
    }
}
