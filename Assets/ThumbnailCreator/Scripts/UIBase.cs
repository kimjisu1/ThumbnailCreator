#region 220810버전
//using System.Collections;
//using System.Collections.Generic;
//using TMPro;
//using UnityEngine;
//using UnityEngine.Events;
//using UnityEngine.Localization.Components;
//using UnityEngine.UI;


//namespace FrameWork.UI
//{
//    public class UIBase : MonoBehaviour
//    {
//        private bool isInit = false;

//        // 자식 하이라키에 있는 UI 보관
//        private Dictionary<string, MonoBehaviour> _dicUI = new Dictionary<string, MonoBehaviour>();

//        // 자식 하이라키에 있는 GameObject 보관 : "go_" 로 시작하는 GameObject
//        private Dictionary<string, GameObject> _dicGameObject = new Dictionary<string, GameObject>();

//        private List<GameObject> viewList = new List<GameObject>();
//        protected virtual void Awake()
//        {
//            if (!isInit)
//            {
//                Initialize();
//            }
//        }
//        protected virtual void Start() { }

//        #region Module

//        public void Initialize()
//        {
//            isInit = true;
//            _myTransform = transform;
//            _myGameObject = gameObject;
//            AddUI(_myTransform);
//            SetMemberUI();
//        }

//        protected Transform _myTransform = default;
//        protected GameObject _myGameObject = default;


//        public virtual void SetMemberUI() { }
//        private void AddUI(Transform parent)
//        {
//            for (int i = 0; i < parent.childCount; ++i)
//            {
//                Transform child = parent.GetChild(i);
//                string[] splits = child.name.Split('_');

//                MonoBehaviour childUI = null;

//                switch (splits[0].ToLower())
//                {
//                    // UGUI Text
//                    case "txt":
//                        {
//                            if (child.TryGetComponent(out Text text))
//                            {
//                                childUI = text;
//                            }
//                            if (child.TryGetComponent(out TMP_Text tmpText))
//                            {
//                                childUI = tmpText;
//                            }
//                        }
//                        break;

//                    // UGUI InputField
//                    case "input":
//                        {
//                            if (child.TryGetComponent(out InputField input))
//                            {
//                                childUI = input;
//                            }
//                            if (child.TryGetComponent(out TMP_InputField tmpInput))
//                            {
//                                childUI = tmpInput;
//                            }
//                        }
//                        break;

//                    // UGUI Image
//                    case "img":
//                        childUI = child.GetComponent<Image>();
//                        break;

//                    // UGUI Button
//                    case "btn":
//                        childUI = child.GetComponent<Button>();
//                        break;

//                    // UGUI Toggle
//                    case "tog":
//                        {
//                            childUI = child.GetComponent<Toggle>();
//                            if (child.parent.TryGetComponent(out ToggleGroup togg))
//                            {
//                                ((Toggle)childUI).group = togg;
//                            }
//                        }
//                        break;

//                    // UGUI ToggleGroup
//                    case "togg":
//                            childUI = child.GetComponent<ToggleGroup>();
//                        break;

//                    // UGUI Slider
//                    case "sld":
//                        childUI = child.GetComponent<Slider>();
//                        break;

//                    // UGUI Scrollbar
//                    case "scb":
//                        childUI = child.GetComponent<Scrollbar>();
//                        break;

//                    case "scv":
//                        childUI = child.GetComponent<ScrollRect>();
//                        break;

//                    // UGUI View
//                    case "view":
//                        childUI = child.GetComponent<ViewBase>();
//                        break;

//                    // GameObject
//                    case "go":
//                        {
//                            GameObject goTemp = child.gameObject;

//                            if (!_dicGameObject.ContainsKey(child.name))
//                            {
//                                _dicGameObject.Add(child.name, goTemp);
//                            }
//                        }
//                        break;
//                }

//                if (childUI != null)
//                {
//                    if (!_dicUI.ContainsKey(child.name))
//                    {
//                        _dicUI.Add(child.name, childUI);
//                    }
//                }
//                if (childUI.TryGetComponent(out ViewBase viewBase))
//                {
//                    viewList.Add(viewBase.gameObject);
//                    viewBase.Initialize();
//                    continue;
//                }
//                if (child.childCount > 0)
//                {
//                    AddUI(child);
//                }
//            }
//        }


