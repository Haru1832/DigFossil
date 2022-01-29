using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public void Dig(Tile tile)
    {
        tile.HP.Subtract(1);
    }
}
