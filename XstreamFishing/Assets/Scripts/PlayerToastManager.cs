/* ToastManager.cs
 * 
 * This file houses the Toast system-- a singleton system responsible for implementing little pop-up "toast" messages for the user.
 * 
 * The Toast system is made accessible throughout the codebase via one public static method-- "Toast()".
 * Unfortunately, this fact couples other systems to the existence of the Toast system (but it sure is convenient in a small project!)
 * A superior solution might be to create a global "request-pool", where individual systems can emit all of their requests to (without regard to who's listening for them).
 * With this approach, the Toast system could simply listen for "toast" requests appearing in the request-pool, and execute toasts when necessary.
 * The benefit-- no system would need to know about the Toast system's existence or how it works, and the Toast system wouldn't care about other systems either! Isolation! Independence!
 * Perhaps this may be experimented with in a larger project.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerToastManager : MonoBehaviour
{

    // Singleton static this variable. When one ToastManager "claims" this variable, all the others go away.
    // Vector3 hidden_pos;
    // Vector3 visible_pos;

    public GameObject canvas;
    public RectTransform toast_panel;
    public Text toast_text;

    // These inspector-accessible variables control how the toast UI panel moves between the hidden and visible positions.
    public AnimationCurve ease;
    public AnimationCurve ease_out;

    // Duration controls.
    public float ease_duration = 0.5f;
    public float show_duration = 2.0f;

    // public int hidden_y = 150;
    // public int visible_y = 150;

    // We don't want to discard toast requests that come in while we are already toasting. What if the message is critical?
    // The queue keeps a rolling data store of work we still need to do.
    Queue<PlayerToastRequest> requests = new Queue<PlayerToastRequest>();
    Queue<PlayerToastRequest> strongRequests = new Queue<PlayerToastRequest>();

    private IEnumerator coroutine;

    // Use this for initialization
    void Awake()
    {
        // if (this == null)
        // {
        //     this = this;
        //     DontDestroyOnLoad(gameObject);
        //     DontDestroyOnLoad(canvas);
        // }
        // else
        // {
        //     Destroy(gameObject);
        // }

        // Init positions
        // hidden_pos = new Vector3(0, hidden_y, 0);
        // visible_pos = new Vector3(0, visible_y, 0);
    }

    // "public static" makes this function accessible from anywhere.
    // note that it does not actually launch a toast operation-- it just throws it on the queue for later execution.
    public void Toast(string msg)
    {
        this.requests.Enqueue(new PlayerToastRequest(msg));
    }
    public void OverwriteToast(string msg)
    {
        this.strongRequests.Enqueue(new PlayerToastRequest(msg));
    }
    void startToastCoroutine()
    {
        show_duration = 1.0f;
        PlayerToastRequest new_strong_request = strongRequests.Dequeue();
        toasting = true;
        this.toast_text.text = new_strong_request.message;

        coroutine = DoToast(this.ease_duration, this.show_duration);
        StartCoroutine(coroutine);
    }
    public void setShowDuration(float seconds)
    {
        this.show_duration = seconds;
    }

    // The Update function is responsible for monitoring the queue and executing requests
    void Update()
    {
        //Debug.Log(strongRequests.Count);
        // If a request exists on the queue, and we're not busy servicing an earlier request, we service the next one on the queue.
        if (!toasting && requests.Count > 0)
        {
            PlayerToastRequest new_request = requests.Dequeue();
            toasting = true;

            this.toast_text.text = new_request.message;
            coroutine = DoToast(this.ease_duration, this.show_duration);
            this.StartCoroutine(coroutine);
            //this.StartCoroutine(DoToast(this.ease_duration, this.show_duration,true));
        }
        if (strongRequests.Count > 0)
        {
            if (toasting)
            {
                this.StopCoroutine(coroutine);
            }
            PlayerToastRequest new_request = strongRequests.Dequeue();


            this.toast_text.text = new_request.message;
            toasting = true;
            coroutine = DoToast(this.ease_duration, this.show_duration);

            this.StartCoroutine(coroutine);

        }
    }


    IEnumerator DoToast(float duration_ease_sec, float duration_show_sec)
    {
        yield return new WaitForSeconds(duration_show_sec);

        this.toasting = false;
        this.toast_text.text = "";
    }

    bool toasting = false;
}

// A simple data structure for holding information about a toast request.
// This could be expanded to store additional request parameters like sound effects, colors, end-of-toast callbacks, etc.
public class PlayerToastRequest
{
    public string message;

    public PlayerToastRequest(string s)
    {
        message = s;
    }
}
