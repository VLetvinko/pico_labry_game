using UnityEngine;

public class ObjProceduralSpawner : MonoBehaviour
{
    [SerializeField] public GameObject [] Cell;

    [SerializeField] private Vector3 CellSize = new Vector3(0, 0, 0);

    [SerializeField] private int rangeFrom = 10;
    [SerializeField] private int rangeTo = 15;

    private int width;
    private int heigh;

    [SerializeField] private BoxCollider CamBox;

    void Start()
    {
        width = Random.Range(rangeFrom+1, rangeTo+1);
        heigh = Random.Range(rangeFrom+1, rangeTo+1);

        Debug.Log(Cell.Length);
        int cellDesign = Random.Range(0, Cell.Length);

        ProceduralCreator creator = new ProceduralCreator();
        ProceduralCreatorCell[,] maze = creator.Create(width, heigh);

        for (int x = 0; x < maze.GetLength(0); x++)
        {
            for (int z = 0; z < maze.GetLength(1); z++)
            {
                Cell c = Instantiate(Cell[cellDesign], new Vector3(x * CellSize.x, 0, z * CellSize.z), Quaternion.identity).GetComponent<Cell>();

                c.wallTop.SetActive(maze[x, z].WallTop);
                c.wallBot.SetActive(maze[x, z].WallBot);
                c.Ground.SetActive(maze[x, z].ground);
                c.Finish.SetActive(maze[x, z].finish);
            }
        }
        spawnCamBox();
    }
    private void spawnCamBox()
    {
        float sizeBoxCollX = (18 * (width-1)) + 36;
        float sizeBoxCollZ = (18 * (heigh-1)) + 36;


        float moveBoxCoolX = (9f * (width-1))-9;
        float moveBoxCoolZ = (9f * (heigh-1))-9 ;

        CamBox = CamBox.GetComponent<BoxCollider>();

        CamBox.transform.position = new Vector3(moveBoxCoolX, 0, moveBoxCoolZ);
        CamBox.size = new Vector3(sizeBoxCollX, 1000, sizeBoxCollZ);
    }
}
