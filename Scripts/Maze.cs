using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maze : MonoBehaviour {

    public int sizeX, sizeZ;
    public MazeCell cellPrefab;
    private MazeCell[,] cells;
    public float genStepDelay;


    // Use this for initialization
    void Start () {
		
	}
	public IEnumerator generate()
    {
        WaitForSeconds delay = new WaitForSeconds(genStepDelay);
        cells = new MazeCell[sizeX, sizeZ];
        for (int x = 0; x < sizeX; x++)
        {
            for (int z = 0; z < sizeZ; z++)
            {
                yield return delay;
                CreateCell(x, z);
            }
        }

    }

    private void CreateCell(int x, int z)
    {
        MazeCell newCell = Instantiate(cellPrefab) as MazeCell;
            cells[x, z] = newCell;
            newCell.name = "Maze Cell: x: " + x + " z: " + z;
            newCell.transform.parent = transform;
        newCell.transform.localPosition = new Vector3(x - sizeX * 0.5f + 0.5f, 0f, z - sizeZ * 0.5f + 0.5f);
    }
	// Update is called once per frame
	void Update () {
		
	}
}
