using gamedevGame.Characters;
using gamedevGame.LevelDesign.LevelBlocks;
using gamedevGame.Sound;

namespace gamedevGame.Collision;

public static class Collider
{
    public static bool HasCollidedWithBlock(IEnumerable<Block> blocks, Hero hero)
    {
        foreach (var block in blocks.Where(block => block != null).Where(block => hero.Hitbox.Intersects(block.BoundingBox)))
        {
            if (block.IsPortal && block.BoundingBox.Contains(hero.Hitbox))
            {
                return true;
            }
                    
            block.IsCollidedWithEvent(hero);
        }

        return false;
    }
    public static void EnemyCollided(IEnumerable<Character> enemyList, Hero hero, Vector2 heroStartPosition)
    {
        foreach (var dummy in enemyList.Where(enemy => enemy != null).Where(enemy => hero.Hitbox.Intersects(enemy.Hitbox)))
        {
            Game1.SoundManager.Play(Sounds.Hurt);
            hero.Position = heroStartPosition;
            hero.Health--;
            hero.StartBlinking(7, Color.Red);
        }
    }
}