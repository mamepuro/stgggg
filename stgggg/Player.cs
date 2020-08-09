using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;

namespace stgggg
{
    public class Player:CollidableObject
    {
        asd.Vector2DF position;
        asd.Vector2DF sideMoveVelocity;
        asd.Vector2DF verticalMoveVelocity;
        public  float chargeTime;
        PlayersHealth playersHealth;
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
            playersHealth = PlayersHealth.Nomal;
        }
        public void Move()
        {
            if(asd.Engine.Keyboard.GetKeyState(asd.Keys.Up) == asd.KeyState.Hold && playersHealth == PlayersHealth.Nomal)
            {
                position -= verticalMoveVelocity;
            }
            if(asd.Engine.Keyboard.GetKeyState(asd.Keys.Down) == asd.KeyState.Hold && playersHealth == PlayersHealth.Nomal)
            {
                position += verticalMoveVelocity;
            }
            if(asd.Engine.Keyboard.GetKeyState(asd.Keys.Left) == asd.KeyState.Hold && playersHealth == PlayersHealth.Nomal)
            {
                position -= sideMoveVelocity;
            }
            if(asd.Engine.Keyboard.GetKeyState(asd.Keys.Right) == asd.KeyState.Hold && playersHealth == PlayersHealth.Nomal)
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
            if(collidableObject is FreezeBullet)
            {
                base.OnCollided(collidableObject);
                if(playersHealth == PlayersHealth.Nomal)
                {
                    this.playersHealth = PlayersHealth.Frozen;
                    Texture = asd.Engine.Graphics.CreateTexture2D("Resources/Frozenplayer.png");
                }
            }
            else
            {
                base.OnCollided(collidableObject);
                Dispose();
            }
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
            if(collidableObject is EnemyBullet)
            {
                CollidableObject enemyBullet = collidableObject;
                if (IsCollide(enemyBullet))
                {
                    OnCollided(enemyBullet);
                    enemyBullet.OnCollided(this);
                }
            }
            if(collidableObject is FreezeBullet)
            {
                CollidableObject freezeBullet = collidableObject;
                if (IsCollide(freezeBullet))
                {
                    OnCollided(freezeBullet);
                    freezeBullet.OnCollided(this);
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
