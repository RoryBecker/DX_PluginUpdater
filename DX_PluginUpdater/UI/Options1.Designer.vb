<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Options1
	Inherits DevExpress.CodeRush.Core.OptionsPage

	<System.Diagnostics.DebuggerNonUserCode()> _
	Public Sub New()
		MyBase.New()

		'This call is required by the Component Designer.
		InitializeComponent()

	End Sub

	'OptionsPage overrides dispose to clean up the component list.
	<System.Diagnostics.DebuggerNonUserCode()> _
	Protected Overrides Sub Dispose(ByVal disposing As Boolean)
		If disposing AndAlso components IsNot Nothing Then
			components.Dispose()
		End If
		MyBase.Dispose(disposing)
	End Sub

	'Required by the Windows Form Designer
	Private components As System.ComponentModel.IContainer

	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.  
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> _
	Private Sub InitializeComponent()
        Me.chkPromptBeforeUpdating = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ynaRestartDXCore = New DX_PluginUpdater.YesNoAskControl()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'chkPromptBeforeUpdating
        '
        Me.chkPromptBeforeUpdating.AutoSize = True
        Me.chkPromptBeforeUpdating.Location = New System.Drawing.Point(23, 29)
        Me.chkPromptBeforeUpdating.Name = "chkPromptBeforeUpdating"
        Me.chkPromptBeforeUpdating.Size = New System.Drawing.Size(171, 17)
        Me.chkPromptBeforeUpdating.TabIndex = 0
        Me.chkPromptBeforeUpdating.Text = "Prompt user before updating. "
        Me.chkPromptBeforeUpdating.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(40, 49)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(472, 23)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "(Unchecking this potion will cause all Local plugins to be updated when UpdatePlu" & _
    "gins is chosen)"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(20, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(273, 14)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Restart DXCore after plugins are installed \ updated."
        '
        'ynaRestartDXCore
        '
        Me.ynaRestartDXCore.Location = New System.Drawing.Point(285, 68)
        Me.ynaRestartDXCore.Name = "ynaRestartDXCore"
        Me.ynaRestartDXCore.Size = New System.Drawing.Size(95, 23)
        Me.ynaRestartDXCore.TabIndex = 2
        Me.ynaRestartDXCore.YesNoAskValue = DX_PluginUpdater.YesNoAskEnum.Ask
        '
        'Options1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ynaRestartDXCore)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.chkPromptBeforeUpdating)
        Me.Name = "Options1"
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Public Shared ReadOnly Property Storage() As DevExpress.CodeRush.Core.DecoupledStorage
        Get
            Return DevExpress.CodeRush.Core.CodeRush.Options.GetStorage(GetCategory(), GetPageName())
        End Get
    End Property

    Public Overrides ReadOnly Property Category() As String
        Get
            Return Options1.GetCategory()
        End Get
    End Property

    Public Overrides ReadOnly Property PageName() As String
        Get
            Return Options1.GetPageName()
        End Get
    End Property

    Public Shared Shadows Sub Show()
        DevExpress.CodeRush.Core.CodeRush.Command.Execute("Options", FullPath)
    End Sub
    Friend WithEvents chkPromptBeforeUpdating As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ynaRestartDXCore As DX_PluginUpdater.YesNoAskControl
    Friend WithEvents Label2 As System.Windows.Forms.Label

	Public Shared ReadOnly Property FullPath() As String
		Get
			Return GetCategory() + "\" + GetPageName()
		End Get
	End Property

End Class
