


using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using SimpleFileBrowser;
using UnityEngine.UI;
using TMPro;
using FrameWork.UI;
using UnityEditor;
using System.Linq;
using System;

public class Panel_ThumbnailCreator : UIBase
{
    #region variable 변수
    public int size;
    public float padding;

    private Button btn_LoadPath;
    private TMP_Text txtmp_LoadPath;

    private Button btn_SavePath;
    private TMP_Text txtmp_SavePath;

    private Button btn_Save;
    private Button btn_SaveFolder;
    private Toggle tog_Save;

    private GameObject go_Content;
    private Button btn_ThumbnailPreview;

    private TMP_Dropdown tmpdrop_ThumbnailAngleX;
    private TMP_Dropdown tmpdrop_ThumbnailAngleY;
    private TMP_Dropdown tmpdrop_ThumbnailAngleZ;

    private TMP_InputField input_ThumbnailPadding;
    private TMP_InputField input_ThumbnailSize;

    private Image img_ThumbnailBackground;
    private TMP_Dropdown tmpdrop_ThumbnailBackground;


    private string[] backgroundTexts = new string[] { "클리어", "블랙", "화이트", "레드", "그린", "블루" };
    private Color[] backgroundColors = new Color[] { Color.clear, Color.black, Color.white, Color.red, Color.green, Color.blue };
    private Dictionary<string, Texture2D> previewDic = new Dictionary<string, Texture2D>();

    private enum eAngleX
    {
        Left = 1,
        Center = 0,
        Right = -1,
    }

    private enum eAngleY
    {
        Bottom = 1,
        Center = 0,
        Top = -1,
    }

    private enum eAngleZ
    {
        Back = 1,
        Center = 0,
        Forward = -1,
    }
    private Vector3 thumbnailAngle;


    private bool _newSave;
    private bool newSave
    {
        get
        {
            return _newSave;
        }
        set
        {
            _newSave = value;
            PlayerPrefs.SetInt("newSave", value == true ? 1 : 0);
        }
    }
    #endregion



