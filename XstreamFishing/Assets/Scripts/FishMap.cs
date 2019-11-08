using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FishMap : MonoBehaviour
{
    int[,] fishCountArray;
    public int arrSize = 10;

    public int chanceSize = 30;
    // Start is called before the first frame update
    void Start()
    {
        fishCountArray = new int[arrSize, arrSize];
        for(int i = 0; i < arrSize;++i){
            for(int j = 0; j < arrSize;++j){
                fishCountArray[i,j] = 5; 
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
       int i = Random.Range(0, arrSize);
       int j = Random.Range(0, arrSize);
       int chance = Random.Range(0,chanceSize);
       if (chance == 0){
           ++fishCountArray[i,j];
       }
    }
    public int getFishCount(int x, int y){
        return fishCountArray[x,y];
    }

    public void decrementFish(int x, int y){
        --fishCountArray[x,y];
        return;
    }
}
