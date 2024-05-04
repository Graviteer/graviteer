using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public enum GravGunState
{
    PushPull,
    Grapple,
    Freeze,
    Launch,
    Ether
}

public class GravityGunController : MonoBehaviour
{
    public InputReader inputReader;
    public LaserScript laserController;
    public bool[] isFunctionAvailable = new bool[4];
    public Color[] laserColors = new Color[4];

    PushPull pushPullFunc;
    LaunchPlayer launchPlayerFunc;
    FreezeAbility freezeFunc;

    void OnEnable()
    {
        inputReader.SetFireModeEvent += SetGravGunState;
    }

    void OnDisable()
    {
        inputReader.SetFireModeEvent -= SetGravGunState;
    }

    // Start is called before the first frame update
    void Start()
    {
        pushPullFunc = GetComponent<PushPull>();
        launchPlayerFunc = GetComponent<LaunchPlayer>();
        freezeFunc = GetComponent<FreezeAbility>();

        SetGravGunState(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DisableGravGunFuncs()
    {
        if (pushPullFunc)
        {
            pushPullFunc.enabled = false;
        }

        if (launchPlayerFunc)
        {
            launchPlayerFunc.enabled = false;
        }

        if (freezeFunc)
        {
            freezeFunc.enabled = false;
        }
    }

    void SetGravGunState(int stateInd)
    {
        if (!isFunctionAvailable[stateInd])
        {
            return;
        }

        DisableGravGunFuncs();
        switch (stateInd)
        {
            case 0:
                pushPullFunc.enabled = true;
                break;
            case 1:
                break;
            case 2:
                launchPlayerFunc.enabled = true;
                break;
            case 3:
                freezeFunc.enabled = true;
                break;
        }

        SetGravGunLaserColor(stateInd);
    }

    void SetGravGunLaserColor(int stateInd)
    {
        Gradient laserGradient = new Gradient();
        GradientColorKey colorKey = new GradientColorKey(laserColors[stateInd], 0.0f);
        GradientAlphaKey alphaKey = new GradientAlphaKey(laserColors[stateInd].a, 1.0f);
        laserGradient.SetKeys(new GradientColorKey[] { colorKey }, new GradientAlphaKey[] { alphaKey });
        laserController.lineRenderer.colorGradient = laserGradient;
    }

}
