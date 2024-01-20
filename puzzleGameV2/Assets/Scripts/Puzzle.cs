using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Puzzle : MonoBehaviour
{
    // Bulmacanýn tamamlanýp tamamlanmadýðýný belirten özellik
    public bool IsCompleted { get; private set; }

    // Nesnenin spawn edilip edilmediðini belirten özellik
    private bool itemSpawn;


    public GameObject ClaimItem;


    // Bulmaca parçalarýnýn gösterildiði nesne
    private GameObject displayImage;

    void Start()
    {
        // Baþlangýçta objeyi devre dýþý býrak
        gameObject.SetActive(false); 


        // Nesnenin spawn durumunu false yap
        itemSpawn = false;



        // "displayImage" adlý nesneyi bul
        displayImage = GameObject.Find("displayImage");
    }
    
    void Update()
    {
        /*if (CompletePuzzle() && !itemSpawn)
         {
             var claimItem = Instantiate(ClaimItem, GameObject.Find("piece8").transform, false);
             claimItem.transform.localScale = new Vector3(15, 15, 15);
             itemSpawn = true;
         }*/

        // Fare týklamasýný kontrol et 
        if (Input.GetMouseButtonDown(0))
        {
            HideDisplay(); // Objeyi gizle
        }
        if (CompletePuzzle())
        {

            Debug.Log("comp");
        }

    }
    
    void HideDisplay()
    {

        if (Input.GetMouseButtonDown(0))
        {
            // Eðer fare týklamasý UI elemaný üzerinde deðilse
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                // Objeyi görünürlüðünü tersine çevir
                this.gameObject.SetActive(!this.gameObject.activeSelf);
            }
            
        }
        // Eðer "displayImage" nesnesinin durumu "normal" ise objeyi devre dýþý býrak
        else if (displayImage.GetComponent<DisplayImage>().CurrentState == DisplayImage.State.normal)
        {
            this.gameObject.SetActive(false);
        }

        else if (Input.GetMouseButtonDown(0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        {
            this.gameObject.SetActive(false);
        }

        Debug.Log("HideDisplay function called");

    }

    
    bool CompletePuzzle()
    {
        if (IsCompleted) return true;

        

        var puzzlePieces = FindObjectsOfType<PuzzlePiece>();

        foreach (PuzzlePiece puzzlePiece in puzzlePieces)
        {
            if (!(int.Parse(puzzlePiece.gameObject.name.ToString().Substring(puzzlePiece.gameObject.name.Length - 1)) ==
                int.Parse(puzzlePiece.gameObject.GetComponent<Image>().sprite.name.ToString().Substring(puzzlePiece.gameObject.GetComponent<Image>().sprite.name.Length - 1))))
            {
                IsCompleted = false;
            }
            else {
                IsCompleted = true;
            }
        }

        return IsCompleted;
    }
    
    
    
}