using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Button Button;
    public Sprite ImagePause, ImagePlay;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PauseNPlay()
    {
        Time.timeScale = (Time.timeScale + 1) % 2;
        switch (Time.timeScale)
        {
            case 0:
                Button.image.sprite = ImagePlay;
                break;
            case 1:
                Button.image.sprite = ImagePause;
                break;
        }
    }
}
