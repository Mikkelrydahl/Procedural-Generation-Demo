using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class SimpleRandomWalkDungeonGenerator : AbstractDungeonGenerator
{
    //De her er allerede i AbstractDungeonGenerator
    //[SerializeField]
    //protected Vector2Int startPosition = Vector2Int.zero;

    [SerializeField]
    protected SimpleRandomWalkData randomWalkParameters;

    //De er blevet rykket til SimpleRandomWalkData
    //[SerializeField]
    //private int iterations = 10;
    //[SerializeField]
    //public int walkLenght = 10;
    //[SerializeField]
    //public bool startRandomlyEachIteration = true;

    //De her er allerede i AbstractDungeonGenerator
    //[SerializeField]
    //private TilemapVisualizer tilemapVisualizer;

    protected override void RunProceduralGeneration()
    {
        // Her bruger vi tilemapVisualizer
        HashSet<Vector2Int> floorPosition = RunRandomWalk(randomWalkParameters, startPosition);
        //Her sletter vi det map der allerede er generetet s? de ikke piler ovenp? hinanden
        tilemapVisualizer.Clear();
        //Her laver vi et nyt map
        tilemapVisualizer.PaintFloorTiles(floorPosition);
        //Her laver vi horisontale og vertikale v?gge
        WallGenerator.CreateWalls(floorPosition, tilemapVisualizer);
        
        //Her kan vi se de skridt der bliver taget i consollen)
        //foreach (var positions in floorPosition)
        //{
        //    Debug.Log(positions);
        //}
    }
    
    protected HashSet<Vector2Int> RunRandomWalk(SimpleRandomWalkData parameters, Vector2Int position)
    {
        var currentPosition = position;
        HashSet<Vector2Int> floorPositions = new HashSet<Vector2Int>();
        for (int i = 0; i < randomWalkParameters.iterations; i++)
        {
            var path = ProceduralGenerationAlgorithms.SimpleRandomWalk(currentPosition, randomWalkParameters.walkLength);
            floorPositions.UnionWith(path); 

            if (randomWalkParameters.startRandomlyEachIteration)
                currentPosition = floorPositions.ElementAt(Random.Range(0, floorPositions.Count));
        }
        return floorPositions;


        // s? hver gang der bliver lavet en ny iteration s? bliver positionen gemt i Hashsettet floorPositions.
        // Hvis StartRandomlyEachIteration er true s? starter hver iteration et tilf?ldigt sted i pathen


       

    }
}
