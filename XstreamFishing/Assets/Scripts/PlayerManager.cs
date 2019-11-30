using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    public Inventory inventory;
    public Text actionText;
    public GameObject shopUI;
    public GameObject inventoryUI;
    private bool startSequence;
    private int num_screens;
    public PlayerInput player_input;
    public Camera main_camera;
    public Camera fp_camera;
    public Canvas main_UI;
    public GameObject boat;
    private SpriteRenderer mat;
    public GameObject sphere;
    public PlayerToastManager ptm;
    public MeshRenderer boat_mesh;
    public GameObject cursor;
    public int index = -1;
    public bool inventory_on_screen = false;
    public AudioClip inventory_open;
    public AudioClip inventory_close;

    public int timer;

    void Start()
    {
        // get minimap sphere material
        mat = sphere.GetComponent<SpriteRenderer>();
        timer = 0;

        // get index, and set position based on index
        index = player_input.playerIndex;

        // on join, turn text the right color and change text
        Text player_join_text = GameObject.Find("PlayerJoinText" + index).GetComponent<Text>();
        player_join_text.text = "Player " + index + " joined!";
        if (index == 1)
        {
            boat.transform.position = new Vector3(-200f, 0f, 200f);
            boat_mesh.materials[0].color = new Color(66 / 265f, 135 / 265f, 245 / 265f, 1);
            mat.color = new Color(66 / 265f, 135 / 265f, 245 / 265f, 1);
            player_join_text.color = new Color(66 / 265f, 135 / 265f, 245 / 265f, 1);
            boat.transform.rotation = new Quaternion(0, 140, 0, 0);
        }
        if (index == 2)
        {
            boat.transform.position = new Vector3(200f, 0f, 200f);
            boat_mesh.materials[0].color = Color.red;
            mat.color = Color.red;
            player_join_text.color = Color.red;
            boat.transform.rotation = new Quaternion(0, 230, 0, 0);
        }
        if (index == 3)
        {
            boat.transform.position = new Vector3(-200f, 0f, -200f);
            mat.color = Color.yellow;
            boat_mesh.materials[0].color = Color.yellow;
            player_join_text.color = Color.yellow;
            boat.transform.rotation = new Quaternion(0, 320, 0, 0);
        }
        if (index == 4)
        {
            boat.transform.position = new Vector3(200f, 0f, -200f);
            mat.color = Color.green;
            boat_mesh.materials[0].color = Color.green;
            player_join_text.color = Color.green;
            boat.transform.rotation = new Quaternion(0, 50, 0, 0);
        }
        ptm = gameObject.GetComponentInParent(typeof(PlayerToastManager)) as PlayerToastManager;
        ptm.Toast("It's a nice day to be out fishing. \n free to come on down to the island pro shop for supplies.\n Heck I'll even throw in some free advice.");
    }

    // toggle inventory
    public void OnX()
    {
        if (inventory_on_screen)
        {
            // move inventory back off of screen
            AudioManager.instance.Play(inventory_open);
            RectTransform rect = inventoryUI.GetComponent<RectTransform>();
            StartCoroutine(LerpInventory(rect, rect.anchoredPosition, new Vector3(-80, 0, -2), 0.3f));
        }
        else
        {
            // move inventory onto screen
            AudioManager.instance.Play(inventory_close);
            RectTransform rect = inventoryUI.GetComponent<RectTransform>();
            StartCoroutine(LerpInventory(rect, rect.anchoredPosition, new Vector3(200, 0, -2), 0.3f));
        }
        inventory_on_screen = !inventory_on_screen;
    }

    IEnumerator LerpInventory(RectTransform rect, Vector3 startPos, Vector3 endPos, float totalTime)
    {
        float currentTime = 0;
        while (currentTime <= totalTime)
        {
            currentTime += Time.deltaTime;
            float normalized = currentTime / totalTime;
            rect.anchoredPosition = Vector3.Lerp(startPos, endPos, normalized);
            yield return null;
        }
    }

    int PlayerCount()
    {
        int count = 0;
        // while player isn't null, add to count
        while (PlayerInput.GetPlayerByIndex(count))
        {
            count += 1;
        }
        return count - 1;
    }

    void UpdateScreenSize()
    {
        int current_num_screens = PlayerCount();

        if (current_num_screens != num_screens)
        {
            num_screens = current_num_screens;
            // indices 1-4
            int index = player_input.playerIndex;
            if (num_screens == 1)
            {
                // set camera sizes to 1 and positions to 0,0
                main_camera.rect = new Rect(0f, 0f, 1f, 1f);
                fp_camera.rect = new Rect(0f, 0f, 1f, 1f);
                main_UI.GetComponent<CanvasScaler>().scaleFactor = 2;
            }
            if (num_screens == 2)
            {
                if (index == 1)
                {
                    main_camera.rect = new Rect(0f, 0.5f, 1f, 0.5f);
                    fp_camera.rect = new Rect(0f, 0.5f, 1f, 0.5f);
                }
                else
                {
                    main_camera.rect = new Rect(0f, 0f, 1f, 0.5f);
                    fp_camera.rect = new Rect(0f, 0f, 1f, 0.5f);
                }
                main_UI.GetComponent<CanvasScaler>().scaleFactor = 1f;
            }
            if (num_screens >= 3)
            {
                main_UI.GetComponent<CanvasScaler>().scaleFactor = 1f;
                if (index <= 2)
                {
                    main_camera.rect = new Rect((index - 1) * 0.5f, 0.5f, 0.5f, 0.5f);
                    fp_camera.rect = new Rect((index - 1) * 0.5f, 0.5f, 0.5f, 0.5f);
                }
                else
                {
                    main_camera.rect = new Rect((index - 3) * 0.5f, 0f, 0.5f, 0.5f);
                    fp_camera.rect = new Rect((index - 3) * 0.5f, 0f, 0.5f, 0.5f);
                }
            }
        }
    }

    void Update()
    {
        UpdateScreenSize();

        // if in third-person check what we have equipped, if cannon give cannon mappings, if rod give fish mappings
        if (!boat.GetComponent<Rigidbody>().isKinematic)
        {
            if (inventory.GetHasCategoryEquipped("rod"))
            {
                actionText.text = "Y: Get Fishin'";
            }
            else
            {
                actionText.text = "RT: Shoot\nLT: Gimbal Up\nLB: Gimbal Down";
            }
        }
        // if (timer >= 45 * 60)
        // {
        //     ptm.Toast("I've been hearing about a SHARK thats eating all the fish in the lake.\n It sure would be wonderful for someone get out there \n and catch it with the GOLDEN ROD.");
        //     timer = 0;
        // }
        // ++timer;
    }
}
