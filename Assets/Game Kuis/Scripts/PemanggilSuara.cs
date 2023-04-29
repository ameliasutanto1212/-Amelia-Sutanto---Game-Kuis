using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PemanggilSuara : MonoBehaviour
{
    public void PanggilSuara(AudioClip suara)
    {
        AudioManager.instance.PlaySFX(suara);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
