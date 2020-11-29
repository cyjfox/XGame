namespace XGame
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_Stone = new System.Windows.Forms.Button();
            this.btn_Seissor = new System.Windows.Forms.Button();
            this.btn_Cloth = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_StartGame = new System.Windows.Forms.Button();
            this.btn_EndGame = new System.Windows.Forms.Button();
            this.lbl_Result = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(165, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(313, 232);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(508, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_Cloth);
            this.groupBox1.Controls.Add(this.btn_Seissor);
            this.groupBox1.Controls.Add(this.btn_Stone);
            this.groupBox1.Location = new System.Drawing.Point(7, 264);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(470, 95);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "请点击下面的按钮出拳";
            // 
            // btn_Stone
            // 
            this.btn_Stone.Location = new System.Drawing.Point(18, 32);
            this.btn_Stone.Name = "btn_Stone";
            this.btn_Stone.Size = new System.Drawing.Size(100, 40);
            this.btn_Stone.TabIndex = 0;
            this.btn_Stone.Text = "石头";
            this.btn_Stone.UseVisualStyleBackColor = true;
            this.btn_Stone.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_Seissor
            // 
            this.btn_Seissor.Location = new System.Drawing.Point(158, 32);
            this.btn_Seissor.Name = "btn_Seissor";
            this.btn_Seissor.Size = new System.Drawing.Size(100, 40);
            this.btn_Seissor.TabIndex = 1;
            this.btn_Seissor.Text = "剪刀";
            this.btn_Seissor.UseVisualStyleBackColor = true;
            this.btn_Seissor.Click += new System.EventHandler(this.btn_Seissor_Click);
            // 
            // btn_Cloth
            // 
            this.btn_Cloth.Location = new System.Drawing.Point(300, 32);
            this.btn_Cloth.Name = "btn_Cloth";
            this.btn_Cloth.Size = new System.Drawing.Size(100, 40);
            this.btn_Cloth.TabIndex = 2;
            this.btn_Cloth.Text = "布";
            this.btn_Cloth.UseVisualStyleBackColor = true;
            this.btn_Cloth.Click += new System.EventHandler(this.btn_Cloth_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(267, 383);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(89, 50);
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(21, 383);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 24);
            this.label2.TabIndex = 4;
            this.label2.Text = "结果：";
            // 
            // btn_StartGame
            // 
            this.btn_StartGame.Location = new System.Drawing.Point(25, 8);
            this.btn_StartGame.Name = "btn_StartGame";
            this.btn_StartGame.Size = new System.Drawing.Size(100, 40);
            this.btn_StartGame.TabIndex = 5;
            this.btn_StartGame.Text = "开始游戏";
            this.btn_StartGame.UseVisualStyleBackColor = true;
            this.btn_StartGame.Click += new System.EventHandler(this.btn_StartGame_Click);
            // 
            // btn_EndGame
            // 
            this.btn_EndGame.Enabled = false;
            this.btn_EndGame.Location = new System.Drawing.Point(25, 73);
            this.btn_EndGame.Name = "btn_EndGame";
            this.btn_EndGame.Size = new System.Drawing.Size(100, 40);
            this.btn_EndGame.TabIndex = 6;
            this.btn_EndGame.Text = "结束游戏";
            this.btn_EndGame.UseVisualStyleBackColor = true;
            this.btn_EndGame.Click += new System.EventHandler(this.btn_EndGame_Click);
            // 
            // lbl_Result
            // 
            this.lbl_Result.AutoSize = true;
            this.lbl_Result.Font = new System.Drawing.Font("宋体", 42F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_Result.Location = new System.Drawing.Point(112, 383);
            this.lbl_Result.Name = "lbl_Result";
            this.lbl_Result.Size = new System.Drawing.Size(0, 56);
            this.lbl_Result.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lbl_Result);
            this.Controls.Add(this.btn_EndGame);
            this.Controls.Add(this.btn_StartGame);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_Cloth;
        private System.Windows.Forms.Button btn_Seissor;
        private System.Windows.Forms.Button btn_Stone;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_StartGame;
        private System.Windows.Forms.Button btn_EndGame;
        private System.Windows.Forms.Label lbl_Result;
    }
}

