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
    public string characterDesc;

    public float characterSpeed;

    public GameObject animalObject;

    public void UpdateStats(CharacterSelect gm)
    {
        gm.nameUI.text = characterName;
        gm.speedUI.text = "speed: " + characterSpeed;
        gm.descUI.text = characterDesc;
    }
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
