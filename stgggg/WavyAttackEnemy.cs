using System;
namespace stgggg
{
    public class WavyAttackEnemy:Enemy
    {
        asd.Vector2DF moveVelocity;
        public int waveAttackCount;
        public WavyAttackEnemy(asd.Vector2DF position, asd.Vector2DF moveVelocity, Player player)
            :base(position,player)
        {
            this.moveVelocity = moveVelocity;
            waveAttackCount = 0;
        }
        public override void Move()
        {
            base.Move();
            Position += moveVelocity;
        }
        public void WaveAttackShot(float degree)
        {
            asd.Vector2DF dirVector = new asd.Vector2DF(1.0f, 0.0f);
            dirVector.Degree = degree;
            //EnemyBullet enemyBullet = new EnemyBullet(Position, dirVector);
            NomalEnemyBullet nomalEnemyBullet = new NomalEnemyBullet(Position, dirVector);
            asd.Engine.AddObject2D(nomalEnemyBullet);
        }
        public void JudgeWaveAttackshot(int count)
        {
            if(count % 4 == 0)
            {
                WaveAttackShot(count * 4);
            }
        }
        protected override void OnUpdate()
        {
            base.OnUpdate();
            JudgeWaveAttackshot(waveAttackCount);
            waveAttackCount += 1;
        }
    }
}
