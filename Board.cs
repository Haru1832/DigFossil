using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    [SerializeField] private Game game;

    public Game Game => game;

    // [SerializeField]
    // private Game m_Game;
    [SerializeField]
    private int m_Columns;
    [SerializeField]
    private int m_Rows;

    [SerializeField]
    private GameObject m_TilePrefab;

    //Not the fastest collection but easy to use.
    private List<Tile> m_TilesList;

    public Tile[,] boardTileArray2d
    {
        get { return GetTilesAs2dArray(); }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        GenerateBoard();
    }

    private void GenerateBoard()
    {
        m_TilesList = new List<Tile>();

        for (int i = 0; i < m_Columns; i++)
        {	
            for (int j = 0; j < m_Rows+1; j++)
            {
                float xPos = -(m_Columns/2f) + i + 0.5f;
                float yPos = -(m_Rows/2f) + j ;
                
                var newTileObject = GameObject.Instantiate(m_TilePrefab, new Vector3(xPos, 0, yPos), Quaternion.Euler(90,0,0));
                var newTile = newTileObject.GetComponent<Tile>();

                if (newTile != null)
                {
                    int random = Random.Range(0, 6);
                    newTile.Initialize(i, j,random,this);
                    m_TilesList.Add(newTile);
                }
            }
        }
    }
    
    private Tile[,] GetTilesAs2dArray()
    {
        Tile[,] boardTileArray2d = new Tile[m_Columns, m_Rows];

        for (int i = 0; i < m_TilesList.Count; i++)
        {
            var t = m_TilesList[i];
            boardTileArray2d[t.Column, t.Row] = t;
        }

        return boardTileArray2d;
    }
}
