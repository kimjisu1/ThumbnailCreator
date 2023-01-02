using UnityEngine;


public static class Cons
{
    #region Time : 시간
    public static readonly WaitForFixedUpdate Time_FrameRateFixedUpdate = new WaitForFixedUpdate();
    public static readonly WaitForSeconds     Time_FrameRate            = new WaitForSeconds(0.012f);
    public static readonly WaitForSeconds     Time_FrameRateMove        = new WaitForSeconds(0.012f);
    public static readonly WaitForSeconds     Time_Sec_0D01             = new WaitForSeconds(0.01f);
    public static readonly WaitForSeconds     Time_Sec_0D03             = new WaitForSeconds(0.03f);
    public static readonly WaitForSeconds     Time_Sec_0D05             = new WaitForSeconds(0.05f);
    public static readonly WaitForSeconds     Time_Sec_0D1              = new WaitForSeconds(0.1f);
    public static readonly WaitForSeconds     Time_Sec_0D2              = new WaitForSeconds(0.2f);
    public static readonly WaitForSeconds     Time_Sec_0D3              = new WaitForSeconds(0.3f);
    public static readonly WaitForSeconds     Time_Sec_0D4              = new WaitForSeconds(0.4f);
    public static readonly WaitForSeconds     Time_Sec_0D5              = new WaitForSeconds(0.5f);
    public static readonly WaitForSeconds     Time_Sec_1                = new WaitForSeconds(1f);
    public static readonly WaitForSeconds     Time_Sec_1D5              = new WaitForSeconds(1.5f);
    public static readonly WaitForSeconds     Time_Sec_2                = new WaitForSeconds(2f);
    public static readonly WaitForSeconds     Time_Sec_2D5              = new WaitForSeconds(2.5f);
    public static readonly WaitForSeconds     Time_Sec_3                = new WaitForSeconds(3f);
    public static readonly WaitForSeconds     Time_Sec_3D5              = new WaitForSeconds(3.5f);
    public static readonly WaitForSeconds     Time_Sec_5                = new WaitForSeconds(5f);
    public static readonly WaitForSeconds     Time_Sec_10               = new WaitForSeconds(10f);
    public static readonly WaitForSeconds     Time_Sec_20               = new WaitForSeconds(20f);
    public static readonly WaitForEndOfFrame  Time_WaitForEndOfFrame    = new WaitForEndOfFrame();
    #endregion



    #region Color : 색상
    public static readonly Color Color_Red              =   new Color(0.89f, 0.24f, 0.13f, 1f);
    public static readonly Color Color_Orange           =   new Color(1f, 0.58f, 0.29f, 1f);
    public static readonly Color Color_Green            =   new Color(0.03f, 0.89f, 0.04f, 1f);
    public static readonly Color Color_MintGreen        =   new Color(0f, 0.91f, 0.74f, 1f);
    public static readonly Color Color_HotPink          =   new Color(0.9f, 0.29f, 0.57f, 1f);
    public static readonly Color Color_Blue             =   new Color(0.23f, 0.33f, 1f, 1f);
    public static readonly Color Color_CodeGateBlue     =   new Color(0f, 0.75f, 1f, 1f);
    public static readonly Color Color_Indigo           =   new Color(0.08f, 0.17f, 0.49f, 1f);
    public static readonly Color Color_Yellow           =   new Color(1f, 0.75f, 0.22f, 1f);
    public static readonly Color Color_Pink             =   new Color(0.92f, 0.1f, 0.9f, 1f);
    public static readonly Color Color_LightGreen       =   new Color(0.5f, 1f, 0.73f, 1f);
    public static readonly Color Color_Ivory            =   new Color(1f, 0.91f, 0.79f, 1f);
    public static readonly Color Color_Gray             =   new Color(0.53f, 0.53f, 0.53f, 1f);
    public static readonly Color Color_Brown            =   new Color(0.64f, 0.16f, 0.16f, 1f);
    public static readonly Color Color_WhiteGray        =   new Color(0.78f, 0.78f, 0.78f, 1f);
    public static readonly Color Color_White            =   new Color(1f, 1f, 1f, 1f);
    public static readonly Color Color_Black            =   new Color(0f, 0f, 0f, 1f);
    public static readonly Color Color_DarkGray         =   new Color(0.19f, 0.19f, 0.19f, 1f);
    public static readonly Color Color_SkyPink          =   new Color(0.97f, 0.77f, 0.77f, 1f);
    public static readonly Color Color_SkyBlue          =   new Color(0.77f, 0.97f, 0.97f, 1f);
    public static readonly Color Color_CobaltBlue       =   new Color(0.38f, 0.77f, 0.89f, 1f);
    public static readonly Color Color_Alpha200_White   =   new Color(1f, 1f, 1f, 0.78f);
    public static readonly Color Color_Purple           =   new Color(0.54f, 0.41f, 0.87f, 1f);

