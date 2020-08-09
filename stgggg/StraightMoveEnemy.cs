using System;
namespace stgggg
{
    public class StraightMoveEnemy:Enemy
    {
        asd.Vector2DF moveVelocity;
        public float count;
        public StraightMoveEnemy(asd.Vector2DF position, asd.Vector2DF moveVelocity, Player player)
            :base(position, player)
        {
            this.moveVelocity = moveVelocity;
            count = 0;
        }
        public asd.Vector2DF CalculateMovePosition(Player player)
        {
            return (player.Position - this.Position).Normal * 3.0f; 
        }
        public void Rush()
        {
            if(count % 120 == 0)
            {
                moveVelocity = CalculateMovePosition(playerInfo);
            }
            else if(count % 120 >= 60)
            {
                Position += moveVelocity;
            }
        }
        protected override void OnUpdate()
        {
            base.OnUpdate();
            Rush();
            count += 1.0f;
        }
    }
}
