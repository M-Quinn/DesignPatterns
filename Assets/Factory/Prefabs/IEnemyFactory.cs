
namespace DesignPatterns.Factory
{
    public interface IEnemyFactory
    {
        public Enemy CreateEnemy(EnemyType type);
    }
}
