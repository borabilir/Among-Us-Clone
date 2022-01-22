using Photon.Pun;
using UnityEngine;
using Random = UnityEngine.Random;

public class AU_GameController : MonoBehaviour
{
    private PhotonView myPv;

    private int whichPlayerIsImposter;

    public static AU_GameController instance;

    public bool numberTaskCompleted;

    // Start is called before the first frame update
    private void Start()
    {
        instance = this;
        myPv = GetComponent<PhotonView>();
        if (PhotonNetwork.IsMasterClient)
        {
            PickImposter();
        }
    }

    private void PickImposter()
    {
        whichPlayerIsImposter = Random.Range(0, PhotonNetwork.CurrentRoom.PlayerCount);
        myPv.RPC(nameof(RPC_SyncImposter), RpcTarget.All, whichPlayerIsImposter);
        Debug.Log("Imposter " + whichPlayerIsImposter);
    }

    [PunRPC]
    void RPC_SyncImposter(int playerNumber)
    {
        whichPlayerIsImposter = playerNumber;
        AU_PlayerController.localPlayer.BecomeImposter(whichPlayerIsImposter);
    }

    public void CompleteNumberTask()
    {
        numberTaskCompleted = true;
        myPv.RPC(nameof(RPC_CompleteNumberTask), RpcTarget.All, numberTaskCompleted);
    }

    [PunRPC]
    void RPC_CompleteNumberTask(bool isCompleted)
    {
        numberTaskCompleted = isCompleted;
    }
}