using UnityEngine;
using System.Collections;

public class WorldChanger : MonoBehaviour
{
    public string BlackWorldMaskName;
    public string SunWorldMaskName;
    public EdgeCollider2D SunWorldCollider;
    public EdgeCollider2D BlackWorldCollider;

    public Sprite SunWorldTexture;
    public Sprite BlackWorldTexture;
    public SpriteRenderer cameraBackground;

    private bool SwapWorldsFlag = true;
    private bool SunWorldActive = false; //TODO make it private

    private Camera _mainCamera;

    private void Start ()
	{
	    _mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent(typeof (Camera)) as Camera;

        HideMask(SunWorldMaskName);
        SunWorldCollider.enabled = false;
        cameraBackground.sprite = BlackWorldTexture;

        if (SunWorldActive)
        {
            HideMask(BlackWorldMaskName);
            BlackWorldCollider.enabled = false;
            cameraBackground.sprite = SunWorldTexture;
        }
	}

    private void Update ()
	{
        if (Input.GetKeyDown(KeyCode.F))
        {
            SwapWorlds();//TODO delete these 
        }
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
                SunWorldCollider.enabled = false;
                BlackWorldCollider.enabled = true;
                cameraBackground.sprite = BlackWorldTexture;

                HideMask(SunWorldMaskName);
                ShowMask(BlackWorldMaskName);
                SunWorldActive = false;
            }
            else
            {
                SunWorldCollider.enabled = true;
                BlackWorldCollider.enabled = false;
                cameraBackground.sprite = SunWorldTexture;

                HideMask(BlackWorldMaskName);
                ShowMask(SunWorldMaskName);
                SunWorldActive = true;
            }
            //SwapWorldsFlag = false;
        }
    }

}