//        #region GetUI

//        /// <summary>
//        /// 자식 하이라키에서 이름으로 GameObject 찾기
//        /// </summary>
//        /// <param name="hierachyName"></param>
//        /// <returns></returns>
//        public GameObject GetChildGObject(string hierachyName)
//        {
//            if (_dicGameObject.TryGetValue(hierachyName,  out GameObject goFind) == false)
//            {
//                Debug.LogError("PanelBase.GetGameObject() : 게임오브젝트 몾찾음 - " + hierachyName);
//                return null;
//            }

//            return goFind;
//        }


//        /// <summary>
//        /// 자식 하이라키에서 이름으로 UGUI Object 얻기
//        /// </summary>
//        /// <typeparam name="T"> UGUI UI 타입지정 : Image, Button, etc...</typeparam>
//        /// <param name="hierachyName"> 씬 하이라키 이름 </param>
//        /// <returns></returns>
//        public T GetUI<T>(string hierachyName) where T : MonoBehaviour
//        {
//            if (_dicUI.TryGetValue(hierachyName, out MonoBehaviour childUI) == false)
//            {
//                DEBUG.LOG("PanelBase PanelBase.GetUI() : UI 몾찾음 - " + hierachyName, eColorManager.UI);
//                return null;
//            }

//            return (T)childUI;
//        }


//        public TMP_Text GetUI_Txtmp(string hierachyName, string str = "")
//        {
//            TMP_Text txtmp = GetUI<TMP_Text>(hierachyName);
//            txtmp.LocalText(str);
//            return txtmp;
//        }

//        /// <summary>
//        /// TMP_Text를 로드함과 동시에 로컬라이제이션 셋업
//        /// </summary>
//        /// <param name="hierachyName"></param>
//        /// <param name="data"></param>
//        /// <returns></returns>
//        public TMP_Text GetUI_Txtmp(string hierachyName, string table, string entry, LocalData localData = null)
//        {
//            TMP_Text txtmp = GetUI<TMP_Text>(hierachyName);
//            txtmp.LocalText(table, entry, localData);
//            return txtmp;
//        }


//        public TMP_Text GetUI_Txtmp(string hierachyName, LocalData localData)
//        {
//            TMP_Text txtmp = GetUI<TMP_Text>(hierachyName);
//            txtmp.LocalText(localData);
//            return txtmp;
//        }


//        public Text GetUI_Txt(string hierachyName, string str = "")
//        {
//            Text txt = GetUI<Text>(hierachyName);
//            txt.LocalText(str);
//            return txt;
//        }

//        /// <summary>
//        /// Text를 로드함과 동시에 로컬라이제이션 셋업
//        /// </summary>
//        /// <param name="hierachyName"></param>
//        /// <param name="data"></param>
//        /// <returns></returns>
//        public Text GetUI_Txt(string hierachyName, string table, string entry, LocalData localData = null)
//        {
//            Text txt = GetUI<Text>(hierachyName);
//            txt.LocalText(table, entry, localData);
//            return txt;
//        }

//        public Text GetUI_Txt(string hierachyName, LocalData localData)
//        {
//            Text txt = GetUI<Text>(hierachyName);
//            txt.LocalText(localData);
//            return txt;
//        }

//        /// <summary>
//        /// Button을 로드함과 동시에 액션 셋업
//        /// </summary>
//        /// <param name="hierachyName"></param>
//        /// <param name="unityAction"></param>
//        /// <returns></returns>
//        public Button GetUI_Button(string hierachyName, UnityAction unityAction = null)
//        {
//            Button btn = GetUI<Button>(hierachyName);
//            if (unityAction != null)
//            {
//                btn.onClick.AddListener(() => Single.Sound.PlayEffect(Cons.click));
//                btn.onClick.AddListener(unityAction);
//            }
//            return btn;
//        }

