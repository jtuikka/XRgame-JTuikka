using UnityEngine;

public class ButtonGame : MonoBehaviour
{
    public Transform player; // Pelaajan GameObjectin Transform
    public Transform teleportLocation; // Kohdepaikka teleportille
    public string[] correctSequence = { "GreenButton", "RedButton", "BlueButton" }; // Oikea painallusjärjestys
    
    private int currentStep = 0; // Seurataan, monesko nappi on painettu oikein

    public void ButtonPressed(string buttonName)
    {
        if (buttonName == correctSequence[currentStep])
        {
            currentStep++;
            
            if (currentStep >= correctSequence.Length)
            {
                TeleportPlayer();
                currentStep = 0; // Nollataan järjestys seuraavaa kertaa varten
            }
        }
        else
        {
            currentStep = 0; // Väärä painallus -> aloitetaan alusta
        }
    }

    private void TeleportPlayer()
    {
        if (player != null && teleportLocation != null)
        {
            player.position = teleportLocation.position;
            player.rotation = teleportLocation.rotation;
        }
    }
}
