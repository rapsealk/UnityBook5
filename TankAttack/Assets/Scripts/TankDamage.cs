using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TankDamage : MonoBehaviour
{
    public Canvas hudCanvas;
    public Image hpBar;

    private MeshRenderer[] renderers;
    private GameObject expEffect = null;
    private int initHp = 100;
    private int currHp = 0;

    void Awake()
    {
        renderers = GetComponentsInChildren<MeshRenderer>();

        currHp = initHp;

        expEffect = Resources.Load<GameObject>("Large Explosion");

        hpBar.color = Color.green;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collider)
    {
        if (currHp > 0 && collider.GetComponent<Collider>().tag == "Cannon")
        {
            currHp -= 20;

            hpBar.fillAmount = (float) currHp / (float) initHp;

            if (hpBar.fillAmount <= 0.4f)
            {
                hpBar.color = Color.red;
            }
            else if (hpBar.fillAmount <= 0.6f)
            {
                hpBar.color = Color.yellow;
            }

            if (currHp <= 0)
            {
                StartCoroutine(ExplosionTank());
            }
        }
    }

    IEnumerator ExplosionTank()
    {
        Object effect = GameObject.Instantiate(expEffect, transform.position, Quaternion.identity);
        Destroy(effect, 3.0f);

        hudCanvas.enabled = false;

        SetTankVisible(false);

        yield return new WaitForSeconds(3.0f);

        hpBar.fillAmount = 1.0f;
        hpBar.color = Color.green;
        hudCanvas.enabled = true;

        currHp = initHp;
        SetTankVisible(true);
    }

    void SetTankVisible(bool isVisible)
    {
        foreach (MeshRenderer _renderer in renderers)
        {
            _renderer.enabled = isVisible;
        }
    }
}
