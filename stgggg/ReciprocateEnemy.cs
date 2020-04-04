using System;
namespace stgggg
{
    public class ReciprocateEnemy:Enemy
    {
        asd.Vector2DF moveVelocity;
        int count;
        public ReciprocateEnemy(asd.Vector2DF position, asd.Vector2DF moveVelocity, Player player)
            :base(position, player)
        {
            this.moveVelocity = moveVelocity;
            count = 0;
        }
        public override void Move()
        {
            base.Move();
            moveVelocity = new asd.Vector2DF((float)Math.Sin(count * 8 * Math.PI / 180.0f) * 5.0f, 0.0f);
            Position += moveVelocity;
        }
        protected override void OnUpdate()
        {
            base.OnUpdate();
            Move();
            count += 1;
        }
    }
}
