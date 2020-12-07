using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    public TimelineReaccio timelineReaccio;
    public Collider col;
    private Animator doorAnim;

    public static Color fingerColor;
    public static Color[] properColors;

    public static bool redIsRed, yellowIsyellow, greenIsGreen, blueIsBlue;

    private void Awake()
    {
        properColors = new Color[4];
    }

    // Start is called before the first frame update
    void Start()
    {
        PaletteColor.ColorPicked += SetFingerColor;
        Glass.GlassColorIsSet += CheckResults;
        //done.text = "";
        //doorAnim = tiger.GetComponent<Animator>();
        fingerColor = new Color(1f, 1f, 1f, 1f);
        
    }

   

    private void SetFingerColor(Color colorPicked, Vector3 colorPosition)
    {
        fingerColor = colorPicked;
    }

    private void CheckResults()
    {
        if(redIsRed && yellowIsyellow && greenIsGreen && blueIsBlue)
        {
            //doorAnim.Play("TigreDesapareix");
            //done.text = "DONE";
            Debug.Log("Done");
            col.enabled = false;
            timelineReaccio.Reacciona();
        }
    }
    private void OnDestroy()
    {
        PaletteColor.ColorPicked -= SetFingerColor;
        Glass.GlassColorIsSet -= CheckResults;
    }
}
