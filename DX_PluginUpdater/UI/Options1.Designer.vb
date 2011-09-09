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
        Me.txtMultiplePlugins = New System.Windows.Forms.TextBox()
        Me.cmdUpdateMultiplePlugins = New System.Windows.Forms.Button()
        Me.txtLog = New System.Windows.Forms.TextBox()
        Me.cmdClearLog = New System.Windows.Forms.Button()
        Me.cmdAddFromLocalMachine = New System.Windows.Forms.Button()
        Me.cmdAddFromCommunitySite = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmdClear = New System.Windows.Forms.Button()
        Me.cmdOpenPluginFolder = New System.Windows.Forms.Button()
        Me.cmdAddFromNewPlugins = New System.Windows.Forms.Button()
        Me.cmdUpdateMe = New System.Windows.Forms.Button()
        Me.txtInstructions = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.chkOnlyShowUpdates = New System.Windows.Forms.CheckBox()
        Me.chkForceUpdate = New System.Windows.Forms.CheckBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtMultiplePlugins
        '
        Me.txtMultiplePlugins.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMultiplePlugins.Location = New System.Drawing.Point(245, 86)
        Me.txtMultiplePlugins.Multiline = True
        Me.txtMultiplePlugins.Name = "txtMultiplePlugins"
        Me.txtMultiplePlugins.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtMultiplePlugins.Size = New System.Drawing.Size(325, 199)
        Me.txtMultiplePlugins.TabIndex = 5
        '
        'cmdUpdateMultiplePlugins
        '
        Me.cmdUpdateMultiplePlugins.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdUpdateMultiplePlugins.Location = New System.Drawing.Point(326, 291)
        Me.cmdUpdateMultiplePlugins.Name = "cmdUpdateMultiplePlugins"
        Me.cmdUpdateMultiplePlugins.Size = New System.Drawing.Size(131, 23)
        Me.cmdUpdateMultiplePlugins.TabIndex = 6
        Me.cmdUpdateMultiplePlugins.Text = "Check for Updates Now"
        Me.cmdUpdateMultiplePlugins.UseVisualStyleBackColor = True
        '
        'txtLog
        '
        Me.txtLog.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtLog.Location = New System.Drawing.Point(3, 320)
        Me.txtLog.Multiline = True
        Me.txtLog.Name = "txtLog"
        Me.txtLog.ReadOnly = True
        Me.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtLog.Size = New System.Drawing.Size(567, 116)
        Me.txtLog.TabIndex = 7
        '
        'cmdClearLog
        '
        Me.cmdClearLog.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdClearLog.Location = New System.Drawing.Point(3, 442)
        Me.cmdClearLog.Name = "cmdClearLog"
        Me.cmdClearLog.Size = New System.Drawing.Size(86, 23)
        Me.cmdClearLog.TabIndex = 8
        Me.cmdClearLog.Text = "Clear Log"
        Me.cmdClearLog.UseVisualStyleBackColor = True
        '
        'cmdAddFromLocalMachine
        '
        Me.cmdAddFromLocalMachine.Location = New System.Drawing.Point(245, 19)
        Me.cmdAddFromLocalMachine.Name = "cmdAddFromLocalMachine"
        Me.cmdAddFromLocalMachine.Size = New System.Drawing.Size(115, 23)
        Me.cmdAddFromLocalMachine.TabIndex = 9
        Me.cmdAddFromLocalMachine.Text = "Local Machine..."
        Me.cmdAddFromLocalMachine.UseVisualStyleBackColor = True
        '
        'cmdAddFromCommunitySite
        '
        Me.cmdAddFromCommunitySite.Location = New System.Drawing.Point(365, 19)
        Me.cmdAddFromCommunitySite.Name = "cmdAddFromCommunitySite"
        Me.cmdAddFromCommunitySite.Size = New System.Drawing.Size(115, 23)
        Me.cmdAddFromCommunitySite.TabIndex = 10
        Me.cmdAddFromCommunitySite.Text = "Community Site..."
        Me.cmdAddFromCommunitySite.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(242, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 13)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Add from:"
        '
        'cmdClear
        '
        Me.cmdClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdClear.Location = New System.Drawing.Point(245, 291)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(75, 23)
        Me.cmdClear.TabIndex = 12
        Me.cmdClear.Text = "Clear Plugins"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'cmdOpenPluginFolder
        '
        Me.cmdOpenPluginFolder.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdOpenPluginFolder.Location = New System.Drawing.Point(3, 291)
        Me.cmdOpenPluginFolder.Name = "cmdOpenPluginFolder"
        Me.cmdOpenPluginFolder.Size = New System.Drawing.Size(119, 23)
        Me.cmdOpenPluginFolder.TabIndex = 13
        Me.cmdOpenPluginFolder.Text = "Open Plugin Folder"
        Me.cmdOpenPluginFolder.UseVisualStyleBackColor = True
        '
        'cmdAddFromNewPlugins
        '
        Me.cmdAddFromNewPlugins.Location = New System.Drawing.Point(245, 44)
        Me.cmdAddFromNewPlugins.Name = "cmdAddFromNewPlugins"
        Me.cmdAddFromNewPlugins.Size = New System.Drawing.Size(115, 23)
        Me.cmdAddFromNewPlugins.TabIndex = 14
        Me.cmdAddFromNewPlugins.Text = "New Plugins..."
        Me.cmdAddFromNewPlugins.UseVisualStyleBackColor = True
        '
        'cmdUpdateMe
        '
        Me.cmdUpdateMe.Location = New System.Drawing.Point(365, 44)
        Me.cmdUpdateMe.Name = "cmdUpdateMe"
        Me.cmdUpdateMe.Size = New System.Drawing.Size(115, 23)
        Me.cmdUpdateMe.TabIndex = 15
        Me.cmdUpdateMe.Text = "Update Me"
        Me.cmdUpdateMe.UseVisualStyleBackColor = True
        Me.cmdUpdateMe.Visible = False
        '
        'txtInstructions
        '
        Me.txtInstructions.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtInstructions.Location = New System.Drawing.Point(2, 3)
        Me.txtInstructions.Multiline = True
        Me.txtInstructions.Name = "txtInstructions"
        Me.txtInstructions.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtInstructions.Size = New System.Drawing.Size(237, 282)
        Me.txtInstructions.TabIndex = 16
        Me.txtInstructions.Text = resources.GetString("txtInstructions.Text")
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(245, 70)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(136, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Plugins to Install or Update"
        '
        'chkOnlyShowUpdates
        '
        Me.chkOnlyShowUpdates.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkOnlyShowUpdates.AutoSize = True
        Me.chkOnlyShowUpdates.Location = New System.Drawing.Point(95, 446)
        Me.chkOnlyShowUpdates.Name = "chkOnlyShowUpdates"
        Me.chkOnlyShowUpdates.Size = New System.Drawing.Size(120, 17)
        Me.chkOnlyShowUpdates.TabIndex = 17
        Me.chkOnlyShowUpdates.Text = "Only Show Updates"
        Me.chkOnlyShowUpdates.UseVisualStyleBackColor = True
        '
        'chkForceUpdate
        '
        Me.chkForceUpdate.AutoSize = True
        Me.chkForceUpdate.Location = New System.Drawing.Point(463, 295)
        Me.chkForceUpdate.Name = "chkForceUpdate"
        Me.chkForceUpdate.Size = New System.Drawing.Size(53, 17)
        Me.chkForceUpdate.TabIndex = 18
        Me.chkForceUpdate.Text = "Force"
        Me.ToolTip1.SetToolTip(Me.chkForceUpdate, "Forces the updater to update plugins even if the remove version is not newer.")
        Me.chkForceUpdate.UseVisualStyleBackColor = True
        '
        'Options1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.chkForceUpdate)
        Me.Controls.Add(Me.chkOnlyShowUpdates)
        Me.Controls.Add(Me.txtInstructions)
        Me.Controls.Add(Me.cmdUpdateMe)
        Me.Controls.Add(Me.cmdAddFromNewPlugins)
        Me.Controls.Add(Me.cmdOpenPluginFolder)
        Me.Controls.Add(Me.cmdClear)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdAddFromCommunitySite)
        Me.Controls.Add(Me.cmdAddFromLocalMachine)
        Me.Controls.Add(Me.cmdClearLog)
        Me.Controls.Add(Me.txtLog)
        Me.Controls.Add(Me.cmdUpdateMultiplePlugins)
        Me.Controls.Add(Me.txtMultiplePlugins)
        Me.Controls.Add(Me.Label2)
        Me.Name = "Options1"
        Me.Size = New System.Drawing.Size(573, 471)
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
    Friend WithEvents txtMultiplePlugins As System.Windows.Forms.TextBox
    Friend WithEvents cmdUpdateMultiplePlugins As System.Windows.Forms.Button
    Friend WithEvents txtLog As System.Windows.Forms.TextBox
    Friend WithEvents cmdClearLog As System.Windows.Forms.Button
    Friend WithEvents cmdAddFromLocalMachine As System.Windows.Forms.Button
    Friend WithEvents cmdAddFromCommunitySite As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cmdOpenPluginFolder As System.Windows.Forms.Button
    Friend WithEvents cmdAddFromNewPlugins As System.Windows.Forms.Button
    Friend WithEvents cmdUpdateMe As System.Windows.Forms.Button
    Friend WithEvents txtInstructions As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents chkOnlyShowUpdates As System.Windows.Forms.CheckBox
    Friend WithEvents chkForceUpdate As System.Windows.Forms.CheckBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip

	Public Shared ReadOnly Property FullPath() As String
		Get
			Return GetCategory() + "\" + GetPageName()
		End Get
	End Property

End Class
