using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloweGameOptions : MonoBehaviour
{

    [Header("Curent View")]
    [SerializeField] public GameObject UsedPrefab; // �������� ��������������� ��������
    [Header("Water Animation")]
    [SerializeField] public float waterMinY = -750f; // ����������� ������� ����
    [SerializeField] public float waterMaxY = -150f;  // ������������ ������� ����
    [SerializeField] public float waterHorizontalRange = 50f; // �������� ��������������� ��������
    [SerializeField] public float waterHorizontalSpeed = 2f; // �������� ��������������� ��������

    [Header("Game Settings")]
    public float indicatorSpeed = 100f;
    public float trackHeight = 300f; // ������ ���� ��� ����
    public float zoneHeight = 75f;
    public int maxAttempts = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
