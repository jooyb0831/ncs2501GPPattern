using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public interface IProduct
{
    public string ProductName{get;set;}

    public void Initialize();
}

public abstract class Factory : MonoBehaviour
{
    public abstract IProduct GetProduct(Vector3 posiiton);

    //모든 공장이 공유하는 매서드
}

public class ProductA : MonoBehaviour, IProduct
{
    [SerializeField] string productName = "ProductA";
    ParticleSystem particleSystem;

    public string ProductName
    {
        get => productName;
        set => productName = value;
    }

    public void Initialize()
    {
        //이 제품에 대한 모든 고유 로직
        gameObject.name = productName;
        particleSystem = GetComponentInChildren<ParticleSystem>();
        particleSystem?.Stop();
        particleSystem?.Play();
    }
}

public class ConcreteFactoryA : Factory
{
    [SerializeField] private ProductA productPrefab;

    public override IProduct GetProduct(Vector3 posiiton)
    {
        //프리팹 인스턴스를 생성하고 제품 컴포넌트 가져오기
        GameObject instance = Instantiate(productPrefab.gameObject, posiiton, Quaternion.identity);
        ProductA newProduct = instance.GetComponent<ProductA>();

        //각 제품에 자체 로직 포함
        newProduct.Initialize();

        return newProduct;
    }
}

public class FactoryPattern : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
