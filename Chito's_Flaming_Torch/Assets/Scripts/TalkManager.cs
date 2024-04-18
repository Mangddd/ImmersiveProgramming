    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    using TMPro;
    using UnityEngine.XR.ARFoundation;
    using UnityEngine.XR.ARSubsystems;


    public class TalkManager : MonoBehaviour
    {
        private bool touchPressed;
        private Vector3 touchPosition;
        public TMP_Text Message;
        public Sprite[] sprites;
        int clickCount = 0;


        void Update()
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                touchPressed = true;
                touchPosition = Input.GetTouch(0).position;
            }


        }

        void FixedUpdate()
        {

            Ray ray = Camera.main.ScreenPointToRay(touchPosition);
            RaycastHit hit;

            if (touchPressed && Physics.Raycast(ray, out hit))
            {

                if (clickCount == 0)
                {
                    GameObject.Find("Character").GetComponent<Image>().sprite = sprites[0];
                    Message.SetText("Hi");
                    clickCount++;
                }


                else if (clickCount == 1)
                {
                    GameObject.Find("Character").GetComponent<Image>().sprite = sprites[1];
                }



                Debug.Log(clickCount);

            }

            touchPressed = false;

        }

    }
