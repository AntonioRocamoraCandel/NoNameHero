using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogosNpcs : MonoBehaviour
{
    private string[] dialogueArray1_0 = { "Sir Lancelot", "0", "Por fin sales de tu casa, estabamos empezando a olvidar tu cara" };
    private string[] dialogueArray1_1 = { "Sir Lancelot", "1", "Te iba a contar algo pero se me ha olvidado que era" };
    private string[] dialogueArray1_2 = { "Sir Lancelot", "2", "A veces es mejor olvidar el pasado y centrarse en el futuro" };
    private string[] dialogueArray1_3 = { "Sir Lancelot", "3", "Hace tiempo yo me enfrenté al guardián del libro, olvidé lo que pasó ese día" };

    private string[] dialogueArray2_0 = { "Lord Guinevere", "0", "Si quieres iniciar una buena aventura solo tienes que ir a la parte este del pueblo" };
    private string[] dialogueArray2_1 = { "Lord Guinevere", "1", "Me han dicho que en la cueva hay una mayor concentración de goblins" };
    private string[] dialogueArray2_2 = { "Lord Guinevere", "2", "Se dice que después de las cuevas hay un guardián custodiando el libro" };
    private string[] dialogueArray2_3 = { "Lord Guinevere", "3", "Manten distancia con el guardián, ya que sus ataques son muy fuertes" };

    private string[] dialogueArray3_0 = { "Toby", "0", "Guau Guau" };
    private string[] dialogueArray3_1 = { "Toby", "1", "*Mueve la colita y se deja acariciar*" };
    private string[] dialogueArray3_2 = { "Toby", "2", "*Aullido*" };
    private string[] dialogueArray3_3 = { "Toby", "3", "*Tiembla de terror y esconde su cola entre sus patas*" };

    
    private string[] dialogueArray4_0 = { "Borracho", "0", "No entiendo nada, pero tu tampoco entenderás nada cuando dés tu primer paso" };
    private string[] dialogueArray4_1 = { "Borracho", "1", "¿No te parece que en este pueblo estamos la misma gente desde hace mucho tiempo?" };
    private string[] dialogueArray4_2 = { "Borracho", "2", "¿No te has preguntado porque sales por el este y siempre vuelves por el oeste?" };
    private string[] dialogueArray4_3 = { "Borracho", "3", "Se dice que la gente que conoce su verdadero nombre nunca vuelve a este pueblo" };

    private string[] dialogueArray5_0 = { "Maribel", "0", "Hola bonito, ¿cuál es tu nombre?, si no tienes te llamaré \"No Name\"" }; 
    private string[] dialogueArray5_1 = { "Maribel", "1", "No hace falta que corras peligros, no quiero perderte... a ti también..." };
    private string[] dialogueArray5_2 = { "Maribel", "2", "\"No Name\", asegurate de volver la próxima vez que te vayas" };
    private string[] dialogueArray5_3 = { "Maribel", "3", "Ya no puedo detenerte, te daré un ramo de flores para que no me olvides... \"No Name\"..." };
    
    private string[] dialogueArray6_0 = { "Rasputin", "0", "He escuchado que los de tu especie podeis saltar en el aire y en las paredes" };
    private string[] dialogueArray6_1 = { "Rasputin", "1", "Por ahí hay tesoros tirados por el suelo, ¿te lo puedes creer?" };
    private string[] dialogueArray6_2 = { "Rasputin", "2", "¿Tu especie dominaba muy bien la magia de fuego no?, ¡No me quemes!" };
    private string[] dialogueArray6_3 = { "Rasputin", "3", "Con tus tremendos saltos no tendrás problema con la asombrosa altura del jefe, ¡Ánimo!" };

    private string[] dialogueArray7_0 = { "???", "0", "Siento mucho lo que le pasó a tu familia..." };
    private string[] dialogueArray7_1 = { "???", "1", "Yo solía ser un aventurero como tú, pero un día me dieron en la rodilla con una flecha" };
    private string[] dialogueArray7_2 = { "???", "2", "¿Tu especie no se extinguió?, debes ser un ejemplar muy valioso" };
    private string[] dialogueArray7_3 = { "???", "3", "Si mueres no te preocupes, yo estoy para encargarme de ese tipo de cosas" };
    private string[][] dialogueArrays;

    private void Start()
    {
        dialogueArrays = new string[][] {
            dialogueArray1_0,
            dialogueArray1_1,
            dialogueArray1_2,
            dialogueArray1_3,
            dialogueArray2_0,
            dialogueArray2_1,
            dialogueArray2_2,
            dialogueArray2_3,
            dialogueArray3_0,
            dialogueArray3_1,
            dialogueArray3_2,
            dialogueArray3_3,
            dialogueArray4_0,
            dialogueArray4_1,
            dialogueArray4_2,
            dialogueArray4_3,
            dialogueArray5_0,
            dialogueArray5_1,
            dialogueArray5_2,
            dialogueArray5_3,
            dialogueArray6_0,
            dialogueArray6_1,
            dialogueArray6_2,
            dialogueArray6_3,
            dialogueArray7_0,
            dialogueArray7_1,
            dialogueArray7_2,
            dialogueArray7_3
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
