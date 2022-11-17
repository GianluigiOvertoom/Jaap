using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class WallGenerator
{
    public static void CreateWalls(HashSet<Vector2Int> floorPositions, TileMapVisualizer tilemapVisualizer)
    {
        var basicWallPosition = FindWallsInDirections(floorPositions, Direction2D.cardirnalDirectionsList);
        var cornerWallPosition = FindWallsInDirections(floorPositions, Direction2D.diagonalDirectionsList);
        CreateBasicWall(tilemapVisualizer, basicWallPosition, floorPositions);
        CreateCornerWall(tilemapVisualizer, cornerWallPosition, floorPositions);
    }

    private static void CreateCornerWall(TileMapVisualizer tilemapVisualizer, HashSet<Vector2Int> cornerWallPosition, HashSet<Vector2Int> floorPositions)
    {
        foreach (var position in cornerWallPosition)
        {
            string neighboursBinaryType = "";

            foreach (var direction in Direction2D.eightDirectionsList)
            {
                var neighbourPosition = position + direction;

                if (floorPositions.Contains(neighbourPosition))
                {
                    neighboursBinaryType += "1";
                }
                else
                {
                    neighboursBinaryType += "0";
                }
            }

            tilemapVisualizer.PaintSingleCornerWall(position, neighboursBinaryType);
        }
    }

    private static void CreateBasicWall(TileMapVisualizer tilemapVisualizer, HashSet<Vector2Int> basicWallPosition, HashSet<Vector2Int> floorPositions)
    {
        foreach (var position in basicWallPosition)
        {
            string neighboursBinaryType = "";

            foreach (var direction in Direction2D.cardirnalDirectionsList)
            {
                var neighbourPosition = position + direction;

                if (floorPositions.Contains(neighbourPosition))
                {
                    neighboursBinaryType += "1";
                }
                else
                {
                    neighboursBinaryType += "0";
                }
            }

            tilemapVisualizer.PaintSingleBasicWall(position, neighboursBinaryType);
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
