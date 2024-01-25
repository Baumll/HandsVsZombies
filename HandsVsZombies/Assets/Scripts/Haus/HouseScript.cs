using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject houseScreamObject;
    private Screamingscript screamingscript;
    private int damage = 0;
    
    void Start()
    {
        screamingscript = houseScreamObject.GetComponent<Screamingscript>();
        StartCoroutine(ZombieDamage());
    }

    // Update is called once per frame
    void Update()
    {
        if (damage >= 15)
        {
            Debug.Log("[House] Zombies Haben das Haus erreicht");
            GameManager.instance.GameLost();
            StopCoroutine(ZombieDamage());
            damage = 0;
        }
    }

    private IEnumerator ZombieDamage()
    {
        while (true)
        {
            if (screamingscript.closestDistance <= 0.35)
            {
                damage = damage + 1;
                yield return new WaitForSeconds(1);
            }
        }
    }
}