//        /// <summary>
//        /// TMP_InputField 로드함과 동시에 액션, 로컬라이제이션 셋업
//        /// </summary>
//        /// <param name="hierachyName"></param>
//        /// <param name="unityAction"></param>
//        /// <returns></returns>
//        public TMP_InputField GetUI_TMPInputField(string hierachyName, UnityAction<string> valueChangedAction = null, UnityAction<string> submitAction = null)
//        {
//            TMP_InputField input = GetUI<TMP_InputField>(hierachyName);
//            if (valueChangedAction != null)
//            {
//                input.onValueChanged.AddListener(valueChangedAction);
//            }
//            if (submitAction != null)
//            {
//                input.onSubmit.AddListener(submitAction);
//            }
//            return input;
//        }

//        #endregion
//        #endregion


//    }
//}
#endregion


/**********************************************************************************************
 * 
 *                  UIBase.cs
 *                  
 *                      - UI를 캐싱하는 클래스
 *                      - 자식 UI(Button, Text...ect) 등을 보관 및 가져오기
 * 
 **********************************************************************************************/

using System;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;


namespace FrameWork.UI
{

    public class UIBase : MonoBehaviour
    {
        private bool isInit = false;                                                                        //1회성 이니셜라이즈용 bool값

        protected GameObject _myGameObject = default;
        protected Dictionary<string, MonoBehaviour> _dicUI = new Dictionary<string, MonoBehaviour>();       // 자식 하이라키에 있는 UI 보관
        protected Dictionary<string, GameObject>    _dicGameObject = new Dictionary<string, GameObject>();  // 자식 하이라키에 있는 GameObject 보관 : "go_" 로 시작하는 GameObject

        public bool dontSetActiveFalse = false;

        #region Base
        protected virtual void Awake() {  Initialize(); }
        protected virtual void Start() { }
        public virtual void Initialize()
        {
            if (isInit)
            {
                return;
            }
            isInit = true;
            _myGameObject = gameObject;
            AddUI(transform);
            SetMemberUI();
            
            if (_myGameObject != null)
            {
                if(!dontSetActiveFalse) _myGameObject.SetActive(false);
            }
 
        }
        protected virtual void SetMemberUI() { }
        #endregion


        #region View


        private List<GameObject> viewList = new List<GameObject>();
        private string curViewName = string.Empty;

        /// <summary>
        /// 체인지뷰
        /// </summary>
        /// <param name="changeViewName"></param>
        public virtual UIBase ChangeView(string changeViewName, bool leave = false)
        {
            return ChangeView<UIBase>(changeViewName, leave);
        }

        public virtual T ChangeView<T>(string changeViewName, bool leave = false)
        {
            T t = default;
            string oldViewName = curViewName;
            //Debug.Log("oldViewName : " + oldViewName);
            for (int i = 0; i < viewList.Count; i++)
            {
                if (viewList[i].name == oldViewName) //올드뷰 이름일때
                {
                    if (leave)
                    {
                        continue;
                    }
                }
                if (viewList[i].name == changeViewName) //바꿀뷰 이름일때
                {
                    viewList[i].SetActive(true);
                    viewList[i].TryGetComponent(out t);
                    curViewName = changeViewName;
                    continue;
                }
                viewList[i].SetActive(false);

            }
            return t;
        }

        /// <summary>
        /// 뷰 가져오기
        /// </summary>
        /// <param name="viewName"></param>
        /// <returns></returns>
        public GameObject GetView(string viewName)
        {
            return GetView<UIBase>(viewName).gameObject;
        }
        public T GetView<T>(string viewName)
        {
            for (int i = 0; i < viewList.Count; i++)
            {
                if (viewName.ToLower() == viewList[i].name.ToLower())
                {
                    return viewList[i].GetComponent<T>();
                }
            }
            return default;
        }
        #endregion


        #region Set UI

        /// <summary>
        /// 하위 하이라키를 탐색하면서, 미리 정해진 UI 이름과 비교해 UI Component 찾기
        /// </summary>
        /// <param name="parent"></param>
        private void AddUI(Transform parent)
        {
            for (int i = 0; i < parent.childCount; ++i)
            {
                Transform child = parent.GetChild(i);
                string[] splits = child.name.Split('_');
                string preName = splits[0].ToLower();

                bool isContinue = SetUI(preName, child); //코어코드

                if (isContinue && child.childCount > 0)
                {
                    AddUI(child);
                }
            }
        }

