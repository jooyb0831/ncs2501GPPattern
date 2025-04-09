using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool; //유니티에서 제공해주는 ObjectPool이 있음.

public class PooledObject : MonoBehaviour
{
    ObjectPool pool;
    public ObjectPool Pool { get => pool; set => pool = value; }
    public void Release()
    {
        pool.ReturnToPool(this);
    }
}
public class ObjectPool : MonoBehaviour
{
    [SerializeField] private uint initPoolSize; //부호가 없는 int. 0에서부터 시작하는 더 큰.
    [SerializeField] private PooledObject objectToPool;

    //풀링된 오브젝트를 컬렉션에 저장
    private Stack<PooledObject> stack;
    // Start is called before the first frame update
    void Start()
    {
        SetupPool();
    }

    //풀 생성(지연을 인지할 수 없을 때 호출)
    private void SetupPool()
    {
        stack = new Stack<PooledObject>();
        PooledObject instance = null;
        for (int i = 0; i < initPoolSize; i++)
        {
            instance = Instantiate(objectToPool);
            instance.Pool = this;
            instance.gameObject.SetActive(false);
            stack.Push(instance);
        }
    }

    //풀에서 첫 번째 액티브 게임 오브젝트를 반환합니다.
    public PooledObject GetPooledObject()
    {
        //풀이 충분히 크지 않으면 새로운 PooledObjects를 인스턴스화 함
        if(stack.Count == 0)
        {
            PooledObject newInstance = Instantiate(objectToPool);
            newInstance.Pool = this;
            return newInstance;
        }
        //그렇지 않으면 목록에서 다음 항목을 가져옴
        PooledObject nextInstance = stack.Pop();
        nextInstance.gameObject.SetActive(true);
        return nextInstance;
    }

    public void ReturnToPool(PooledObject pooledObject)
    {
        stack.Push(pooledObject);
        pooledObject.gameObject.SetActive(false);
    }
}
