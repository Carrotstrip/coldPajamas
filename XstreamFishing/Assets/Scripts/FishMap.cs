using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FishMap : MonoBehaviour
{
    int[,] fishCountArray;
    GameObject[,] fishCubes;
    public int arrSize = 10;
    public GameObject FishCube;
    Gradient gradient;
    GradientColorKey[] colorKey;
    GradientAlphaKey[] alphaKey;

    public int chanceSize = 30;
    public int num_start_fish = 0;
    bool eating;
    int fish_eaten;

    // Start is called before the first frame update
    void Start()
    {
        eating = false;
        fish_eaten = 0;
        gradient = new Gradient();

        // Populate the color keys at the relative time 0 and 1 (0 and 100%)
        colorKey = new GradientColorKey[2];
        colorKey[0].color = Color.black;
        colorKey[0].time = 0.0f;
        colorKey[1].color = new Color(3f / 256f, 252f / 256f, 232f / 256f, 1);
        colorKey[1].time = 1.0f;

        // Populate the alpha  keys at relative time 0 and 1  (0 and 100%)
        alphaKey = new GradientAlphaKey[2];
        alphaKey[0].alpha = 1.0f;
        alphaKey[0].time = 0.0f;
        alphaKey[1].alpha = 0.0f;
        alphaKey[1].time = 1.0f;

        gradient.SetKeys(colorKey, alphaKey);

        fishCountArray = new int[arrSize, arrSize];
        fishCubes = new GameObject[arrSize, arrSize];
        for (int i = 0; i < arrSize; ++i)
        {
            for (int j = 0; j < arrSize; ++j)
            {
                fishCountArray[i, j] = num_start_fish;
                // instantiate a fish cube on each tile
                fishCubes[i, j] = GameObject.Instantiate(FishCube, new Vector3(i * 75 - 340, 0, j * 75 - 340), Quaternion.identity);
                Material mat = fishCubes[i, j].GetComponent<MeshRenderer>().materials[0];
                mat.color = gradient.Evaluate(0.1f * num_start_fish);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        int i = Random.Range(0, arrSize);
        int j = Random.Range(0, arrSize);
        int chance = Random.Range(0, chanceSize);
        if (chance == 0)
        {
            ++fishCountArray[i, j];
            // update color of tile
            Material mat = fishCubes[i, j].GetComponent<MeshRenderer>().materials[0];
            mat.color = gradient.Evaluate(0.1f * fishCountArray[i, j]);
        }

        // eat three fish, then move
        if (!eating)
        {
            eating = true;
            StartCoroutine(EatFish());
        }
    }

    IEnumerator EatFish()
    {
        yield return new WaitForSeconds(1f);
        eating = false;
    }

    public int getFishCount(int x, int y)
    {
        return fishCountArray[x, y];
    }

    public void decrementFish(int x, int y)
    {
        --fishCountArray[x, y];
        Material mat = fishCubes[x, y].GetComponent<MeshRenderer>().materials[0];
        mat.color = gradient.Evaluate(0.1f * fishCountArray[x, y]);
        return;
    }
}
