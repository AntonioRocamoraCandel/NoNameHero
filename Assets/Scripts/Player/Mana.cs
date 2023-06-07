using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Mana : MonoBehaviour
{
    public Slider visualMana;
    public float mana;
    public int costoMana;
    

    private void Start(){
        StartCoroutine(tiempo());
    }

    public void Update()
    {
        visualMana.GetComponent<Slider>().value = mana;
        if (InputSystem.GetDevice<Keyboard>() != null)
        {
            if (Keyboard.current[Key.Q].wasPressedThisFrame && mana >= costoMana)
            {
                mana -=costoMana;
            }
        }
        else if (InputSystem.GetDevice<Gamepad>() != null)
        {
            if (Gamepad.current.leftTrigger.wasPressedThisFrame && mana >= costoMana)
            {
                mana -=costoMana;
            }
        }
    }

    IEnumerator tiempo()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            if(mana < 100){
                mana+=1;
            }
        }
    }
}