    #region Init 초기화
    protected override void SetMemberUI()
    {
        base.SetMemberUI();


        /*좌측*/

        //프리팹 로드 관련
        btn_LoadPath = GetUI_Button("btn_LoadPath", OnClick_LoadPath);
        txtmp_LoadPath = GetUI_Txtmp("txtmp_LoadPath");
        txtmp_LoadPath.text = PlayerPrefs.GetString("txtmp_LoadPath");

        //썸네일 세이브 관련
        btn_SavePath = GetUI_Button("btn_SavePath", OnClick_SavePath);
        txtmp_SavePath = GetUI_Txtmp("txtmp_SavePath");
        txtmp_SavePath.text = PlayerPrefs.GetString("txtmp_SavePath");

        //썸네일 저장
        btn_Save = GetUI_Button("btn_Save", OnClick_Save);

        //썸네일 저장폴더 열기
        btn_SaveFolder = GetUI_Button("btn_SaveFolder", () => Application.OpenURL(txtmp_SavePath.text));

        //새로저장 토글
        tog_Save = GetUI_Toggle("tog_Save", () => newSave = true, () => newSave = false);
        tog_Save.isOn = newSave = PlayerPrefs.GetInt("newSave") == 1 ? true : false;



        /*중앙*/

        //썸네일 미리보기
        go_Content = GetChildGObject("go_Content");
        btn_ThumbnailPreview = GetUI_Button("btn_ThumbnailPreview", OnClick_ThumbnailPreview);



        /*우측*/

        //앵글XYZ 드롭다운
        InitThumbnailAngle();

        //썸네일 패딩 인풋필드
        input_ThumbnailPadding = GetUI<TMP_InputField>("input_ThumbnailPadding");
        padding = PlayerPrefs.GetFloat("thumbnailPadding");
        input_ThumbnailPadding.text = padding.ToString();
        input_ThumbnailPadding.onValueChanged.AddListener((x) =>
        {
            if (float.TryParse(x, out padding))
            {
                padding = Mathf.Clamp(padding, -0.25f, 0.25f);
                PlayerPrefs.SetFloat("thumbnailPadding", padding);
            }
            else
            {
                padding = 0f;
            }

        });
        input_ThumbnailPadding.onEndEdit.AddListener((x) =>
        {
            input_ThumbnailPadding.text = padding.ToString();
        });

        //썸네일 사이즈 인풋필드
        input_ThumbnailSize = GetUI<TMP_InputField>("input_ThumbnailSize");
        size = PlayerPrefs.GetInt("thumbnailSize");
        input_ThumbnailSize.text = size.ToString();
        input_ThumbnailSize.onValueChanged.AddListener((x) =>
        {
            if (int.TryParse(x, out size))
            {
                size = Mathf.Clamp(size, 32, 4096);
                PlayerPrefs.SetInt("thumbnailSize", size);
            }
            else
            {
                size = 32;
            }

        });
        input_ThumbnailSize.onEndEdit.AddListener((x) =>
        {
            input_ThumbnailSize.text = size.ToString();
        });

        //썸네일 배경색상 이미지
        img_ThumbnailBackground = GetUI_Img("img_ThumbnailBackground");
        //썸네일 배경색상 드롭다운
        tmpdrop_ThumbnailBackground = GetUI<TMP_Dropdown>("tmpdrop_ThumbnailBackground");
        InitThumbnailBackground();
        tmpdrop_ThumbnailBackground.onValueChanged.AddListener((i) =>
        {
            img_ThumbnailBackground.color = backgroundColors[i];
            PlayerPrefs.SetString("backgroundColor", backgroundTexts[i]);
        });
        int colorIdx = Array.IndexOf(backgroundTexts, PlayerPrefs.GetString("backgroundColor"));
        if (colorIdx != -1)
        {
            img_ThumbnailBackground.color = backgroundColors[colorIdx];
            tmpdrop_ThumbnailBackground.SetValueWithoutNotify(colorIdx);
        }
    }

    /// <summary>
    /// 썸네일앵글 드롭다운 초기화
    /// </summary>
    void InitThumbnailAngle()
    {
        tmpdrop_ThumbnailAngleX = GetUI<TMP_Dropdown>("tmpdrop_ThumbnailAngleX");
        tmpdrop_ThumbnailAngleX.onValueChanged.AddListener((_) =>
        {
            string str = tmpdrop_ThumbnailAngleX.options[tmpdrop_ThumbnailAngleX.value].text;
            int x = (int)String2Enum<eAngleX>(str);
            thumbnailAngle.x = x;
        });

        tmpdrop_ThumbnailAngleY = GetUI<TMP_Dropdown>("tmpdrop_ThumbnailAngleY");
        tmpdrop_ThumbnailAngleY.onValueChanged.AddListener((_) =>
        {
            string str = tmpdrop_ThumbnailAngleY.options[tmpdrop_ThumbnailAngleY.value].text;
            int y = (int)String2Enum<eAngleY>(str);
            thumbnailAngle.y = y;
        });

        tmpdrop_ThumbnailAngleZ = GetUI<TMP_Dropdown>("tmpdrop_ThumbnailAngleZ");
        tmpdrop_ThumbnailAngleZ.onValueChanged.AddListener((_) =>
        {
            string str = tmpdrop_ThumbnailAngleZ.options[tmpdrop_ThumbnailAngleZ.value].text;
            int z = (int)String2Enum<eAngleZ>(str);
            thumbnailAngle.z = z;
        });

        SetThumbnailAngle<eAngleX>(tmpdrop_ThumbnailAngleX);
        SetThumbnailAngle<eAngleY>(tmpdrop_ThumbnailAngleY);
        SetThumbnailAngle<eAngleZ>(tmpdrop_ThumbnailAngleZ);

        tmpdrop_ThumbnailAngleX.SetValueWithoutNotify(1);
        tmpdrop_ThumbnailAngleY.SetValueWithoutNotify(2);
        tmpdrop_ThumbnailAngleZ.SetValueWithoutNotify(1);
        thumbnailAngle = new Vector3(1f, -1f, 1f);

    }

