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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Options1))
        Me.chkFindPromptBeforeUpdating = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.chkFindRefactoringPlugins = New System.Windows.Forms.CheckBox()
        Me.chkFindNavigationPlugins = New System.Windows.Forms.CheckBox()
        Me.chkFindCodeGenPlugins = New System.Windows.Forms.CheckBox()
        Me.optAllPlugins = New System.Windows.Forms.RadioButton()
        Me.optSelectedPlugins = New System.Windows.Forms.RadioButton()
        Me.cmdFindNewPlugins = New System.Windows.Forms.Button()
        Me.chkFindCodeIssuePlugins = New System.Windows.Forms.CheckBox()
        Me.chkFindMiscPlugins = New System.Windows.Forms.CheckBox()
        Me.grpFindNewPlugins = New System.Windows.Forms.GroupBox()
        Me.chkFindPaintingPlugins = New System.Windows.Forms.CheckBox()
        Me.grpUpdatePlugins = New System.Windows.Forms.GroupBox()
        Me.ynaCheckForPluginUpdatesOnStartup = New DX_PluginUpdater.YesNoAskControl()
        Me.cmdUpdatePluginsNow = New System.Windows.Forms.Button()
        Me.grpCommonOptions = New System.Windows.Forms.GroupBox()
        Me.ynaRestartDXCore = New DX_PluginUpdater.YesNoAskControl()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.grpTest = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.grpWarning = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.chkUserUnderstandsWarning = New System.Windows.Forms.CheckBox()
        Me.grpFindNewPlugins.SuspendLayout()
        Me.grpUpdatePlugins.SuspendLayout()
        Me.grpCommonOptions.SuspendLayout()
        Me.grpTest.SuspendLayout()
        Me.grpWarning.SuspendLayout()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'chkFindPromptBeforeUpdating
        '
        Me.chkFindPromptBeforeUpdating.AutoSize = True
        Me.chkFindPromptBeforeUpdating.Location = New System.Drawing.Point(9, 46)
        Me.chkFindPromptBeforeUpdating.Name = "chkFindPromptBeforeUpdating"
        Me.chkFindPromptBeforeUpdating.Size = New System.Drawing.Size(171, 17)
        Me.chkFindPromptBeforeUpdating.TabIndex = 0
        Me.chkFindPromptBeforeUpdating.Text = "Prompt user before updating. "
        Me.chkFindPromptBeforeUpdating.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(26, 66)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(472, 23)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "(Unchecking this option will cause all Local plugins to be updated when UpdatePlu" & _
    "gins is chosen)"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(40, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(261, 14)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Restart DXCore after plugins are installed \ updated."
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(6, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(210, 14)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Update Plugins on startup"
        '
        'chkFindRefactoringPlugins
        '
        Me.chkFindRefactoringPlugins.AutoSize = True
        Me.chkFindRefactoringPlugins.Location = New System.Drawing.Point(62, 62)
        Me.chkFindRefactoringPlugins.Name = "chkFindRefactoringPlugins"
        Me.chkFindRefactoringPlugins.Size = New System.Drawing.Size(118, 17)
        Me.chkFindRefactoringPlugins.TabIndex = 6
        Me.chkFindRefactoringPlugins.Text = "Refactoring Plugins"
        Me.chkFindRefactoringPlugins.UseVisualStyleBackColor = True
        '
        'chkFindNavigationPlugins
        '
        Me.chkFindNavigationPlugins.AutoSize = True
        Me.chkFindNavigationPlugins.Location = New System.Drawing.Point(62, 85)
        Me.chkFindNavigationPlugins.Name = "chkFindNavigationPlugins"
        Me.chkFindNavigationPlugins.Size = New System.Drawing.Size(113, 17)
        Me.chkFindNavigationPlugins.TabIndex = 7
        Me.chkFindNavigationPlugins.Text = "Navigation Plugins"
        Me.chkFindNavigationPlugins.UseVisualStyleBackColor = True
        '
        'chkFindCodeGenPlugins
        '
        Me.chkFindCodeGenPlugins.AutoSize = True
        Me.chkFindCodeGenPlugins.Location = New System.Drawing.Point(208, 62)
        Me.chkFindCodeGenPlugins.Name = "chkFindCodeGenPlugins"
        Me.chkFindCodeGenPlugins.Size = New System.Drawing.Size(109, 17)
        Me.chkFindCodeGenPlugins.TabIndex = 8
        Me.chkFindCodeGenPlugins.Text = "Code Gen Plugins"
        Me.chkFindCodeGenPlugins.UseVisualStyleBackColor = True
        '
        'optAllPlugins
        '
        Me.optAllPlugins.AutoSize = True
        Me.optAllPlugins.Location = New System.Drawing.Point(42, 16)
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
        Me.optSelectedPlugins.Location = New System.Drawing.Point(42, 39)
        Me.optSelectedPlugins.Name = "optSelectedPlugins"
        Me.optSelectedPlugins.Size = New System.Drawing.Size(129, 17)
        Me.optSelectedPlugins.TabIndex = 9
        Me.optSelectedPlugins.TabStop = True
        Me.optSelectedPlugins.Text = "Selected Plugin Types"
        Me.optSelectedPlugins.UseVisualStyleBackColor = True
        '
        'cmdFindNewPlugins
        '
        Me.cmdFindNewPlugins.Location = New System.Drawing.Point(274, 53)
        Me.cmdFindNewPlugins.Name = "cmdFindNewPlugins"
        Me.cmdFindNewPlugins.Size = New System.Drawing.Size(128, 23)
        Me.cmdFindNewPlugins.TabIndex = 10
        Me.cmdFindNewPlugins.Text = "Find New Plugins Now"
        Me.ToolTip1.SetToolTip(Me.cmdFindNewPlugins, "Uses last *saved* settings.")
        Me.cmdFindNewPlugins.UseVisualStyleBackColor = True
        '
        'chkFindCodeIssuePlugins
        '
        Me.chkFindCodeIssuePlugins.AutoSize = True
        Me.chkFindCodeIssuePlugins.Location = New System.Drawing.Point(208, 85)
        Me.chkFindCodeIssuePlugins.Name = "chkFindCodeIssuePlugins"
        Me.chkFindCodeIssuePlugins.Size = New System.Drawing.Size(116, 17)
        Me.chkFindCodeIssuePlugins.TabIndex = 8
        Me.chkFindCodeIssuePlugins.Text = "Code Issue Plugins"
        Me.chkFindCodeIssuePlugins.UseVisualStyleBackColor = True
        '
        'chkFindMiscPlugins
        '
        Me.chkFindMiscPlugins.AutoSize = True
        Me.chkFindMiscPlugins.Location = New System.Drawing.Point(208, 108)
        Me.chkFindMiscPlugins.Name = "chkFindMiscPlugins"
        Me.chkFindMiscPlugins.Size = New System.Drawing.Size(82, 17)
        Me.chkFindMiscPlugins.TabIndex = 8
        Me.chkFindMiscPlugins.Text = "Misc Plugins"
        Me.chkFindMiscPlugins.UseVisualStyleBackColor = True
        '
        'grpFindNewPlugins
        '
        Me.grpFindNewPlugins.Controls.Add(Me.chkFindCodeGenPlugins)
        Me.grpFindNewPlugins.Controls.Add(Me.chkFindRefactoringPlugins)
        Me.grpFindNewPlugins.Controls.Add(Me.chkFindNavigationPlugins)
        Me.grpFindNewPlugins.Controls.Add(Me.optSelectedPlugins)
        Me.grpFindNewPlugins.Controls.Add(Me.chkFindPaintingPlugins)
        Me.grpFindNewPlugins.Controls.Add(Me.chkFindCodeIssuePlugins)
        Me.grpFindNewPlugins.Controls.Add(Me.optAllPlugins)
        Me.grpFindNewPlugins.Controls.Add(Me.chkFindMiscPlugins)
        Me.grpFindNewPlugins.Location = New System.Drawing.Point(17, 192)
        Me.grpFindNewPlugins.Name = "grpFindNewPlugins"
        Me.grpFindNewPlugins.Size = New System.Drawing.Size(502, 138)
        Me.grpFindNewPlugins.TabIndex = 11
        Me.grpFindNewPlugins.TabStop = False
        Me.grpFindNewPlugins.Text = "Find New Plugin Options"
        '
        'chkFindPaintingPlugins
        '
        Me.chkFindPaintingPlugins.AutoSize = True
        Me.chkFindPaintingPlugins.Location = New System.Drawing.Point(62, 108)
        Me.chkFindPaintingPlugins.Name = "chkFindPaintingPlugins"
        Me.chkFindPaintingPlugins.Size = New System.Drawing.Size(100, 17)
        Me.chkFindPaintingPlugins.TabIndex = 8
        Me.chkFindPaintingPlugins.Text = "Painting Plugins"
        Me.chkFindPaintingPlugins.UseVisualStyleBackColor = True
        '
        'grpUpdatePlugins
        '
        Me.grpUpdatePlugins.Controls.Add(Me.ynaCheckForPluginUpdatesOnStartup)
        Me.grpUpdatePlugins.Controls.Add(Me.Label3)
        Me.grpUpdatePlugins.Controls.Add(Me.chkFindPromptBeforeUpdating)
        Me.grpUpdatePlugins.Controls.Add(Me.Label1)
        Me.grpUpdatePlugins.Location = New System.Drawing.Point(17, 100)
        Me.grpUpdatePlugins.Name = "grpUpdatePlugins"
        Me.grpUpdatePlugins.Size = New System.Drawing.Size(502, 86)
        Me.grpUpdatePlugins.TabIndex = 11
        Me.grpUpdatePlugins.TabStop = False
        Me.grpUpdatePlugins.Text = "Update Plugin Options"
        '
        'ynaCheckForPluginUpdatesOnStartup
        '
        Me.ynaCheckForPluginUpdatesOnStartup.Location = New System.Drawing.Point(222, 20)
        Me.ynaCheckForPluginUpdatesOnStartup.Name = "ynaCheckForPluginUpdatesOnStartup"
        Me.ynaCheckForPluginUpdatesOnStartup.Size = New System.Drawing.Size(95, 23)
        Me.ynaCheckForPluginUpdatesOnStartup.TabIndex = 4
        Me.ynaCheckForPluginUpdatesOnStartup.YesNoAskValue = DX_PluginUpdater.YesNoAskEnum.Ask
        '
        'cmdUpdatePluginsNow
        '
        Me.cmdUpdatePluginsNow.Location = New System.Drawing.Point(85, 53)
        Me.cmdUpdatePluginsNow.Name = "cmdUpdatePluginsNow"
        Me.cmdUpdatePluginsNow.Size = New System.Drawing.Size(111, 23)
        Me.cmdUpdatePluginsNow.TabIndex = 10
        Me.cmdUpdatePluginsNow.Text = "Update Plugins Now"
        Me.ToolTip1.SetToolTip(Me.cmdUpdatePluginsNow, "Uses last *saved* settings.")
        Me.cmdUpdatePluginsNow.UseVisualStyleBackColor = True
        '
        'grpCommonOptions
        '
        Me.grpCommonOptions.Controls.Add(Me.ynaRestartDXCore)
        Me.grpCommonOptions.Controls.Add(Me.Label2)
        Me.grpCommonOptions.Location = New System.Drawing.Point(17, 336)
        Me.grpCommonOptions.Name = "grpCommonOptions"
        Me.grpCommonOptions.Size = New System.Drawing.Size(502, 41)
        Me.grpCommonOptions.TabIndex = 12
        Me.grpCommonOptions.TabStop = False
        Me.grpCommonOptions.Text = "Common Options"
        '
        'ynaRestartDXCore
        '
        Me.ynaRestartDXCore.Location = New System.Drawing.Point(307, 14)
        Me.ynaRestartDXCore.Name = "ynaRestartDXCore"
        Me.ynaRestartDXCore.Size = New System.Drawing.Size(95, 23)
        Me.ynaRestartDXCore.TabIndex = 2
        Me.ynaRestartDXCore.YesNoAskValue = DX_PluginUpdater.YesNoAskEnum.Ask
        '
        'grpTest
        '
        Me.grpTest.Controls.Add(Me.Label4)
        Me.grpTest.Controls.Add(Me.cmdUpdatePluginsNow)
        Me.grpTest.Controls.Add(Me.cmdFindNewPlugins)
        Me.grpTest.Location = New System.Drawing.Point(17, 383)
        Me.grpTest.Name = "grpTest"
        Me.grpTest.Size = New System.Drawing.Size(502, 84)
        Me.grpTest.TabIndex = 13
        Me.grpTest.TabStop = False
        Me.grpTest.Text = "Test"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(26, 17)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(433, 33)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Note: Despite the phrase 'Test', these functions are real and will update \ insta" & _
    "ll plugins. " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Additionally they operate using the latest *saved* settings."
        '
        'grpWarning
        '
        Me.grpWarning.Controls.Add(Me.chkUserUnderstandsWarning)
        Me.grpWarning.Controls.Add(Me.Label5)
        Me.grpWarning.Location = New System.Drawing.Point(17, 4)
        Me.grpWarning.Name = "grpWarning"
        Me.grpWarning.Size = New System.Drawing.Size(502, 90)
        Me.grpWarning.TabIndex = 14
        Me.grpWarning.TabStop = False
        Me.grpWarning.Text = "Warning"
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(6, 17)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(486, 47)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = resources.GetString("Label5.Text")
        '
        'chkUserUnderstandsWarning
        '
        Me.chkUserUnderstandsWarning.AutoSize = True
        Me.chkUserUnderstandsWarning.Location = New System.Drawing.Point(222, 67)
        Me.chkUserUnderstandsWarning.Name = "chkUserUnderstandsWarning"
        Me.chkUserUnderstandsWarning.Size = New System.Drawing.Size(91, 17)
        Me.chkUserUnderstandsWarning.TabIndex = 1
        Me.chkUserUnderstandsWarning.Text = "I understand "
        Me.chkUserUnderstandsWarning.UseVisualStyleBackColor = True
        '
        'Options1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.grpWarning)
        Me.Controls.Add(Me.grpTest)
        Me.Controls.Add(Me.grpCommonOptions)
        Me.Controls.Add(Me.grpUpdatePlugins)
        Me.Controls.Add(Me.grpFindNewPlugins)
        Me.Name = "Options1"
        Me.Size = New System.Drawing.Size(536, 480)
        Me.grpFindNewPlugins.ResumeLayout(False)
        Me.grpFindNewPlugins.PerformLayout()
        Me.grpUpdatePlugins.ResumeLayout(False)
        Me.grpUpdatePlugins.PerformLayout()
        Me.grpCommonOptions.ResumeLayout(False)
        Me.grpTest.ResumeLayout(False)
        Me.grpWarning.ResumeLayout(False)
        Me.grpWarning.PerformLayout()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

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
    Friend WithEvents chkFindCodeIssuePlugins As System.Windows.Forms.CheckBox
    Friend WithEvents chkFindMiscPlugins As System.Windows.Forms.CheckBox
    Friend WithEvents grpFindNewPlugins As System.Windows.Forms.GroupBox
    Friend WithEvents grpUpdatePlugins As System.Windows.Forms.GroupBox
    Friend WithEvents cmdUpdatePluginsNow As System.Windows.Forms.Button
    Friend WithEvents grpCommonOptions As System.Windows.Forms.GroupBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents grpTest As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents chkFindPaintingPlugins As System.Windows.Forms.CheckBox
    Friend WithEvents grpWarning As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents chkUserUnderstandsWarning As System.Windows.Forms.CheckBox

	Public Shared ReadOnly Property FullPath() As String
		Get
			Return GetCategory() + "\" + GetPageName()
		End Get
	End Property

End Class
