using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ProceduralGenerationAlgorithms
{

public static HashSet<Vector2Int> SimpleRandomWalk(Vector2Int startPosition, int walkLength)
    //Vector2Int representerer 2D positions
    {
        HashSet<Vector2Int> path = new HashSet<Vector2Int>();

        path.Add(startPosition);
        var previousposition = startPosition;

        for (int i = 0; i < walkLength; i++)
        {
            var newPosition = previousposition + Direction2D.GetRandomCardinalDirection();
            path.Add(newPosition);
            previousposition = newPosition;
        }
        return path;
    }

    // Bliver brugt til at g� i en tilf�ldig retning x antal skridt.
    // Vi bruger en List og ikke Hashset fordi List gemmer r�kkef�lgen af elementer
    public static List<Vector2Int> RandomWalkCorridor(Vector2Int startPosition, int corridorLength)
    {
        List<Vector2Int> corridor = new List<Vector2Int>();
        var direction = Direction2D.GetRandomCardinalDirection();
        var currentPosition = startPosition;
        for (int i = 0; i < corridorLength; i++)
        {
            currentPosition += direction;
            corridor.Add(currentPosition);
        }
        return corridor;
    }

    //BoundsInt laver en box mellem 2 punkter
    public static List<BoundsInt> BinarySpacePartitioning(BoundsInt spaceToSplit, int minWidth, int minHeight)
    {
        Queue<BoundsInt> roomsQueue = new Queue<BoundsInt>();
        List<BoundsInt> roomsList = new List<BoundsInt>();
        roomsQueue.Enqueue(spaceToSplit);
        while(roomsQueue.Count > 0)
        {
            var room = roomsQueue.Dequeue();
            if(room.size.y >= minHeight && room.size.x >= minWidth)
            {
                if(Random.value < 0.5f)
                {
                    if(room.size.y >= minHeight * 2)
                    {
                        SplitHorizontally(minWidth, minHeight, roomsQueue, room);
                    } else if(room.size.x >= minWidth * 2)
                    {
                        SplitVertically(minWidth, minHeight, roomsQueue, room);
                    }else if(room.size.x >= minWidth && room.size.y >= minHeight)
                    {
                        roomsList.Add(room);
                    }
                }
                else
                {
                    if (room.size.x >= minWidth * 2)
                    {
                        SplitVertically(minWidth, minHeight, roomsQueue, room);
                    }
                    if (room.size.y >= minHeight * 2)
                    {
                        SplitHorizontally(minWidth, minHeight, roomsQueue, room);
                    }
                    else if (room.size.x >= minWidth && room.size.y >= minHeight)
                    {
                        roomsList.Add(room);
                    }
                }
            }
        }
        return roomsList;
    }

    private static void SplitVertically(int minWidth, int minHeight, Queue<BoundsInt> roomsQueue, BoundsInt room)
    {
        throw new System.NotImplementedException();
    }

    private static void SplitHorizontally(int minWidth, int minHeight, Queue<BoundsInt> roomsQueue, BoundsInt room)
    {
        throw new System.NotImplementedException();
    }
}

public static class Direction2D
    //Direction2D laver directions
{
    public static List<Vector2Int> cardinalDirectionsList = new List<Vector2Int>
    {
        new Vector2Int(0,1), //UP
        new Vector2Int(1,0), //RIGHT
        new Vector2Int(0, -1), //DOWN
        new Vector2Int(-1,0) //LEFT
    };

    public static Vector2Int GetRandomCardinalDirection()
        // V�lger random Direction
    {
        return cardinalDirectionsList[Random.Range(0, cardinalDirectionsList.Count)];
    }
}