    public static readonly Color codegateColor          =   new Color(0.17f, 0.56f, 1f); //코게
    public static readonly Color jagalchiColor          =   new Color(0.46f, 0.79f, 1f); //자갈치
    #endregion


    #region String : 단순 스트링값
    //Sound
    public const string click = "click";

    // 버튼음
    public const string effect_btn_0 = "effect_btn_0";
    public const string effect_btn_1 = "effect_btn_1";
    public const string effect_btn_2 = "effect_btn_2";
    public const string effect_warn_0 = "effect_warn_0";
    public const string effect_info_0 = "effect_info_0";
    public const string effect_poshit_1 = "effect_poshit_1";
    public const string effect_poshit_2 = "effect_poshit_2";
    
    // 점프
    public const string effect_jump_ = "effect_jump_";
    public const string effect_jump_0 = "effect_jump_0";
    public const string effect_jump_1 = "effect_jump_1";
    public const string effect_jump_2 = "effect_jump_2";
    public const string effect_jump_3 = "effect_jump_3";
    public const string effect_jump_4 = "effect_jump_4";

    // 2단 점프
    public const string effect_hjump_ = "effect_hjump_";
    public const string effect_hjump_0 = "effect_hjump_0";
    public const string effect_hjump_1 = "effect_hjump_1";
    public const string effect_hjump_2 = "effect_hjump_2";
    public const string effect_hjump_3 = "effect_hjump_3";
    
    // 바다 빠짐
    public const string effect_dive_0 = "effect_dive_0";

    // 대쉬
    public const string effect_dash = "Dash_03";

    //BGM
    public const string bgm_game_0 = "bgm_game_0";
    public const string bgm_lobby_0 = "bgm_lobby_0";
    public const string bgm_theme_0 = "bgm_theme_0";
    public const string bgm_world_0 = "bgm_world_0";

    public const string Setting_Quality = "Setting_Quality";
    public const string Setting_Language = "Setting_Language";
    public const string Setting_VolumeMaster = "Setting_VolumedMaster";
    public const string Setting_VolumeBGM = "Setting_VolumeBGM";
    public const string Setting_VolumeEffect = "Setting_VolumeEffect";
    public const string Setting_VolumeMedia = "Setting_VolumeMedia";

    //Addessable
    public const string AddressablePath_Use_Asset_Database = "Use Asset Database (fastest)";
    public const string AddressablePath_Simulate_Groups = "Simulate Groups (advanced)";
    public const string AddressablePath_Use_Existing_Build = "Use Existing Build (requires built groups)";

