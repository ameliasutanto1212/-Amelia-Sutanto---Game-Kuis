using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Timer : MonoBehaviour
{
    [SerializeField]
    private UI_PesanLevel _tempatPesan = null;

    [SerializeField]
    private Slider _timeBar = null;

    [SerializeField]
    private float _waktuJawab = 30; // Dalam Detik

    private bool _waktuBerjalan = false; //public bool waktuBerjalan = false;

    private float _sisaWaktu = 0f; // Data Sementara

    public bool WaktuBerjalan
    {
        get => _waktuBerjalan;
        set => _waktuBerjalan = value;
    }

    // Start is called before the first frame update
    private void Start()
    {
        UlangiWaktu();
        _waktuBerjalan = true;
    }

    // Update is called once per frame
    private void Update()
    {
        if (!_waktuBerjalan)
            return;

        //Dikurangi sebanyak waktu menggambar satu frame (Second per Frame)
        _sisaWaktu -= Time.deltaTime;
        _timeBar.value = _sisaWaktu/_waktuJawab;

        if(_sisaWaktu <= 0f)
        {
            _tempatPesan.Pesan = "Waktu Sudah Habis!!!";
            _tempatPesan.gameObject.SetActive(true);
            Debug.Log("Waktu Habis");
            _waktuBerjalan = false;
            return;
        }

        //Debug.Log(_sisaWaktu);
    }
    public void UlangiWaktu()
    {
        _sisaWaktu = _waktuJawab;
    }
}
