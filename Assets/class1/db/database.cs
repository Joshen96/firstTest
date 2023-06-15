using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;
using UnityEngine.UI;
using System.Security.Cryptography;
using System;
using UnityEngine.Rendering;


public class database : MonoBehaviour
{
    [SerializeField]
    GameObject textPrefab = null;
    [SerializeField]
    GameObject Content = null;

    public class Dataschedule
    {
        public string subject { get; set; }
        public string teacher { get; set; }

        public string classroom { get; set; }
        public int dotw { get; set; }

        public int classtime { get; set; }
    }


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            uploadDB();
        }
    }
    // Start is called before the first frame update
    private IEnumerator GetLoginCoroutine()
    {
        using (UnityWebRequest www =
            UnityWebRequest.Post("http://localhost/getchedule.php", ""))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ProtocolError)
            {
                //Debug.Log(www.error);
            }
            else
            {
                //Debug.Log("핸들러 " + www.downloadHandler.text);
                string data = www.downloadHandler.text; //텍스트로 받아온다

                List<Dataschedule> datainfos =
                   JsonConvert.DeserializeObject<List<Dataschedule>>(data); //역직열화 숫자는 인트 같은작업을 해준다 제이슨사용이유
                //목록으로 만들어줌

                foreach (Dataschedule datainfo in datainfos)
                {
                   // Debug.Log(datainfo.subject + " : " + datainfo.teacher + " : " + datainfo.classroom);



                    GameObject subjecttext = GameObject.Instantiate(textPrefab, Content.transform);
                    //GameObject nametext = GameObject.Instantiate(textPrefab, Content.transform);
                   // GameObject agetext = GameObject.Instantiate(textPrefab, Content.transform);
                    Text text1 = subjecttext.GetComponent<Text>();
                    //Text text2 = nametext.GetComponent<Text>();
                    //Text text3 = agetext.GetComponent<Text>();
                    //text1.text = string.Format("아이디 : [ {0,10} ] 이름 : [ {1,8} ] 나이 : [ {2,4} ]", datainfo.id, datainfo.name,datainfo.age);
                    text1.text = string.Format("{0}\n{1}\n{2}", datainfo.subject,datainfo.teacher,datainfo.classroom);
                    //text2.text = string.Format("{0}", datainfo.teacher);
                    //text3.text = string.Format("{0}", datainfo.classroom);
                    //text.transform.parent = Content.transform;

                }
            }
        }
    }
    public void uploadDB()
    {
        StartCoroutine(GetLoginCoroutine());
    }
}
