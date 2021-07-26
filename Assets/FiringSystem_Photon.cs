using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class FiringSystem_Photon : MonoBehaviour
{
    /// <summary>
    /// Фотон
    /// </summary>
    private PhotonView photonView;

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
        photonView = GetComponent<PhotonView>();

        if (!photonView.IsMine)
        {
            return;
        }
        else
        {
            //timerReload = timeReload;
            textAmmo.GetComponent<Text>();

            textAmmo.text = clip + " / " + bulletInClip;
            imageWeapon.GetComponent<Image>();

            updateSprite = true;
        }
    }

    private void FixedUpdate()
    {
        if (!photonView.IsMine) return;

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

                imageWeapon.GetComponent<Image>().sprite = spriteGuns[1];
            }
            else
            {
                //spriteRenderer.sprite = sprites[0];

                imageWeapon.GetComponent<Image>().sprite = spriteGuns[0];
                Debug.Log("No Pistol ");
            }
            if (pistol && silencer)
            {
                spriteRenderer.sprite = sprites[2];

                imageWeapon.GetComponent<Image>().sprite = spriteGuns[2];
            }
        }
        updateSprite = false;
    }

    /// <summary>
    /// Кнопка для выстрела
    /// </summary>
    public void On_Click_Shoot()
    {
        if (!photonView.IsMine) return;

        if (pistol)
        {
            Debug.Log("0");
            if (bulletInClip > 0)
            {
                PhotonNetwork.Instantiate(bullet.name, spawnBullet.transform.position, transform.rotation);
                bulletInClip--;
                textAmmo.text = clip + " / " + bulletInClip;
                Debug.Log("1");
            }
            else
            {
                isRedyShoot = false;
                Debug.Log("2");
            }
            Debug.Log("3");
        }
        Debug.Log("4");
    }

    /// <summary>
    /// Перезарядка
    /// </summary>
    private void Reload()
    {
        if (!photonView.IsMine) return;

        timerReload -= Time.deltaTime;

        spriteRenderer.sprite = sprites[3];

        if (timerReload <= 0 && !isReadyClip && clip != 0)
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
        if (!photonView.IsMine) return;

        clip += _clips;
        bulletInClip = bullet;

        if (bulletInClip > 9)
        {
            clip++;
        }
        textAmmo.text = clip + " / " + bulletInClip;
    }
}
