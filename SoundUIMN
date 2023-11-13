using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SoundUIMN : Singleton<SoundUIMN>
{
    public AudioSource PlaySfxAudioSource, PlayMusicBGAudioSource;
    [SerializeField] AudioClip click, playbtnClick;
    [SerializeField] private AudioClip lobbyMusicBG, gamePlayMusicBG;
    [SerializeField] private AudioClip coinFlipStart;
    [SerializeField] private AudioClip cardDraw, cardPut, cardRotate, cardSlide, cardPick, cardRemove, cardPUCollect, cardBuff, cardGiveBuff;
    [SerializeField] private AudioClip cardCreateEquipment, orbCreateEquipment, cardEquipEquipment, equipmentBreak;
    [SerializeField] private AudioClip showPoup, hidePopup, showNotificationPopup;
    [SerializeField] private AudioClip showTurn;
    [SerializeField] private AudioClip explosion;
    [SerializeField] private AudioClip winning, losing;
    [SerializeField] private AudioClip fireOn, fireOff;
    [SerializeField] private AudioClip perkUnlock;

    [Header("Battle Sound")]
    [SerializeField] private AudioClip defaultW;
    [SerializeField] private AudioClip slingShot;
    [SerializeField] private AudioClip bow;
    [SerializeField] private AudioClip sword, dagger, spear;
    [SerializeField] private AudioClip wood, stone;
    public int volumeMusic = 100;
    public int volumeSFX = 100;

	int maxVolume = 100;
    private void Start()
    {
        LoadDataSetting();
    }
    public void LoadDataSetting()
    {
        int statusMusic = PlayerPrefs.GetInt(Schema.volumeMusic.ToString(), 100);
        SetVolume(statusMusic);
        int statusSFX = PlayerPrefs.GetInt(Schema.volumeEff.ToString(), 100);
        SetVolumeEffect(statusSFX);
        PlayBackgroundMusic(2f);
    }

    static float timeClick = 0;
    public static void Click()
    {
        if (timeClick > Time.time) return;
        timeClick = Time.time + 0.1f;
        Instance.PlaySound(SOUND.CLICK);
    }
    public static void ClickBtn()
    {
        if (timeClick > Time.time) return;
        timeClick = Time.time + 0.1f;
        Instance.PlaySound(SOUND.CARD_PICK);
    }

    public static void ClickToggle()
    {
        Click();
    }

    private void Play(AudioClip audio)
    {
        if (audio)
        {
            float pitch = Random.Range(0.98f, 1.02f);
            PlaySfxAudioSource.pitch = pitch;
            PlaySfxAudioSource.clip = audio;
            PlaySfxAudioSource.PlayOneShot(audio, volumeSFX);
        }
    }

    public void PlaySound(SOUND sEnum)
    {
        switch(sEnum) 
        {
            case SOUND.COIN_FLIP_START:
                Play(coinFlipStart);
                break;
            case SOUND.CARD_DRAW:
                Play(cardDraw);
                break;
            case SOUND.CARD_PUT:
                Play(cardPut);
                break;
            case SOUND.CARD_ROTATE:
                Play(cardRotate);
                break;
            case SOUND.CARD_SLIDE:
                Play(cardSlide);
                break;
            case SOUND.CLICK:
                Play(click);
                break;
            case SOUND.PLAY_BTN_CLICK:
                Play(playbtnClick);
                break;
            case SOUND.CARD_PICK:
                Play(cardPick);
                break;
            case SOUND.CARD_REMOVE:
                Play(cardRemove);
                break;
            case SOUND.CARD_PU_COLLECT:
                Play(cardPUCollect);
                break;
            case SOUND.SHOW_POPUP:
                Play(showPoup);
                break;
            case SOUND.HIDE_POPUP:
                Play(hidePopup);
                break;
            case SOUND.SHOW_NOTIFICATION_POPUP:
                Play(showNotificationPopup);
                break;
            case SOUND.CARD_BUFF:
                Play(cardBuff);
                break;
            case SOUND.CARD_GIVEBUFF:
                Play(cardGiveBuff);
                break;
            case SOUND.CARD_CREATE_EQUIPMENT:
                Play(cardCreateEquipment);
                break;
            case SOUND.ORB_CREATE_EQUIPMENT:
                Play(orbCreateEquipment);
                break;
            case SOUND.CARD_EQUIP_EQUIPMENT:
                Play(cardEquipEquipment);
                break;
            case SOUND.EQUIPMENT_BREAK:
                Play(equipmentBreak);
                break;
            case SOUND.SHOW_TURN:
                Play(showTurn);
                break;
            case SOUND.EXPLOSION:
                Play(explosion);
                break;
            case SOUND.WINNING:
                Play(winning);
                break;
            case SOUND.LOSING:
                Play(losing);
                break;
            case SOUND.FIRE_ON:
                Play(fireOn);
                break;
            case SOUND.FIRE_OFF:
                Play(fireOff);
                break;
            case SOUND.PERK_UNLOCK:
                Play(perkUnlock);
                break;
        }
    }

    public void PlayWeaponSound(GameCard card)
    {
        switch(card.cardData.cardAttribute.weaponType) 
        {
            case WeaponType.SLING_SHOT:
                Play(slingShot);
                break;
            case WeaponType.BOW:
                Play(bow);
                break;
            case WeaponType.SWORD:
                Play(sword);
                break;
            case WeaponType.DAGGER:
                Play(dagger);
                break;
             case WeaponType.WOOD:
                AudioClip clip = card.cardData.cardAttribute.subType == SubType.ARCHER_TOWER ? wood : stone;
                Play(clip);
                break;
            case WeaponType.STONE:
                Play(stone);
                break;
            case WeaponType.SPEAR:
                Play(spear);
                break;
            default:
                Play(defaultW);
                break;
        }
    }

    public void SetVolumeEffect(int value)
    {
        volumeSFX = value;
        if (PlaySfxAudioSource)
            PlaySfxAudioSource.volume = volumeSFX * 0.01f * 0.05f;
    }
    public void SetVolume(int volume)
    {
        volumeMusic = volume;

        if (PlayMusicBGAudioSource)
        {
            StopAllCoroutines();
            StartCoroutine(FadeVolume(volume));
        }
    }

    private IEnumerator FadeVolume(int target)
    {
        target = Mathf.Min(target, maxVolume);
        int currVolume = (int)(PlayMusicBGAudioSource.volume * 100);
        while (currVolume != target)
        {
            currVolume = (int)Mathf.MoveTowards(currVolume, target, 1);
            PlayMusicBGAudioSource.volume = currVolume * 0.01f;
            yield return null;
        }
      
    }

    public void PlayBackgroundMusic(float delayTime = 0)
    {
        PlayMusicBGAudioSource.Stop();
        Invoke("PlayingBackgroundMusic", delayTime);
    }

    private void PlayingBackgroundMusic()
    {
        var currentScene = SceneMN.GetScene();
        if (currentScene == SceneName.GamePlayScene || currentScene == SceneName.PVEScene)
            PlayMusicBGAudioSource.clip = gamePlayMusicBG;
        else
            PlayMusicBGAudioSource.clip = lobbyMusicBG;

        PlayMusicBGAudioSource.volume = 0;
        PlayMusicBGAudioSource.playOnAwake = false;
        PlayMusicBGAudioSource.pitch = 1;
        PlayMusicBGAudioSource.loop = true;
        PlayMusicBGAudioSource.Play();

        if (volumeMusic > 0)
        {
            StopAllCoroutines();
            StartCoroutine(FadeVolume(volumeMusic));
        }
    }

    public void UpdateMusicBackground(int volume)
    {
        PlayerPrefs.SetInt(Schema.volumeMusic.ToString(), volume);
        SetVolume(volume);
    }

    public void UpdateSfx(int volume)
    {
        PlayerPrefs.SetInt(Schema.volumeEff.ToString(), volume);
        SetVolumeEffect(volume);
    }
}

public enum SOUND
{
    CLICK, PLAY_BTN_CLICK,
    COIN_FLIP_START,
    CARD_DRAW, CARD_PUT, CARD_ROTATE, CARD_SLIDE, CARD_PICK, CARD_REMOVE, CARD_PU_COLLECT, CARD_BUFF, CARD_GIVEBUFF,
    CARD_CREATE_EQUIPMENT, ORB_CREATE_EQUIPMENT, CARD_EQUIP_EQUIPMENT, EQUIPMENT_BREAK,
    SHOW_POPUP, HIDE_POPUP, SHOW_NOTIFICATION_POPUP,
    SHOW_TURN, EXPLOSION,
    WINNING, LOSING,
    FIRE_ON, FIRE_OFF,
    SLING_SHOT, BOW, SWORD,
    PERK_UNLOCK
}
