using VContainer;
using VContainer.Unity;

public class GameLifetimeScope : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        base.Configure(builder);

        builder.Register<IPlayerService, PlayerService>(Lifetime.Singleton);
        builder.Register<IEnemySpawner, EnemySpawner>(Lifetime.Singleton);
        builder.Register<IScoreService, ScoreService>(Lifetime.Singleton);
        
        builder.RegisterEntryPoint<GameManager>();
        builder.RegisterComponentInHierarchy<ScoreUI>();
        builder.RegisterComponentInHierarchy<InputHandler>();
    }
}