    //Scene
    //public const string Scene_Logo      = "0.Logo";
    //public const string Scene_Patch     = "1.Patch";
    //public const string Scene_Title     = "2.Title";
    //public const string Scene_Lobby     = "3.Lobby";
    //public const string Scene_Loading   = "99.Loading";
    public const string Scene_Logo              = "000_Scene_Logo";
    public const string Scene_Patch             = "001_Scene_Patch";
    public const string Scene_Title             = "002_Scene_Title";
    public const string Scene_Lobby             = "003_Scene_Lobby";
    public const string Scene_Loading           = "004_Scene_Loading";
    public const string Scene_World             = "100_Scene_World";
    public const string Scene_World_Arzmeta     = "100_Scene_World_Arzmeta";
    public const string Scene_World_Busan       = "100_Scene_World_Busan";
    public const string Scene_FallGuys          = "101_Scene_FallGuys";
    public const string Scene_OXQuiz            = "102_Scene_OXQuiz";
    public const string Scene_InfinityCode      = "103_Scene_InfinityCode";
    public const string Scene_CTFZone           = "104_Scene_CTFZone";
    public const string Scene_GameZone          = "105_Scene_GameZone";
    public const string Scene_MeetingRoom       = "106_Scene_MeetingRoom";
    public const string Scene_StoreConnecity    = "107_Scene_StoreConnecity";
    public const string Scene_LectureHall       = "108_Scene_LectureHall";
    public const string Scene_MeetingRoom_22Christmas  = "106_Scene_MeetingRoom_22Christmas";
    public const string Scene_LectureHall_22Christmas  = "108_Scene_LectureHall_22Christmas";
    public const string Scene_VoteHall          = "109_Scene_VoteHall";
    //public const string Scene_MyRoom            = "200_Scene_MyRoom";
    public const string Scene_MyRoom            = "201_Scene_MyRoomCustom";
    public const string Scene_Realtime_Lobby    = "800_Scene_Realtime_Lobby";
    public const string Scene_Realtime_World    = "801_Scene_Realtime_World";
    public const string Scene_Realtime_FallGuys = "802_Scene_Realtime_FallGuys";
    public const string Scene_Realtime_OXQuiz   = "803_Scene_Realtime_OXQuiz";
    public const string Scene_Seed              = "999_Scene_Seed";
    
    // Common
    public const string PlayerController = "PlayerController";
    public const string MyCamera = "PlayerController/CameraRig/TrackingSpace/CenterEyeAnchor";

    // Player Camera
    public const string CameraParent = "CameraParent";
    public const string PlayerParent = "PlayerParent";
    public const string Hair = "Hair";
    public const string Top = "Top";
    public const string Bottom = "Bottom";
    public const string MainCamera = "MainCamera";
    public const string PlayerCameraRoot = "PlayerCameraRoot";
    public const string NickName = "NickName";
    public const string AvatarParts = "AvatarParts";
    public const string HUDParent = "HUDParent";
    public const string Hand = "Bip001 R Hand";

    // MyPlayer controllers
    public const string TPSController = "ThirdPersonController";
    public const string AvatarPartsController = "AvatarPartsController";

    // TPS Controllers
    public const string CharacterController = "CharacterController";
    public const string DashController = "CharacterDashController";
    public const string CharacterParticleController = "CharacterParticleController";
    public const string FallController = "CharacterFallController";
    public const string VolumeController = "CharacterVolumeController";

    // Player Input
    public const string StarterAssetsInputs = "StarterAssetsInputs";
    public const string PlayerInput = "PlayerInput";
    public const string Animator = "Animator";

    public const string LeanPinchCamera = "go_LeanPinch";
    public const string ViewJoyStickZone = "view_JoystickZone";
    public const string ViewChat = "view_Chat";
    public const string ViewTop = "view_Top";
    public const string ViewTouch = "view_TouchZone";

    public const string JoyStickMove = "joystick_Move";
    public const string JoyStickJump = "joystick_Jump";
    public const string JoyStickDash = "joystick_Dash";

    // Player Animation
    public const string StandMove = "Stand Move";
    public const string Grounded = "Grounded";
    public const string Jump = "Jump";
    public const string Dash = "Dash";
    public const string FreeFall = "FreeFall";
    public const string MotionSpeed = "MotionSpeed";



    //Input
    public const string Horizontal = "Horizontal";
    public const string Vertical = "Vertical";

