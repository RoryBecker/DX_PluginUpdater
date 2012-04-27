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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cmdUpdatePluginsNow = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ynaRestartDXCore = New DX_PluginUpdater.YesNoAskControl()
        Me.ynaCheckForPluginUpdatesOnStartup = New DX_PluginUpdater.YesNoAskControl()
        Me.chkFindPaintingPlugins = New System.Windows.Forms.CheckBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
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
        Me.Label2.Location = New System.Drawing.Point(42, 24)
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
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkFindCodeGenPlugins)
        Me.GroupBox1.Controls.Add(Me.chkFindRefactoringPlugins)
        Me.GroupBox1.Controls.Add(Me.chkFindNavigationPlugins)
        Me.GroupBox1.Controls.Add(Me.optSelectedPlugins)
        Me.GroupBox1.Controls.Add(Me.chkFindPaintingPlugins)
        Me.GroupBox1.Controls.Add(Me.chkFindCodeIssuePlugins)
        Me.GroupBox1.Controls.Add(Me.optAllPlugins)
        Me.GroupBox1.Controls.Add(Me.chkFindMiscPlugins)
        Me.GroupBox1.Location = New System.Drawing.Point(17, 131)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(502, 152)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Find New Plugin Options"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.ynaCheckForPluginUpdatesOnStartup)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.chkFindPromptBeforeUpdating)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Location = New System.Drawing.Point(17, 14)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(502, 101)
        Me.GroupBox2.TabIndex = 11
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Update Plugin Options"
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
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.ynaRestartDXCore)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Location = New System.Drawing.Point(17, 298)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(502, 51)
        Me.GroupBox3.TabIndex = 12
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Common Options"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label4)
        Me.GroupBox4.Controls.Add(Me.cmdUpdatePluginsNow)
        Me.GroupBox4.Controls.Add(Me.cmdFindNewPlugins)
        Me.GroupBox4.Location = New System.Drawing.Point(17, 365)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(502, 84)
        Me.GroupBox4.TabIndex = 13
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Test"
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
        'ynaRestartDXCore
        '
        Me.ynaRestartDXCore.Location = New System.Drawing.Point(307, 20)
        Me.ynaRestartDXCore.Name = "ynaRestartDXCore"
        Me.ynaRestartDXCore.Size = New System.Drawing.Size(95, 23)
        Me.ynaRestartDXCore.TabIndex = 2
        Me.ynaRestartDXCore.YesNoAskValue = DX_PluginUpdater.YesNoAskEnum.Ask
        '
        'ynaCheckForPluginUpdatesOnStartup
        '
        Me.ynaCheckForPluginUpdatesOnStartup.Location = New System.Drawing.Point(222, 20)
        Me.ynaCheckForPluginUpdatesOnStartup.Name = "ynaCheckForPluginUpdatesOnStartup"
        Me.ynaCheckForPluginUpdatesOnStartup.Size = New System.Drawing.Size(95, 23)
        Me.ynaCheckForPluginUpdatesOnStartup.TabIndex = 4
        Me.ynaCheckForPluginUpdatesOnStartup.YesNoAskValue = DX_PluginUpdater.YesNoAskEnum.Ask
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
        'Options1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "Options1"
        Me.Size = New System.Drawing.Size(536, 480)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
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
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdUpdatePluginsNow As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents chkFindPaintingPlugins As System.Windows.Forms.CheckBox

	Public Shared ReadOnly Property FullPath() As String
		Get
			Return GetCategory() + "\" + GetPageName()
		End Get
	End Property

End Class
