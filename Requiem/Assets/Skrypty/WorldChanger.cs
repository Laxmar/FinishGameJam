using UnityEngine;
using System.Collections;

public class WorldChanger : MonoBehaviour
{
    public string BlackWorldMaskName;
    public string SunWorldMaskName;
    public bool SwapWorldsFlag;
    public bool SunWorldActive = true; //TODO make it private

    private Camera _mainCamera;

    private void Start ()
	{
	    _mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent(typeof (Camera)) as Camera;
        if (SunWorldActive)
        {
            HideMask(BlackWorldMaskName);
        }
	}

    private void Update ()
	{
        SwapWorlds();//TODO delete these 
	}

    private void HideMask(string maskName)
    {
        _mainCamera.cullingMask &= ~(1 << LayerMask.NameToLayer(maskName));
    }

    private void ShowMask(string maskName)
    {
        _mainCamera.cullingMask |= (1 << LayerMask.NameToLayer(maskName));
    }

    public void SwapWorlds()
    {
        if (SwapWorldsFlag)
        {
            if (SunWorldActive)
            {
                HideMask(SunWorldMaskName);
                ShowMask(BlackWorldMaskName);
                SunWorldActive = false;
            }
            else
            {
                HideMask(BlackWorldMaskName);
                ShowMask(SunWorldMaskName);
                SunWorldActive = true;
            }
            SwapWorldsFlag = false;
        }
    }
        
}
