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
    public Vector2 shark_pos;
    public bool freeze_shark;

    // Start is called before the first frame update
    void Start()
    {
        freeze_shark = false;
        shark_pos = new Vector2(0, 0);
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
                mat.color = gradient.Evaluate(0.2f * num_start_fish);
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
            if (getFishCount(i, j) < 5)
                ++fishCountArray[i, j];
            // update color of tile
            Material mat = fishCubes[i, j].GetComponent<MeshRenderer>().materials[0];
            mat.color = gradient.Evaluate(0.2f * fishCountArray[i, j]);
        }

        // eat three fish, then move
        if (!eating)
        {
            // if shark has eaten 3 fish, move one tile
            if (numFish((int)shark_pos.x, (int)shark_pos.y) <= 0 && !freeze_shark)
            {

                fish_eaten = 0;
                DecideMove();
            }
            eating = true;
            // Debug.Log("eating a fish at " + (int)shark_pos.x + ", " + (int)shark_pos.y);
            decrementFish((int)shark_pos.x, (int)shark_pos.y);
            StartCoroutine(EatFish());
        }
    }

    void DecideMove()
    {
        // Vector2 bestLocation = shark_pos;
        List<Vector2> valid_locations = new List<Vector2>();
        int maxFish = 0;
        for (int i = 0; i <= 3; ++i)
        {
            Vector2 dir;
            switch (i)
            {
                case 0:
                    dir = new Vector2(1, 0);
                    break;
                case 1:
                    dir = new Vector2(-1, 0);
                    break;
                case 2:
                    dir = new Vector2(0, 1);
                    break;
                default:
                    dir = new Vector2(0, -1);
                    break;
            }
            Vector2 temp = dir + shark_pos;
            if (temp.x >= 10 || temp.y >= 10 || temp.x < 0 || temp.y < 0)
                continue;

            // if max is strictly higher, delete rest of array and only append this pos
            if (numFish((int)temp.x, (int)temp.y) > maxFish)
            {
                maxFish = fishCountArray[(int)temp.x, (int)temp.y];
                // bestLocation = temp;
                valid_locations.Clear();
                valid_locations.Add(temp);
            }

            // if fish is equal to max, add to array
            if (numFish((int)temp.x, (int)temp.y) == maxFish)
            {
                maxFish = fishCountArray[(int)temp.x, (int)temp.y];
                // bestLocation = temp;
                valid_locations.Add(temp);
            }
        }

        // select random int within index, and set shark pos to that vec
        int index = Random.Range(0, valid_locations.Count - 1);
        shark_pos = valid_locations[index];
    }

    IEnumerator EatFish()
    {
        yield return new WaitForSeconds(1.5f);
        eating = false;
        fish_eaten += 1;
    }

    public int getFishCount(int x, int y)
    {
        return fishCountArray[x, y];
    }
    public int numFish(int x, int y)
    {
        return fishCountArray[x, y];
    }

    public void decrementFish(int x, int y)
    {
        if (fishCountArray[x, y] >= 1)
            --fishCountArray[x, y];

        Material mat = fishCubes[x, y].GetComponent<MeshRenderer>().materials[0];
        mat.color = gradient.Evaluate(0.2f * fishCountArray[x, y]);
        return;
    }
}