    //HUD
    public const string Panel_HUD = "Panel_HUD";
    public const string Panel_Map = "Panel_Map";
    public const string Panel_WorldProfile = "Panel_WorldProfile";
    public const string Panel_Quest = "Panel_Quest";
    public const string Panel_Setting = "Panel_Setting";
    public const string Panel_Chat = "Panel_Chat";
    public const string Panel_NPC = "Panel_NPC";
    public const string Panel_SNS = "Panel_SNS";
    public const string Panel_Search = "Panel_Search";
    public const string Panel_Comment = "Panel_Comment";
    public const string Panel_WritePost = "Panel_WritePost";
    public const string Panel_Tutorial = "Panel_Tutorial";
    public const string Panel_Kiosk = "Panel_Kiosk";
    public const string Panel_ConveyorBelt = "Panel_ConveyorBelt";
    public const string Panel_Photo = "Panel_Photo";
    public const string Panel_Telescope = "Panel_Telescope";
    public const string Panel_Phone = "Panel_Phone";
    public const string Panel_Friend = "Panel_Friend";
    public const string Panel_Camera = "Panel_Camera";
    public const string Panel_Scan = "Panel_Scan";
    public const string Panel_Messanger = "Panel_Messanger";
    public const string Panel_MyRoomPlaymode = "Panel_MyRoomPlaymode";
    public const string Panel_BusinessCard_World = "Panel_BusinessCard_World";
    public const string Panel_Game = "Panel_Game";

    // 로그인용 웹뷰 URL 구분자
    public const string Login_header = "arzmeta://";
    public const string Login_type = "login?";
    public const string Login_error = "loginCancel!";
    #endregion

    #region Prefab : 프리팹명
    public const string PanelBase = "PanelBase";
    public const string Panel_Base = "Panel_Base";
    //Popup_Common
    //public const string PopupSmall = "PopupSmall";
    //public const string PopupMedium = "PopupMedium";
    //public const string PopupLarge = "PopupLarge";
    public const string Popup_ScrollView = "Popup_ScrollView";
    public const string PopupTOSDetail = "PopupTOSDetail";
    public const string PopupHorizontal = "PopupHorizontal";
    public const string PopupVertical = "PopupVertical";
    public const string ToastPopupHorizontal = "ToastPopupHorizontal";
    public const string ToastPopupVertical = "ToastPopupVertical";
    public const string PopupMakeRoom = "PopupMakeRoom";
    public const string PopupSearchRoom = "PopupSearchRoom";
    public const string Popup_Purchase = "Popup_Purchase";
    public const string Popup_PayArowanaToken = "Popup_PayArowanaToken";
    public const string Popup_CompletePayment = "Popup_CompletePayment";
    public const string Popup_TermsOfService = "Popup_TermsOfService";
    public const string Popup_Banner = "Popup_Banner";
    public const string Popup_BrandList = "Popup_BrandList";
    public const string Popup_BusinessCard_World = "Popup_BusinessCard_World";
    
    //Panel_LogoScene
    public const string Panel_HancomLogo = "Panel_HancomLogo";
    public const string Panel_HancomForntisLogo = "Panel_HancomForntisLogo";
    public const string Panel_CodeGateLogo = "Panel_CodeGateLogo";
    public const string Panel_ArzmetaLogo = "Panel_ArzmetaLogo";
    
    //Panel_TitleScene
    public const string Panel_ManualLogin = "Panel_ManualLogin";
    public const string Panel_Title = "Panel_Title";
    public const string Panel_Login_Social = "Panel_Login_Social";
    public const string Panel_Login = "Panel_Login";
    public const string Panel_CreateAccount = "Panel_CreateAccount";
    public const string Panel_FindID = "Panel_FindID";
    public const string Panel_ChangeEmail = "Panel_ChangeEmail";
    public const string Panel_FindPW = "Panel_FindPW";
    public const string Panel_AutoLogin = "Panel_AutoLogin";
    public const string Panel_DormantAccount = "Panel_DormantAccount";

