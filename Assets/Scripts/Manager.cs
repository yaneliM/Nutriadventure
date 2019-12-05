using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    private Gyroscope gyro;
	public GameObject Pause;
    Scoreboard SB;
    public Text score;
    public GameObject healthImage;
    public Sprite health7,health6,health5,health4,health3,health2,health1;
   // public GameObject Game;

    // Start is called before the first frame update
    void Start()
    {
        Pause.SetActive(false);
        SB = FindObjectOfType<Scoreboard>();
        gyro = Input.gyro;
    }

    // Update is called once per frame
    void Update()
    {
        
        Gameover();
        UpdateHealth();
        score.text = SB.score_value().ToString();

    }

    public void Pause_btn()
    {

        Pause.SetActive(true);
        Debug.Log("Pause");
        gyro.enabled = false;

    }

    public void cont_btn()
    {

        Pause.SetActive(false);
        gyro.enabled = true;

    }

    public void exit_btn()
    {

        Debug.Log("Salir");
        SceneManager.LoadScene("MapNGoals");

    }

    public void UpdateHealth(){

        if(SB.health > 0 && SB.health <= 15 ) healthImage.GetComponent<Image>().sprite = health1;
        if(SB.health > 15 && SB.health <= 30 ) healthImage.GetComponent<Image>().sprite = health2;    
        if(SB.health > 30 && SB.health <= 45 ) healthImage.GetComponent<Image>().sprite = health3;    
        if(SB.health > 45 && SB.health <= 55 ) healthImage.GetComponent<Image>().sprite = health4;    
        if(SB.health > 55 && SB.health <= 70 ) healthImage.GetComponent<Image>().sprite = health5;    
        if(SB.health > 70 && SB.health <= 85 ) healthImage.GetComponent<Image>().sprite = health6;    
        if(SB.health > 85 && SB.health <= 100 ) healthImage.GetComponent<Image>().sprite = health7;        

    }

    public void Gameover()
    {


        if(SB.carne_f && SB.cereales_f && 
        SB.frutas_f && SB.lacteos_f && 
        SB.verduras_f)
        {

            Debug.Log("Ganaste");
            PlayerPrefs.SetString("gameOver","Correcto");
            PlayerPrefs.SetInt("score",SB.score_value());
            PlayerPrefs.Save();
            SceneManager.LoadScene("ENDetapa");
        }

        if(SB.total>=15)
        {
            Debug.Log("Perdiste por excesos");
            PlayerPrefs.SetString("gameOver","Exceso");
            PlayerPrefs.SetInt("score",SB.score_value());
            PlayerPrefs.Save();
            SceneManager.LoadScene("ENDetapa");
        }

        if(SB.health <= 10)
        {

            Debug.Log("Muerto");
            PlayerPrefs.SetString("gameOver","Salud");
            PlayerPrefs.SetInt("score",SB.score_value());
            PlayerPrefs.Save();
            SceneManager.LoadScene("ENDetapa");

        }
    }

}



