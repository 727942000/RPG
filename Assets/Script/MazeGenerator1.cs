using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    public int width = 11;  // 迷宫宽度
    public int height = 11; // 迷宫高度
    public GameObject wallPrefab;  // 墙壁预制体
    public GameObject floorPrefab; // 地板预制体

    private Transform mazeHolder;

    private void Start()
    {
        mazeHolder = new GameObject("Maze").transform;
        GenerateMaze();
        string maze = 
"1111111111111111111110101010101010101010101111111110111111011010111110101101110110101010101010101010101111111111110111011010111111111101110110101010101010101010101111110111111111011011110101111111110110111011011111111101101010101010101010101011111111111111100110111011111111111001101010101010101010101011111111111111100110111011111111111001101010101010101010101011111111111111110111111111111111111111";


    }

    private void GenerateMaze()
    {
        bool[,] visited = new bool[width, height];
        List<Vector2> frontier = new List<Vector2>();

        // 初始化迷宫
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                visited[x, y] = false;

                if (x % 2 == 0 && y % 2 == 0)
                {
                    Instantiate(floorPrefab, new Vector3(x, 0, y), Quaternion.identity, mazeHolder);
                }
                else
                {
                    Instantiate(wallPrefab, new Vector3(x, 0, y), Quaternion.identity, mazeHolder);
                }
            }
        }

        // 从随机点开始
        Vector2 start = new Vector2(UnityEngine.Random.Range(0, width / 2) * 2, UnityEngine.Random.Range(0, height / 2) * 2);
        visited[(int)start.x, (int)start.y] = true;
        frontier.Add(start);

        while (frontier.Count > 0)
        {
            int randomIndex = UnityEngine.Random.Range(0, frontier.Count);
            Vector2 current = frontier[randomIndex];
            frontier.RemoveAt(randomIndex);

            List<Vector2> neighbors = GetNeighbors(current);

            foreach (Vector2 neighbor in neighbors)
            {
                int nx = (int)neighbor.x;
                int ny = (int)neighbor.y;

                if (!visited[nx, ny])
                {
                    visited[nx, ny] = true;
                    frontier.Add(neighbor);

                    Vector2 wall = (current + neighbor) / 2;
                    Instantiate(floorPrefab, new Vector3(nx, 0, ny), Quaternion.identity, mazeHolder);
                    Instantiate(floorPrefab, new Vector3(wall.x, 0, wall.y), Quaternion.identity, mazeHolder);
                }
            }
        }
    }

    private List<Vector2> GetNeighbors(Vector2 pos)
    {
        int x = (int)pos.x;
        int y = (int)pos.y;
        List<Vector2> neighbors = new List<Vector2>();

        if (x >= 2) neighbors.Add(new Vector2(x - 2, y));
        if (x < width - 2) neighbors.Add(new Vector2(x + 2, y));
        if (y >= 2) neighbors.Add(new Vector2(x, y - 2));
        if (y < height - 2) neighbors.Add(new Vector2(x, y + 2));

        return neighbors;
    }
}
