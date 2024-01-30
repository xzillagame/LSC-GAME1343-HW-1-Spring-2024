using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] string CharacterName;
    [SerializeField] int ProficiencyBonus;
    [SerializeField] bool UsingFinesseWeapon;
    [SerializeField] [Range(-5,5)] int StrengthModifier;
    [SerializeField] [Range(-5,5)] int DexterityModifier;



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
