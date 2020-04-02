using System;
using System.Collections.Generic;
using System.Linq;
namespace stgggg
{
    public class Player:CollidableObject
    {
        asd.Vector2DF position;
        asd.Vector2DF sideMoveVelocity;
        asd.Vector2DF verticalMoveVelocity;
        public  float chargeTime;
        public Player()
        {
            Texture = asd.Engine.Graphics.CreateTexture2D("Resources/player.png");
            position = new asd.Vector2DF(asd.Engine.WindowSize.X / 2.0f , asd.Engine.WindowSize.Y / 2.0f);
            Position = position;//Positionプロパティはフィールドを通して管理する。
            sideMoveVelocity = new asd.Vector2DF(3.0f, 0.0f);
            verticalMoveVelocity = new asd.Vector2DF(0.0f, 3.0f);
            chargeTime = 0.0f;
            CenterPosition = new asd.Vector2DF(Texture.Size.X / 2.0f, Texture.Size.Y / 2.0f);
            radius = Texture.Size.Y / 2.0f;
        }
        public void Move()
        {
            if(asd.Engine.Keyboard.GetKeyState(asd.Keys.Up) == asd.KeyState.Hold)
            {
                position -= verticalMoveVelocity;
            }
            if(asd.Engine.Keyboard.GetKeyState(asd.Keys.Down) == asd.KeyState.Hold)
            {
                position += verticalMoveVelocity;
            }
            if(asd.Engine.Keyboard.GetKeyState(asd.Keys.Left) == asd.KeyState.Hold)
            {
                position -= sideMoveVelocity;
            }
            if(asd.Engine.Keyboard.GetKeyState(asd.Keys.Right) == asd.KeyState.Hold)
            {
                position += sideMoveVelocity;
            }
            position.X = asd.MathHelper.Clamp(position.X, asd.Engine.WindowSize.X - Texture.Size.X, 0.0f);
            position.Y = asd.MathHelper.Clamp(position.Y, asd.Engine.WindowSize.Y - Texture.Size.Y, 0.0f);
            Position = position;
        }
        public void FireBullet()
        {
            if(asd.Engine.Keyboard.GetKeyState(asd.Keys.Space) == asd.KeyState.Push)
            {
                PlayerBullet playerBullet = new PlayerBullet(new asd.Vector2DF(position.X + Texture.Size.X + 10.0f, position.Y + Texture.Size.Y / 2.0f));
                asd.Engine.AddObject2D(playerBullet);
            }
        }
        public void FireChargeBullet()
        {
            if(asd.Engine.Keyboard.GetKeyState(asd.Keys.N) == asd.KeyState.Hold)
            {
                chargeTime += 0.2f;
                chargeTime = asd.MathHelper.Clamp(chargeTime, 60.0f, 0.0f);
            }
            if(asd.Engine.Keyboard.GetKeyState(asd.Keys.A) == asd.KeyState.Push && chargeTime > 0.0f)
            {
                PlayerBullet playerBullet = new PlayerBullet(new asd.Vector2DF(position.X + Texture.Size.X + 10.0f, position.Y + Texture.Size.Y / 2.0f), chargeTime);
                playerBullet.Scale = new asd.Vector2DF(chargeTime, chargeTime);
                asd.Engine.AddObject2D(playerBullet);
                chargeTime = 0.0f;
            }
        }
        public override void OnCollided(CollidableObject collidableObject)
        {
            base.OnCollided(collidableObject);
            Dispose();
        }
        public override void CollideWithObject(CollidableObject collidableObject)
        {
            if(collidableObject == null)
            {
                return;
            }
            if(collidableObject is Enemy)
            {
                CollidableObject enemy = collidableObject;//衝突したオブジェクトがEnemyである事を明示する
                if (IsCollide(enemy))
                {
                    OnCollided(enemy);
                }
            }
        }
        protected override void OnUpdate()
        {
            base.OnUpdate();
            Move();
            FireBullet();
            FireChargeBullet();
            CheckCollision();
        }
    }
}
