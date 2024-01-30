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

        houseScript = house.GetComponent<HouseHP>();
        

    }

    void Update()
    {        
        Color healthColor = Color.Lerp(Color.green, Color.red, houseScript.damage / houseScript.maxHP);
        image.color = healthColor;
        image.fillAmount = (houseScript.maxHP - houseScript.damage) / houseScript.maxHP;
    }
}