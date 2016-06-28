namespace TestSalesforce
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnConnectSF = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusMain = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.timerStateTime = new System.Windows.Forms.Timer(this.components);
            this.txtInfos = new System.Windows.Forms.TextBox();
            this.lstQueries = new System.Windows.Forms.ListBox();
            this.btnExecQuery = new System.Windows.Forms.Button();
            this.btnCopyLastResultOnly = new System.Windows.Forms.Button();
            this.btnOpenJSONViewer = new System.Windows.Forms.Button();
            this.btnOpenJSONConvertToCSharp = new System.Windows.Forms.Button();
            this.btnOpenGoogleSearch = new System.Windows.Forms.Button();
            this.btnAddDoubleQuotes = new System.Windows.Forms.Button();
            this.txtQuotes = new System.Windows.Forms.TextBox();
            this.btnRemoveDoubleQuotes = new System.Windows.Forms.Button();
            this.btnTestParams = new System.Windows.Forms.Button();
            this.lstUserId = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnConnectSF
            // 
            this.btnConnectSF.Location = new System.Drawing.Point(12, 12);
            this.btnConnectSF.Name = "btnConnectSF";
            this.btnConnectSF.Size = new System.Drawing.Size(111, 45);
            this.btnConnectSF.TabIndex = 0;
            this.btnConnectSF.Text = "Connect Salesforce";
            this.btnConnectSF.UseVisualStyleBackColor = true;
            this.btnConnectSF.Click += new System.EventHandler(this.btnConnectSF_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusMain,
            this.toolStripStatusTime});
            this.statusStrip1.Location = new System.Drawing.Point(0, 689);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(927, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusMain
            // 
            this.toolStripStatusMain.Name = "toolStripStatusMain";
            this.toolStripStatusMain.Size = new System.Drawing.Size(863, 17);
            this.toolStripStatusMain.Spring = true;
            this.toolStripStatusMain.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusTime
            // 
            this.toolStripStatusTime.AutoSize = false;
            this.toolStripStatusTime.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.toolStripStatusTime.Name = "toolStripStatusTime";
            this.toolStripStatusTime.Size = new System.Drawing.Size(49, 17);
            this.toolStripStatusTime.Text = "00:00:00";
            // 
            // timerStateTime
            // 
            this.timerStateTime.Tick += new System.EventHandler(this.timerStateTime_Tick);
            // 
            // txtInfos
            // 
            this.txtInfos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInfos.BackColor = System.Drawing.Color.Black;
            this.txtInfos.ForeColor = System.Drawing.Color.Lime;
            this.txtInfos.Location = new System.Drawing.Point(12, 417);
            this.txtInfos.Multiline = true;
            this.txtInfos.Name = "txtInfos";
            this.txtInfos.ReadOnly = true;
            this.txtInfos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtInfos.Size = new System.Drawing.Size(903, 259);
            this.txtInfos.TabIndex = 3;
            // 
            // lstQueries
            // 
            this.lstQueries.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstQueries.FormattingEnabled = true;
            this.lstQueries.ItemHeight = 14;
            this.lstQueries.Location = new System.Drawing.Point(12, 84);
            this.lstQueries.Name = "lstQueries";
            this.lstQueries.Size = new System.Drawing.Size(451, 326);
            this.lstQueries.TabIndex = 5;
            // 
            // btnExecQuery
            // 
            this.btnExecQuery.Location = new System.Drawing.Point(486, 84);
            this.btnExecQuery.Name = "btnExecQuery";
            this.btnExecQuery.Size = new System.Drawing.Size(123, 45);
            this.btnExecQuery.TabIndex = 6;
            this.btnExecQuery.Text = "Exec Selected Query";
            this.btnExecQuery.UseVisualStyleBackColor = true;
            this.btnExecQuery.Click += new System.EventHandler(this.btnExecQuery_Click);
            // 
            // btnCopyLastResultOnly
            // 
            this.btnCopyLastResultOnly.Location = new System.Drawing.Point(486, 154);
            this.btnCopyLastResultOnly.Name = "btnCopyLastResultOnly";
            this.btnCopyLastResultOnly.Size = new System.Drawing.Size(123, 45);
            this.btnCopyLastResultOnly.TabIndex = 7;
            this.btnCopyLastResultOnly.Text = "Copy Last Result Only";
            this.btnCopyLastResultOnly.UseVisualStyleBackColor = true;
            this.btnCopyLastResultOnly.Click += new System.EventHandler(this.btnCopyLastResultOnly_Click);
            // 
            // btnOpenJSONViewer
            // 
            this.btnOpenJSONViewer.Location = new System.Drawing.Point(486, 224);
            this.btnOpenJSONViewer.Name = "btnOpenJSONViewer";
            this.btnOpenJSONViewer.Size = new System.Drawing.Size(123, 45);
            this.btnOpenJSONViewer.TabIndex = 8;
            this.btnOpenJSONViewer.Text = "Open JSON Viewer";
            this.btnOpenJSONViewer.UseVisualStyleBackColor = true;
            this.btnOpenJSONViewer.Click += new System.EventHandler(this.btnOpenJSONViewer_Click);
            // 
            // btnOpenJSONConvertToCSharp
            // 
            this.btnOpenJSONConvertToCSharp.Location = new System.Drawing.Point(486, 294);
            this.btnOpenJSONConvertToCSharp.Name = "btnOpenJSONConvertToCSharp";
            this.btnOpenJSONConvertToCSharp.Size = new System.Drawing.Size(123, 45);
            this.btnOpenJSONConvertToCSharp.TabIndex = 9;
            this.btnOpenJSONConvertToCSharp.Text = "Open JSON convert to CSharp";
            this.btnOpenJSONConvertToCSharp.UseVisualStyleBackColor = true;
            this.btnOpenJSONConvertToCSharp.Click += new System.EventHandler(this.btnOpenJSONConvertToCSharp_Click);
            // 
            // btnOpenGoogleSearch
            // 
            this.btnOpenGoogleSearch.Location = new System.Drawing.Point(486, 364);
            this.btnOpenGoogleSearch.Name = "btnOpenGoogleSearch";
            this.btnOpenGoogleSearch.Size = new System.Drawing.Size(123, 45);
            this.btnOpenGoogleSearch.TabIndex = 10;
            this.btnOpenGoogleSearch.Text = "Open Google Search";
            this.btnOpenGoogleSearch.UseVisualStyleBackColor = true;
            this.btnOpenGoogleSearch.Click += new System.EventHandler(this.btnOpenGoogleSearch_Click);
            // 
            // btnAddDoubleQuotes
            // 
            this.btnAddDoubleQuotes.Location = new System.Drawing.Point(661, 154);
            this.btnAddDoubleQuotes.Name = "btnAddDoubleQuotes";
            this.btnAddDoubleQuotes.Size = new System.Drawing.Size(123, 45);
            this.btnAddDoubleQuotes.TabIndex = 11;
            this.btnAddDoubleQuotes.Text = "Add Double Quotes";
            this.btnAddDoubleQuotes.UseVisualStyleBackColor = true;
            this.btnAddDoubleQuotes.Click += new System.EventHandler(this.btnAddDoubleQuotes_Click);
            // 
            // txtQuotes
            // 
            this.txtQuotes.Location = new System.Drawing.Point(661, 206);
            this.txtQuotes.Multiline = true;
            this.txtQuotes.Name = "txtQuotes";
            this.txtQuotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtQuotes.Size = new System.Drawing.Size(123, 63);
            this.txtQuotes.TabIndex = 12;
            // 
            // btnRemoveDoubleQuotes
            // 
            this.btnRemoveDoubleQuotes.Location = new System.Drawing.Point(661, 275);
            this.btnRemoveDoubleQuotes.Name = "btnRemoveDoubleQuotes";
            this.btnRemoveDoubleQuotes.Size = new System.Drawing.Size(123, 45);
            this.btnRemoveDoubleQuotes.TabIndex = 13;
            this.btnRemoveDoubleQuotes.Text = "Remove Double Quotes";
            this.btnRemoveDoubleQuotes.UseVisualStyleBackColor = true;
            this.btnRemoveDoubleQuotes.Click += new System.EventHandler(this.btnRemoveDoubleQuotes_Click);
            // 
            // btnTestParams
            // 
            this.btnTestParams.Location = new System.Drawing.Point(661, 364);
            this.btnTestParams.Name = "btnTestParams";
            this.btnTestParams.Size = new System.Drawing.Size(123, 45);
            this.btnTestParams.TabIndex = 14;
            this.btnTestParams.Text = "Test Params";
            this.btnTestParams.UseVisualStyleBackColor = true;
            this.btnTestParams.Click += new System.EventHandler(this.btnTestParams_Click);
            // 
            // lstUserId
            // 
            this.lstUserId.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstUserId.FormattingEnabled = true;
            this.lstUserId.ItemHeight = 14;
            this.lstUserId.Location = new System.Drawing.Point(633, 84);
            this.lstUserId.Name = "lstUserId";
            this.lstUserId.Size = new System.Drawing.Size(282, 60);
            this.lstUserId.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(633, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "User ID";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(927, 711);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstUserId);
            this.Controls.Add(this.btnTestParams);
            this.Controls.Add(this.btnRemoveDoubleQuotes);
            this.Controls.Add(this.txtQuotes);
            this.Controls.Add(this.btnAddDoubleQuotes);
            this.Controls.Add(this.btnOpenGoogleSearch);
            this.Controls.Add(this.btnOpenJSONConvertToCSharp);
            this.Controls.Add(this.btnOpenJSONViewer);
            this.Controls.Add(this.btnCopyLastResultOnly);
            this.Controls.Add(this.btnExecQuery);
            this.Controls.Add(this.lstQueries);
            this.Controls.Add(this.txtInfos);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnConnectSF);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMain";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConnectSF;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusMain;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusTime;
        private System.Windows.Forms.Timer timerStateTime;
        private System.Windows.Forms.TextBox txtInfos;
        private System.Windows.Forms.ListBox lstQueries;
        private System.Windows.Forms.Button btnExecQuery;
        private System.Windows.Forms.Button btnCopyLastResultOnly;
        private System.Windows.Forms.Button btnOpenJSONViewer;
        private System.Windows.Forms.Button btnOpenJSONConvertToCSharp;
        private System.Windows.Forms.Button btnOpenGoogleSearch;
        private System.Windows.Forms.Button btnAddDoubleQuotes;
        private System.Windows.Forms.TextBox txtQuotes;
        private System.Windows.Forms.Button btnRemoveDoubleQuotes;
        private System.Windows.Forms.Button btnTestParams;
        private System.Windows.Forms.ListBox lstUserId;
        private System.Windows.Forms.Label label1;
    }
}

