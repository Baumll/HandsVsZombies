using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseHP : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject houseScreamObject;
    private ScreamingScript screamingscript;
    public int maxHP = 15;
    public int damage = 0;
    private bool ZombieDamageisAktiv = false;
    
    void Start()
    {
        screamingscript = houseScreamObject.GetComponent<ScreamingScript>();
        maxHP = 15;

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("HouseHitpoints" + damage);
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
    }

    private IEnumerator ZombieDamage()
    {
        yield return new WaitForSeconds(1);
        Debug.Log("ZombieDamageisAktiv");
        ZombieDamageisAktiv = false;        
        
        if (screamingscript.closestDistance <= 0.5)
        {
            damage = damage + 1;
        }
        
    }
}