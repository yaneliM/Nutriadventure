using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelBtnController : MonoBehaviour
{
    //Estan estan como public para poder simular valores reales... se supone que estos valores se consiguen de lo que esta guardado
    public int currentLevel;
    public int currentEtapa;
    public int edad;
    /////////////////////////////////////////
    private int i,j;
    // Start is called before the first frame update
    public enum GoalsStates {Desayuno,Comida,Cena,Metas,Badges};
    public GoalsStates current;
    //Menu Canvas Objects
    public GameObject Desayuno1,Desayuno2, Comida1,Comida2,Comida3, Cena1,Cena2, MetaScr,BadgesScr;


    void Start()
    {
        current = GoalsStates.Metas;
        /*Con esto al cargarse se ponen todos los botones desactivados */
        for(i=1; i<=7;i++){
            for(j=1; j<=3; j++){
                Debug.Log(i+""+j+"BTN false");
                GameObject.Find(i+""+j+"BTN").GetComponent<Button>().interactable = false;
                Debug.Log(i+""+j+"BTN false");
            }
        }

        /*Con esto, los botones de los niveles anteriores al actual se ponen activos */
        for(i=1; i<currentLevel;i++){
            for(j=1; j<=3; j++){
                GameObject.Find(i+""+j+"BTN").GetComponent<Button>().interactable = true;
                Debug.Log(i+""+j+"BTN true");
            }
        }

        /*Con esto se toma en cuenta solo el nivel actual para activar las etapas anteriores y la actual */
        for(j=1; j<=currentEtapa; j++){
                GameObject.Find(currentLevel+""+j+"BTN").GetComponent<Button>().interactable = true;
                Debug.Log(i+""+j+"BTN true");
            }
 
    }


    // Update is called once per frame
    void Update()
    {
       switch (current)
        {
            case GoalsStates.Desayuno:
                Comida1.SetActive(false);
                Comida2.SetActive(false);
                Comida3.SetActive(false);
                Cena1.SetActive(false);
                Cena2.SetActive(false);
                MetaScr.SetActive(false);
                BadgesScr.SetActive(false);
                if(edad <= 9){
                    Desayuno1.SetActive(true);
                    Desayuno2.SetActive(false);
                }
                else{
                    Desayuno2.SetActive(true);
                    Desayuno1.SetActive(false);
                }
            break;

            case GoalsStates.Comida:
                Desayuno1.SetActive(false);
                Desayuno2.SetActive(false);
                Cena1.SetActive(false);
                Cena2.SetActive(false);
                MetaScr.SetActive(false);
                BadgesScr.SetActive(false);
                if(edad <=6){
                    Comida1.SetActive(true);
                    Comida2.SetActive(false);
                    Comida3.SetActive(false);
                }
                else if(edad >=7 && edad <=9){
                    Comida1.SetActive(false);
                    Comida2.SetActive(true);
                    Comida3.SetActive(false);
                }
                else if(edad >= 10){
                    Comida1.SetActive(false);
                    Comida2.SetActive(false);
                    Comida3.SetActive(true);
                }
            break;

            case GoalsStates.Cena:
                Desayuno1.SetActive(false);
                Desayuno2.SetActive(false);
                Comida1.SetActive(false);
                Comida2.SetActive(false);
                Comida3.SetActive(false);
                MetaScr.SetActive(false);
                BadgesScr.SetActive(false);
                if(edad <= 6){
                    Cena1.SetActive(true);
                    Cena2.SetActive(false);
                }
                else{
                    Cena1.SetActive(false);
                    Cena2.SetActive(true);
                }

            break;

            case GoalsStates.Metas:
                Desayuno1.SetActive(false);
                Desayuno2.SetActive(false);
                Comida1.SetActive(false);
                Comida2.SetActive(false);
                Comida3.SetActive(false);
                Cena1.SetActive(false);
                Cena2.SetActive(false);
                
                MetaScr.SetActive(true);
                BadgesScr.SetActive(false);
            break;

            case GoalsStates.Badges:
                Desayuno1.SetActive(false);
                Desayuno2.SetActive(false);
                Comida1.SetActive(false);
                Comida2.SetActive(false);
                Comida3.SetActive(false);
                Cena1.SetActive(false);
                Cena2.SetActive(false);

                MetaScr.SetActive(false);
                BadgesScr.SetActive(true);
            break;

        }
    }

    public void OnFirstEtapa()
    {
        Debug.Log("Desayuno");
        /*Esta parte deberia llevar al canvas correcto
        asi que deberia checar el valor edad para saber a cual ir */
        current = GoalsStates.Desayuno;
    }

    public void OnSecondEtapa()
    {
        Debug.Log("Comida");
        /*Esta parte deberia llevar al canvas correcto
        asi que deberia checar el valor edad para saber a cual ir */
        current = GoalsStates.Comida;
    }

    public void OnThirdEtapa()
    {
        Debug.Log("Cena");
        /*Esta parte deberia llevar al canvas correcto
        asi que deberia checar el valor edad para saber a cual ir */
        current = GoalsStates.Cena;
    }

    //si se preciona la TACHA, regresa a la pagina principal
    public void OnCancel()
    {
        Debug.Log("Start");
        SceneManager.LoadScene("Main");
    }

    //En los canvas de las metas, si se preciona la CASITA, regresa al canvas de los niveles
    public void OnHome()
    {
        Debug.Log("Home");
        current = GoalsStates.Metas;
    }
    //En el mapa si se presiona el trofeo lleva al canvas de medallas
    public void OnBadges()
    {
        Debug.Log("Badges");
        current = GoalsStates.Badges;
    }

    //En las metas, el signo de interrogacion, abre otros canvas (que no he hecho) con las instrucciones
    public void OnInstruction(){
        Debug.Log("Abrir panel de instrucciones");
    }

    //En las metas, con el play llevaria a algun canvas random con "sabias que...?" (que no he hecho)
    public void OnPlay(){
        Debug.Log("Aqui van canvas de sabias que y luego el juego");

        //Como es la misma funcion para todas las metas
        //Aqui deberia haber esa diferenciacion de que abra la escena del juego, pero que se sepa
        //Que tipos de cosas pueden o no salir
        switch(current){
            case GoalsStates.Desayuno:
                //SceneManager.LoadScene("GameDesayuno");
            break;

            case GoalsStates.Comida:
               //SceneManager.LoadScene("GameComida");
            break;

            case GoalsStates.Cena:
                //SceneManager.LoadScene("GameCena");
            break;
        }


    }
}
