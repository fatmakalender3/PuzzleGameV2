using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class IntroTime : MonoBehaviour
{

    public float waitTime = 26.0f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(waitIntroTime());
    }

    IEnumerator waitIntroTime() {  
        
        yield return new WaitForSeconds(waitTime);

        SceneManager.LoadScene(1);
    }
}
