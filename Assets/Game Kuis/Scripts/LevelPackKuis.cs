//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(
    fileName = "Level Pack Baru",
    menuName = "Game Kuis/Level Pack Kuis")]
public class LevelPackKuis : ScriptableObject
{
    [SerializeField]
    private LevelSoalKuis[] _isiLevel = new LevelSoalKuis[0];

    [SerializeField]
    private int _harga = 0;

    public int BanyakLevel => _isiLevel.Length;

    public int Harga => _harga;

    public LevelSoalKuis AmbilLevelKe(int index)
    {
        return _isiLevel[index];
    }

    // Start is called before the first frame update
    //void Start()
    //{
        
    //}

    // Update is called once per frame
    //void Update()
    //{
        
    //}
}
