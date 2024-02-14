namespace BubbleSort
{
   partial class BubbleSortForm
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
         labelNums = new Label();
         textBoxNums = new TextBox();
         buttonGenerate = new Button();
         label1 = new Label();
         label2 = new Label();
         textBoxThreads = new TextBox();
         buttonSort = new Button();
         progressBar = new ProgressBar();
         labelAssembler = new Label();
         labelCpp = new Label();
         labelCs = new Label();
         labelAsmTime = new Label();
         labelCppTime = new Label();
         labelCshTime = new Label();
         radioButtonAsm = new RadioButton();
         radioButtonCpp = new RadioButton();
         radioButtonCsh = new RadioButton();
         SuspendLayout();
         // 
         // labelNums
         // 
         labelNums.AutoSize = true;
         labelNums.Font = new Font("Arial", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
         labelNums.Location = new Point(12, 9);
         labelNums.Name = "labelNums";
         labelNums.Size = new Size(173, 24);
         labelNums.TabIndex = 0;
         labelNums.Text = "Numbers per file: ";
         // 
         // textBoxNums
         // 
         textBoxNums.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
         textBoxNums.Location = new Point(191, 7);
         textBoxNums.Name = "textBoxNums";
         textBoxNums.Size = new Size(78, 26);
         textBoxNums.TabIndex = 1;
         textBoxNums.Text = "100";
         // 
         // buttonGenerate
         // 
         buttonGenerate.Font = new Font("Arial", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
         buttonGenerate.Location = new Point(12, 37);
         buttonGenerate.Name = "buttonGenerate";
         buttonGenerate.Size = new Size(257, 37);
         buttonGenerate.TabIndex = 2;
         buttonGenerate.Text = "Generate";
         buttonGenerate.UseVisualStyleBackColor = true;
         buttonGenerate.Click += buttonGenerate_Click;
         // 
         // label1
         // 
         label1.AutoSize = true;
         label1.Location = new Point(12, 77);
         label1.Name = "label1";
         label1.Size = new Size(292, 15);
         label1.TabIndex = 3;
         label1.Text = "---------------------------------------------------------";
         // 
         // label2
         // 
         label2.AutoSize = true;
         label2.Font = new Font("Arial", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
         label2.Location = new Point(12, 102);
         label2.Name = "label2";
         label2.Size = new Size(98, 24);
         label2.TabIndex = 5;
         label2.Text = "Threads: ";
         // 
         // textBoxThreads
         // 
         textBoxThreads.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
         textBoxThreads.Location = new Point(116, 100);
         textBoxThreads.Name = "textBoxThreads";
         textBoxThreads.Size = new Size(78, 26);
         textBoxThreads.TabIndex = 6;
         textBoxThreads.Text = "4";
         // 
         // buttonSort
         // 
         buttonSort.Font = new Font("Arial", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
         buttonSort.Location = new Point(12, 161);
         buttonSort.Name = "buttonSort";
         buttonSort.Size = new Size(257, 37);
         buttonSort.TabIndex = 7;
         buttonSort.Text = "Sort";
         buttonSort.UseVisualStyleBackColor = true;
         buttonSort.Click += buttonSort_Click;
         // 
         // progressBar
         // 
         progressBar.Location = new Point(12, 204);
         progressBar.Name = "progressBar";
         progressBar.Size = new Size(257, 37);
         progressBar.TabIndex = 8;
         // 
         // labelAssembler
         // 
         labelAssembler.AutoSize = true;
         labelAssembler.Font = new Font("Arial", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
         labelAssembler.Location = new Point(12, 251);
         labelAssembler.Name = "labelAssembler";
         labelAssembler.Size = new Size(62, 24);
         labelAssembler.TabIndex = 9;
         labelAssembler.Text = "Asm: ";
         // 
         // labelCpp
         // 
         labelCpp.AutoSize = true;
         labelCpp.Font = new Font("Arial", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
         labelCpp.Location = new Point(12, 275);
         labelCpp.Name = "labelCpp";
         labelCpp.Size = new Size(61, 24);
         labelCpp.TabIndex = 10;
         labelCpp.Text = "C++: ";
         // 
         // labelCs
         // 
         labelCs.AutoSize = true;
         labelCs.Font = new Font("Arial", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
         labelCs.Location = new Point(12, 299);
         labelCs.Name = "labelCs";
         labelCs.Size = new Size(55, 24);
         labelCs.TabIndex = 11;
         labelCs.Text = "C#  :";
         // 
         // labelAsmTime
         // 
         labelAsmTime.AutoSize = true;
         labelAsmTime.Font = new Font("Arial", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
         labelAsmTime.Location = new Point(80, 251);
         labelAsmTime.Name = "labelAsmTime";
         labelAsmTime.Size = new Size(55, 24);
         labelAsmTime.TabIndex = 12;
         labelAsmTime.Text = "0 ms";
         // 
         // labelCppTime
         // 
         labelCppTime.AutoSize = true;
         labelCppTime.Font = new Font("Arial", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
         labelCppTime.Location = new Point(80, 275);
         labelCppTime.Name = "labelCppTime";
         labelCppTime.Size = new Size(55, 24);
         labelCppTime.TabIndex = 13;
         labelCppTime.Text = "0 ms";
         // 
         // labelCshTime
         // 
         labelCshTime.AutoSize = true;
         labelCshTime.Font = new Font("Arial", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
         labelCshTime.Location = new Point(80, 299);
         labelCshTime.Name = "labelCshTime";
         labelCshTime.Size = new Size(55, 24);
         labelCshTime.TabIndex = 14;
         labelCshTime.Text = "0 ms";
         // 
         // radioButtonAsm
         // 
         radioButtonAsm.AutoSize = true;
         radioButtonAsm.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
         radioButtonAsm.Location = new Point(12, 129);
         radioButtonAsm.Name = "radioButtonAsm";
         radioButtonAsm.Size = new Size(120, 26);
         radioButtonAsm.TabIndex = 15;
         radioButtonAsm.TabStop = true;
         radioButtonAsm.Text = "Assembler";
         radioButtonAsm.UseVisualStyleBackColor = true;
         // 
         // radioButtonCpp
         // 
         radioButtonCpp.AutoSize = true;
         radioButtonCpp.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
         radioButtonCpp.Location = new Point(138, 129);
         radioButtonCpp.Name = "radioButtonCpp";
         radioButtonCpp.Size = new Size(64, 26);
         radioButtonCpp.TabIndex = 16;
         radioButtonCpp.TabStop = true;
         radioButtonCpp.Text = "C++";
         radioButtonCpp.UseVisualStyleBackColor = true;
         // 
         // radioButtonCsh
         // 
         radioButtonCsh.AutoSize = true;
         radioButtonCsh.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
         radioButtonCsh.Location = new Point(208, 129);
         radioButtonCsh.Name = "radioButtonCsh";
         radioButtonCsh.Size = new Size(53, 26);
         radioButtonCsh.TabIndex = 17;
         radioButtonCsh.TabStop = true;
         radioButtonCsh.Text = "C#";
         radioButtonCsh.UseVisualStyleBackColor = true;
         // 
         // BubbleSortForm
         // 
         AutoScaleDimensions = new SizeF(7F, 15F);
         AutoScaleMode = AutoScaleMode.Font;
         ClientSize = new Size(434, 361);
         Controls.Add(radioButtonCsh);
         Controls.Add(radioButtonCpp);
         Controls.Add(radioButtonAsm);
         Controls.Add(labelCshTime);
         Controls.Add(labelCppTime);
         Controls.Add(labelAsmTime);
         Controls.Add(labelCs);
         Controls.Add(labelCpp);
         Controls.Add(labelAssembler);
         Controls.Add(progressBar);
         Controls.Add(buttonSort);
         Controls.Add(textBoxThreads);
         Controls.Add(label2);
         Controls.Add(label1);
         Controls.Add(buttonGenerate);
         Controls.Add(textBoxNums);
         Controls.Add(labelNums);
         Name = "BubbleSortForm";
         Text = "BubbleSort";
         Load += BubbleSortForm_Load;
         ResumeLayout(false);
         PerformLayout();
      }

      #endregion

      private Label labelNums;
      private TextBox textBoxNums;
      private Button buttonGenerate;
      private Label label1;
      private Label label2;
      private TextBox textBoxThreads;
      private Button buttonSort;
      private ProgressBar progressBar;
      private Label labelAssembler;
      private Label labelCpp;
      private Label labelCs;
      private Label labelAsmTime;
      private Label labelCppTime;
      private Label labelCshTime;
      private RadioButton radioButtonAsm;
      private RadioButton radioButtonCpp;
      private RadioButton radioButtonCsh;
   }
}
