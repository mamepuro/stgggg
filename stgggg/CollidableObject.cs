using System;
namespace stgggg
{
    public class CollidableObject:asd.TextureObject2D
    {
        public float radius = 0.0f;
        public CollidableObject()
        {
        }
        public bool IsCollide(CollidableObject collidableObject)
        {
            return (collidableObject.Position - this.Position).Length < radius + collidableObject.radius;
        }
        public virtual void OnCollided(CollidableObject collidableObject)
        {
            //継承先で定義する
        }
        public virtual void CollideWithObject(CollidableObject collidableObject)
        {

        }
        public void CheckCollision()
        {
            foreach(var obj in Layer.Objects)
            {
                CollideWithObject(obj as CollidableObject);
            }
        }
    }
}
