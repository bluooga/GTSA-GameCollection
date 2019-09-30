using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PongOptions : MonoBehaviour
{
    public int gamemodenumber;
    public static float accel;
    public static float bsSpeed;
    public Dropdown GMdrop;
    public Slider ACslide;
    public Slider BSSlider;
    public Text AccelFeedback;
    public Text BSFeedback;



    private void Awake()
    {
        accel = ACslide.value;
        bsSpeed = BSSlider.value;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(gamemodenumber);
    }
    public void GmChange()
    {
        gamemodenumber = GMdrop.value;
    }

    public void AccelChange()
    {
        accel = ACslide.value;
        AccelFeedback.text = accel.ToString();
    }

    public void bSpeedChange()
    {
        bsSpeed = BSSlider.value;
        BSFeedback.text = bsSpeed.ToString();
    }
}
