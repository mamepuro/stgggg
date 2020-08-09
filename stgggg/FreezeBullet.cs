using System;
namespace stgggg
{
    public class FreezeBullet:CollidableObject
    {
        asd.Vector2DF moveVector;
        public FreezeBullet(asd.Vector2DF position, asd.Vector2DF moveVector)
        {
            Texture = asd.Engine.Graphics.CreateTexture2D("Resources/FreezeBullet.png");
            Position = position;
            this.moveVector = moveVector;
            CenterPosition = new asd.Vector2DF(Texture.Size.X / 2.0f, Texture.Size.Y / 2.0f);
            radius = Texture.Size.X / 2.0f;
        }
        public void Move()
        {
            Position += moveVector;
        }
        public void DisposeEnemyBullet()
        {
            if (Position.X > (asd.Engine.WindowSize.X + Texture.Size.X / 2.0f) || Position.X < -Texture.Size.X / 2.0f || Position.Y > (asd.Engine.WindowSize.Y + Texture.Size.Y / 2.0f) || Position.Y < -Texture.Size.Y / 2.0f)
            {
                Dispose();
            }
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
            DisposeEnemyBullet();
        }
}
}
