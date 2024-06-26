using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelect : MonoBehaviour
{
    public Transform targetPlayer;

    public Transform camTarget;
    public Transform camTrans;
    
    public TextMeshProUGUI nameUI;

    public TextMeshProUGUI speedUI;

    public TextMeshProUGUI descUI;

    public CharacterScriptable stats;

    public static CharacterSelect instance;
    //creates an array of scriptable objects
    public CharacterScriptable[] animalArray;
    //you can make an empty game object anywhere in the scene
    //this will reference that location
    public Transform location;
    // a list of the animals to parse through
    private List<GameObject> animalList;
    //keeps track of the animal we are on
    private int currentAnimal;
    

    GameObject chosenAnimal = null;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //camTrans = Camera.main.GetComponent<Transform>();
        stats.UpdateStats(this);
        //creates a new list at the start
        animalList = new List<GameObject>();
        //runs through the animal array of scriptable objects to:
        //instantiate the animal object
        //not show it immediately
        //and add it to the animal list
        foreach (var characterScriptable in animalArray)
        {
            GameObject newAnimal = Instantiate(characterScriptable.animalObject, location);
            
            newAnimal.SetActive(false);
            animalList.Add(newAnimal);
        }
        //call function after instatiating all of the cars, only showing the one it is on
        ShowAnimal();
        
        
        
    }

    void ShowAnimal()
    {
        animalList[currentAnimal].SetActive(true);
        chosenAnimal = animalList[currentAnimal];
        stats = animalArray[currentAnimal];
        stats.UpdateStats(this);
        Debug.Log(animalArray[currentAnimal]);
        Debug.Log(chosenAnimal);
      

    }

    public void Next()
    {
        //set the animal to not be visable
        animalList[currentAnimal].SetActive(false);
        //if the current animal shown is not out of the bounds of the list
        //add one to the number and show the corresponding animal
        //else set the current animal number to 0 t start the list over
        if (currentAnimal < animalList.Count - 1)
        {
            currentAnimal++;
        }
        else
        {
            currentAnimal = 0;
        }
        
        ShowAnimal();
        
    }

    //same thing but instead check to see if you are at the front of the list
    //if so go to the end of the list and show that car
    public void Back()
    {
        animalList[currentAnimal].SetActive(false);

        if (currentAnimal == 0)
        {
            currentAnimal = animalList.Count - 1;
        }
        else
        {
            currentAnimal--;
        }
        ShowAnimal();
    }

    public void PlayGame()
    {
        
        SceneManager.LoadScene("MainGame");
        chosenAnimal.gameObject.SetActive(false);
        PlayDebug();
        //animalArray[currentAnimal].GameObject().SetActive(false);
      
        //Camera.main.transform.SetParent(chosenAnimal.transform);

        //camTarget = chosenAnimal.GetComponent<Transform>();
        //camTrans.position = camTarget.position + new Vector3(1,2,-3);
        //how to then make this constantly update?? idk
    }

    public void PlayDebug()
    {
        Debug.Log(chosenAnimal.name);
        string newPath = "Prefabs/" + animalArray[currentAnimal].name;
        Debug.Log(newPath);
        GameObject finalAnimal = Instantiate(Resources.Load<GameObject>(newPath), new Vector3(0,0,0), Quaternion.identity);
        finalAnimal.transform.position = new Vector3(0, 0, 0);
        Camera.main.transform.SetParent(finalAnimal.transform);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            PlayDebug();
        }
    }
}
