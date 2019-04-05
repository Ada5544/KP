<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Форма переопределяет dispose для очистки списка компонентов.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Является обязательной для конструктора форм Windows Forms
    Private components As System.ComponentModel.IContainer

    'Примечание: следующая процедура является обязательной для конструктора форм Windows Forms
    'Для ее изменения используйте конструктор форм Windows Form.  
    'Не изменяйте ее в редакторе исходного кода.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Button1 = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer3 = New System.Windows.Forms.Timer(Me.components)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ПказыватьПодсказкиToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.РежимсаперабезПраваНаОшибкуToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ПоказатьКакНужноСобратьКартинкуToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Timer1
        '
        Me.Timer1.Interval = 10
        '
        'Button1
        '
        Me.Button1.BackgroundImage = Global.WindowsApplication1.My.Resources.Resources._next
        Me.Button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(72, 392)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(308, 84)
        Me.Button1.TabIndex = 0
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.BackgroundImage = Global.WindowsApplication1.My.Resources.Resources.no
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox1.Location = New System.Drawing.Point(360, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(76, 52)
        Me.PictureBox1.TabIndex = 4
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'Timer2
        '
        Me.Timer2.Interval = 1000
        '
        'Timer3
        '
        Me.Timer3.Interval = 10
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ПказыватьПодсказкиToolStripMenuItem, Me.РежимсаперабезПраваНаОшибкуToolStripMenuItem, Me.ПоказатьКакНужноСобратьКартинкуToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.ShowCheckMargin = True
        Me.ContextMenuStrip1.ShowImageMargin = False
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(375, 92)
        '
        'ПказыватьПодсказкиToolStripMenuItem
        '
        Me.ПказыватьПодсказкиToolStripMenuItem.BackgroundImage = Global.WindowsApplication1.My.Resources.Resources.доска
        Me.ПказыватьПодсказкиToolStripMenuItem.CheckOnClick = True
        Me.ПказыватьПодсказкиToolStripMenuItem.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ПказыватьПодсказкиToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.ПказыватьПодсказкиToolStripMenuItem.Name = "ПказыватьПодсказкиToolStripMenuItem"
        Me.ПказыватьПодсказкиToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.H), System.Windows.Forms.Keys)
        Me.ПказыватьПодсказкиToolStripMenuItem.Size = New System.Drawing.Size(374, 22)
        Me.ПказыватьПодсказкиToolStripMenuItem.Text = "Показывать подсказки"
        '
        'РежимсаперабезПраваНаОшибкуToolStripMenuItem
        '
        Me.РежимсаперабезПраваНаОшибкуToolStripMenuItem.BackgroundImage = Global.WindowsApplication1.My.Resources.Resources.доска
        Me.РежимсаперабезПраваНаОшибкуToolStripMenuItem.CheckOnClick = True
        Me.РежимсаперабезПраваНаОшибкуToolStripMenuItem.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.РежимсаперабезПраваНаОшибкуToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.РежимсаперабезПраваНаОшибкуToolStripMenuItem.Name = "РежимсаперабезПраваНаОшибкуToolStripMenuItem"
        Me.РежимсаперабезПраваНаОшибкуToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.РежимсаперабезПраваНаОшибкуToolStripMenuItem.Size = New System.Drawing.Size(374, 22)
        Me.РежимсаперабезПраваНаОшибкуToolStripMenuItem.Text = "Режим ""сапера"" (без права на ошибку)"
        '
        'ПоказатьКакНужноСобратьКартинкуToolStripMenuItem
        '
        Me.ПоказатьКакНужноСобратьКартинкуToolStripMenuItem.BackgroundImage = Global.WindowsApplication1.My.Resources.Resources.доска
        Me.ПоказатьКакНужноСобратьКартинкуToolStripMenuItem.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ПоказатьКакНужноСобратьКартинкуToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.ПоказатьКакНужноСобратьКартинкуToolStripMenuItem.Name = "ПоказатьКакНужноСобратьКартинкуToolStripMenuItem"
        Me.ПоказатьКакНужноСобратьКартинкуToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.M), System.Windows.Forms.Keys)
        Me.ПоказатьКакНужноСобратьКартинкуToolStripMenuItem.Size = New System.Drawing.Size(374, 22)
        Me.ПоказатьКакНужноСобратьКартинкуToolStripMenuItem.Text = "Показать, как нужно собрать картинку"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.WindowsApplication1.My.Resources.Resources.фон
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(465, 727)
        Me.ContextMenuStrip = Me.ContextMenuStrip1
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Button1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Собери картинку 2016"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents Timer3 As System.Windows.Forms.Timer
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ПказыватьПодсказкиToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents РежимсаперабезПраваНаОшибкуToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ПоказатьКакНужноСобратьКартинкуToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
