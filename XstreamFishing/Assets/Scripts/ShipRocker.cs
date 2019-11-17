using System;
using UnityEngine;
 
public class ShipRocker: MonoBehaviour
{
    //updown movement from
    //https://forum.unity.com/threads/trying-to-simulate-a-ships-rocking-motion-in-the-ocean.465557/
 
    float originalY;
    public float speed = 2.0f;
    public float bobbingMultiplier = .5f;
    //public float rollMultiplier = .4f;
    private Quaternion startRotation;

    private PlayerController pc;
 
    void Start()
    {
        originalY = this.transform.position.y;
        pc = GetComponent<PlayerController>();
        // startRotation = transform.rotation;
    }
 
    void Update()
    {
        if(!pc.can_fly)BobUpAndDown();
        // RollFrontToBack();
        // RollSideToSide();
    }
 
    void BobUpAndDown( )
    {
        transform.position = new Vector3(this.transform.position.x,
                                         originalY + ((float)Math.Sin(Time.time*speed) * bobbingMultiplier),
                                         this.transform.position.z);
    } 
    // void RollSideToSide( )
    // {
    //     float f = Mathf.Sin( Time.time * rollMultiplier ) * 10f;
    //     transform.rotation = startRotation * Quaternion.AngleAxis( f, Vector3.forward );
    // }
 
    // void RollFrontToBack()
    // {
    //     float f = Mathf.Sin(Time.time * rollMultiplier) * 2f;
    //     transform.rotation = startRotation * Quaternion.AngleAxis(f, Vector3.left);
    // }
}
 