    /// <summary>
    /// 썸네일 앵글 셋업
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="dropdown"></param>
    private void SetThumbnailAngle<T>(TMP_Dropdown dropdown)
    {
        dropdown.ClearOptions();
        Array strs = Enum.GetNames(typeof(T));
        foreach (var item in strs)
        {
            TMP_Dropdown.OptionData optionData = new TMP_Dropdown.OptionData(item.ToString());
            dropdown.options.Add(optionData);
        }
    }

    /// <summary>
    /// 썸네일 배경색상 드롭다운 초기화
    /// </summary>
    void InitThumbnailBackground()
    {
        tmpdrop_ThumbnailBackground.ClearOptions();
        for (int i = 0; i < backgroundTexts.Length; i++)
        {
            TMP_Dropdown.OptionData optionData = new TMP_Dropdown.OptionData(backgroundTexts[i]);
            tmpdrop_ThumbnailBackground.options.Add(optionData);
        }
    }
    #endregion



    #region OnClick 온클릭

    /// <summary>
    /// 프리팹패스 로드 브라우저
    /// </summary>
    void OnClick_LoadPath()
    {
        FileBrowser.ShowLoadDialog(OnSuccess_LoadPath, OnCancel_LoadPath, FileBrowser.PickMode.Folders);
    }




    /// <summary>
    /// 썸네일저장패스 
    /// </summary>
    void OnClick_SavePath()
    {
        FileBrowser.ShowLoadDialog(OnSuccess_SavePath, OnCancel_SavePath, FileBrowser.PickMode.Folders);
    }

    /// <summary>
    /// 썸네일 미리보기
    /// </summary>
    public void OnClick_ThumbnailPreview()
    {
        for (int i = go_Content.transform.childCount - 1; i >= 0; i--)
        {
            Destroy(go_Content.transform.GetChild(i).gameObject);
        }
        CreateThumbnails(true);
    }

    /// <summary>
    /// 썸네일 저장
    /// </summary>
    private void OnClick_Save()
    {
        previewDic.Clear();
        CreateThumbnails(false);

        foreach (var item in previewDic)
        {
            string dicPath = txtmp_SavePath.text;
            string filePath = item.Key;
            if (newSave)
            {
                filePath = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + "_" + filePath;
            }
            Tex2PNG(item.Value, dicPath, filePath + ".png");
        }

        Debug.Log($"<color=green><b>썸네일 저장완료</b></color>");
    }

    #endregion



    #region ThumbnailCreate 썸네일 만들기
    /// <summary>
    /// 썸네일 만들기
    /// </summary>
    /// <param name="preview">
    /// 미리보기 하면 썸네일 출력
    /// 미리보기 안하면 저장용 딕셔너리에 셋업
    /// </param>
    void CreateThumbnails(bool preview)
    {
        RuntimePreviewGenerator.PreviewDirection = thumbnailAngle;
        RuntimePreviewGenerator.Padding = padding;
        RuntimePreviewGenerator.BackgroundColor = img_ThumbnailBackground.color;

        string[] loadPaths = Directory.GetFiles(txtmp_LoadPath.text, "*.prefab");
        for (int i = 0; i < loadPaths.Length; i++)
        {
            string loadPath = loadPaths[i];
            GameObject obj = Instantiate(PrefabUtility.LoadPrefabContents(loadPath));
            CreateThumbnail(obj.transform, preview);
        }

        if (preview)
        {
            Debug.Log($"<color=yellow><b>썸네일 미리보기 완료</b></color>");
        }
    }

