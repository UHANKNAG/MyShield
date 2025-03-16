using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // 스크린상의 마우스 좌표를 카메라가 찍고 있는 world 좌표로 바꿔 준다
        transform.position = mousePos;
    }
}
