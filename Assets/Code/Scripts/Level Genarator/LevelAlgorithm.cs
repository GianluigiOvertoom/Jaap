using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelAlgorithm
{
    public static HashSet<Vector2Int> SimpleRandomWalk(Vector2Int startPosition, int walkLength)
    {
        HashSet<Vector2Int> path = new HashSet<Vector2Int>();

        path.Add(startPosition);
        var previousPosition = startPosition;

        for (int i = 0; i < walkLength; i++)
        {
            var newPosition = previousPosition + Direction2D.GetRandomCardirnalDirection();
            path.Add(newPosition);
            previousPosition = newPosition;
        }
        return path;
    }
}

public static class Direction2D
{
    public static List<Vector2Int> cardirnalDirectionsList = new List<Vector2Int>
    {
        new Vector2Int(0,1),
        new Vector2Int(1,0),
        new Vector2Int(0,-1),
        new Vector2Int(-1,0)
    };

    public static Vector2Int GetRandomCardirnalDirection()
    {
        return cardirnalDirectionsList[Random.Range(0, cardirnalDirectionsList.Count)];
    }
}