    //Panel_LobbyScene
    public const string Panel_CreateAvatar = "Panel_CreateAvatar";
    public const string Panel_NickName = "Panel_NickName";
    public const string Panel_ChangeProfile = "Panel_ChangeProfile";
    public const string Panel_Profile = "Panel_Profile";
    public const string Panel_Channel = "Panel_Channel";
    public const string Panel_Content = "Panel_Content";
    public const string Panel_ChangePassword = "Panel_ChangePassword";
    public const string Panel_Preset = "Panel_Preset";
    public const string Panel_BusinessCard = "Panel_BusinessCard";
    public const string Panel_BusinessCardCheck = "Panel_BusinessCardCheck";

    //Panel_Game
    public const string Panel_GameSelect = "Panel_GameSelect";
    public const string Panel_GameLobby = "Panel_GameLobby";
    public const string Panel_MultiGame = "Panel_MultiGame";
    public const string Panel_SingleGame = "Panel_SingleGame";
    public const string Panel_InfinityCode = "Panel_InfinityCode";

    //Panel_Setting 하위 View
    public const string View_Account = "View_Account";
    public const string View_Payment = "View_Payment";
    public const string View_Channel = "View_Channel";
    public const string View_System = "View_System";
    public const string View_Notice = "View_Notice";
    public const string View_FAQ = "View_FAQ";
    public const string Panel_LeaveAccount = "Panel_LeaveAccount";
    public const string Panel_AccountConnect = "Panel_AccountConnect";
    public const string Panel_LinkAccount = "Panel_LinkAccount";

    //Panel_Quest 하위 View
    public const string View_QuestComplete = "View_QuestComplete";

    //Panel_ChatBot 
    public const string Panel_ChatBot = "Panel_ChatBot";

    //Panel_MeetingRoom 및 하위 View 
    public const string Panel_OfficeRoom = "Panel_OfficeRoom";

    public const string View_OfficeRoomInfo = "View_OfficeRoomInfo";
    public const string View_OfficeRoomCodeEnter = "View_OfficeRoomCodeEnter";
    public const string View_MakeOfficeRoom = "View_MakeOfficeRoom";
    
    public const string Popup_SelectOfficeInfo = "Popup_SelectOfficeInfo";
    public const string Popup_OfficeRoomInfo = "Popup_OfficeRoomInfo";
    public const string Popup_OfficeUserInfo = "Popup_OfficeUserInfo";
    public const string Popup_OfficePassword = "Popup_OfficePassword";

    public const string View_OfficeUserGuestUI = "View_OfficeUserGuestUI";
    public const string View_OfficeUserHostUI = "View_OfficeUserHostUI";
    
    #endregion



    #region Resources : 순수데이터

    //Path

    //Addressable안쓰고 Resources쓰는것 임시 패스
    public const string Path_Addressable = "Addressable/";

    public const string Path_Avatar = Path_Addressable + "Avatar/";
        public const string Path_Thumbnail = Path_Avatar + "Thumbnail/";
            public const string Path_ThumbnailHair = Path_Thumbnail + "Hair/";
            public const string Path_ThumbnailTop = Path_Thumbnail + "Top/";
            public const string Path_ThumbnailBottom = Path_Thumbnail + "Bottom/";
            public const string Path_ThumbnailSet = Path_Thumbnail + "Set/";
            public const string Path_ThumbnailShoes = Path_Thumbnail + "Shoes/";
            public const string Path_ThumbnailAcc = Path_Thumbnail + "Acc/";

    public const string Path_AudioClip = Path_Addressable + "AudioClip/";

    public const string Path_ArzPhoneIcon = Path_Addressable + "ArzPhone/Icon/";
    public const string Path_Image = Path_Addressable + "Image/";

    public const string Path_MasterData = Path_Addressable + "MasterData/";

