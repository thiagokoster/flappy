using Godot;

namespace Flappy;

public partial class ObstacleSpawner : Node
{
    [Export]
    private PackedScene _obstacleScene;

    [Export]
    private Node2D _spawnLocation;

    [Export]
    private Node _level;
    private Timer timer;

    private ObstacleBuilder _obstacleBuilder;
    private RandomNumberGenerator _numberGenerator;

    private float _maxWait = 3;
    private float _minWait = 0.5f;
    private float _positionVariation = 40;

    public override void _Ready()
    {
        _numberGenerator = new RandomNumberGenerator
        {
            Seed = "Flappy".Hash() // Setting hashing so retries are the same.
        };

        timer = GetNode<Timer>("Timer");
        timer.Timeout += OnTimeout;


        _obstacleBuilder = new ObstacleBuilder(_obstacleScene);
    }


    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);

    }

    private void OnTimeout()
    {
        SpawnObstacle();
    }

    private void SpawnObstacle()
    {
        // Restarts the timer with a randon value;
        var timeout = _numberGenerator.RandfRange(_minWait,_maxWait);
        GD.Print($"New obstacule in {timeout} seconds...");
        timer.Start(timeout);

        var obstacleBuilder = _obstacleBuilder.AddBottom();

        // Add Top or not
        if (_numberGenerator.Randi() % 2 == 0)
        {
            obstacleBuilder.AddTop(120f);
        }

        var obstacle = obstacleBuilder.Build();

        // Changes vertical position
        var positionDiff = _numberGenerator.RandfRange(-_positionVariation, _positionVariation);
        obstacle.Position = _spawnLocation.Position + Vector2.Up * positionDiff;
        _level.AddChild(obstacle);
    }

}