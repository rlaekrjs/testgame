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
        //싱글톤 생성
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
        if (player == null)//플레이어가 없다면
        {
            //시간 정지
            Time.timeScale = 0;
        }
    }
    public static float PointDirection(Vector2 pos1, Vector2 pos2)
    {
        ///점과 점사이의 각도를 알려줍니다
        Vector2 pos = pos2 - pos1;
        float angle = (float)Mathf.Atan2(pos.y, pos.x)*Mathf.Rad2Deg;
        if (angle < 0f)
            angle += 360f;
        return angle;
    }

    public static Vector3 VectorRotation(float _angle)
    {
        ///겜메 Length_x,y
        //반전화
        _angle -= 90;
        _angle *= -1;
        if (_angle < 0f)
            _angle += 360f;
        return new Vector3(Mathf.Sin(_angle * Mathf.Deg2Rad), Mathf.Cos(_angle * Mathf.Deg2Rad), 0);
    }
}