    public const string Path_Prefab = Path_Addressable + "Prefab/";
        public const string Path_Prefab_Common = Path_Prefab + "Common/";
        public const string Path_Prefab_HallOfFame = Path_Prefab + "HallOfFame/";
        public const string Path_Prefab_NPC = Path_Prefab + "NPC/";
        public const string Path_Prefab_Particle = Path_Prefab + "Particle/";
        public const string Player_Prefab_Player = Path_Prefab + "Player/";
            public const string Player_Realtime = Player_Prefab_Player + "Player_Realtime";
        public const string Path_Prefab_View = Path_Prefab + "View/";
        public const string Path_Interaction = Path_Prefab + "Interaction/";

    public const string Path_ScriptableObject = Path_Addressable + "ScriptableObject/";
    public const string Path_Animator = Path_Addressable + "Animator/";
    public const string Path_RenderTexture = Path_Addressable + "RenderTexture/";



    // 로컬라이제이션 카테고리
    public const string Local_Arzmeta = "Arzmeta";
    public const string Local_Quest = "Quest";
    public const string Local_NPC = "NPC";
    public const string Local_AvatarParts = "AvatarParts";
    public const string Local_InfinityCodes = "InfinityCodes";
    public const string Local_Game = "Game";
    public const string Local_OXQuiz = "OXQuiz";
    public const string Local_Terms = "Terms";

    //Layer
    public const string Layer_Default = "Default";
    public const string Layer_TransparentFX = "TransparentFX";
    public const string Layer_IgnoreRaycast = "Ignore Raycast";
    public const string Layer_PostProcessing = "Post Processing";
    public const string Layer_Water = "Water";
    public const string Layer_UI = "UI";
    public const string Layer_Ignore = "Ignore";
    public const string Player = "Player";
    public const string Layer_NPC = "NPC";
    public const string OtherPlayer = "OtherPlayer";
    public const string Layer_TouchZone = "TouchZone";
    public const string Layer_OutLine = "OutLine";
    public const string Layer_InteractionArea = "InteractionArea";
    public const string Layer_Book = "Book";
    public const string Layer_NoneInteractable = "NoneInteractable";
    public const string NonCollideable = "NoneCollideable";
    public const string Layer_Code = "Code";

    //마이룸
    public const string Path_MyRoom = "MyRoom";

    //Animation

    //Animator

    //AudioClip

    //DB

    //Font

    //Particle
    public const string EF_summon = "EF_summon";
    public const string EF_Dummy = "EF_Dummy";
    public const string EF_Star = "EF_Star";

    //Sprite

    //Video

    //Web
    public const string RequestServerUrl = "/Rooms?servertype=";
    public static readonly string RequestInnerServerUrl = $"http://{InnerServerUrl}:8080/Rooms";
    public const string InnerServerUrl = "192.168.0.47";
    // public const string InnerServerUrl = "192.168.10.168";

    public const string RequestMakeRoom = "/MakeRoom"; // 클라우드 서버에 룸 생성할 때 사용 
    public static readonly string RequestInnerServerMakeRoom = $"http://{InnerServerUrl}:8080/MakeRoom";

    public const string Panel_MyRoomMain = "Panel_MyRoomMain";
    public const string Panel_MyRoomControl = "Panel_MyRoomControl";
    public const string Panel_MyRoomInven = "Panel_MyRoomInven";
    public const string Popup_ItemDetail = "Popup_ItemDetail";
    public const string Popup_ItemSave = "Popup_ItemSave";
    public const string Popup_ItemHistory = "Popup_ItemHistory";

    //GameName
    public const string JumpingMatching = "점핑매칭";
    public const string OxQuiz = "OX 퀴즈";
    
    //PlayerPrefs
    public const string GameRoomId = "GameRoomId";
    public const string GameType = "GameType";
    public const string GameZoneFloor = "GameZoneFloor";
    // public const string CurChannel = "CurChannel";

    //회의룸
    // public const string Meeting_RoomName = "Meeting_RoomName";
    // public const string Meeting_RoomId = "Meeting_RoomId";
    // public const string Meeting_PassWord = "Meeting_PassWord";

    #endregion
}


