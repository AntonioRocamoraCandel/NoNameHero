using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogosNpcs : MonoBehaviour
{
    private string[] dialogueArray1_0 = { "Sir Lancelot", "0", "Vaya día hermoso, ¿no crees? A veces olvidamos apreciar la belleza de nuestro entorno." };
    private string[] dialogueArray1_1 = { "Sir Lancelot", "1", "Vaya día hermoso, ¿no crees? A veces olvidamos apreciar la belleza de nuestro entorno." };
    private string[] dialogueArray1_2 = { "Sir Lancelot", "2", "Vaya día hermoso, ¿no crees? A veces olvidamos apreciar la belleza de nuestro entorno." };
    
    private string[] dialogueArray2_0 = { "Lord Guinevere", "0", "¡Cuidado con la cueva de las setas! Se dice que está lleno de criaturas peligrosas." };
    private string[] dialogueArray2_1 = { "Lord Guinevere", "1", "¡Cuidado con la cueva de las setas! Se dice que está lleno de criaturas peligrosas." };
    private string[] dialogueArray2_2 = { "Lord Guinevere", "2", "¡Cuidado con la cueva de las setas! Se dice que está lleno de criaturas peligrosas." };
    
    private string[] dialogueArray3_0 = { "Toby", "0", "Guau Guau" };
    private string[] dialogueArray3_1 = { "Toby", "1", "*Mueve la colita y se deja acariciar*" };
    private string[] dialogueArray3_2 = { "Toby", "2", "*Aullido*" };

    
    private string[] dialogueArray4_0 = { "Lady Isolde", "0", "Me encanta ver a los aventureros valientes que vienen a nuestro pueblo. " };
    private string[] dialogueArray4_1 = { "Lady Isolde", "1", "Me encanta ver a los aventureros valientes que vienen a nuestro pueblo. " };
    private string[] dialogueArray4_2 = { "Lady Isolde", "2", "Me encanta ver a los aventureros valientes que vienen a nuestro pueblo. " };

    private string[] dialogueArray5_0 = { "Sir Percival", "0", "¿Sabías que el herrero del pueblo es un excelente músico? " };
    private string[] dialogueArray5_1 = { "Sir Percival", "1", "¿Sabías que el herrero del pueblo es un excelente músico? " };
    private string[] dialogueArray5_2 = { "Sir Percival", "2", "¿Sabías que el herrero del pueblo es un excelente músico? " };
    
    private string[] dialogueArray6_0 = { "Rasputin", "0", "Un momento, quien eres, yo a ti te conozco" };
    private string[] dialogueArray6_1 = { "Rasputin", "1", "Un momento, quien eres, yo a ti te conozco" };
    private string[] dialogueArray6_2 = { "Rasputin", "2", "Un momento, quien eres, yo a ti te conozco" };

    private string[] dialogueArray7_0 = { "Vagabundo", "0", "¿Sabías que el herrero del pueblo es un excelente músico? " };
    private string[] dialogueArray7_1 = { "Vagabundo", "1", "¿Sabías que el herrero del pueblo es un excelente músico? " };
    private string[] dialogueArray7_2 = { "Vagabundo", "2", "¿Sabías que el herrero del pueblo es un excelente músico? " };
    private string[][] dialogueArrays;

    private void Start()
    {
        dialogueArrays = new string[][] {
            dialogueArray1_0,
            dialogueArray1_1,
            dialogueArray1_2,
            dialogueArray2_0,
            dialogueArray2_1,
            dialogueArray2_2,
            dialogueArray3_0,
            dialogueArray3_1,
            dialogueArray3_2,
            dialogueArray4_0,
            dialogueArray4_1,
            dialogueArray4_2,
            dialogueArray5_0,
            dialogueArray5_1,
            dialogueArray5_2,
            dialogueArray6_0,
            dialogueArray6_1,
            dialogueArray6_2,
            dialogueArray7_0,
            dialogueArray7_1,
            dialogueArray7_2
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
