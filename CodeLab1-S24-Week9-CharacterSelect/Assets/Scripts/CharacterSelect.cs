using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelect : MonoBehaviour
{
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
    

    public GameObject chosenAnimal;
    
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
        Instantiate(chosenAnimal);
    }
    
    

}
