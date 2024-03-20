using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public RawImage healthBarImage;
    

    [SerializeField] private GameObject house;
    private HouseHP houseScript;
    private Image image;

    void Start()
    {
        image = GetComponent<Image>();
        if (healthBarImage == null)
            healthBarImage = GetComponent<RawImage>();

        //Schadenswerte und maximale Lebenspunkte werden von "HauseHP"-Script übernommen
        houseScript = house.GetComponent<HouseHP>();
        

    }

    void Update()
    {        
        //Mit zunehmendem Schaden wandelt sich die Farbe der Lebensanzeige von grün zu rot und wird zusätzlich kleiner (aber bleibt dennoch gut sichtbar)
        Color healthColor = Color.Lerp(Color.green, Color.red, houseScript.damage / houseScript.maxHP);
        image.color = healthColor;
        image.fillAmount = (houseScript.maxHP - houseScript.damage) / houseScript.maxHP;
    }
}