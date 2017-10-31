namespace MovieLib.Windows
{
    partial class MovieDetailForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
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
            this._titleLabel = new System.Windows.Forms.Label();
            this._descriptionLabel = new System.Windows.Forms.Label();
            this._lengthLabel = new System.Windows.Forms.Label();
            this._ownedCheckBox = new System.Windows.Forms.CheckBox();
            this._title = new System.Windows.Forms.TextBox();
            this._description = new System.Windows.Forms.TextBox();
            this._length = new System.Windows.Forms.TextBox();
            this._saveButton = new System.Windows.Forms.Button();
            this._cancelButton = new System.Windows.Forms.Button();
            this._miniuteLabel = new System.Windows.Forms.Label();
            this._titleError = new System.Windows.Forms.ErrorProvider(this.components);
            this._lengthError = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this._titleError)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._lengthError)).BeginInit();
            this.SuspendLayout();
            // 
            // _titleLabel
            // 
            this._titleLabel.AutoSize = true;
            this._titleLabel.Location = new System.Drawing.Point(45, 38);
            this._titleLabel.Name = "_titleLabel";
            this._titleLabel.Size = new System.Drawing.Size(27, 13);
            this._titleLabel.TabIndex = 0;
            this._titleLabel.Text = "Title";
            // 
            // _descriptionLabel
            // 
            this._descriptionLabel.AutoSize = true;
            this._descriptionLabel.Location = new System.Drawing.Point(12, 64);
            this._descriptionLabel.Name = "_descriptionLabel";
            this._descriptionLabel.Size = new System.Drawing.Size(60, 13);
            this._descriptionLabel.TabIndex = 1;
            this._descriptionLabel.Text = "Description";
            // 
            // _lengthLabel
            // 
            this._lengthLabel.AutoSize = true;
            this._lengthLabel.Location = new System.Drawing.Point(32, 152);
            this._lengthLabel.Name = "_lengthLabel";
            this._lengthLabel.Size = new System.Drawing.Size(40, 13);
            this._lengthLabel.TabIndex = 2;
            this._lengthLabel.Text = "Length";
            // 
            // _ownedCheckBox
            // 
            this._ownedCheckBox.AutoSize = true;
            this._ownedCheckBox.Location = new System.Drawing.Point(78, 175);
            this._ownedCheckBox.Name = "_ownedCheckBox";
            this._ownedCheckBox.Size = new System.Drawing.Size(60, 17);
            this._ownedCheckBox.TabIndex = 3;
            this._ownedCheckBox.Text = "Owned";
            this._ownedCheckBox.UseVisualStyleBackColor = true;
            // 
            // _title
            // 
            this._title.Location = new System.Drawing.Point(78, 35);
            this._title.Name = "_title";
            this._title.Size = new System.Drawing.Size(418, 20);
            this._title.TabIndex = 5;
            this._title.Validating += new System.ComponentModel.CancelEventHandler(this.OnTitleValidating);
            // 
            // _description
            // 
            this._description.Location = new System.Drawing.Point(78, 61);
            this._description.Multiline = true;
            this._description.Name = "_description";
            this._description.Size = new System.Drawing.Size(418, 82);
            this._description.TabIndex = 6;
            // 
            // _length
            // 
            this._length.Location = new System.Drawing.Point(78, 149);
            this._length.Name = "_length";
            this._length.Size = new System.Drawing.Size(100, 20);
            this._length.TabIndex = 7;
            this._length.Validating += new System.ComponentModel.CancelEventHandler(this.OnLengthValidating);
            // 
            // _saveButton
            // 
            this._saveButton.Location = new System.Drawing.Point(340, 216);
            this._saveButton.Name = "_saveButton";
            this._saveButton.Size = new System.Drawing.Size(75, 23);
            this._saveButton.TabIndex = 8;
            this._saveButton.Text = "Save";
            this._saveButton.UseVisualStyleBackColor = true;
            this._saveButton.Click += new System.EventHandler(this.OnSave);
            // 
            // _cancelButton
            // 
            this._cancelButton.Location = new System.Drawing.Point(421, 216);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(75, 23);
            this._cancelButton.TabIndex = 9;
            this._cancelButton.Text = "Cancel";
            this._cancelButton.UseVisualStyleBackColor = true;
            this._cancelButton.Click += new System.EventHandler(this.OnCancel);
            // 
            // _miniuteLabel
            // 
            this._miniuteLabel.AutoSize = true;
            this._miniuteLabel.Location = new System.Drawing.Point(184, 152);
            this._miniuteLabel.Name = "_miniuteLabel";
            this._miniuteLabel.Size = new System.Drawing.Size(45, 13);
            this._miniuteLabel.TabIndex = 10;
            this._miniuteLabel.Text = "miniutes";
            // 
            // _titleError
            // 
            this._titleError.ContainerControl = this;
            // 
            // _lengthError
            // 
            this._lengthError.ContainerControl = this;
            // 
            // MovieDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 251);
            this.Controls.Add(this._miniuteLabel);
            this.Controls.Add(this._cancelButton);
            this.Controls.Add(this._saveButton);
            this.Controls.Add(this._length);
            this.Controls.Add(this._description);
            this.Controls.Add(this._title);
            this.Controls.Add(this._ownedCheckBox);
            this.Controls.Add(this._lengthLabel);
            this.Controls.Add(this._descriptionLabel);
            this.Controls.Add(this._titleLabel);
            this.Name = "MovieDetailForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Movie Detail";
            ((System.ComponentModel.ISupportInitialize)(this._titleError)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._lengthError)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _titleLabel;
        private System.Windows.Forms.Label _descriptionLabel;
        private System.Windows.Forms.Label _lengthLabel;
        private System.Windows.Forms.CheckBox _ownedCheckBox;
        private System.Windows.Forms.TextBox _title;
        private System.Windows.Forms.TextBox _description;
        private System.Windows.Forms.TextBox _length;
        private System.Windows.Forms.Button _saveButton;
        private System.Windows.Forms.Button _cancelButton;
        private System.Windows.Forms.Label _miniuteLabel;
        private System.Windows.Forms.ErrorProvider _titleError;
        private System.Windows.Forms.ErrorProvider _lengthError;
    }
}