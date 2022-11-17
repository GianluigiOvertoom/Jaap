using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class WallGenerator
{
    public static void CreateWalls(HashSet<Vector2Int> floorPosition, TileMapVisualizer tilemapVisualizer)
    {
        var basicWallPosition = FindWallsInDirections(floorPosition, Direction2D.cardirnalDirectionsList);
        foreach (var position in basicWallPosition)
        {
            tilemapVisualizer.PaintSingleBasicWall(position);
        }
    }

    private static HashSet<Vector2Int> FindWallsInDirections(HashSet<Vector2Int> floorPosition, List<Vector2Int> directionList)
    {
        HashSet<Vector2Int> wallPositions = new HashSet<Vector2Int>();
        foreach (var position in floorPosition)
        {
            foreach (var direction in directionList)
            {
                var neighbourPosition = position + direction;
                if(floorPosition.Contains(neighbourPosition) == false)
                {
                    wallPositions.Add(neighbourPosition);
                }
            }
        }
        return wallPositions;
    }
}
