using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DisplayImage : MonoBehaviour
{
    private int currentWall;

    public enum State
    {
        normal, zoom, ChangedView
    };

    public State CurrentState { get; set; }

    public int CurrentWall
    {
        get { return currentWall; }

        set
        {
            if (value == 4)
            {
                currentWall = 1;
            }
            else if (value == 0)
            {
                currentWall = 3;
            }
            else
            {
                currentWall = value;
            }
        }
    }

    private int previousWall;

    void Start()
    {
        previousWall = 0;
        currentWall = 1;
    }

    public void ChangeWalls()
    {
        // Hata Kontrolü //
        string spritePath = "Sprites/wall/wall" + currentWall.ToString();
        Sprite loadedSprite = Resources.Load<Sprite>(spritePath);

        if (loadedSprite == null)
        {
            Debug.LogError("Sprite yüklenirken hata oluþtu! Yol: " + spritePath);
        }
        else
        {
            Debug.Log("Sprite baþarýyla yüklendi! Yol: " + spritePath);
        }
        //Hata Kontrolü Son//


        if (currentWall != previousWall)
        {
            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/wall/wall" + currentWall.ToString());
        }

        previousWall = currentWall;
    }
}