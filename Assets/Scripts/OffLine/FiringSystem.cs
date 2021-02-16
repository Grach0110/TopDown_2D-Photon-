using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Система стрельбы
/// </summary>
public class FiringSystem : MonoBehaviour
{
    [SerializeField] GameObject imageWeapon;
    [SerializeField] Sprite[] spriteGuns;
    /// <summary>
    /// Текст с боеприпасами
    /// </summary>
    [SerializeField] Text textAmmo;

    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Sprite[] sprites;
    /// <summary>
    /// Обновить спрайт
    /// </summary>
    public bool updateSprite;

    /// <summary>
    /// Пистолет в наличии
    /// </summary>
    public bool pistol;
    /// <summary>
    /// Глушитель в наличии
    /// </summary>
    public bool silencer;

    /// <summary>
    /// Префаб пули
    /// </summary>
    [SerializeField] GameObject bullet;
    /// <summary>
    /// Точка выстрела
    /// </summary>
    [SerializeField] Transform spawnBullet;

    /// <summary>
    /// Время перезорядки обоймы
    /// </summary>
    public float timeReload = 5f;
    /// <summary>
    /// Таймер перезарядки обоймы
    /// </summary>
    private float timerReload;
    /// <summary>
    /// Обойма перезарежена
    /// </summary>
    private bool isReadyClip;

    //public float timeDlayBeforeFirinf = 1f; // задержка перед выстрелом
    //public float timerDelayBeforeFirinf; // таймер

    /// <summary>
    /// Готов к стрельбе
    /// </summary>
    private bool isRedyShoot;
    /// <summary>
    /// Количество обойм
    /// </summary>
    public int clip = 3;
    /// <summary>
    /// Количество патрон в обойме
    /// </summary>
    public int bulletInClip = 9;

    private void Start()
    {
        //timerReload = timeReload;
        textAmmo.GetComponent<Text>();

        textAmmo.text = clip + " / " + bulletInClip;
        imageWeapon.GetComponent<Image>();
    }

    private void Update()
    {
        if (updateSprite)
        {
            UpdateSprite(updateSprite);
        }
        if (!isRedyShoot && pistol)
        {
            Reload();
        }
        if (clip <= 0)
        {
            isReadyClip = false;
        }
        //TestDev();
    
    }

    /// <summary>
    /// Обновить спрайт
    /// </summary>
    private void UpdateSprite(bool _s)
    {
        if (updateSprite)
        {
            if (pistol)
            {
                spriteRenderer.sprite = sprites[1];

                imageWeapon.GetComponent<Image>().sprite = spriteGuns[0];
            }
            else
            {
                spriteRenderer.sprite = sprites[0];

                //imageWeapon.sprite = null;
            }
            if (pistol && silencer)
            {
                spriteRenderer.sprite = sprites[2];

                imageWeapon.GetComponent<Image>().sprite = spriteGuns[1];
            }
            

        }
        updateSprite = false;
    }

    /// <summary>
    /// Кнопка для выстрела
    /// </summary>
    public void On_Click_Shoot()
    {
        if (pistol)
        {
            if (bulletInClip > 0)
            {
                Instantiate(bullet, spawnBullet.transform.position, transform.rotation);
                bulletInClip--;
                textAmmo.text = clip + " / " + bulletInClip;
            }
            else
            {
                isRedyShoot = false;
            }
        }
    }

    /// <summary>
    /// Перезарядка
    /// </summary>
    private void Reload()
    {
        timerReload -= Time.deltaTime;

        spriteRenderer.sprite = sprites[3];

        if (timerReload < 0 && !isReadyClip && clip !=0 )
        {
            spriteRenderer.sprite = sprites[3];
            isRedyShoot = true;
            timerReload = timeReload;
            clip--;
            bulletInClip = 9;
            textAmmo.text = clip + " / " + bulletInClip;

            updateSprite = true;
        }
    }

    public void UpdateAmmo(int _clips, int bullet)
    {
        clip += _clips;
        bulletInClip = bullet;

        if (bulletInClip > 9)
        {
            clip++;
        }
        textAmmo.text = clip + " / " + bulletInClip;
    }




    public void TestDev()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            //imageWeapon.sprite = spriteGuns[0];
            imageWeapon.GetComponent<Image>().sprite = spriteGuns[0];
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            //imageWeapon.sprite = spriteGuns[1];
            imageWeapon.GetComponent<Image>().sprite = spriteGuns[1];
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            //imageWeapon.sprite = spriteGuns[1];
            imageWeapon.GetComponent<Image>().sprite = null;
        }
    }
}