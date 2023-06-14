using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogosNpcs : MonoBehaviour
{
    public string[] dialogueArray1 = { "Sir Lancelot", "0", "Vaya día hermoso, ¿no crees? A veces olvidamos apreciar la belleza de nuestro entorno." };
    public string[] dialogueArray6 = { "Sir Lancelot", "1", "Un momento, quien eres, yo a ti te conozco" };
    public string[] dialogueArray2 = { "Lady Guinevere", "1", "¡Cuidado con la cueva de las setas! Se dice que está lleno de criaturas peligrosas." };
    public string[] dialogueArray3 = { "Sir Gawain", "1", "Dicen que la cueva de las setas está maldita, pero yo no creo en esas tonterías" };
    public string[] dialogueArray4 = { "Lady Isolde", "1", "Me encanta ver a los aventureros valientes que vienen a nuestro pueblo. " };
    public string[] dialogueArray5 = { "Sir Percival", "1", "¿Sabías que el herrero del pueblo es un excelente músico? " };

    private string[][] dialogueArrays;

    private void Start()
    {
        dialogueArrays = new string[][] {
            dialogueArray1,
            dialogueArray2,
            dialogueArray3,
            dialogueArray4,
            dialogueArray5,
            dialogueArray6
        };
    }

    public string FindDialogueByPositions(string name, string vuelta)
    {
        foreach (string[] dialogueArray in dialogueArrays)
        {
            if (dialogueArray.Length >= 3 && dialogueArray[0] == name && dialogueArray[1] == vuelta)
            {
                return dialogueArray[2];
            }
        }
        return null; // Si no se encuentra ninguna coincidencia
    }
}
