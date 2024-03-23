using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseHP : MonoBehaviour
{

    [SerializeField] private GameObject houseScreamObject;
    private Screaming screamingscript;
    public float maxHP = 15;
    public float damage = 0;
    private bool ZombieDamageisAktiv = false;
    public AudioSource loseSound;
    
    void Start()
    {
        screamingscript = houseScreamObject.GetComponent<Screaming>();

    }


    void Update()
    {
        //Wiederholen der Schadenskalkulation aller 1 Sekunde
        if (!ZombieDamageisAktiv)
        {
            StartCoroutine(ZombieDamage());
            ZombieDamageisAktiv = true;
        }

        //Wenn der Schadenswert den maximalen Lebenspunktewert erreicht, gilt das Spiel als verloren und ein entsprechendes GameOver Geräusch wird abgespielt
        if (damage >= maxHP)
        {
            Debug.Log("[House] Zombies Haben das Haus erreicht");
            
            GameManager.Instance.GameLost();
            loseSound.Play();
            damage = 0;
        }
    }

    //Aller einer Sekunde wird dem Haus 1 Schadenspunkt hinzugefügt, wenn sich ein Zombie daneben befindet
    //Die Distanz des nahesten Zombies wird aus dem "Screaming"-Script übernommen
    private IEnumerator ZombieDamage()
    {
        yield return new WaitForSeconds(1);
        ZombieDamageisAktiv = false;        
        
        if (screamingscript.closestDistance <= 0.5 && screamingscript.zombies.Length > 0)
        {
            damage = damage + 1;
        }
        
    }
}