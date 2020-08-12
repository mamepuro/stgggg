using System;
namespace stgggg
{
    public class NomalEnemyBullet:EnemyBullet
    {
        public asd.Vector2DF _moveVelocity;
        public NomalEnemyBullet(asd.Vector2DF position, asd.Vector2DF moveVelocity)
            :base(position)
        {
            Texture = asd.Engine.Graphics.CreateTexture2D("Resources/EnemyBullet.png");
            Position = position;
            _moveVelocity = moveVelocity;
            CenterPosition = new asd.Vector2DF(Texture.Size.X / 2.0f, Texture.Size.Y / 2.0f);
            radius = Texture.Size.X / 2.0f;
        }
        protected override void Move()
        {
            Position += _moveVelocity;
        }
        public override void OnCollided(CollidableObject collidableObject)
        {
            base.OnCollided(collidableObject);
            Dispose();
        }
        protected override void OnUpdate()
        {
            base.OnUpdate();
            Move();
        }
    }
}