    /// <summary>
    /// 썸네일 만들기
    /// </summary>
    /// <param name="tr"></param>
    /// <param name="preview"></param>
    private void CreateThumbnail(Transform tr, bool preview = true)
    {
        Texture2D tex = RuntimePreviewGenerator.GenerateModelPreview(tr, size, size);

        if (preview)
        {
            GameObject go_ThumbnailPreview = Instantiate(Resources.Load<GameObject>("go_ThumbnailPreview"), go_Content.transform);
            go_ThumbnailPreview.GetComponent<Image>().sprite = Tex2Sprite(tex);
        }
        else
        {
            string[] paths = tr.name.Split('\\');
            string name = paths[paths.Length - 1];
            name = name.Replace("(Clone)", "");
            previewDic.Add(name, tex);
        }
        Destroy(tr.gameObject);
    }

    #endregion



    #region ETC 기타
    public void OnSuccess_LoadPath(string[] paths)
    {
        for (int i = 0; i < paths.Length; i++)
        {
            txtmp_LoadPath.text = paths[i];
        }
        PlayerPrefs.SetString("txtmp_LoadPath", txtmp_LoadPath.text);
        Debug.Log($"<color=white><b>프리팹 폴더경로 저장 완료</b></color>");
    }

    public void OnCancel_LoadPath() { }

    public void OnSuccess_SavePath(string[] paths)
    {
        Debug.Log("paths : " + paths.Length);
        for (int i = 0; i < paths.Length; i++)
        {
            txtmp_SavePath.text = paths[i];
        }
        PlayerPrefs.SetString("txtmp_SavePath", txtmp_SavePath.text);
        Debug.Log($"<color=white><b>썸네일 폴더경로 저장 완료</b></color>");
        Debug.Log("txtmp_SavePath.text : " + PlayerPrefs.GetString("txtmp_SavePath"));
    }
    public void OnCancel_SavePath() { }

    #endregion



    #region Util 유틸
    /// <summary>
    /// Texture2D를 PNG로 변경하여 생성
    /// </summary>
    /// <param name="_path"></param>
    /// <param name="_texture"></param>
    private Sprite Tex2Sprite(Texture2D _tex)
    {
        try
        {
            return Sprite.Create(_tex, new Rect(0, 0, _tex.width, _tex.height), new Vector2(0.5f, 0.5f));
        }
        catch
        {
            return null;
        }
    }
    /// <summary>
    /// Texture2D를 PNG로 변경하여 생성
    /// </summary>
    /// <param name="_dicPath"></param>
    /// <param name="_texture"></param>
    private void Tex2PNG(Texture2D _texture, string _dicPath, string _filePath)
    {
        byte[] _bytes = duplicateTexture(_texture).EncodeToPNG();
        CreateFile(_dicPath, _filePath, _bytes);
    }


    /// <summary>
    /// png저장을 위한 텍스쳐 복제
    /// </summary>
    /// <param name="source"></param>
    /// <returns></returns>
    private Texture2D duplicateTexture(Texture2D source)
    {
        RenderTexture renderTex = RenderTexture.GetTemporary(
                    source.width,
                    source.height,
                    0,
                    RenderTextureFormat.Default,
                    RenderTextureReadWrite.Linear);

        Graphics.Blit(source, renderTex);
        RenderTexture previous = RenderTexture.active;
        RenderTexture.active = renderTex;
        Texture2D readableText = new Texture2D(source.width, source.height);
        readableText.ReadPixels(new Rect(0, 0, renderTex.width, renderTex.height), 0, 0);
        readableText.Apply();
        RenderTexture.active = previous;
        RenderTexture.ReleaseTemporary(renderTex);
        return readableText;
    }
    /// <summary>
    /// string을 enum으로 변환
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="_str"></param>
    /// <returns></returns>
    private static T String2Enum<T>(string _str) where T : Enum
    {
        try { return (T)Enum.Parse(typeof(T), _str); }
        catch { return (T)Enum.Parse(typeof(T), "none"); }
    }


