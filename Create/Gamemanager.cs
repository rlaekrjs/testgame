using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gamemanager : MonoBehaviour
{
    private static Gamemanager instance = null;
    public playerMove player;
    public int score;
    public int gaugescore;
    public Text text;
    public Text gaugetext;
    public Userlnterface Heal;
    private void Start()
    {
        SetText();
    }
    void Awake()
    {
        //�̱��� ����
        if (instance != null)
            Destroy(gameObject);
        else
            instance = this;
    }
    public static Gamemanager instance_
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }
    public void SetText()
    {
        text.text = "Score : " + score.ToString();
    }
    public void gaugeText()
    {
        gaugetext.text = gaugescore.ToString() + " %";
    }
    // Update is called once per frame
    void Update()
    {
        if (player == null)//�÷��̾ ���ٸ�
        {
            //�ð� ����
            Time.timeScale = 0;
        }
    }
    public static float PointDirection(Vector2 pos1, Vector2 pos2)
    {
        ///���� �������� ������ �˷��ݴϴ�
        Vector2 pos = pos2 - pos1;
        float angle = (float)Mathf.Atan2(pos.y, pos.x)*Mathf.Rad2Deg;
        if (angle < 0f)
            angle += 360f;
        return angle;
    }

    public static Vector3 VectorRotation(float _angle)
    {
        ///�׸� Length_x,y
        //����ȭ
        _angle -= 90;
        _angle *= -1;
        if (_angle < 0f)
            _angle += 360f;
        return new Vector3(Mathf.Sin(_angle * Mathf.Deg2Rad), Mathf.Cos(_angle * Mathf.Deg2Rad), 0);
    }
}
