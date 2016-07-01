'システム名 ： HABITS
'概要　　　 ：
'説明　　　 ： 宣言
'履歴　　　 ： 2010/04/01　ＳＷＪ　作成
'Copyright(c) System Works Japan Co.,Ltd. 2010 All Rights Reserved.

Option Explicit On
Option Strict Off
Option Compare Binary

Module 宣言

    Public DBA As Habits.DB.DBAccess
    Public DBA2 As Habits.DB.DBAccess

    '--------------------------------------------------
    ' フォーム
    '--------------------------------------------------
    Public M01 As Object                        ' メニュー・フォーム
    Public rtn As Long                          ' 戻り値
    Public CST_CODE As Long                     ' 顧客番号
    Public SER_NO As Integer                    ' 来店者番号
    Public MESSAGE_CNT As Integer               ' 未チェックメッセージ件数

    Public USER_DATE As Date                    ' ユーザー日付

    Public NETWORK_FLAG As Boolean              ' 通信許可フラグ（True：通信してよい、False：通信させない）
    Public ACTIVE_NETWORK_FLAG As Boolean       ' 通信中フラグ（True:通信中のため再通信させない、False：通信なし）
    Public FORCED_CLOSE_FLAG As Boolean         ' 強制終了フラグ（True：強制終了させる、False：通常処理中）
    Public MESSAGE_CHECK_FLAG As Boolean        ' メッセージ件数チェック中フラグ（True:メッセージCK不要、False：メッセージCK要）
    Public MANAGER_MODE As Boolean              ' 管理者モード（True：管理者モード、False：その他）

    Public sShopcode As String                  ' 店舗コード


    Public TAX_MANAGEMENT_TYPE As Integer       ' 税区分（1：免税事業者or2：課税事業者）
    Public iTaxtype As Integer                  ' 会計時消費税計算タイプ
    Public iServicetype As Integer              ' 会計時サービス計算タイプ
    Public ReCheckFlag As Boolean               ' 再会計時チェックフラグ

    Public ReCheckDenpyoFlag As Boolean         ' 再会計時伝票ボタン押下チェックフラグ

    '--------------------------------------------------
    ' 定数
    '--------------------------------------------------
    Public Const APP_NAME As String = "HabitsProject"
    Public Const TTL As String = "HABITS"                   ' タイトル
    Public Const URL_HABITS_MAIN As String = "https://Habits.swj.co.jp/"        ' WebサーバのHabitsURL元
    Public Const URL_HABITS_NETWORK As String = ".DataSync/"                    ' WebサーバのHabitsデータ通信ディレクトリ
    Public Const URL_HABITS_NDATAFOLDER As String = ".DataSync/DownloadData/"   ' WebサーバのHabitsデータ通信データ保管ディレクトリ

    'データ保存フォルダ
    Public Const MESSAGE_PATH As String = "MessageData"     ' メッセージ通信用フォルダ
    Public Const MASTER_PATH As String = "MasterTable"      ' マスタ更新用フォルダ
    Public Const RESERVE_PATH As String = "ReserveTable"    ' 予約データ用フォルダ

    Public Const Clng_MAXCstNo As Long = 1000000            ' 最大顧客番号
    Public Const Clng_STFreeNo As Long = 500000             ' フリー顧客の開始顧客番号
    Public Const Max_MasterNo As Integer = 9999             ' 最大コード番号
    Public Const Min_Date As String = "1900/1/1"

    '来店処理可能フラグ
    'True : 設定日が当日で無い場合でも、来店処理を可能とする。
    Public Visit_Mode As Boolean = False

    '会計処理可能フラグ
    'True : 設定日が当日で無い場合でも、会計処理を可能とする。
    Public Cashiers_Mode As Boolean = False

    '来店区分
    Public Const VISIT_RETURN As Integer = 1            ' 再来
    Public Const VISIT_NEW As Integer = 2               ' 新規
    Public Const VISIT_FREE As Integer = 3              ' フリー
    Public Const VISIT_FREE_CHAR As String = "フリー"   ' フリー文言

    '登録区分
    Public Const BTN_REGIST As String = "登録"     ' 登録
    Public Const BTN_UPDATE As String = "変更"     ' 変更
    Public Const BTN_DELETE As String = "削除"     ' 削除

    '登録区分
    Public Const REGISTER_COMPLETION As Integer = 1     ' 登録済

    '通信中エラー回数
    Public Const CONNECT_ERROR As Integer = 5

    '会計時店販対象フラグ
    'False:店販対象の会計時、在庫数が0や-であってもアナウンスしない
    Public Const item_mode As Boolean = False

    '情報メッセージ
    Public Const Clng_Okcrb1 As Long = vbOKOnly + vbCritical + vbDefaultButton1       '警告
    Public Const Clng_Okexb1 As Long = vbOKOnly + vbExclamation + vbDefaultButton1    '注意
    Public Const Clng_Okinb1 As Long = vbOKOnly + vbInformation + vbDefaultButton1    '情報

    '確認メッセージ
    Public Const Clng_Ynqub1 As Long = vbYesNo + vbQuestion + vbDefaultButton1        '問い合わせ
    Public Const Clng_Ynqub2 As Long = vbYesNo + vbQuestion + vbDefaultButton2        '第2ボタンを標準

    'メッセージ印刷に使用する改行コード
    Public Const NEW_LINE_CODE As String = "<br/>"

End Module
