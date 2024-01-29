using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public RawImage healthBarImage;
    [SerializeField] private RectTransform healthbarTransform;
    

    private Transform playerTransform;
    [SerializeField] private GameObject house;
    private HouseScript houseScript;

    void Start()
    {
        if (healthBarImage == null)
            healthBarImage = GetComponent<RawImage>();

        houseScript = house.GetComponent<HouseScript>();
        
        if (Camera.main != null)
        {
            playerTransform = Camera.main.transform;
        }
    }

    void Update()
    {
        if (playerTransform != null)
        {

            transform.LookAt(playerTransform);
        }
        
        Color healthColor = Color.Lerp(Color.red, Color.green, houseScript.damage / houseScript.maxHP);
        healthBarImage.color = healthColor;

        float healthbarWidth = Mathf.Lerp(0.5f, 0f, houseScript.damage / houseScript.maxHP);
        healthbarTransform.localScale = new Vector3(healthbarWidth, healthbarTransform.localScale.y, healthbarTransform.localScale.z);
    }
}