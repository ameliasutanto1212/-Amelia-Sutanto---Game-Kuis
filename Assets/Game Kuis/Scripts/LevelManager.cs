using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    //[System.Serializable]
    //private struct DataSoal
    //{
    //    public Sprite hint;
    //    public string pertanyaan;
    //    public string judulLevel;

    //    public string[] jawabanTeks;
    //    public bool[] adalahBenar;
    //}

    [SerializeField]
    private InisialDataGameplay _inisialData = null;

    [SerializeField]
    private PlayerProgress _playerProgress = null;

    [SerializeField]
    private LevelPackKuis _soalSoal = null;
    //private DataSoal[] _soalSoal = new DataSoal[0];

    [SerializeField]
    private UI_Pertanyaan _tempatPertanyaan = null;

    [SerializeField]
    private UI_PoinJawaban[] _tempatPilihanJawaban = new UI_PoinJawaban[0];

    [SerializeField]
    private GameSceneManager _gameSceneManager = null;

    [SerializeField]
    private string _namaScenePilihMenu = string.Empty;

    private int _indexSoal = -1; //0;
    //private int startSoal = 1; //true

    // Start is called before the first frame update
    private void Start()
    {
        //SEMENTARA
        //if (!_playerProgress.MuatProgres())
        //{
        //    _playerProgress.SimpanProgres();
        //}

        _soalSoal = _inisialData.levelPack;
        _indexSoal = _inisialData.levelIndex - 1;

        NextLevel();

        // Subscribe events
        UI_PoinJawaban.EventJawabSoal += UI_PoinJawaban_EventJawabSoal;
    }

    private void OnDestroy()
    {
        // Unsubscribe events
        UI_PoinJawaban.EventJawabSoal -= UI_PoinJawaban_EventJawabSoal;
    }

    private void OnApplicationQuit()
    {
        _inisialData.SaatKalah = false;
    }

    private void UI_PoinJawaban_EventJawabSoal(string jawaban, bool adalahBenar)
    {
        //throw new System.NotImplementedException();
        if (adalahBenar)
        {
            _playerProgress.progresData.koin += 20;
        }
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
        if (_indexSoal >= _soalSoal.BanyakLevel)
        //if (_indexSoal >= _soalSoal.Length)
        {
            //_indexSoal = 0;
            _gameSceneManager.BukaScene(_namaScenePilihMenu);
            return;
        }

        //Ambil data Pertanyaan
        LevelSoalKuis soal = _soalSoal.AmbilLevelKe(_indexSoal);
        //DataSoal soal = _soalSoal[_indexSoal];

        //Set informasi soal
        //_tempatPertanyaan.SetPertanyaan(soal.judulLevel, soal.pertanyaan, soal.hint);
        _tempatPertanyaan.SetPertanyaan($"Soal {_indexSoal + 1}", 
            soal.pertanyaan, soal.hint);

        for (int i = 0; i < _tempatPilihanJawaban.Length; i++)
        {
            UI_PoinJawaban poin = _tempatPilihanJawaban[i];
            LevelSoalKuis.OpsiJawaban opsi = soal.opsiJawaban[i];
            poin.SetJawaban(opsi.jawabanTeks, opsi.adalahBenar);
            //poin.SetJawaban(soal.jawabanTeks[i], soal.adalahBenar[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
