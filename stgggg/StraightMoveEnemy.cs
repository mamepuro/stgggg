using System;
namespace stgggg
{
    public class StraightMoveEnemy:Enemy
    {
        asd.Vector2DF moveVelocity;
        public StraightMoveEnemy(asd.Vector2DF position, asd.Vector2DF moveVelocity, Player player)
            :base(position, player)
        {
            this.moveVelocity = moveVelocity;
        }
    }
}
