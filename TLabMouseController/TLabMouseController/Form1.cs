using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace TLabMouseController
{
    public partial class Form1 : Form
    {
        private Dictionary<string, (int, int)> coords;
        private Dictionary<string, string> moveDir;
        private Dictionary<string, int> moveAmount;
        private Dictionary<string, string> keyDic;
        private List<string> keyList;
        private bool keepAlive;
        private InputHandler.CursorHandler cursorHandler;

        [DllImport("user32.dll")]
        private static extern short GetAsyncKeyState(int vKey);
        [DllImport("User32.dll")]
        static extern bool GetCursorPos(out POINT lppoint);

        // 透明な画像をカーソルとして読み込むことでカーソルを視覚的に見えなくする

        [StructLayout(LayoutKind.Sequential)]
        struct POINT
        {
            public int X { get; set; }
            public int Y { get; set; }
        }

        public Form1()
        {
            InitializeComponent();
            coords = new Dictionary<string, (int, int)>();
            moveDir = new Dictionary<string, string>();
            moveAmount = new Dictionary<string, int>();
            keyDic = new Dictionary<string, string>();
            keyList = new List<string>();
            keepAlive = true;
            cursorHandler = new InputHandler.CursorHandler();
            Thread mainLoop = new Thread(new ThreadStart(MainLoop));
            mainLoop.IsBackground = true;
            mainLoop.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadConfig();
        }

        private void SetTextBox(string configName)
        {
            if (configName == "lastConfig")
            {
                configName = Configs.Items[Configs.Items.Count - 1].ToString();
            }
            string key = keyDic.First(content => content.Value == configName).Key;
            (int, int) coord = coords[key];
            ConfigName.Text = configName;
            XCoord.Text = coord.Item1.ToString();
            YCoord.Text = coord.Item2.ToString();
            MoveDir.Text = moveDir[key];
            MoveAmount.Text = moveAmount[key].ToString();
            Key.Text = key;

            for (int i = 0; i < Configs.Items.Count; i++)
            {
                if(Configs.Items[i].ToString() == configName)
                {
                    Configs.SelectedIndex = i;
                    return;
                }
            }
        }

        private void AddItem()
        {
            // lastConfigは予約済みの値なのでユーザーからは登録出来ないようにする
            if (ConfigName.Text == "lastConfig")
            {
                MessageBox.Show(
                    string.Format(" lastConfig は予約済みの値です"));
                return;
            }

            for (int i = 0; i < Configs.Items.Count; i++)
            {
                if (ConfigName.Text == Configs.Items[i].ToString())
                {
                    MessageBox.Show(
                        string.Format("同じ値のConfigNameが既に存在しています"));
                    return;
                }
            }

            for (int i = 0; i < coords.Count; i++)
            {
                if (keyList[i] == Key.Text)
                {
                    MessageBox.Show(
                        string.Format("同じ値のKeyが既に存在しています"));
                    return;
                }
            }

            int coordXParse;
            int coordYParse;
            try
            {
                coordXParse = Int32.Parse(XCoord.Text);
                coordYParse = Int32.Parse(YCoord.Text);
            }
            catch (FormatException exception)
            {
                // 文字列の変換に失敗した
                MessageBox.Show(
                    string.Format("整数を文字型で入力してください{0}", exception.Message));
                return;
            }

            // 方向の整合性チェック
            string dir = "None";
            if(MoveDir.Text == "Up" || MoveDir.Text == "Down"
                || MoveDir.Text == "Right" || MoveDir.Text == "Left")
            {
                dir = MoveDir.Text;
            }

            int amount;
            try
            {
                amount = Int32.Parse(MoveAmount.Text);
            }
            catch (FormatException exception)
            {
                // 文字列の変換に失敗した
                MessageBox.Show(
                    string.Format("整数を文字型で入力してください{0}", exception.Message));
                return;
            }

            coords.Add(Key.Text, (coordXParse, coordYParse));
            moveDir.Add(Key.Text, dir);
            moveAmount.Add(Key.Text, amount);
            keyList.Add(Key.Text);
            keyDic.Add(Key.Text, ConfigName.Text);
            Configs.Items.Add(ConfigName.Text);
            Configs.SelectedIndex = Configs.Items.Count - 1;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            AddItem();
        }

        private void DeleteItem(string removeItem)
        {
            // (入力キー，ConfigName)の辞書から逆引きする
            string removeKey = keyDic.First(content => content.Value == removeItem).Key;
            coords.Remove(key: removeKey);
            moveDir.Remove(key: removeKey);
            moveAmount.Remove(key: removeKey);
            keyList.Remove(removeKey);
            keyDic.Remove(key: removeKey);
            Configs.Items.Remove(removeItem);
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if(Configs.Items.Count == 0)
            {
                return;
            }

            string removeItem = Configs.SelectedItem.ToString();
            DeleteItem(removeItem);
            if(Configs.Items.Count > 0)
            {
                SetTextBox("lastConfig");
            }
        }

        private void ChangeButton_Click(object sender, EventArgs e)
        {
            if (Configs.Items.Count == 0)
            {
                return;
            }

            string prevName = Configs.Items[Configs.SelectedIndex].ToString();
            DeleteItem(prevName);
            AddItem();
        }

        private void Configs_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetTextBox(Configs.Items[Configs.SelectedIndex].ToString());
        }

        private delegate void updateKeyUI(string keyCoord);
        private delegate void updateCoordUI(int x, int y);
        private delegate void updateCursorVisible(string visible);
        private void UpdateKeyUI(string keyCoord)
        {
            KeyPressed.Text = keyCoord;
        }
        private void UpdateCoordUI(int x, int y)
        {
            CursorPos.Text = x.ToString() + ", " + y.ToString();
        }
        private void UpdateCursorVisible(string visible)
        {
            CursorVisible.Text = visible;
        }

        private int LoopIndex(int i)
        {
            return (i + 1) % keyList.Count;
        }

        private void MainLoop()
        {
            int index = 0;
            (int, int) inputCoord;
            string dir;
            int amount;
            string keyCoord;
            short state;
            bool escPressed = false;
            POINT pt = new POINT();
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(Keys));
            updateCoordUI updateCoord = new updateCoordUI(UpdateCoordUI);
            updateKeyUI updateKey = new updateKeyUI(UpdateKeyUI);
            updateCursorVisible updateCursor = new updateCursorVisible(UpdateCursorVisible);
            Invoke(updateCursor, "Show");
            InputHandler.InputHandler inputHandler = new InputHandler.InputHandler();

            while (keepAlive)
            {
                // カーソル位置を確認
                GetCursorPos(out pt);
                Invoke(updateCoord, pt.X, pt.Y);

                short escape = GetAsyncKeyState((int)Keys.Escape);
                if ((escape & 0x8000) != 0)
                {
                    if(escPressed == false)
                    {
                        escPressed = true;
                        cursorHandler.ShowCursor(false);
                        Invoke(updateCursor, cursorHandler.MouseVisible ? "Show" : "Hide");
                    }
                }
                else
                {
                    escPressed = false;
                }

                // キー入力を確認
                if (keyList.Count > 0)
                {
                    index = LoopIndex(index);
                    keyCoord = keyList[index];
                    state = 0;
                    state = GetAsyncKeyState(
                        (int)(Keys)converter.ConvertFromString(keyCoord));
                    if ((state & 0x8000) != 0)
                    {
                        Invoke(updateKey, keyCoord);
                        inputCoord = coords[keyCoord];
                        dir = moveDir[keyCoord];
                        amount = moveAmount[keyCoord];
                        inputHandler.Click(inputCoord.Item1, inputCoord.Item2, dir, amount);
                    }
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "フォームを閉じますか?",
                "確認",
                MessageBoxButtons.YesNo);

            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                keepAlive = false;
                cursorHandler.ShowCursor(true);
                SaveConfig();
                MessageBox.Show("アプリケーションを終了します");
            }
        }

        private void SaveConfig()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            StreamWriter writer = new StreamWriter(
                @".\Resources\Configs.txt", false, Encoding.GetEncoding("Shift_JIS"));
            for(int i = 0; i < Configs.Items.Count; i++)
            {
                string configName = Configs.Items[i].ToString();
                string saveKey = keyDic.First(content => content.Value == configName).Key;
                (int, int) coord = coords[saveKey];
                string coordX = coord.Item1.ToString();
                string coordY = coord.Item2.ToString();
                string dir = moveDir[saveKey];
                string amount = moveAmount[saveKey].ToString();
                writer.WriteLine(
                    configName + "," +
                    coordX + "," +
                    coordY + "," +
                    dir + "," +
                    amount + "," +
                    saveKey
                    );
            }
            writer.Close();
        }

        private void LoadConfig()
        {
            if (File.Exists(@".\Resources\Configs.txt"))
            {
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                FileStream stream = new FileStream(
                    @".\Resources\Configs.txt",
                    FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                StreamReader reader = new StreamReader(stream);

                if (reader.Peek() != 0)
                {
                    while (reader.Peek() >= 0)
                    {
                        string[] data = reader.ReadLine().Split(',');
                        ConfigName.Text = data[0];
                        XCoord.Text = data[1];
                        YCoord.Text = data[2];
                        MoveDir.Text = data[3];
                        MoveAmount.Text = data[4];
                        Key.Text = data[5];
                        AddItem();
                    }
                }

                reader.Close();
                stream.Close();
            }
        }
    }
}
