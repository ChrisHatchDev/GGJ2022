using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TumorType
{
    one,
    two,
    three,
}

public class Tumor : MonoBehaviour
{
    public TumorType type;

    public float Size;
    public bool Healed;

    public Animator anim;

    public List<GameObject> tumorModels = new List<GameObject>();

    #if UNITY_EDITOR
    private void OnValidate()
    {
        if(GetComponent<SphereCollider>() != null)
        {
            Size = GetComponent<SphereCollider>().radius;
        }

        switch (type)
        {
            case TumorType.one:
                tumorModels[0].SetActive(true);
                tumorModels[1].SetActive(false);
                tumorModels[2].SetActive(false);
            break;

            case TumorType.two:
                tumorModels[0].SetActive(false);
                tumorModels[1].SetActive(true);
                tumorModels[2].SetActive(false);
            break;

            case TumorType.three:
                tumorModels[0].SetActive(false);
                tumorModels[1].SetActive(false);
                tumorModels[2].SetActive(true);
            break;

            default:
                tumorModels[0].SetActive(true);
                tumorModels[1].SetActive(false);
                tumorModels[2].SetActive(false);
            break;
        }
    }
    #endif

    public void Heal()
    {
        Healed = true;

        if (anim)
        {
            anim.SetTrigger("healed");
        }
    }

    public void DestroyTumor()
    {
        this.gameObject.SetActive(false);
    }
}
