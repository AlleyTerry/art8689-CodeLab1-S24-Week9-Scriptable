using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu (fileName = "New Character", 
                  menuName = "New Character",
                  order = 0)]
public class CharacterScriptable : ScriptableObject
{
    public static CharacterScriptable instance;
    public string characterName;

    public float characterSpeed;

    public GameObject animalObject;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
