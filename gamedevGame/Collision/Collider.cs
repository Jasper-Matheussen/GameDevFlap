using gamedevGame.Characters;
using gamedevGame.LevelDesign.LevelBlocks;
using gamedevGame.LevelDesign.Levels;
using gamedevGame.Sound;

namespace gamedevGame.Collision;

public class Collider
{
    public bool HasCollidedWithBlock(List<Block> blocks, Hero hero)
    {
        foreach (var block in blocks)
        {
            if (block != null)
            {
                if (hero.Hitbox.Intersects(block.BoundingBox))
                {
                    if (block.IsPortal && block.BoundingBox.Contains(hero.Hitbox))
                    {
                        return true;
                    }
                    
                    block.IsCollidedWithEvent(hero);
                }
                
            }
        }

        return false;
    }
    public void EnemyCollided(List<Character> enemyList, Hero hero, Vector2 heroStartPosition)
    {
        foreach (var enemy in enemyList.Where(enemy => enemy != null).Where(enemy => hero.Hitbox.Intersects(enemy.Hitbox)))
        {
            Game1.SoundManager.Play(Sounds.Hurt);
            hero.Position = heroStartPosition;
            hero.Health--;
        }
    }
}