using UnityEngine;

public class ButtonGame : MonoBehaviour
{
    public Transform player; // Pelaajan GameObjectin Transform
    public Transform teleportLocation; // Kohdepaikka teleportille
    public string[] correctSequence = { "Green Button", "Red Button", "Blue Button" }; // Oikea painallusjärjestys
    
    private int currentStep = 0; // Seurataan, monesko nappi on painettu oikein

    public void ButtonPressed(string buttonName)
    {
        Debug.Log($"Napin nimi: '{buttonName}', Odotettu: '{correctSequence[currentStep]}'");

        if (buttonName == correctSequence[currentStep])
        {
            Debug.Log($"✅ Oikea painallus! Seuraava vaihe: {currentStep + 1}");
            currentStep++;
            
            if (currentStep >= correctSequence.Length)
            {
                TeleportPlayer();
                currentStep = 0; // Nollataan järjestys seuraavaa kertaa varten
            }
        }
        else
        {
            Debug.Log($"❌ Väärä painallus: {buttonName}. Aloitetaan alusta.");
            currentStep = 0; // Väärä painallus -> aloitetaan alusta
        }
    }

    private void TeleportPlayer()
    {
        Debug.Log("🚀 Teleporttausmetodia kutsuttiin!");

        if (player != null && teleportLocation != null)
        {
            player.position = teleportLocation.position;
            player.rotation = teleportLocation.rotation;
        }
    }
}
