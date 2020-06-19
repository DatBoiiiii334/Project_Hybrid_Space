using UnityEngine;

public class CursedPatient : MonoBehaviour, IChangable
{
    public static CursedPatient instance = null;

    //private MeshFilter RegularPatientMesh;
    //public Mesh NormalMesh;
    //public Mesh ZombiePatientMesh;
    //public Mesh ShroomPatientMesh;
    //public Mesh EmptyPatientMesh;
    //public Mesh UnHolyPatientMesh;

    public GameObject StandaartPatient;
    public GameObject EmptyPatient;
    public GameObject ZombiePatient;
    public GameObject ShroomPatient;
    public GameObject UnholyPatient;
    public GameObject PalePatient;

    public bool TurnZombie;
    public bool TurnShroom;
    public bool TurnEmpty;
    public bool TurnUnholy;
    public bool TurnNormal;
    public bool TurnPale;

    public bool CanBeStabbed;

    private void Start()
    {
        //RegularPatientMesh = gameObject.GetComponent<MeshFilter>();
        //NormalMesh = RegularPatientMesh.mesh;
    }

    private void Update()
    {
        if (TurnZombie) {
            TurnPatientZombie();
            CanBeStabbed = true;
            TurnZombie = false;
        }
        if (TurnShroom) {
            TurnPatientShroom();
            CanBeStabbed = true;
            TurnShroom = false;
        }
        if (TurnEmpty) {
            TurnPatientEmpty();
            CanBeStabbed = false;
            TurnEmpty = false;
        }
        if (TurnUnholy) {
            TurnPatientUnholy();
            CanBeStabbed = true;
            TurnUnholy = false;
        }
        if (TurnNormal) {
            TurnPatientNormal();
            CanBeStabbed = true;
            TurnNormal = false;
        }
        if (TurnPale) {
            TurnPatientPale();
            CanBeStabbed = true;
            TurnPale = false;
        }
    }

    public void TurnPatientNormal()
    {
        //RegularPatientMesh.mesh = NormalMesh;
        PalePatient.SetActive(false);
        EmptyPatient.SetActive(false);
        StandaartPatient.SetActive(true);
        ZombiePatient.SetActive(false);
        ShroomPatient.SetActive(false);
        UnholyPatient.SetActive(false);
    }

    public void TurnPatientZombie()
    {
        //RegularPatientMesh.mesh = ZombiePatientMesh;
        PalePatient.SetActive(false);
        EmptyPatient.SetActive(false);
        StandaartPatient.SetActive(false);
        ZombiePatient.SetActive(true);
        ShroomPatient.SetActive(false);
        UnholyPatient.SetActive(false);
    }

    public void TurnPatientShroom()
    {
        //RegularPatientMesh.mesh = ShroomPatientMesh;
        PalePatient.SetActive(false);
        EmptyPatient.SetActive(false);
        StandaartPatient.SetActive(false);
        ZombiePatient.SetActive(false);
        ShroomPatient.SetActive(true);
        UnholyPatient.SetActive(false);
    }

    public void TurnPatientEmpty()
    {
        //Debug.Log("Working on turning patient");
        //RegularPatientMesh.mesh = EmptyPatientMesh;
        PalePatient.SetActive(false);
        EmptyPatient.SetActive(true);
        StandaartPatient.SetActive(false);
        ZombiePatient.SetActive(false);
        ShroomPatient.SetActive(false);
        UnholyPatient.SetActive(false);
        //Debug.Log("Empty Patient");
    }

    public void TurnPatientUnholy()
    {
        // RegularPatientMesh.mesh = UnHolyPatientMesh;
        PalePatient.SetActive(false);
        EmptyPatient.SetActive(false);
        StandaartPatient.SetActive(false);
        ZombiePatient.SetActive(false);
        ShroomPatient.SetActive(false);
        UnholyPatient.SetActive(true);

    }

    public void TurnPatientPale()
    {
        EmptyPatient.SetActive(false);
        StandaartPatient.SetActive(false);
        ZombiePatient.SetActive(false);
        ShroomPatient.SetActive(false);
        UnholyPatient.SetActive(false);
        PalePatient.SetActive(true);
    }
}
