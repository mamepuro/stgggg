using System;
namespace stgggg
{
    public class PlayerBullet:CollidableObject
    {
        asd.Vector2DF moveVelocity;
        public PlayerBullet(asd.Vector2DF position, float radiusMagnification = 1.0f) //radiusMagnificationで弾の半径の倍率を決定する　インスタンス生成時に引数がない場合1を代入する
        {
            Texture = asd.Engine.Graphics.CreateTexture2D("Resources/EnemyBullet.png");
            Position = position;
            moveVelocity = new asd.Vector2DF(10.0f, 0.0f);
            CenterPosition = new asd.Vector2DF(Texture.Size.X / 2.0f, Texture.Size.Y / 2.0f);
            radius = Texture.Size.X / 2.0f * radiusMagnification;
        }
        public void Move()
        {
            Position += moveVelocity;
        }
        public void DisposeBullet()
        {
            if(Position.X > (asd.Engine.WindowSize.X + Texture.Size.X / 2.0f) || Position.X < -Texture.Size.X / 2.0f || Position.Y > (asd.Engine.WindowSize.Y + Texture.Size.Y / 2.0f) || Position.Y < -Texture.Size.Y / 2.0f)
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
            DisposeBullet();
        }
    }
}
