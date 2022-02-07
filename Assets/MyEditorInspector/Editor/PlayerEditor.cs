using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Player))]
public class PlayerEditor : UnityEditor.Editor
{
    Player Player;
    bool showWeapons;

    void OnEnable()
    {
        //获取当前编辑自定义Inspector的对象
        Player = (Player)target;
    }
    public override void OnInspectorGUI()
    {
               //设置整个界面是以垂直方向来布局
        EditorGUILayout.BeginVertical();

        //空两行
        EditorGUILayout.Space();
        EditorGUILayout.Space();

        //绘制palyer的基本信息
        EditorGUILayout.LabelField("Base Info");
        Player.id = EditorGUILayout.IntField("Player ID",Player.id);
        Player.PlayerName = EditorGUILayout.TextField("PlayerName",Player.PlayerName);

        //空三行
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.Space();

        //绘制Player的背景故事
        EditorGUILayout.LabelField("Back Story");
        Player.backStory = EditorGUILayout.TextArea(Player.backStory,GUILayout.MinHeight(100));

        //空三行
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.Space();

        //使用滑块绘制 Player 生命值
        Player.health = EditorGUILayout.Slider("Health",Player.health,0,100);

        //根据生命值设置生命条的背景颜色
        if(Player.health<20){
            GUI.color = Color.red;
        }
        else if(Player.health>80){
            GUI.color = Color.green;
        }
        else
        {
            GUI.color = Color.gray;
        }

        //指定生命值的宽高
        Rect progressRect = GUILayoutUtility.GetRect(50,50);

        //绘制生命条
        EditorGUI.ProgressBar(progressRect,Player.health/100.0f,"Health");

        //用此处理，以防上面的颜色变化会影响到下面的颜色变化
        GUI.color = Color.white;

        //空三行
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.Space();

        //使用滑块绘制伤害值
        Player.damage = EditorGUILayout.Slider("Damage",Player.damage,0,20);

        //根据伤害值的大小设置显示的类型和提示语
        if(Player.damage<10){
            EditorGUILayout.HelpBox("伤害太低了吧！！", MessageType.Error);
        }
        else if(Player.damage>15){
            EditorGUILayout.HelpBox("伤害有点高啊！！", MessageType.Warning);
        }
        else{
            EditorGUILayout.HelpBox("伤害适中！！", MessageType.Info);
        }

         //空三行
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.Space();

        //设置内容折叠
        showWeapons=EditorGUILayout.Foldout(showWeapons,"Weapons");
        if(showWeapons){
            Player.weaponDamage1=EditorGUILayout.FloatField("Weapon 1 Damage",Player.weaponDamage1);
             Player.weaponDamage2=EditorGUILayout.FloatField("Weapon 2 Damage",Player.weaponDamage2);
        }

        //空三行
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.Space();

        //绘制鞋子信息
        EditorGUILayout.LabelField("Shoe");
        //以水平方向绘制
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Name",GUILayout.MaxWidth(50));
        Player.shoeName=EditorGUILayout.TextField(Player.shoeName);
        EditorGUILayout.LabelField("Size",GUILayout.MaxWidth(50));
        Player.shoeSize=EditorGUILayout.IntField(Player.shoeSize);
        EditorGUILayout.LabelField("Type",GUILayout.MaxWidth(50));
        Player.shoeType=EditorGUILayout.TextField(Player.shoeType);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.EndVertical();
    }
    
}