    /// <summary>
    /// enum을 string으로 변환
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="_enum"></param>
    /// <returns></returns>
    public static string Enum2String<T>(T _enum) where T : Enum
    {
        try { return Enum.GetName(typeof(T), _enum); }
        catch { return string.Empty; }
    }

    /// <summary>
    /// enum원형의 길이 구하기
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static int EnumLength<T>()
    {
        return Enum.GetNames(typeof(T)).Length;
    }


    /// <summary>
    /// 파일 생성
    /// </summary>
    /// <param name="_DirectoryPath"></param>
    /// <param name="_bytes"></param>
    public void CreateFile(string _DirectoryPath, string _filePath, byte[] _bytes)
    {
        if (!Directory.Exists(_DirectoryPath))
        {
            Directory.CreateDirectory(_DirectoryPath);
        }
        string pullPath = Path.Combine(_DirectoryPath, _filePath);
        File.WriteAllBytes(pullPath, _bytes);
    }
    #endregion
}



//using System.Collections;
//using System.Collections.Generic;
//using System.IO;
//using UnityEngine;
//using SimpleFileBrowser;
//using UnityEngine.UI;
//using TMPro;
//using FrameWork.UI;
//using UnityEditor;
//using System.Linq;
//using System;

//public class Panel_ThumbnailCreator : UIBase
//{
//    //GameObject prefab;
//    private string path;
//    public int size;

//    private Button btn_LoadPath;
//    private Button btn_SavePath;
//    private Button btn_ThumbnailPreview;

//    private Button btn_Save;

//    private TMP_Text txtmp_LoadPath;
//    private TMP_Text txtmp_SavePath;

//    private TMP_Dropdown tmpdrop_CameraAngle;
//    //private TMP_Dropdown tmpdrop_ThumbnailSize;
//    private TMP_InputField input_ThumbnailSize;

//    private Image img_ThumbnailBackground;
//    private TMP_Dropdown tmpdrop_ThumbnailBackground;

//    private GameObject go_Content;


//    //private int[] thumbnailSizes = new int[] { 32, 64, 128, 256, 512, 1024 };
//    private string[] backgroundTexts = new string[] { "클리어", "블랙", "화이트", "레드", "그린", "블루" };
//    private Color[] backgroundColors = new Color[] { Color.clear, Color.black, Color.white, Color.red, Color.green, Color.blue };

//    private List<Texture2D> previewList = new List<Texture2D>();


//    private void CreateThumbnailPreview(Transform tr, bool preview = true)
//    {
//        Texture2D tex = RuntimePreviewGenerator.GenerateModelPreview(tr, size, size);

//        if (preview)
//        {
//            GameObject go_ThumbnailPreview = Instantiate(Resources.Load<GameObject>("go_ThumbnailPreview"), go_Content.transform);
//            go_ThumbnailPreview.GetComponent<Image>().sprite = Tex2Sprite(tex);
//            Destroy(tr.gameObject);
//        }
//        else
//        {
//            previewList.Add(tex);
//        }
//    }



//    protected override void SetMemberUI()
//    {
//        base.SetMemberUI();
//        btn_LoadPath = GetUI_Button("btn_LoadPath", OnClick_LoadPath);
//        btn_SavePath = GetUI_Button("btn_SavePath", OnClick_SavePath);
//        btn_ThumbnailPreview = GetUI_Button("btn_ThumbnailPreview", OnClick_ThumbnailPreview);
//        btn_Save = GetUI_Button("btn_Save", OnClick_Save);

