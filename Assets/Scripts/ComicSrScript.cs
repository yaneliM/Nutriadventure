using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ComicSrScript : MonoBehaviour
{
    void Update(){

    }
    public void OnNext(){
        SceneManager.LoadScene("MapNGoals");
    }

}
