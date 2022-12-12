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
    private int iterations = 10;
    [SerializeField]
    public int walkLenght = 10;
    [SerializeField]
    public bool startRandomlyEachIteration = true;

    //De her er allerede i AbstractDungeonGenerator
    //[SerializeField]
    //private TilemapVisualizer tilemapVisualizer;

    protected override void RunProceduralGeneration()
    {
        // Her bruger vi tilemapVisualizer
        HashSet<Vector2Int> floorPosition = RunRandomWalk();
        //Her sletter vi det map der allerede er generetet så de ikke piler ovenpå hinanden
        tilemapVisualizer.Clear();
        //Her laver vi et nyt map
        tilemapVisualizer.PaintFloorTiles(floorPosition);
        
        //Her kan vi se de skridt der bliver taget i consollen)
        //foreach (var positions in floorPosition)
        //{
        //    Debug.Log(positions);
        //}
    }
    
    protected HashSet<Vector2Int> RunRandomWalk()
    {
        var currentPosition = startPosition;
        HashSet<Vector2Int> floorPositions = new HashSet<Vector2Int>();
        for (int i = 0; i < iterations; i++)
        {
            var path = ProceduralGenerationAlgorithms.SimpleRandomWalk(currentPosition, walkLenght);
            // Hashset lader os tilføje path fra SimpleRandomWalk til floorPositions
            floorPositions.UnionWith(path); //kopier path til floorPositions i Hashset uden duplicates

            //tilader at starte ny iteration på et tilfældigt sted i pathen
            if (startRandomlyEachIteration)
                currentPosition = floorPositions.ElementAt(Random.Range(0, floorPositions.Count));
        }
        return floorPositions;


        // så hver gang der bliver lavet en ny iteration så bliver positionen gemt i Hashsettet floorPositions.
        // Hvis StartRandomlyEachIteration er true så starter hver iteration et tilfældigt sted i pathen


        //HUSK ( Video 5 min 11:30 (få den til ikke at gentage skridt)

    }
}