//        txtmp_LoadPath = GetUI_Txtmp("txtmp_LoadPath");
//        txtmp_LoadPath.text = PlayerPrefs.GetString("txtmp_LoadPath");
//        txtmp_SavePath = GetUI_Txtmp("txtmp_SavePath");
//        txtmp_SavePath.text = PlayerPrefs.GetString("txtmp_SavePath");

//        //썸네일 카메라각도
//        tmpdrop_CameraAngle = GetUI<TMP_Dropdown>("tmpdrop_CameraAngle");

//        //썸네일 사이즈
//        //tmpdrop_ThumbnailSize = GetUI<TMP_Dropdown>("tmpdrop_ThumbnailSize");
//        //SetThumbnailSize();
//        //tmpdrop_ThumbnailSize.onValueChanged.AddListener(delegate { OnValueChanged_ThumbnailSize(tmpdrop_ThumbnailSize); });
//        //size = PlayerPrefs.GetInt("thumbnailSize");
//        //int sizeIdx = Array.IndexOf(thumbnailSizes, size);
//        //if(sizeIdx!=-1)
//        //{
//        //    tmpdrop_ThumbnailSize.SetValueWithoutNotify(sizeIdx);
//        //}

//        //썸네일 사이즈 TMP
//        input_ThumbnailSize = GetUI<TMP_InputField>("input_ThumbnailSize");
//        size = PlayerPrefs.GetInt("thumbnailSize");
//        input_ThumbnailSize.text = size.ToString();
//        input_ThumbnailSize.onValueChanged.AddListener((x) =>
//        {
//            if(int.TryParse(x, out size))
//            {
//                size = Mathf.Clamp(size, 32, 4096);
//                PlayerPrefs.SetInt("thumbnailSize", size);
//            }
//            else
//            {
//                size = 32;
//            }

//        });
//        input_ThumbnailSize.onEndEdit.AddListener((x) => 
//        {
//            input_ThumbnailSize.text = size.ToString();
//        });

//        //썸네일컬러
//        img_ThumbnailBackground = GetUI_Img("img_ThumbnailBackground");

//        //썸네일 배경
//        tmpdrop_ThumbnailBackground = GetUI<TMP_Dropdown>("tmpdrop_ThumbnailBackground");
//        SetThumbnailBackground();
//        tmpdrop_ThumbnailBackground.onValueChanged.AddListener(OnValueChanged_ThumbnailBackground);
//        //tmpdrop_ThumbnailBackground.onValueChanged.AddListener(delegate { Function_Dropdown2(tmpdrop_ThumbnailBackground); });
//        int colorIdx = Array.IndexOf(backgroundTexts, PlayerPrefs.GetString("backgroundColor"));
//        if(colorIdx != -1)
//        {
//            img_ThumbnailBackground.color = backgroundColors[colorIdx];
//            tmpdrop_ThumbnailBackground.SetValueWithoutNotify(colorIdx);
//        }

//        //img_ThumbnailPreview = GetUI_Img("img_ThumbnailPreview");

//        go_Content = GetChildGObject("go_Content");


//    }

//    private void OnClick_Save()
//    {
//        CreateThumbnailPreview(false);
//        for (int i = 0; i < previewList.Count; i++)
//        {
//            Tex2PNG(previewList[i], txtmp_SavePath.text, i.ToString() + ".png");
//        }
//    }

//    void OnClick_LoadPath()
//    {
//        FileBrowser.ShowLoadDialog(OnSuccess_LoadPath, OnCancel_LoadPath, FileBrowser.PickMode.Folders);
//        //SimpleFileBrowserCanvas.SetActive(true);
//        //onSuccess += OnSuccess_LoadPath;
//        //onCancel += OnCancel_LoadPath;
//    }



//    void SetThumbnailBackground()
//    {
//        tmpdrop_ThumbnailBackground.ClearOptions();
//        for (int i = 0; i < backgroundTexts.Length; i++)
//        {
//            TMP_Dropdown.OptionData optionData = new TMP_Dropdown.OptionData(backgroundTexts[i]);
//            tmpdrop_ThumbnailBackground.options.Add(optionData);
//        }
//    }

