using UnityEngine;

public class SingletonManager<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T m_instance;

    public static T instance
    {
        get
        {
            if (m_instance==null)
            {
                GameObject obj;
                obj=GameObject.Find(typeof(T).Name);

                if (obj==null)
                {
                    obj=new GameObject(typeof(T).Name);
                    m_instance=obj.AddComponent<T>();
                }
                else
                {
                    m_instance=obj.GetComponent<T>();
                }

            }
            return m_instance;
        }
    }

    private void Awake()
    {
        //instance=this; //이걸 추가할 필요가 있을까?, 추가하면 오류 발생
    }
}
