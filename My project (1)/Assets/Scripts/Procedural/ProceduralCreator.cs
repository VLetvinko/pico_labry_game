using System.Collections.Generic;
using UnityEngine;

public class ProceduralCreatorCell : MonoBehaviour
{
    public int X;
    public int Z;

    public bool WallTop = true;
    public bool WallBot = true;
    public bool ground = true;
    public bool finish = false;

    public bool check = false;

    public int distance;
}

public class ProceduralCreator : MonoBehaviour
{

    public int width;
    public int heigh;

    public ProceduralCreatorCell[,] Create(int width, int heigh)
    {
        this.width = width;
        this.heigh = heigh;

        ProceduralCreatorCell[,] maze = new ProceduralCreatorCell[width, heigh];

        for (int x = 0; x < maze.GetLength(0); x++)
        {
            for (int z = 0; z < maze.GetLength(1); z++)
            {
                maze[x, z] = new ProceduralCreatorCell { X = x, Z = z };
            }

            maze[x, heigh - 1].WallTop = false;
            maze[x, maze.GetLength(1) - 1].ground = false;
        }

        for (int z = 0; z < maze.GetLength(1); z++)
        {
            maze[width - 1, z].WallBot = false;
            maze[maze.GetLength(0) - 1, z].ground = false;
        }

        RemoveWalls(maze);
        createFinish(maze);

        return maze;
    }

    [System.Obsolete]
    private void RemoveWalls(ProceduralCreatorCell[,] maze)
    {
        ProceduralCreatorCell current = maze[0, 0];

        current.check = true;
        current.distance = 0;

        Stack<ProceduralCreatorCell> stack = new Stack<ProceduralCreatorCell>();
        do
        {
            int x = current.X;
            int z = current.Z;

            List<ProceduralCreatorCell> checkedWalls = new List<ProceduralCreatorCell>();

            if (x > 0 && !maze[x - 1, z].check) checkedWalls.Add(maze[x - 1, z]);
            if (z > 0 && !maze[x, z - 1].check) checkedWalls.Add(maze[x, z - 1]);
            if (x < width - 2 && !maze[x + 1, z].check) checkedWalls.Add(maze[x + 1, z]);
            if (z < heigh - 2 && !maze[x, z + 1].check) checkedWalls.Add(maze[x, z + 1]);

            if (checkedWalls.Count > 0)
            {
                ProceduralCreatorCell chosen = checkedWalls[Random.RandomRange(0, checkedWalls.Count)];
                removeEdgeWall(current, chosen);
                chosen.check = true;
                stack.Push(chosen);
                current = chosen;
                chosen.distance = stack.Count;
            }
            else
            {
                current = stack.Pop();
            }

        } while (stack.Count > 0);
    }

    private void removeEdgeWall(ProceduralCreatorCell TopW, ProceduralCreatorCell BotW)
    {

        if (TopW.X == BotW.X)
        {
            if (TopW.Z > BotW.Z) TopW.WallBot = false;
            else BotW.WallBot = false;
        }
        else
        {
            if (TopW.X > BotW.X) TopW.WallTop = false;
            else BotW.WallTop = false;
        }
    }

    private void createFinish(ProceduralCreatorCell[,] maze)
    {
        ProceduralCreatorCell first = maze[0, 0];

        for (int x = 0; x < maze.GetLength(0); x++)
        {
            if (maze[x, heigh - 2].distance > first.distance) first = maze[x, heigh - 2];
            if (maze[x, 0].distance > first.distance) first = maze[x, 0];
        }

        for (int z = 0; z < maze.GetLength(1); z++)
        {
            if (maze[width - 2, z].distance > first.distance) first = maze[width - 2, z];
            if (maze[0, z].distance > first.distance) first = maze[0, z];
        }

        maze[first.X, first.Z].finish = true;
    }
}