//    public TMP_Text txtmp_ThumbnailSize;
//    //void SetThumbnailSize()
//    //{
//    //    tmpdrop_ThumbnailSize.ClearOptions();
//    //    for (int i = 0; i < thumbnailSizes.Length; i++)
//    //    {
//    //        TMP_Dropdown.OptionData optionData = new TMP_Dropdown.OptionData(thumbnailSizes[i].ToString());
//    //        tmpdrop_ThumbnailSize.options.Add(optionData);
//    //    }
//    //}

//    private void OnValueChanged_ThumbnailBackground(int idx)
//    {
//        //Debug.Log("select : " + idx);
//        img_ThumbnailBackground.color = backgroundColors[idx];
//        PlayerPrefs.SetString("backgroundColor", backgroundTexts[idx]);
//    }
//    //private void OnValueChanged_ThumbnailSize(TMP_Dropdown select)
//    //{
//    //    string op = select.options[select.value].text;
//    //    size = int.Parse(op);
//    //    PlayerPrefs.SetInt("thumbnailSize", size);
//    //}

//    //private void Function_Dropdown2(TMP_Dropdown select)
//    //{
//    //    string op = select.options[select.value].text;
//    //    Debug.Log("Dropdown Change!" + op);
//    //}

//    public void OnSuccess_LoadPath(string[] paths)
//    {
//        for (int i = 0; i < paths.Length; i++)
//        {
//            Debug.Log("path : " + paths[i]);
//            txtmp_LoadPath.text = paths[i];
//        }
//        PlayerPrefs.SetString("txtmp_LoadPath", txtmp_LoadPath.text);
//        //onCancel.Invoke();
//        //CreateThumbnailPreview();
//    }

//    /// <summary>
//    /// 썸네일 미리보기
//    /// </summary>
//    public void OnClick_ThumbnailPreview()
//    {
//        for (int i = go_Content.transform.childCount - 1; i >= 0; i--)
//        {
//            Destroy(go_Content.transform.GetChild(i).gameObject);
//        }
//        CreateThumbnailPreview(true);
//    }

//    void CreateThumbnailPreview(bool preview)
//    {
//        RuntimePreviewGenerator.BackgroundColor = img_ThumbnailBackground.color;
//        string[] loadPaths = Directory.GetFiles(txtmp_LoadPath.text, "*.prefab");
//        for (int i = 0; i < loadPaths.Length; i++)
//        {
//            string loadPath = loadPaths[i];
//            //Debug.Log("loadPath  : " + loadPath);
//            GameObject obj = Instantiate(PrefabUtility.LoadPrefabContents(loadPath));
//            CreateThumbnailPreview(obj.transform, preview);
//            Destroy(obj);
//        }
//    }

//    public void OnCancel_LoadPath()
//    {
//        //onSuccess -= OnSuccess_LoadPath;
//        //onCancel -= OnCancel_LoadPath;
//        //SimpleFileBrowserCanvas.SetActive(false);
//    }


//    void OnClick_SavePath()
//    {
//        FileBrowser.ShowLoadDialog(OnSuccess_SavePath, OnCancel_SavePath, FileBrowser.PickMode.Folders);
//        //SimpleFileBrowserCanvas.SetActive(true);
//        //onSuccess += OnSuccess_SavePath;
//        //onCancel += OnCancel_SavePath;
//    }
//    public void OnSuccess_SavePath(string[] paths)
//    {
//        for (int i = 0; i < paths.Length; i++)
//        {
//            Debug.Log("path : " + paths[i]);
//            txtmp_SavePath.text = paths[i];
//        }
//        PlayerPrefs.SetString("txtmp_SavePath", txtmp_SavePath.text);
//        //onCancel.Invoke();
//    }
//    public void OnCancel_SavePath()
//    {
//        //onSuccess -= OnSuccess_SavePath;
//        //onCancel -= OnCancel_SavePath;
//        //SimpleFileBrowserCanvas.SetActive(false);
//    }

