using UnityEngine;
using System.Collections;

public class LevelCreator : MonoBehaviour {

    public Texture2D[] layers;
    public Transform[] blocks;
    public Color[] colourCodes;

    void Start()
    {
        for (int i = 0; i < layers.Length; i++)
        {
            LoadLayer(i);
        }
    }

    void LoadLayer(int layer)
    {
        Color[] blockColours = new Color[layers[layer].width * layers[layer].height];
        blockColours = layers[layer].GetPixels();

        for(int y = 0; y < layers[layer].height; y++)
        {
            for (int x = 0; x < layers[layer].width; x++)
            {
                for (int i = 0; i < blocks.Length; i++)
                {
                    if (blockColours[x + y * layers[layer].width] == colourCodes[i])
                    {
                        Instantiate(blocks[i], new Vector2(x, y), Quaternion.identity);
                    }
                }
            }
        }
    }

}
