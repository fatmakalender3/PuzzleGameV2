using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunc : MonoBehaviour
{
    private DisplayImage currentDisplay;

    private ZoomInObject[] zoomInObjects;

    private float initialCameraSize;
    private Vector3 initialCameraPosition;


    void Awake()
    {
        currentDisplay = GameObject.Find("displayImage").GetComponent<DisplayImage>();
        initialCameraSize = Camera.main.orthographicSize;
        initialCameraPosition = Camera.main.transform.position;

        zoomInObjects = FindObjectsOfType<ZoomInObject>();
    }

    // ************* MENÜ BUTONLARI ************* //

    public void LoadLevel1()
    {
        SceneManager.LoadScene(2);

    }

    public void QuitGame()
    {
        Application.Quit();
    }

    // ************* MENÜ BUTONLARI SON ************* //



    // ************* YÖNLENDÝRME BUTONLARI ************* //

    public void OnRightClickArrow()
    {
        currentDisplay.CurrentWall = currentDisplay.CurrentWall + 1;

    }

    public void OnRightLeftArrow()
    {
        currentDisplay.CurrentWall = currentDisplay.CurrentWall - 1;
    }

    public void OnClickReturn()
    {

            //GameObject.Find("displayImage").GetComponent<DisplayImage>().CurrentState = DisplayImage.State.normal;
            //currentDisplay.CurrentState = DisplayImage.State.normal;

            if (currentDisplay.CurrentState == DisplayImage.State.zoom)
            {
                currentDisplay.CurrentState = DisplayImage.State.normal;

                foreach (var zoomInObject in zoomInObjects)
                {
                    zoomInObject.gameObject.layer = 0;
                }

                Camera.main.orthographicSize = initialCameraSize;
                Camera.main.transform.position = initialCameraPosition;
            }
            else
            {
                currentDisplay.GetComponent<SpriteRenderer>().sprite
                    = Resources.Load<Sprite>("Sprites/wall" + currentDisplay.CurrentWall);
                currentDisplay.CurrentState = DisplayImage.State.normal;
                /*
                Camera.main.orthographicSize = initialCameraSize;
                Camera.main.transform.position = initialCameraPosition;

                foreach (var zoomInObject in zoomInObjects)
                {
                    zoomInObject.gameObject.layer = 0;
                }*/
            }
    
    }

    

    // ************* YÖNLENDÝRME BUTONLARI SON ************* //

}