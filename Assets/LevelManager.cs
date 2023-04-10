using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [System.Serializable]
    private struct DataSoal
    {
        public Sprite hint;
        public string pertanyaan;
        public string judulLevel;

        public string[] jawabanTeks;
        public bool[] adalahBenar;
    }

    [SerializeField]
    private DataSoal[] _soalSoal = new DataSoal[0];

    [SerializeField]
    private UI_Pertanyaan _tempatPertanyaan = null;

    [SerializeField]
    private UI_PoinJawaban[] _tempatPilihanJawaban = new UI_PoinJawaban[0];

    private int _indexSoal = -1; //0;
    //private int startSoal = 1; //true

    // Start is called before the first frame update
    private void Start()
    {
        NextLevel();
    }

    public void NextLevel()
    {
        //if (startSoal == 0)
        //{
            //Soal index selanjutnya
            _indexSoal++;
        //}
        //startSoal = 0;

        //Jika index melampaui soal terakhir, ulang dari awal
        if (_indexSoal >= _soalSoal.Length)
        {
            _indexSoal = 0;
        }

        //Ambil data Pertanyaan
        DataSoal soal = _soalSoal[_indexSoal];

        //Set informasi soal
        //_tempatPertanyaan.SetPertanyaan(soal.judulLevel, soal.pertanyaan, soal.hint);
        _tempatPertanyaan.SetPertanyaan($"Soal {_indexSoal + 1}", 
            soal.pertanyaan, soal.hint);

        for (int i = 0; i < _tempatPilihanJawaban.Length; i++)
        {
            UI_PoinJawaban poin = _tempatPilihanJawaban[i];
            poin.SetJawaban(soal.jawabanTeks[i], soal.adalahBenar[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
