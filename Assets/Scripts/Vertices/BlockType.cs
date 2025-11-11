using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BlockType
{
    Air,
    Grass,
    Dirt,
    Stone,
    Bedrock,
    Wood,
    Leaf,
    Water,
    Sand,
    CoalOre,
    IronOre,
    GoldOre,
    DiamondOre
}

[System.Serializable]
public class BlockData
{
    public BlockType blocktype;
    public Color blockcolor;
    public bool isSolid;

    public BlockData(BlockType type)
    {
        blocktype = type;
        isSolid = type !=  BlockType.Air;

        switch (type)
        {
            case BlockType.Grass:
                blockcolor = new Color(0.2f, 0.8f, 0.2f);
                break;
            case BlockType.Dirt:
                blockcolor = new Color(0.6f, 0.4f, 0.2f);
                break;
            case BlockType.Stone:
                blockcolor = new Color(0.5f, 0.5f, 0.5f);
                break;
            case BlockType.Bedrock:
                blockcolor = new Color(0.2f, 0.2f, 0.2f);
                break;
            case BlockType.Wood:
                blockcolor = new Color(0.6f, 0.3f, 0.1f);
                break;
            case BlockType.Leaf:
                blockcolor = new Color(0.1f, 0.6f, 0.1f);
                break;
            case BlockType.Water:
                blockcolor = new Color(0.2f, 0.4f, 0.9f);
                break;
            case BlockType.Sand:
                blockcolor = new Color(0.9f, 0.85f, 0.6f);
                break;
            case BlockType.CoalOre:
                blockcolor = new Color(0.3f, 0.3f, 0.3f);
                break;
            case BlockType.IronOre:
                blockcolor = new Color(0.7f, 0.6f, 0.5f);
                break;
            case BlockType.GoldOre:
                blockcolor = new Color(0.9f, 0.8f, 0.2f);
                break;
            case BlockType.DiamondOre:
                blockcolor = new Color(0.3f, 0.8f, 0.9f);
                break;
            default:
                blockcolor = Color.clear;
                isSolid = false;
                break;
        }
    }
}
