
namespace TLabMouseController
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Configs = new System.Windows.Forms.ComboBox();
            this.ConfigName = new System.Windows.Forms.TextBox();
            this.explain1 = new System.Windows.Forms.TextBox();
            this.XCoord = new System.Windows.Forms.TextBox();
            this.explain2 = new System.Windows.Forms.TextBox();
            this.YCoord = new System.Windows.Forms.TextBox();
            this.explain3 = new System.Windows.Forms.TextBox();
            this.MoveDir = new System.Windows.Forms.TextBox();
            this.explain4 = new System.Windows.Forms.TextBox();
            this.MoveAmount = new System.Windows.Forms.TextBox();
            this.explain5 = new System.Windows.Forms.TextBox();
            this.Key = new System.Windows.Forms.TextBox();
            this.explain6 = new System.Windows.Forms.TextBox();
            this.KeyPressed = new System.Windows.Forms.TextBox();
            this.explain7 = new System.Windows.Forms.TextBox();
            this.CursorPos = new System.Windows.Forms.TextBox();
            this.explain8 = new System.Windows.Forms.TextBox();
            this.CursorVisible = new System.Windows.Forms.TextBox();
            this.explain9 = new System.Windows.Forms.TextBox();
            this.AddButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.ChangeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Configs
            // 
            this.Configs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Configs.FormattingEnabled = true;
            this.Configs.Location = new System.Drawing.Point(32, 43);
            this.Configs.Name = "Configs";
            this.Configs.Size = new System.Drawing.Size(120, 23);
            this.Configs.TabIndex = 0;
            this.Configs.SelectedIndexChanged += new System.EventHandler(this.Configs_SelectedIndexChanged);
            // 
            // ConfigName
            // 
            this.ConfigName.Location = new System.Drawing.Point(35, 128);
            this.ConfigName.Name = "ConfigName";
            this.ConfigName.Size = new System.Drawing.Size(120, 23);
            this.ConfigName.TabIndex = 1;
            // 
            // explain1
            // 
            this.explain1.BackColor = System.Drawing.SystemColors.Control;
            this.explain1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.explain1.Location = new System.Drawing.Point(173, 131);
            this.explain1.Name = "explain1";
            this.explain1.ReadOnly = true;
            this.explain1.Size = new System.Drawing.Size(200, 16);
            this.explain1.TabIndex = 2;
            this.explain1.TabStop = false;
            this.explain1.Text = "ConfigName";
            // 
            // XCoord
            // 
            this.XCoord.Location = new System.Drawing.Point(35, 157);
            this.XCoord.Name = "XCoord";
            this.XCoord.Size = new System.Drawing.Size(120, 23);
            this.XCoord.TabIndex = 3;
            // 
            // explain2
            // 
            this.explain2.BackColor = System.Drawing.SystemColors.Control;
            this.explain2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.explain2.Location = new System.Drawing.Point(173, 160);
            this.explain2.Name = "explain2";
            this.explain2.ReadOnly = true;
            this.explain2.Size = new System.Drawing.Size(200, 16);
            this.explain2.TabIndex = 4;
            this.explain2.TabStop = false;
            this.explain2.Text = "X Coord";
            // 
            // YCoord
            // 
            this.YCoord.Location = new System.Drawing.Point(35, 186);
            this.YCoord.Name = "YCoord";
            this.YCoord.Size = new System.Drawing.Size(120, 23);
            this.YCoord.TabIndex = 4;
            // 
            // explain3
            // 
            this.explain3.BackColor = System.Drawing.SystemColors.Control;
            this.explain3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.explain3.Location = new System.Drawing.Point(173, 189);
            this.explain3.Name = "explain3";
            this.explain3.ReadOnly = true;
            this.explain3.Size = new System.Drawing.Size(200, 16);
            this.explain3.TabIndex = 6;
            this.explain3.TabStop = false;
            this.explain3.Text = "Y Coord";
            // 
            // MoveDir
            // 
            this.MoveDir.Location = new System.Drawing.Point(35, 215);
            this.MoveDir.Name = "MoveDir";
            this.MoveDir.Size = new System.Drawing.Size(120, 23);
            this.MoveDir.TabIndex = 7;
            // 
            // explain4
            // 
            this.explain4.BackColor = System.Drawing.SystemColors.Control;
            this.explain4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.explain4.Location = new System.Drawing.Point(173, 218);
            this.explain4.Name = "explain4";
            this.explain4.ReadOnly = true;
            this.explain4.Size = new System.Drawing.Size(200, 16);
            this.explain4.TabIndex = 8;
            this.explain4.TabStop = false;
            this.explain4.Text = "Up/Down/Right/Left";
            // 
            // MoveAmount
            // 
            this.MoveAmount.Location = new System.Drawing.Point(35, 244);
            this.MoveAmount.Name = "MoveAmount";
            this.MoveAmount.Size = new System.Drawing.Size(120, 23);
            this.MoveAmount.TabIndex = 9;
            // 
            // explain5
            // 
            this.explain5.BackColor = System.Drawing.SystemColors.Control;
            this.explain5.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.explain5.Location = new System.Drawing.Point(173, 247);
            this.explain5.Name = "explain5";
            this.explain5.ReadOnly = true;
            this.explain5.Size = new System.Drawing.Size(200, 16);
            this.explain5.TabIndex = 10;
            this.explain5.TabStop = false;
            this.explain5.Text = "Move Amount";
            // 
            // Key
            // 
            this.Key.Location = new System.Drawing.Point(35, 273);
            this.Key.Name = "Key";
            this.Key.Size = new System.Drawing.Size(120, 23);
            this.Key.TabIndex = 11;
            // 
            // explain6
            // 
            this.explain6.BackColor = System.Drawing.SystemColors.Control;
            this.explain6.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.explain6.Location = new System.Drawing.Point(173, 276);
            this.explain6.Name = "explain6";
            this.explain6.ReadOnly = true;
            this.explain6.Size = new System.Drawing.Size(200, 16);
            this.explain6.TabIndex = 12;
            this.explain6.TabStop = false;
            this.explain6.Text = "Key to resister";
            // 
            // KeyPressed
            // 
            this.KeyPressed.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.KeyPressed.Location = new System.Drawing.Point(379, 128);
            this.KeyPressed.Name = "KeyPressed";
            this.KeyPressed.ReadOnly = true;
            this.KeyPressed.Size = new System.Drawing.Size(100, 23);
            this.KeyPressed.TabIndex = 13;
            // 
            // explain7
            // 
            this.explain7.BackColor = System.Drawing.SystemColors.Control;
            this.explain7.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.explain7.Location = new System.Drawing.Point(501, 131);
            this.explain7.Name = "explain7";
            this.explain7.ReadOnly = true;
            this.explain7.Size = new System.Drawing.Size(200, 16);
            this.explain7.TabIndex = 14;
            this.explain7.TabStop = false;
            this.explain7.Text = "Current Key inputed";
            // 
            // CursorPos
            // 
            this.CursorPos.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.CursorPos.Location = new System.Drawing.Point(379, 157);
            this.CursorPos.Name = "CursorPos";
            this.CursorPos.ReadOnly = true;
            this.CursorPos.Size = new System.Drawing.Size(100, 23);
            this.CursorPos.TabIndex = 15;
            // 
            // explain8
            // 
            this.explain8.BackColor = System.Drawing.SystemColors.Control;
            this.explain8.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.explain8.Location = new System.Drawing.Point(501, 160);
            this.explain8.Name = "explain8";
            this.explain8.ReadOnly = true;
            this.explain8.Size = new System.Drawing.Size(200, 16);
            this.explain8.TabIndex = 16;
            this.explain8.TabStop = false;
            this.explain8.Text = "Cursor coord";
            // 
            // CursorVisible
            // 
            this.CursorVisible.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.CursorVisible.Location = new System.Drawing.Point(379, 186);
            this.CursorVisible.Name = "CursorVisible";
            this.CursorVisible.ReadOnly = true;
            this.CursorVisible.Size = new System.Drawing.Size(100, 23);
            this.CursorVisible.TabIndex = 17;
            // 
            // explain9
            // 
            this.explain9.BackColor = System.Drawing.SystemColors.Control;
            this.explain9.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.explain9.Location = new System.Drawing.Point(504, 189);
            this.explain9.Name = "explain9";
            this.explain9.ReadOnly = true;
            this.explain9.Size = new System.Drawing.Size(200, 16);
            this.explain9.TabIndex = 18;
            this.explain9.TabStop = false;
            this.explain9.Text = "Show/Hide (Switch with ESC key)";
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(32, 347);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(120, 23);
            this.AddButton.TabIndex = 19;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(32, 376);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(120, 23);
            this.DeleteButton.TabIndex = 20;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // ChangeButton
            // 
            this.ChangeButton.Location = new System.Drawing.Point(32, 405);
            this.ChangeButton.Name = "ChangeButton";
            this.ChangeButton.Size = new System.Drawing.Size(120, 23);
            this.ChangeButton.TabIndex = 21;
            this.ChangeButton.Text = "Change";
            this.ChangeButton.UseVisualStyleBackColor = true;
            this.ChangeButton.Click += new System.EventHandler(this.ChangeButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Configs);
            this.Controls.Add(this.ConfigName);
            this.Controls.Add(this.explain1);
            this.Controls.Add(this.XCoord);
            this.Controls.Add(this.explain2);
            this.Controls.Add(this.YCoord);
            this.Controls.Add(this.explain3);
            this.Controls.Add(this.MoveDir);
            this.Controls.Add(this.explain4);
            this.Controls.Add(this.MoveAmount);
            this.Controls.Add(this.explain5);
            this.Controls.Add(this.Key);
            this.Controls.Add(this.explain6);
            this.Controls.Add(this.KeyPressed);
            this.Controls.Add(this.explain7);
            this.Controls.Add(this.CursorPos);
            this.Controls.Add(this.explain8);
            this.Controls.Add(this.CursorVisible);
            this.Controls.Add(this.explain9);
            this.Controls.Add(this.ChangeButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.DeleteButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox Configs;
        private System.Windows.Forms.TextBox ConfigName;
        private System.Windows.Forms.TextBox explain1;
        private System.Windows.Forms.TextBox XCoord;
        private System.Windows.Forms.TextBox explain2;
        private System.Windows.Forms.TextBox YCoord;
        private System.Windows.Forms.TextBox explain3;
        private System.Windows.Forms.TextBox MoveDir;
        private System.Windows.Forms.TextBox explain4;
        private System.Windows.Forms.TextBox MoveAmount;
        private System.Windows.Forms.TextBox explain5;
        private System.Windows.Forms.TextBox Key;
        private System.Windows.Forms.TextBox explain6;
        private System.Windows.Forms.TextBox KeyPressed;
        private System.Windows.Forms.TextBox explain7;
        private System.Windows.Forms.TextBox CursorPos;
        private System.Windows.Forms.TextBox explain8;
        private System.Windows.Forms.TextBox CursorVisible;
        private System.Windows.Forms.TextBox explain9;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button ChangeButton;
    }
}

