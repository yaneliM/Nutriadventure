using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
//Crea los objetos iniciales dentro de un rango
//Actualiza la cantidad de objetos instanciados, cada vez que se elimina alguno
public class SpawnObject : MonoBehaviour
{
    int i = 0;
    float xRand,yRand,zRand;
    bool validNum;
    public static GameObject[] posibleObjects;   
    public static int spawnedQuantity;
    public int maxSpawned = 15;
   /*Iniciar el sistema con 10 objetos en posiciones random */
    void Start()
    {

        posibleObjects = Resources.LoadAll<GameObject>("Prefabs");

        
    }
    // Update is called once per frame
    void Update()
    {
        if(maxSpawned > spawnedQuantity){
            SpawnRandomObject();
        }
        
    }

    void SpawnRandomObject(){

        int item = Random.Range(0,posibleObjects.Length);
        GameObject newObj = Instantiate(posibleObjects[item]) as GameObject;
        spawnedQuantity++;
        
        validNum = false;
        /*Validar que se encuentre en un rango enter 3 y 9 unidades, en x y z */
        while(!validNum){
            xRand = Random.Range(-10.0f,10.0f);
            zRand = Random.Range(-10.0f,10.0f);
            /*Verificar que se encuentren en un rango circular (siempre a >2.5 unidades de la camara) 
                con x^2 + y^2 = r^2 ecuacion de un circulo en el plano, do9nde r = 3*/
            if((xRand*xRand + zRand*zRand) > 9.0f && (xRand*xRand + zRand*zRand) < 81.0f)
                validNum = true;
        }


            yRand = Random.Range(-3.0f,6.0f);

        
        Vector3 position = new Vector3(xRand,yRand,zRand);
        newObj.transform.position = position;
 

    }

    public GameObject[] GetObjects(){
        return posibleObjects;
    }



}
