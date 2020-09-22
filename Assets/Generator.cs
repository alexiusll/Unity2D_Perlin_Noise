using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    //污预置件
    public GameObject dirtPerfab;
    public GameObject caoPerfab;


    int minX = -32;
    int maxX = 32;
    int minY = -10;
    int maxY = 10;

    PerlinNoise noise;

    void Start()
    {
        noise = new PerlinNoise(Random.Range(100000,10000000));
        Regenerate();
    }

    void Update()
    {

    }

    private void Regenerate()
    {
        float width = dirtPerfab.transform.lossyScale.x;
        float height = dirtPerfab.transform.lossyScale.y;


        for (int i = minX; i < maxX ; i++) //x值
        {
            int columnHeight = 2 + noise.getNoise(i - minX,maxY - minY -2);
            for (int j = minY; j < minY + columnHeight; j++) //y值
            {
                GameObject block = (j == minY + columnHeight - 1) ? caoPerfab : dirtPerfab;
                Instantiate(block, new Vector2(i * width , j * height) , Quaternion.identity);
            }
        }
    }
}
