//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class MazeGenera : MonoBehaviour
//{
//    public int width = 10;
//    public int height = 10;
//    public GameObject wallPrefab;

//    private Transform mazeHolder;
//    private int[,] maze;
//    private List<Vector2> visitedCells;

//    private void Start()
//    {
//        mazeHolder = new GameObject("Maze").transform;
//        maze = new int[width, height];
//        visitedCells = new List<Vector2>();

//        GenerateMaze(new Vector2(0, 0));
//    }

//    private void GenerateMaze(Vector2 cell)
//    {
//        visitedCells.Add(cell);
//        maze[(int)cell.x, (int)cell.y] = 1; // Mark the cell as visited

//        // Possible movement directions (up, down, left, right)
//        Vector2[] directions = new Vector2[]
//        {
//            Vector2.up,
//            Vector2.down,
//            Vector2.left,
//            Vector2.right
//        };

//        // Shuffle the directions randomly
//        ShuffleArray(directions);

//        foreach (Vector2 dir in directions)
//        {
//            Vector2 nextCell = cell + dir * 2;

//            if (IsInsideMaze(nextCell) && !visitedCells.Contains(nextCell))
//            {
//                // Remove the wall between current cell and next cell
//                Vector2 wallPosition = cell + dir;
//                Instantiate(wallPrefab, wallPosition, Quaternion.identity, mazeHolder);
//                GenerateMaze(nextCell);
//            }
//        }
//    }

//    private bool IsInsideMaze(Vector2 cell)
//    {
//        return cell.x >= 0 && cell.x < width && cell.y >= 0 && cell.y < height;
//    }

//    private void ShuffleArray(Vector2[] arr)
//    {
//        for (int i = 0; i < arr.Length; i++)
//        {
//            int randomIndex = Random.Range(i, arr.Length);
//            Vector2 temp = arr[i];
//            arr[i] = arr[randomIndex];
//            arr[randomIndex] = temp;
//        }
//    }
//}
