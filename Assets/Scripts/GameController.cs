using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private Gyroscope gyro;
	Scoreboard SB;
    //Actualizar el texto de score
    public Text score;
    //Objectos utilizados en las escenas
    //Menu de pausa
    public GameObject Pause;
    //Herramientas
    public GameObject imgCuchara, imgTenedor, imgBomba, imgMisil, botonCambiar;
    //Imagenes de salud    
    public GameObject healthImage;
    public Sprite health7,health6,health5,health4,health3,health2,health1;
    //Botones de opciones
    public GameObject comerBTN, destruirBTN;

 

    // Start is called before the first frame update
    void Start()
    {
        //Set up state of panels
        healthImage.GetComponent<Image>().sprite = health4;
        Pause.SetActive(false);
        imgCuchara.SetActive(false);
        imgTenedor.SetActive(false);
        imgBomba.SetActive(false);
        imgMisil.SetActive(false);
        botonCambiar.SetActive(false);

        comerBTN.SetActive(false);
        destruirBTN.SetActive(false);

        //Get reference to scoreboard script
        SB = FindObjectOfType<Scoreboard>();
        //
        gyro = Input.gyro;
    }

    // Update is called once per frame
    void Update()
    {
        Gameover();
        UpdateHealth();
        score.text = SB.score_value().ToString();
    }

    //Funciones necesarias para el manejo del menu de pause y subopciones
    public void OnPause(){
        Pause.SetActive(true);
        gyro.enabled = false;
    }
    public void OnContinue(){
        Pause.SetActive(false);
        gyro.enabled = true;
    }
    public void OnExit(){
        SceneManager.LoadScene("MapNGoals");
    }

    //Funcion para la actualizacion de la imagen de salud (emoji)
    public void UpdateHealth(){

        if(SB.health > 0 && SB.health <= 15 ) healthImage.GetComponent<Image>().sprite = health1;
        if(SB.health > 15 && SB.health <= 30 ) healthImage.GetComponent<Image>().sprite = health2;    
        if(SB.health > 30 && SB.health <= 45 ) healthImage.GetComponent<Image>().sprite = health3;    
        if(SB.health > 45 && SB.health <= 55 ) healthImage.GetComponent<Image>().sprite = health4;    
        if(SB.health > 55 && SB.health <= 70 ) healthImage.GetComponent<Image>().sprite = health5;    
        if(SB.health > 70 && SB.health <= 85 ) healthImage.GetComponent<Image>().sprite = health6;    
        if(SB.health > 85 && SB.health <= 100 ) healthImage.GetComponent<Image>().sprite = health7;        

    } 

    //Funcion que revisa si se termino el juego
     public void Gameover()
    {

        //Si todas las metas fueron completadas el juego termina correctamente
        if(SB.carne_f && SB.cereales_f && SB.frutas_f && SB.lacteos_f && SB.verduras_f)
        {
            Debug.Log("Ganaste");
            PlayerPrefs.SetString("gameOver","Correcto");
            PlayerPrefs.SetInt("score",SB.score_value()); //score solo de la etapa para la pantalla de final de etapa
            PlayerPrefs.SetInt("scoreTotal", PlayerPrefs.GetInt("scoreTotal")+SB.score_value()); //toma los valores de score de cada etapa para la pantalla de final de nivel
            PlayerPrefs.Save();
            SceneManager.LoadScene("ENDetapa");
        }

        //Si se comio mas de 15 objetos de metas que ya hayan sido completadas
        if(SB.excesos >= 15)
        {
            Debug.Log("Perdiste por excesos");
            PlayerPrefs.SetString("gameOver","Exceso");
            PlayerPrefs.SetInt("score",SB.score_value());
            PlayerPrefs.Save();
            SceneManager.LoadScene("ENDetapa");
        }

        //Si la salud esta muy baja pierde
        if(SB.health <= 5)
        {

            Debug.Log("Muerto");
            PlayerPrefs.SetString("gameOver","Salud");
            PlayerPrefs.SetInt("score",SB.score_value());
            PlayerPrefs.Save();
            SceneManager.LoadScene("ENDetapa");

        }

        //La escena GameOver revisa el valor de gameOver, para mostrar el canvas correcto
    }
    
}
