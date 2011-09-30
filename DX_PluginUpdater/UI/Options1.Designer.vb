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
        Me.cmdUpdatePlugins = New System.Windows.Forms.Button()
        Me.txtLog = New System.Windows.Forms.TextBox()
        Me.cmdClearLog = New System.Windows.Forms.Button()
        Me.cmdOpenPluginFolder = New System.Windows.Forms.Button()
        Me.cmdUpdateMe = New System.Windows.Forms.Button()
        Me.chkOnlyShowUpdates = New System.Windows.Forms.CheckBox()
        Me.chkForceUpdate = New System.Windows.Forms.CheckBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.optLocal = New System.Windows.Forms.RadioButton()
        Me.optNew = New System.Windows.Forms.RadioButton()
        Me.optAll = New System.Windows.Forms.RadioButton()
        Me.cmdRefresh = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tabPlugins = New System.Windows.Forms.TabPage()
        Me.chkLstPlugins = New System.Windows.Forms.CheckedListBox()
        Me.tabFeeds = New System.Windows.Forms.TabPage()
        Me.txtFeeds = New System.Windows.Forms.TextBox()
        Me.tabCustom = New System.Windows.Forms.TabPage()
        Me.txtCustom = New System.Windows.Forms.TextBox()
        Me.tabKeywords = New System.Windows.Forms.TabPage()
        Me.chkIncludeCommunitySite = New System.Windows.Forms.CheckBox()
        Me.TabControl1.SuspendLayout()
        Me.tabPlugins.SuspendLayout()
        Me.tabFeeds.SuspendLayout()
        Me.tabCustom.SuspendLayout()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdUpdatePlugins
        '
        Me.cmdUpdatePlugins.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdUpdatePlugins.Location = New System.Drawing.Point(3, 273)
        Me.cmdUpdatePlugins.Name = "cmdUpdatePlugins"
        Me.cmdUpdatePlugins.Size = New System.Drawing.Size(131, 23)
        Me.cmdUpdatePlugins.TabIndex = 6
        Me.cmdUpdatePlugins.Text = "Check for Updates Now"
        Me.cmdUpdatePlugins.UseVisualStyleBackColor = True
        '
        'txtLog
        '
        Me.txtLog.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtLog.Location = New System.Drawing.Point(3, 300)
        Me.txtLog.Multiline = True
        Me.txtLog.Name = "txtLog"
        Me.txtLog.ReadOnly = True
        Me.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtLog.Size = New System.Drawing.Size(544, 120)
        Me.txtLog.TabIndex = 7
        '
        'cmdClearLog
        '
        Me.cmdClearLog.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdClearLog.Location = New System.Drawing.Point(3, 426)
        Me.cmdClearLog.Name = "cmdClearLog"
        Me.cmdClearLog.Size = New System.Drawing.Size(86, 23)
        Me.cmdClearLog.TabIndex = 8
        Me.cmdClearLog.Text = "Clear Log"
        Me.cmdClearLog.UseVisualStyleBackColor = True
        '
        'cmdOpenPluginFolder
        '
        Me.cmdOpenPluginFolder.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdOpenPluginFolder.Location = New System.Drawing.Point(424, 273)
        Me.cmdOpenPluginFolder.Name = "cmdOpenPluginFolder"
        Me.cmdOpenPluginFolder.Size = New System.Drawing.Size(119, 23)
        Me.cmdOpenPluginFolder.TabIndex = 13
        Me.cmdOpenPluginFolder.Text = "Open Plugin Folder"
        Me.cmdOpenPluginFolder.UseVisualStyleBackColor = True
        '
        'cmdUpdateMe
        '
        Me.cmdUpdateMe.Location = New System.Drawing.Point(429, 3)
        Me.cmdUpdateMe.Name = "cmdUpdateMe"
        Me.cmdUpdateMe.Size = New System.Drawing.Size(115, 24)
        Me.cmdUpdateMe.TabIndex = 15
        Me.cmdUpdateMe.Text = "Update Me"
        Me.cmdUpdateMe.UseVisualStyleBackColor = True
        Me.cmdUpdateMe.Visible = False
        '
        'chkOnlyShowUpdates
        '
        Me.chkOnlyShowUpdates.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkOnlyShowUpdates.AutoSize = True
        Me.chkOnlyShowUpdates.Location = New System.Drawing.Point(95, 430)
        Me.chkOnlyShowUpdates.Name = "chkOnlyShowUpdates"
        Me.chkOnlyShowUpdates.Size = New System.Drawing.Size(120, 17)
        Me.chkOnlyShowUpdates.TabIndex = 17
        Me.chkOnlyShowUpdates.Text = "Only Show Updates"
        Me.chkOnlyShowUpdates.UseVisualStyleBackColor = True
        '
        'chkForceUpdate
        '
        Me.chkForceUpdate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkForceUpdate.AutoSize = True
        Me.chkForceUpdate.Location = New System.Drawing.Point(140, 277)
        Me.chkForceUpdate.Name = "chkForceUpdate"
        Me.chkForceUpdate.Size = New System.Drawing.Size(53, 17)
        Me.chkForceUpdate.TabIndex = 18
        Me.chkForceUpdate.Text = "Force"
        Me.ToolTip1.SetToolTip(Me.chkForceUpdate, "Forces the updater to update plugins even if the remove version is not newer.")
        Me.chkForceUpdate.UseVisualStyleBackColor = True
        '
        'optLocal
        '
        Me.optLocal.AutoSize = True
        Me.optLocal.Location = New System.Drawing.Point(374, 5)
        Me.optLocal.Name = "optLocal"
        Me.optLocal.Size = New System.Drawing.Size(49, 17)
        Me.optLocal.TabIndex = 23
        Me.optLocal.Text = "Local"
        Me.optLocal.UseVisualStyleBackColor = True
        '
        'optNew
        '
        Me.optNew.AutoSize = True
        Me.optNew.Location = New System.Drawing.Point(321, 5)
        Me.optNew.Name = "optNew"
        Me.optNew.Size = New System.Drawing.Size(46, 17)
        Me.optNew.TabIndex = 22
        Me.optNew.Text = "New"
        Me.optNew.UseVisualStyleBackColor = True
        '
        'optAll
        '
        Me.optAll.AutoSize = True
        Me.optAll.Checked = True
        Me.optAll.Location = New System.Drawing.Point(279, 5)
        Me.optAll.Name = "optAll"
        Me.optAll.Size = New System.Drawing.Size(36, 17)
        Me.optAll.TabIndex = 21
        Me.optAll.TabStop = True
        Me.optAll.Text = "All"
        Me.optAll.UseVisualStyleBackColor = True
        '
        'cmdRefresh
        '
        Me.cmdRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdRefresh.Location = New System.Drawing.Point(474, 219)
        Me.cmdRefresh.Name = "cmdRefresh"
        Me.cmdRefresh.Size = New System.Drawing.Size(53, 20)
        Me.cmdRefresh.TabIndex = 20
        Me.cmdRefresh.Text = "Refresh"
        Me.cmdRefresh.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.tabPlugins)
        Me.TabControl1.Controls.Add(Me.tabFeeds)
        Me.TabControl1.Controls.Add(Me.tabCustom)
        Me.TabControl1.Controls.Add(Me.tabKeywords)
        Me.TabControl1.Location = New System.Drawing.Point(3, 3)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(544, 268)
        Me.TabControl1.TabIndex = 19
        '
        'tabPlugins
        '
        Me.tabPlugins.Controls.Add(Me.chkLstPlugins)
        Me.tabPlugins.Controls.Add(Me.chkIncludeCommunitySite)
        Me.tabPlugins.Controls.Add(Me.cmdRefresh)
        Me.tabPlugins.Location = New System.Drawing.Point(4, 22)
        Me.tabPlugins.Name = "tabPlugins"
        Me.tabPlugins.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPlugins.Size = New System.Drawing.Size(536, 242)
        Me.tabPlugins.TabIndex = 0
        Me.tabPlugins.Text = "Plugins"
        Me.tabPlugins.UseVisualStyleBackColor = True
        '
        'chkLstPlugins
        '
        Me.chkLstPlugins.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkLstPlugins.CheckOnClick = True
        Me.chkLstPlugins.FormattingEnabled = True
        Me.chkLstPlugins.Location = New System.Drawing.Point(6, 6)
        Me.chkLstPlugins.Name = "chkLstPlugins"
        Me.chkLstPlugins.Size = New System.Drawing.Size(524, 196)
        Me.chkLstPlugins.TabIndex = 0
        '
        'tabFeeds
        '
        Me.tabFeeds.Controls.Add(Me.txtFeeds)
        Me.tabFeeds.Location = New System.Drawing.Point(4, 22)
        Me.tabFeeds.Name = "tabFeeds"
        Me.tabFeeds.Padding = New System.Windows.Forms.Padding(3)
        Me.tabFeeds.Size = New System.Drawing.Size(536, 248)
        Me.tabFeeds.TabIndex = 1
        Me.tabFeeds.Text = "Feeds"
        Me.tabFeeds.UseVisualStyleBackColor = True
        '
        'txtFeeds
        '
        Me.txtFeeds.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtFeeds.Location = New System.Drawing.Point(3, 3)
        Me.txtFeeds.Multiline = True
        Me.txtFeeds.Name = "txtFeeds"
        Me.txtFeeds.Size = New System.Drawing.Size(530, 242)
        Me.txtFeeds.TabIndex = 2
        Me.txtFeeds.Text = "http://rorybecker.co.uk/DevExpress/community/plugins/CRFWPlugins.xml" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "http://rory" & _
            "becker.co.uk/DevExpress/community/plugins/RoryPlugins.xml" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'tabCustom
        '
        Me.tabCustom.Controls.Add(Me.txtCustom)
        Me.tabCustom.Location = New System.Drawing.Point(4, 22)
        Me.tabCustom.Name = "tabCustom"
        Me.tabCustom.Padding = New System.Windows.Forms.Padding(3)
        Me.tabCustom.Size = New System.Drawing.Size(536, 248)
        Me.tabCustom.TabIndex = 2
        Me.tabCustom.Text = "Custom"
        Me.tabCustom.UseVisualStyleBackColor = True
        '
        'txtCustom
        '
        Me.txtCustom.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtCustom.Location = New System.Drawing.Point(3, 3)
        Me.txtCustom.Multiline = True
        Me.txtCustom.Name = "txtCustom"
        Me.txtCustom.Size = New System.Drawing.Size(530, 242)
        Me.txtCustom.TabIndex = 2
        '
        'tabKeywords
        '
        Me.tabKeywords.Location = New System.Drawing.Point(4, 22)
        Me.tabKeywords.Name = "tabKeywords"
        Me.tabKeywords.Size = New System.Drawing.Size(536, 248)
        Me.tabKeywords.TabIndex = 3
        Me.tabKeywords.Text = "Keywords"
        Me.tabKeywords.UseVisualStyleBackColor = True
        '
        'chkIncludeCommunitySite
        '
        Me.chkIncludeCommunitySite.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkIncludeCommunitySite.AutoSize = True
        Me.chkIncludeCommunitySite.Location = New System.Drawing.Point(289, 221)
        Me.chkIncludeCommunitySite.Name = "chkIncludeCommunitySite"
        Me.chkIncludeCommunitySite.Size = New System.Drawing.Size(179, 17)
        Me.chkIncludeCommunitySite.TabIndex = 4
        Me.chkIncludeCommunitySite.Text = "Show All Community Site Plugins"
        Me.chkIncludeCommunitySite.UseVisualStyleBackColor = True
        '
        'Options1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.optLocal)
        Me.Controls.Add(Me.optNew)
        Me.Controls.Add(Me.optAll)
        Me.Controls.Add(Me.chkForceUpdate)
        Me.Controls.Add(Me.chkOnlyShowUpdates)
        Me.Controls.Add(Me.cmdUpdateMe)
        Me.Controls.Add(Me.cmdOpenPluginFolder)
        Me.Controls.Add(Me.cmdClearLog)
        Me.Controls.Add(Me.txtLog)
        Me.Controls.Add(Me.cmdUpdatePlugins)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "Options1"
        Me.Size = New System.Drawing.Size(547, 455)
        Me.TabControl1.ResumeLayout(False)
        Me.tabPlugins.ResumeLayout(False)
        Me.tabPlugins.PerformLayout()
        Me.tabFeeds.ResumeLayout(False)
        Me.tabFeeds.PerformLayout()
        Me.tabCustom.ResumeLayout(False)
        Me.tabCustom.PerformLayout()
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
    Friend WithEvents cmdUpdatePlugins As System.Windows.Forms.Button
    Friend WithEvents txtLog As System.Windows.Forms.TextBox
    Friend WithEvents cmdClearLog As System.Windows.Forms.Button
    Friend WithEvents cmdOpenPluginFolder As System.Windows.Forms.Button
    Friend WithEvents cmdUpdateMe As System.Windows.Forms.Button
    Friend WithEvents chkOnlyShowUpdates As System.Windows.Forms.CheckBox
    Friend WithEvents chkForceUpdate As System.Windows.Forms.CheckBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents optLocal As System.Windows.Forms.RadioButton
    Friend WithEvents optNew As System.Windows.Forms.RadioButton
    Friend WithEvents optAll As System.Windows.Forms.RadioButton
    Friend WithEvents cmdRefresh As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tabPlugins As System.Windows.Forms.TabPage
    Friend WithEvents chkLstPlugins As System.Windows.Forms.CheckedListBox
    Friend WithEvents tabFeeds As System.Windows.Forms.TabPage
    Friend WithEvents txtFeeds As System.Windows.Forms.TextBox
    Friend WithEvents tabCustom As System.Windows.Forms.TabPage
    Friend WithEvents txtCustom As System.Windows.Forms.TextBox
    Friend WithEvents tabKeywords As System.Windows.Forms.TabPage
    Friend WithEvents chkIncludeCommunitySite As System.Windows.Forms.CheckBox

	Public Shared ReadOnly Property FullPath() As String
		Get
			Return GetCategory() + "\" + GetPageName()
		End Get
	End Property

End Class
