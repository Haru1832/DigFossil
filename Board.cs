using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    [SerializeField] private Canvas canvas;
    
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
    
    [SerializeField] 
    private Item[] Items;

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
            for (int j = 0; j < m_Rows; j++)
            {
                float xPos = -(m_Columns/2f) + i + 0.5f;
                float yPos = -(m_Rows/2f) + j ;
                
                var newTileObject = GameObject.Instantiate(m_TilePrefab, new Vector3(xPos, 0, yPos), Quaternion.Euler(90,0,0));
                var newTile = newTileObject.GetComponent<Tile>();

                if (newTile != null)
                {
                    int random = Random.Range(1, 6);
                    newTile.Initialize(i, j,random,this);
                    m_TilesList.Add(newTile);
                }
            }
        }
        
        GenerateItems();
    }

    private void GenerateItems()
    {
        SetItems();

        void SetItems()
        {

            List<GameObject> itemImages=new List<GameObject>();
            
            foreach (Item item in Items)
            {
                var canColumns = m_Columns - item.width;
                var canRows = m_Rows - item.height;

                var column = Random.Range(0, canColumns);
                var row = Random.Range(0, canRows);

                float xPos = -(m_Columns/2f) + column + (item.width/2f) ;
                float yPos = -(m_Rows/2f) + row + (item.height/2f)-0.5f;
                
                var itemImage = Instantiate(item.gameObject, new Vector3(xPos, 0, yPos), Quaternion.Euler(90,0,0),canvas.transform);

                itemImages.Add(itemImage);
                
                var tiles = boardTileArray2d;

                for (int i = 0; i < item.width; i++)
                {
                    for (int j = 0; j < item.height; j++)
                    {
                        var m_tile = tiles[column + i, row + j];
                        if (m_tile.isUnderItem || m_tile ==null)
                        {
                            foreach (var _tile in tiles)
                            {
                                _tile.isUnderItem = false;
                            }

                            foreach (var image in itemImages)
                            {
                                Destroy(image);
                            }
                            itemImages.Clear();
                            SetItems();
                            return;
                        }
                        else
                        {
                            m_tile.isUnderItem = true;
                        }

                    }
                }
            }
        }
        //テスト用
        // var _tiles = boardTileArray2d;
        //
        // foreach (var _tile in _tiles)
        // {
        //     if(_tile.isUnderItem)
        //         _tile.gameObject.SetActive(false);
        // }
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