//    void Update()
//    {
//        if (Input.GetKeyDown(KeyCode.Alpha1))
//        {

//        }

//        if (Input.GetKeyDown(KeyCode.Alpha2))
//        {

//        }
//        if (Input.GetKeyDown(KeyCode.Alpha3))
//        {

//        }
//        if (Input.GetKeyDown(KeyCode.Alpha4))
//        {

//        }
//        if (Input.GetKeyDown(KeyCode.Alpha5))
//        {

//        }
//        if (Input.GetKeyDown(KeyCode.Alpha6))
//        {

//        }
//        if (Input.GetKeyDown(KeyCode.Alpha7))
//        {

//        }
//        if (Input.GetKeyDown(KeyCode.Alpha8))
//        {

//        }
//        if (Input.GetKeyDown(KeyCode.Alpha9))
//        {

//        }
//        if (Input.GetKeyDown(KeyCode.Alpha0))
//        {

//        }
//    }


//    /// <summary>
//    /// Texture2D를 PNG로 변경하여 생성
//    /// </summary>
//    /// <param name="_path"></param>
//    /// <param name="_texture"></param>
//    public Sprite Tex2Sprite(Texture2D _tex)
//    {
//        return Sprite.Create(_tex, new Rect(0, 0, _tex.width, _tex.height), new Vector2(0.5f, 0.5f));
//    }

//    /// <summary>
//    /// Sprite를 PNG로 변경하여 생성
//    /// </summary>
//    /// <param name="_path"></param>
//    /// <param name="_sprite"></param>
//    public void Sprite2PNG(Sprite _sprite, string _dicPath, string _filePath)
//    {
//        Tex2PNG(_sprite.texture, _dicPath, _filePath);
//    }
//    /// <summary>
//    /// Texture2D를 PNG로 변경하여 생성
//    /// </summary>
//    /// <param name="_dicPath"></param>
//    /// <param name="_texture"></param>
//    public void Tex2PNG(Texture2D _texture, string _dicPath, string _filePath)
//    {
//        Debug.Log("_path : " + _dicPath);

//        byte[] _bytes = duplicateTexture(_texture).EncodeToPNG();
//        CreateFile(_dicPath, _filePath, _bytes);
//    }


//    /// <summary>
//    /// png저장을 위한 텍스쳐 듀플
//    /// </summary>
//    /// <param name="source"></param>
//    /// <returns></returns>
//    Texture2D duplicateTexture(Texture2D source)
//    {
//        RenderTexture renderTex = RenderTexture.GetTemporary(
//                    source.width,
//                    source.height,
//                    0,
//                    RenderTextureFormat.Default,
//                    RenderTextureReadWrite.Linear);

//        Graphics.Blit(source, renderTex);
//        RenderTexture previous = RenderTexture.active;
//        RenderTexture.active = renderTex;
//        Texture2D readableText = new Texture2D(source.width, source.height);
//        readableText.ReadPixels(new Rect(0, 0, renderTex.width, renderTex.height), 0, 0);
//        readableText.Apply();
//        RenderTexture.active = previous;
//        RenderTexture.ReleaseTemporary(renderTex);
//        return readableText;
//    }


//    /// <summary>
//    /// 파일 생성
//    /// </summary>
//    /// <param name="_DirectoryPath"></param>
//    /// <param name="_bytes"></param>
//    public void CreateFile(string _DirectoryPath, string _filePath, byte[] _bytes)
//    {
//        if (!Directory.Exists(_DirectoryPath))
//        {
//            Directory.CreateDirectory(_DirectoryPath);
//        }
//        File.WriteAllBytes(Path.Combine(_DirectoryPath, _filePath), _bytes);
//    }
//}
