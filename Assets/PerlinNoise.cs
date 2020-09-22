using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerlinNoise
{
    long seed; //种子

    public PerlinNoise(long seed)
    {
        this.seed = seed;
    }

    //产生伪随机数
    private int random(int x,int range)
    {
        return (int)((x + seed) ^ 5) % range;
    }

    public int getNoise(int x,int range)
    {
        int chunkSize = 16; //振动频率，波长
        float noise = 0;
        range /= 2; //range/2 + range/4 + range/8+....
        while (chunkSize > 0)
        {
            int chunkIndex = x / chunkSize;

            float prog = (x % chunkSize) / (chunkSize * 1f);

            float left_random = random(chunkIndex, range);
            float right_random = random(chunkIndex+1, range);

            //生成噪点
            noise += (1 - prog) * left_random + prog * right_random;

        chunkSize /= 2;
        range /= 2;

        range = Mathf.Max(1, range);
    }
        //四舍五入
        return (int)Mathf.Round(noise);
    }

}
