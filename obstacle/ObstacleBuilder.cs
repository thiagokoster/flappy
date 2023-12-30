using System;
using Godot;

namespace Flappy;

class ObstacleBuilder
{
    private readonly PackedScene _obstacleScene;
    private Node2D _top = null;
    private Node2D _bottom = null;

    public ObstacleBuilder(PackedScene obstacleScene)
    {
        _obstacleScene = obstacleScene;
    }

    public Node2D Build()
    {

        // Add root of the obstacle
        var obstacle = new Node2D();

        if (_top is not null)
            obstacle.AddChild(_top);
        if (_bottom is not null)
            obstacle.AddChild(_bottom);

        _top = null;
        _bottom = null;

        return obstacle;
    }

    public ObstacleBuilder AddTop(float gap)
    {
        //TODO: Get scene from an obstacle pool instead of instantiate 1 by 1.
        _top = _obstacleScene.Instantiate() as Node2D;
        _top.Rotate(MathF.PI);

        _top.Position += Vector2.Up * gap;
        return this;
    }

    public ObstacleBuilder AddBottom()
    {
        //TODO: Get scene from an obstacle pool instead of instantiate 1 by 1.
        _bottom = _obstacleScene.Instantiate() as Node2D;
        return this;
    }
}
