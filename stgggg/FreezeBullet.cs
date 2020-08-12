using System;
namespace stgggg
{
    public class FreezeBullet:EnemyBullet
    {
        asd.Vector2DF moveVector;
        public FreezeBullet(asd.Vector2DF position, asd.Vector2DF moveVector)
            :base(position)
        {
            Texture = asd.Engine.Graphics.CreateTexture2D("Resources/FreezeBullet.png");
            Position = position;
            this.moveVector = moveVector;
            CenterPosition = new asd.Vector2DF(Texture.Size.X / 2.0f, Texture.Size.Y / 2.0f);
            radius = Texture.Size.X / 2.0f;
        }
        protected override void Move()
        {
            Position += moveVector;
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
