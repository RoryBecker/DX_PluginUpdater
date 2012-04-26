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
        Me.chkFindPromptBeforeUpdating = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ynaRestartDXCore = New DX_PluginUpdater.YesNoAskControl()
        Me.ynaCheckForPluginUpdatesOnStartup = New DX_PluginUpdater.YesNoAskControl()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.chkFindRefactoringPlugins = New System.Windows.Forms.CheckBox()
        Me.chkFindNavigationPlugins = New System.Windows.Forms.CheckBox()
        Me.chkFindCodeGenPlugins = New System.Windows.Forms.CheckBox()
        Me.optAllPlugins = New System.Windows.Forms.RadioButton()
        Me.optSelectedPlugins = New System.Windows.Forms.RadioButton()
        Me.cmdFindNewPlugins = New System.Windows.Forms.Button()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'chkFindPromptBeforeUpdating
        '
        Me.chkFindPromptBeforeUpdating.AutoSize = True
        Me.chkFindPromptBeforeUpdating.Location = New System.Drawing.Point(23, 29)
        Me.chkFindPromptBeforeUpdating.Name = "chkFindPromptBeforeUpdating"
        Me.chkFindPromptBeforeUpdating.Size = New System.Drawing.Size(171, 17)
        Me.chkFindPromptBeforeUpdating.TabIndex = 0
        Me.chkFindPromptBeforeUpdating.Text = "Prompt user before updating. "
        Me.chkFindPromptBeforeUpdating.UseVisualStyleBackColor = True
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
        'ynaCheckForPluginUpdatesOnStartup
        '
        Me.ynaCheckForPluginUpdatesOnStartup.Location = New System.Drawing.Point(285, 100)
        Me.ynaCheckForPluginUpdatesOnStartup.Name = "ynaCheckForPluginUpdatesOnStartup"
        Me.ynaCheckForPluginUpdatesOnStartup.Size = New System.Drawing.Size(95, 23)
        Me.ynaCheckForPluginUpdatesOnStartup.TabIndex = 4
        Me.ynaCheckForPluginUpdatesOnStartup.YesNoAskValue = DX_PluginUpdater.YesNoAskEnum.Ask
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(20, 104)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(273, 14)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Update Plugins on startup"
        '
        'chkFindRefactoringPlugins
        '
        Me.chkFindRefactoringPlugins.AutoSize = True
        Me.chkFindRefactoringPlugins.Location = New System.Drawing.Point(43, 192)
        Me.chkFindRefactoringPlugins.Name = "chkFindRefactoringPlugins"
        Me.chkFindRefactoringPlugins.Size = New System.Drawing.Size(118, 17)
        Me.chkFindRefactoringPlugins.TabIndex = 6
        Me.chkFindRefactoringPlugins.Text = "Refactoring Plugins"
        Me.chkFindRefactoringPlugins.UseVisualStyleBackColor = True
        '
        'chkFindNavigationPlugins
        '
        Me.chkFindNavigationPlugins.AutoSize = True
        Me.chkFindNavigationPlugins.Location = New System.Drawing.Point(43, 215)
        Me.chkFindNavigationPlugins.Name = "chkFindNavigationPlugins"
        Me.chkFindNavigationPlugins.Size = New System.Drawing.Size(113, 17)
        Me.chkFindNavigationPlugins.TabIndex = 7
        Me.chkFindNavigationPlugins.Text = "Navigation Plugins"
        Me.chkFindNavigationPlugins.UseVisualStyleBackColor = True
        '
        'chkFindCodeGenPlugins
        '
        Me.chkFindCodeGenPlugins.AutoSize = True
        Me.chkFindCodeGenPlugins.Location = New System.Drawing.Point(43, 238)
        Me.chkFindCodeGenPlugins.Name = "chkFindCodeGenPlugins"
        Me.chkFindCodeGenPlugins.Size = New System.Drawing.Size(109, 17)
        Me.chkFindCodeGenPlugins.TabIndex = 8
        Me.chkFindCodeGenPlugins.Text = "Code Gen Plugins"
        Me.chkFindCodeGenPlugins.UseVisualStyleBackColor = True
        '
        'optAllPlugins
        '
        Me.optAllPlugins.AutoSize = True
        Me.optAllPlugins.Location = New System.Drawing.Point(23, 146)
        Me.optAllPlugins.Name = "optAllPlugins"
        Me.optAllPlugins.Size = New System.Drawing.Size(72, 17)
        Me.optAllPlugins.TabIndex = 9
        Me.optAllPlugins.TabStop = True
        Me.optAllPlugins.Text = "All Plugins"
        Me.optAllPlugins.UseVisualStyleBackColor = True
        '
        'optSelectedPlugins
        '
        Me.optSelectedPlugins.AutoSize = True
        Me.optSelectedPlugins.Location = New System.Drawing.Point(23, 169)
        Me.optSelectedPlugins.Name = "optSelectedPlugins"
        Me.optSelectedPlugins.Size = New System.Drawing.Size(129, 17)
        Me.optSelectedPlugins.TabIndex = 9
        Me.optSelectedPlugins.TabStop = True
        Me.optSelectedPlugins.Text = "Selected Plugin Types"
        Me.optSelectedPlugins.UseVisualStyleBackColor = True
        '
        'cmdFindNewPlugins
        '
        Me.cmdFindNewPlugins.Location = New System.Drawing.Point(26, 261)
        Me.cmdFindNewPlugins.Name = "cmdFindNewPlugins"
        Me.cmdFindNewPlugins.Size = New System.Drawing.Size(130, 23)
        Me.cmdFindNewPlugins.TabIndex = 10
        Me.cmdFindNewPlugins.Text = "Find New Plugins"
        Me.cmdFindNewPlugins.UseVisualStyleBackColor = True
        '
        'Options1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.cmdFindNewPlugins)
        Me.Controls.Add(Me.optSelectedPlugins)
        Me.Controls.Add(Me.optAllPlugins)
        Me.Controls.Add(Me.chkFindCodeGenPlugins)
        Me.Controls.Add(Me.chkFindNavigationPlugins)
        Me.Controls.Add(Me.chkFindRefactoringPlugins)
        Me.Controls.Add(Me.ynaCheckForPluginUpdatesOnStartup)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ynaRestartDXCore)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.chkFindPromptBeforeUpdating)
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
    Friend WithEvents chkFindPromptBeforeUpdating As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ynaRestartDXCore As DX_PluginUpdater.YesNoAskControl
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ynaCheckForPluginUpdatesOnStartup As DX_PluginUpdater.YesNoAskControl
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents chkFindRefactoringPlugins As System.Windows.Forms.CheckBox
    Friend WithEvents chkFindNavigationPlugins As System.Windows.Forms.CheckBox
    Friend WithEvents chkFindCodeGenPlugins As System.Windows.Forms.CheckBox
    Friend WithEvents optAllPlugins As System.Windows.Forms.RadioButton
    Friend WithEvents optSelectedPlugins As System.Windows.Forms.RadioButton
    Friend WithEvents cmdFindNewPlugins As System.Windows.Forms.Button

	Public Shared ReadOnly Property FullPath() As String
		Get
			Return GetCategory() + "\" + GetPageName()
		End Get
	End Property

End Class
