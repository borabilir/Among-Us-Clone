using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaitingRoomController : MonoBehaviour
{
    PhotonView myPV;

    [SerializeField] float timeToStart;
    float timerToStart;
    bool readyToStart;

    [SerializeField] GameObject StartButton;
    [SerializeField] TextMeshProUGUI countDownDisplay;

    [SerializeField] int nextLevel;

    // Start is called before the first frame update
    void Start()
    {
        myPV = GetComponent<PhotonView>();
        timerToStart = timeToStart;
    }

    // Update is called once per frame
    void Update()
    {
        StartButton.SetActive(PhotonNetwork.IsMasterClient);

        if (PhotonNetwork.IsMasterClient)
        {
            if (readyToStart)
            {
                timerToStart -= Time.deltaTime;
                countDownDisplay.text = ((int)timerToStart).ToString();
            }
            else
            {
                timerToStart = timeToStart;
                countDownDisplay.text = string.Empty;
            }
            if (PhotonNetwork.IsMasterClient)
            {
                if (timerToStart <= 0)
                {
                    timerToStart = 100;
                    PhotonNetwork.AutomaticallySyncScene = true;
                    PhotonNetwork.LoadLevel(nextLevel);
                }
            }
        }
    }

    public void Play()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            myPV.RPC(nameof(RPC_Play), RpcTarget.All);
        }
    }

    [PunRPC]
    void RPC_Play()
    {
        readyToStart = !readyToStart;
    }

}
