using UnityEngine;

public class showNumberScript : MonoBehaviour
{
    private TextMesh op;

    // Start is called before the first frame update
    private showNumberScript()
    {

        op = null;
    }

    private void Start()
    {
        op = gameObject.GetComponent<TextMesh>();


    }

    // Update is called once per frame
    private void Update()
    {


        gameObject.transform.parent.gameObject.SendMessage("getInputCode", gameObject.name,
            SendMessageOptions.DontRequireReceiver);

    }

    public void receive(string message)
    {
        if (op != null)
            op.text = message;
       
    }
    public void receive(Color col)
    {
        if (op != null)
            op.color = col;
    }

}
