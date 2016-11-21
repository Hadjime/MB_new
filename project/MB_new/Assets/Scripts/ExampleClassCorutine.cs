using UnityEngine;
using System.Collections;

public class ExampleClass : MonoBehaviour
{
    // [SerializeField] делает приватные переменные видимыми в инспекторе, но все так же недоступными из другиз скриптов
    [SerializeField]
    private bool isTestingUpdateCoroutine = false;
    [SerializeField]
    private bool isTestingStartCoroutine = false;
    [SerializeField]
    private bool isTestingNextFixedUpdate = false;
    /*
    Продолжить после следующего FixedUpdate:
    yield return new WaitForFixedUpdate();


    Продолжить после следующего LateUpdate и рендеринга сцены:
    yield return new WaitForEndOfFrame();


    Продолжить через некоторое время:
    yield return new WaitForSeconds(0.1f); // продолжить примерно через 100ms


    Продолжить по завершению другого корутина:
    yield return StartCoroutine(AnotherCoroutine());


    Продолжить после загрузки удаленного ресурса:
    yield return new WWW(someLink);


    Все прочие возвращаемые значения указывают, что нужно продолжить после прохода текущей итерации цикла Update:
    yield return null;


    Выйти из корутина можно так:
    yield return break;

    */


    IEnumerator WaitAndPrint()
    {
		while (true) {
			print ("start cor!");
			yield return new WaitForSeconds (5);
			print ("WaitAndPrint " + Time.time);
		}
    }

    IEnumerator Start()
    {
        if (isTestingStartCoroutine)
        {
            // Вызов функции Старта через Coroutine 
            // все что до yield return StartCoroutine("WaitAndPrint"); сработает как обычный старт с задержкой в 0 секунд
            print("Starting " + Time.time);

            // Start function WaitAndPrint as a coroutine
            yield return StartCoroutine("WaitAndPrint");
            // вызов произойдет после выполнения IEnumerator WaitAndPrint() (получается что старт вызывается инвоком, только по канону 
            print("Done " + Time.time);
        }
    }

    IEnumerator Example()
    {
        yield return new WaitForFixedUpdate();
        Debug.Log("Start on next FixedUpdate " + Time.time);
    }

    void Awake()
    {
        if (isTestingUpdateCoroutine)
        {
            StartCoroutine(TestCoroutine());
        }

        if (isTestingNextFixedUpdate)
        {
            StartCoroutine("Example");
        }
    }

    IEnumerator TestCoroutine()
    {
        while (true)
        {
            yield return null;
            Debug.Log("Вызов " + Time.deltaTime);
        }
        /*
         * Следует обратить внимание на то, что в корутине сначала вызывается yield return null, и только потом идет запись в лог.
         * В нашем случае это имеет значение, потому что выполнение корутина начинается в момент вызова StartCoroutine(TestCoroutine()), 
         * а переход к следующему блоку кода после yield return null будет осуществлён после метода Update, 
         * так что и до и после первого yield return null Time.deltaTime будет указывать на одно и то же значение.
         */
    }
}