        /// <summary>
        /// UI 딕셔너리에 셋업
        /// </summary>
        /// <param name="preName"></param>
        /// <param name="child"></param>
        /// <returns></returns>
        protected virtual bool SetUI(string preName, Transform child)
        {
            MonoBehaviour childUI = null;
            switch (preName)
            {
                case "view":
                    childUI = child.GetComponent<UIBase>();
                    break;
                // UGUI Text
                case "txt":
                    childUI = child.GetComponent<Text>();
                    break;

                // TextMeshPro
                case "txtmp":
                    childUI = child.GetComponent<TMP_Text>();
                    break;

                // UGUI Image
                case "img":
                    childUI = child.GetComponent<Image>();
                    break;

                // UGUI Button
                case "btn":
                    childUI = child.GetComponent<Button>();
                    break;

                // UGUI TMP_Dropdown
                case "tmpdrop":
                    childUI = child.GetComponent<TMP_Dropdown>();
                    break;

                // UGUI Toggle
                case "tog":
                    {
                        childUI = child.GetComponent<Toggle>();
                        Transform tempTransform = child.transform.parent;
                        if (tempTransform != null)
                        {
                            string tempName = tempTransform.name.ToLower();
                            if (tempName.Contains("togg"))
                            {
                                ToggleGroup togGroup = tempTransform.GetComponent<ToggleGroup>();
                                if (togGroup != null)
                                {
                                    Toggle toggle = (Toggle)childUI;
                                    toggle.group = togGroup;
                                }
                            }
                        }
                    }
                    break;

                // UGUI ToggleGroup
                case "togg":
                    {
                        childUI = child.GetComponent<ToggleGroup>();
                        if (childUI == null)
                        {
                            childUI = child.gameObject.AddComponent<ToggleGroup>();
                        }
                    }
                    break;

                // UGUI Slider
                case "sld":
                    childUI = child.GetComponent<Slider>();
                    break;

                // UGUI InputFielder
                case "input":
                    {
                        if (child.GetComponent<InputField>())
                        {
                            childUI = child.GetComponent<InputField>();
                        }
                        else if (child.GetComponent<TMP_InputField>())
                        {
                            childUI = child.GetComponent<TMP_InputField>();
                        }
                    }
                    break;

                // UGUI Scrollbar
                case "scrollbar":
                    childUI = child.GetComponent<Scrollbar>();
                    break;

                // GameObject
                case "go":
                    {
                        GameObject goTemp = child.gameObject;

                        if (!_dicGameObject.ContainsKey(child.name))
                        {
                            _dicGameObject.Add(child.name, goTemp);
                        }
                    }
                    break;
                case "dropdown":
                    {
                        if (child.GetComponent<Dropdown>())
                        {
                            childUI = child.GetComponent<Dropdown>();
                        }
                        if (child.GetComponent<TMP_Dropdown>())
                        {
                            childUI = child.GetComponent<TMP_Dropdown>();
                        }
                    }
                    break;
                    
            }

            if (childUI != null)
            {
                if (!_dicUI.ContainsKey(child.name))
                {
                    _dicUI.Add(child.name, childUI);
                }
                if (childUI.TryGetComponent(out UIBase viewBase))
                {
                    viewBase.Initialize();
                    viewList.Add(viewBase.gameObject);
                    return false;
                } 
            }
            return true;
        }
        #endregion


        #region Get UI

        /// <summary>
        /// 자식 하이라키에서 이름으로 GameObject 찾기
        /// </summary>
        /// <param name="hierachyName"></param>
        /// <returns></returns>
        public GameObject GetChildGObject(string hierachyName)
        {
            GameObject goFind = default;

            if (_dicGameObject.TryGetValue(hierachyName, out goFind) == false)
            {
                Debug.LogError("PanelBase.GetGameObject() : 게임오브젝트 몾찾음 - " + hierachyName);
                return null;
            }

            return goFind;
        }


        /// <summary>
        /// 자식 하이라키에서 이름으로 UGUI Object 얻기
        /// </summary>
        /// <typeparam name="T"> UGUI UI 타입지정 : Image, Button, etc...</typeparam>
        /// <param name="hierachyName"> 씬 하이라키 이름 </param>
        /// <returns></returns>
        public T GetUI<T>(string hierachyName) where T : MonoBehaviour
        {
            if (_dicUI.TryGetValue(hierachyName, out MonoBehaviour childUI) == false)
            {
                DEBUG.LOG("PanelBase PanelBase.GetUI() : UI 몾찾음 - " + hierachyName, eColorManager.UI);
                return null;
            }

            return (T)childUI;
        }

