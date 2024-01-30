using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] string CharacterName = "N/A";
    [SerializeField] int ProficiencyBonus = 0;
    [SerializeField] bool UsingFinesseWeapon = false;
    [SerializeField] [Range(-5,5)] int StrengthModifier = 0;
    [SerializeField] [Range(-5,5)] int DexterityModifier = 0;

    //UnSeralized Variable to store the final caluclation of the hit modifier
    int HitModifier = 0;


    void Start()
    {
        //Roll d20 rolls for player hit and enemy AC
        int _playerD20Roll = RollD20Die();
        int _enemyD20Roll = RollD20Die();

        //Calculates the Players HitModifier
        FindHitModifierValue();

        //Displays Character Name and the calculated HitModifier that was found
        DisplayCharacterHitModifier();

        //Display Enemy AC
        Debug.Log("Enemy AC is: " + _enemyD20Roll);

        //Display Player Die Roll
        Debug.Log(CharacterName + " rolled a " + _playerD20Roll);

        //Determine if Player Hits Enemy or Not
        //If players d20 roll plus their hit modifier is greater than enemies AC d20 roll, then player hits
        //Else players attack misses
        if (_playerD20Roll + HitModifier >= _enemyD20Roll)
        {
            Debug.Log("Player hit enemy!");
        }
        else
        {
            Debug.Log("Enemy avoids attack!");
        }


    }


    void FindHitModifierValue()
    {
        //Temporary value to store what will be the final modifier value
        int _finalHitModiferValue = 0;


        //If using Finesse Weapon, determine if Stength of Dexterity is greater
        if (UsingFinesseWeapon)
        {
            //Check if Strenght Modifier is greater than Dexterity Modifier
            //If so, then add the value of Strength Modifier to final Modifier value
            //Else add Dexeterity Modifier to final Modifier
            if(StrengthModifier > DexterityModifier)
            {
                _finalHitModiferValue += StrengthModifier;
            }
            else 
            {
                _finalHitModiferValue += DexterityModifier;
            }
        }
        //Add Strength Modifier only if not using Finesse Weapon
        else
        {
            _finalHitModiferValue += StrengthModifier;
        }


        //Add final Proficenecy Bonus Modifier
        _finalHitModiferValue += ProficiencyBonus;



        //Assign HitModifier to the final modifier calculated
        HitModifier = _finalHitModiferValue;

    }

    void DisplayCharacterHitModifier()
    {
        Debug.Log(CharacterName + "'s hit modifier is: " + DisplayNumberWithSign(HitModifier));
    }

    string DisplayNumberWithSign(int _numToFindSign)
    {
        //Tempoaray String to store the sign and the numbers of the sign to find as a string for displaying
        string _returnString;

        //If value of parameter is greater than or equal to 0, add the + sign to front of string
        if(_numToFindSign >= 0)
        {
            _returnString = "+" + _numToFindSign.ToString();
        }
        //Else if value is less than 0, add the - sign to the end
        else
        {
            _returnString = _numToFindSign.ToString();
        }


        return _returnString;
    }

    int RollD20Die()
    {
        //Max value in Random Range is 21 due to Range with intergers being exclusive of max
        return Random.Range(1, 21);
    }



}
