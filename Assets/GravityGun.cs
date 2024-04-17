using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public enum GravGunState
{
    PushPull, Grapple, Freeze, Launch, Ether
}

public class GravityGun : MonoBehaviour
{

    GravGunState gravGunFunc;
    PushPull pushPullFunc;
    // Start is called before the first frame update
    void Start()
    {
        pushPullFunc = GetComponent<PushPull>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    public void ButtonGravGunFunc()
    {
        switch(gravGunFunc){
            case GravGunState.PushPull:
                pushPullFunc.moveObject();
                break;
            case GravGunState.Grapple:
                break;
            case GravGunState.Freeze:
                break;
            case GravGunState.Launch:
                break;
            case GravGunState.Ether:
                break;
        }
    }

}
