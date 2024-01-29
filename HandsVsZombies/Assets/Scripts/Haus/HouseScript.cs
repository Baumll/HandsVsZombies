using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject houseScreamObject;
    private Screamingscript screamingscript;
    [HideInInspector] public int damage = 0;
    [HideInInspector] public int maxHP;
    private bool ZombieDamageisAktiv = false;
    
    void Start()
    {
        screamingscript = houseScreamObject.GetComponent<Screamingscript>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!ZombieDamageisAktiv)
        {
            StartCoroutine(ZombieDamage());
            ZombieDamageisAktiv = true;
        }

        if (damage >= maxHP)
        {
            Debug.Log("[House] Zombies Haben das Haus erreicht");
            GameManager.instance.GameLost();
            //StopCoroutine(ZombieDamage());
            damage = 0;
        }
        
        Debug.Log("HouseHitpoints" + damage);
    }

    private IEnumerator ZombieDamage()
    {
        yield return new WaitForSeconds(1);
        Debug.Log("ZombieDamageisAktiv");
        ZombieDamageisAktiv = false;        
        
        if (screamingscript.closestDistance <= 0.4)
        {
            damage = damage + 1;
        }
        
    }
}