        /// <summary>
        /// Image 찾으면서 Sprite 셋업
        /// </summary>
        /// <param name="hierachyName"></param>
        /// <param name="str"></param>
        /// <returns></returns>
        public Image GetUI_Img(string hierachyName, string str = "")
        {
            Image img = GetUI<Image>(hierachyName);
            if (str != "")
            {
                img.sprite = Resources.Load<Sprite>(Cons.Path_Image + str);
            }
            return img;
        }


        /// <summary>
        /// TMP_Text 찾으면서 텍스트 기본값 셋업
        /// </summary>
        /// <param name="hierachyName"></param>
        /// <param name="str"></param>
        /// <returns></returns>
        public TMP_Text GetUI_Txtmp(string hierachyName, string str = "")
        {
            TMP_Text txtmp = GetUI<TMP_Text>(hierachyName);
            return txtmp;
        }




   







        /// <summary>
        /// Button 찾으면서 액션 셋업
        /// </summary>
        /// <param name="hierachyName"></param>
        /// <param name="unityAction"></param>
        /// <returns></returns>
        public Button GetUI_Button(string hierachyName, UnityAction unityAction = null, string soundName = "")
        {
            Button btn = GetUI<Button>(hierachyName);

            //사운드 실행
            //btn.onClick.AddListener(() => Single.Sound.PlayEffect(soundName == "" ? Cons.click : soundName));

            //버튼이벤트 있으면 실행
            if (unityAction != null) 
            {
                btn.onClick.AddListener(unityAction);
            }
            
            return btn;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hierachyName"></param>
        /// <param name="unityAction"></param>
        /// <returns></returns>
        public TMP_InputField GetUI_TMPInputField(string hierachyName, UnityAction<string> valueChangedAction = null, UnityAction<string> submitAction = null)
        {
            TMP_InputField input = GetUI<TMP_InputField>(hierachyName);
            if (valueChangedAction != null)
            {
                input.onValueChanged.AddListener(valueChangedAction);
            }
            if (submitAction != null)
            {
                input.onSubmit.AddListener(submitAction);
            }
            return input;
        }
        

        /// <summary>
        /// Toggle 찾으면서 체인지벨류 액션 셋업
        /// </summary>
        /// <param name="hierachyName"></param>
        /// <param name="toggleOn"></param>
        /// <returns></returns>
        public Toggle GetUI_Toggle(string hierachyName, UnityAction toggleOn = null, UnityAction toggleOff = null)
        {
            Toggle tog = GetUI<Toggle>(hierachyName);
            if (toggleOn != null)
            {
                //tog.onValueChanged.AddListener((b) => { if (b) Single.Sound.PlayEffect(Cons.click); });
                tog.onValueChanged.AddListener((b) => { if (b) toggleOn(); });
            }
            if (toggleOff != null)
            {
                //tog.onValueChanged.AddListener((b) => { if (!b) Single.Sound.PlayEffect(Cons.click); });
                tog.onValueChanged.AddListener((b) => { if (!b) toggleOff(); });
            }
            return tog;
        }

        /// <summary>
        /// Toggle 찾으면서 체인지벨류 액션 셋업
        /// </summary>
        /// <param name="hierachyName"></param>
        /// <param name="toggleOn"></param>
        /// <returns></returns>
        public Toggle GetUI_Toggle(string hierachyName, UnityAction<bool> toggleAction)
        {
            Toggle tog = GetUI<Toggle>(hierachyName);
            if (toggleAction != null)
            {
                //tog.onValueChanged.AddListener((b) => { if (b) Single.Sound.PlayEffect(Cons.click); });
                tog.onValueChanged.AddListener(toggleAction);
            }
            return tog;
        }

        #endregion


        #region ETC
        //public void Unload()
        //{
        //    _dicUI.Clear();
        //    _dicGameObject.Clear();
        //}
        #endregion
    }
}